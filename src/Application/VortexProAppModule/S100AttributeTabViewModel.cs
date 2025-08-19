using ActiproSoftware.Windows.Extensions;
using ArcGIS.Core.Data;
using ArcGIS.Core.Events;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Editing;
using ArcGIS.Desktop.Editing.Attributes;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;
using S100Framework.Catalogues;
using S100Framework.DomainModel;
using S100Framework.WPF;
using S100Framework.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using IO = System.IO;

namespace VortexProAppModule
{
    //  https://github.com/esri/arcgis-pro-sdk/wiki/ProConcepts-Editing#customizing-the-attributes-dockpane

    internal class S100AttributeTabViewModel : AttributeTabEmbeddableControl
    {
        const string S100AttributesUpdate = "S100AttributesUpdate";

        private static CultureInfo culture = new("en-GB", false);

        public class InspectorHandle
        {
            public Func<Inspector, string, Type> TypeSelector { get; set; }

            public Func<FeatureCatalogue, Primitives?, IEnumerable<string>> Types { get; set; }

            public Func<string, string, string, string?, S100Framework.WPF.ViewModel.ViewModelBase> CreateViewModel { get; set; }
        }

        internal record SelectedTemplate(string Schema, string Code)
        {
            public static SelectedTemplate Empty => new(string.Empty, string.Empty);
        }

        internal record SelectedType(string Code);

        private readonly VortexProAppModule.Module _module;

        private InspectorHandle _inspectorHandle = default;

        private InspectorHandle _inspectorHandleInformationAssociation => new() {
            TypeSelector = this.InformationAssociationTypeSelector,
            Types = (fc, p) => fc.InformationAssociationTypes.Select(e => e.Code),
            CreateViewModel = (schema, code, type, pid) => {
                return S100Framework.WPF.Helper.CreateInformationAssociationViewModel(schema, code, pid);
            },
        };

        private InspectorHandle _inspectorHandleFeatureAssociation => new() {
            TypeSelector = this.FeatureAssociationTypeSelector,
            Types = (fc, p) => fc.FeatureAssociationTypes.Select(e => e.Code),
            CreateViewModel = (schema, code, type, pid) => {
                return S100Framework.WPF.Helper.CreateFeatureAssociationViewModel(schema, code, pid);
            },
        };

        private InspectorHandle _inspectorHandleInformation => new() {
            TypeSelector = this.InformationTypeSelector,
            Types = (fc, p) => fc.InformationTypes.Select(e => e.Code),
            CreateViewModel = (schema, code, type, pid) => {
                return S100Framework.WPF.Helper.CreateInformationTypeViewModel(schema, type, pid);
            },
        };

        private InspectorHandle _inspectorHandleFeature => new() {
            TypeSelector = this.FeatureTypeSelector,
            Types = (fc, p) => fc.FeatureTypesByPrimivive(p.Value).Select(e => e.Code),
            CreateViewModel = (schema, code, type, pid) => {
                return S100Framework.WPF.Helper.CreateFeatureTypeViewModel(schema, type, pid);
            },
        };



        private SelectedTemplate _selectedTemplate = SelectedTemplate.Empty;

        private SelectedType _selectedModelType = default;

        private S100AttributeEditorControlHost _host;

        private ObservableCollection<string> _schemas = new();

        private string _selectedSchema = default;

        private object _selectedProperty = default;

        private SelectedAssociationObjectViewModel _selectedAssociationProperty = default;

        private SelectedInformationTypeObjectViewModel _selectedInformationProperty = default;

        private SelectedFeatureTypeObjectViewModel _selectedFeatureProperty = default;

        private Boolean _isEditingEnabled = false;

        private Boolean _isVisible = false;

        private ObservableCollection<SelectedType> _modelTypes = new();

        private bool _isSelectedSchemaEnabled = true;

        private bool _isSelectedModelTypeEnabled = false;

        private string[] _catalogues;

        private SubscriptionToken _tokenEditStarted;

        public S100AttributeTabViewModel(XElement options, bool canChangeOptions) : base(options, canChangeOptions) {
            _module = VortexProAppModule.Module.Current;
            _catalogues = _module.GetFeatureCatalogues();


            Project.Current.PropertyChanged += this.Current_PropertyChanged;
            this.IsEditingEnabled = Project.Current.IsEditingEnabled;

            Schemas.AddRange(_catalogues);

            CreateInstance = new RelayCommand(async () => {
                var inspector = base.Inspector;

                if (inspector != default) {
                    //if (!Project.Current.IsEditingEnabled) {
                    //    await Project.Current.SetIsEditingEnabledAsync(true);
                    //}

                    inspector["ps"] = SelectedSchema;
                    inspector["code"] = SelectedModelType.Code;

                    IsSelectedSchemaEnabled = false;
                    IsSelectedModelTypeEnabled = false;

                    await QueuedTask.Run(() => {
                        inspector.Apply();
                    }, TaskCreationOptions.None);
                }
            });


            Host = new S100AttributeEditorControlHost {
                QueryAssociation = async (QueryAssociationsEventArgs e) => {
                    return await QueuedTask.Run(() => {
                        var inspector = base.Inspector;

                        using var fc = inspector.MapMember switch {
                            FeatureLayer l => l.GetFeatureClass(),
                            StandaloneTable t => t.GetTable(),
                            _ => throw new InvalidOperationException(),
                        };

                        using var geodatabase = (Geodatabase)fc.GetDatastore();

                        var syntax = geodatabase.GetSQLSyntax();
                        var tableNames = syntax.ParseTableName(fc.GetName());

                        var associationName = e.type switch {
                            QueryAssociationsEventArgs.AssociationsType.InformationAssociations => syntax.QualifyTableName(tableNames.Item1, tableNames.Item2, "informationassociation"),
                            QueryAssociationsEventArgs.AssociationsType.FeatureAssociations => syntax.QualifyTableName(tableNames.Item1, tableNames.Item2, "featureassociation"),
                            _ => throw new InvalidOperationException(),
                        };

                        using var association = geodatabase.OpenDataset<Table>(associationName);

                        var q = new QueryFilter {
                            WhereClause = $"ps = '{inspector["ps"]}' AND code = '{e.association}'",
                        };

                        var ids = new List<AssociationId>();

                        using var cursor = association.Search(q, true);
                        while (cursor.MoveNext()) {
                            ids.Add(new AssociationId($"{Convert.ToString(cursor.Current["name"])}"));
                        }

                        return ids;
                    }, TaskCreationOptions.None);
                },

                QueryInformationTypes = async (QueryInformationTypesEventArgs e) => {
                    var informationtypes = S100Framework.WPF.Helper.InformationAssociationBindings(SelectedSchema, e.association!, e.role!);

                    if (!informationtypes.Any())
                        return Enumerable.Empty<InformationTypeId>();

                    return await QueuedTask.Run(() => {
                        var inspector = base.Inspector;

                        var ids = new List<InformationTypeId>();

                        var mapView = MapView.Active?.Map;
                        if (mapView is not null) {
                            var local = new ArcGIS.Desktop.Editing.Attributes.Inspector();

                            var selection = mapView.GetSelection();

                            foreach (var selectionSet in selection.ToDictionary()) {
                                if (!(selectionSet.Key is ArcGIS.Desktop.Mapping.StandaloneTable))
                                    continue;
                                foreach (var i in selectionSet.Value) {
                                    local.Load(selectionSet.Key, i);

                                    var ps = Convert.ToString(local["ps"]);
                                    var code = Convert.ToString(local["code"]);
                                    if (string.Compare(Convert.ToString(inspector["ps"]), ps, true) != 0)
                                        continue;
                                    if (string.IsNullOrEmpty(code))
                                        continue;

                                    if (!informationtypes.Contains(code))
                                        continue;

                                    ids.Add(new InformationTypeId(code, Convert.ToString(local["name"])));
                                }
                            }

                            if (ids.Any())
                                return ids;
                        }

                        var values = informationtypes.Select(i => $"'{i}'");
                        var q = new QueryFilter {
                            WhereClause = $"ps = '{inspector["ps"]}' AND code IN ({string.Join(',', values)})",
                            //PrefixClause = "TOP 10" ONLY MSSQL
                        };

                        foreach (var primitive in new string[] { "informationtype" }) {
                            int top = 5;

                            using var r = inspector.OpenDataset<Table>(primitive);

                            using var cursor = r.Search(q, true);
                            while (cursor.MoveNext() && top > 0) {
                                var row = cursor.Current;
                                ids.Add(new InformationTypeId(Convert.ToString(row["code"]), Convert.ToString(row["name"])));

                                top -= 1;
                            }
                        }
                        return ids;
                    }, TaskCreationOptions.None);
                },

                QueryFeatureTypes = async (QueryFeatureTypesEventArgs e) => {
                    var features = S100Framework.WPF.Helper.FeatureAssociationBindings(SelectedSchema, e.association!, e.role!);

                    if (!features.Any())
                        return Enumerable.Empty<FeatureTypeId>();

                    return await QueuedTask.Run(() => {
                        var inspector = base.Inspector;

                        var ids = new List<FeatureTypeId>();

                        var mapView = MapView.Active?.Map;
                        if (mapView is not null) {
                            var local = new ArcGIS.Desktop.Editing.Attributes.Inspector();

                            var selection = mapView.GetSelection();

                            foreach (var selectionSet in selection.ToDictionary()) {
                                if (!(selectionSet.Key is ArcGIS.Desktop.Mapping.FeatureLayer))
                                    continue;
                                foreach (var i in selectionSet.Value) {
                                    local.Load(selectionSet.Key, i);

                                    var ps = Convert.ToString(local["ps"]);
                                    var code = Convert.ToString(local["code"]);
                                    if (string.Compare(Convert.ToString(inspector["ps"]), ps, true) != 0)
                                        continue;
                                    if (string.IsNullOrEmpty(code))
                                        continue;

                                    if (!features.Contains(code))
                                        continue;

                                    ids.Add(new FeatureTypeId(code, Convert.ToString(local["name"])));
                                }
                            }

                            if (ids.Any())
                                return ids;
                        }

                        var values = features.Select(i => $"'{i}'");
                        var q = new QueryFilter {
                            WhereClause = $"ps = '{inspector["ps"]}' AND code IN ({string.Join(',', values)})",
                            //PrefixClause = "TOP 10" ONLY MSSQL
                        };

                        foreach (var primitive in new string[] { "point", "pointset", "curve", "surface" }) {
                            int top = 5;

                            using var f = inspector.OpenDataset<FeatureClass>(primitive);

                            using var cursor = f.Search(q, true);
                            while (cursor.MoveNext() && top > 0) {
                                var feature = cursor.Current;
                                ids.Add(new FeatureTypeId(Convert.ToString(feature["code"]), Convert.ToString(feature["name"])));

                                top -= 1;
                            }
                        }
                        return ids;
                    }, TaskCreationOptions.None);
                },

                SelectInformationBinding = async (SelectInformationBindingEventArgs e) => {
                    if (MapView.Active is null)
                        return;
                    await QueuedTask.Run(() => {
                        foreach (var layer in MapView.Active.Map.GetStandaloneTablesAsFlattenedList().OfType<StandaloneTable>()) {
                            if (layer is StandaloneTable table) {
                                if (table.GetTable().GetName().EndsWith("informationtype", StringComparison.OrdinalIgnoreCase)) {
                                    table.Select(new QueryFilter {
                                        WhereClause = $"upper(name) = '{e.informationId}'"
                                    }, SelectionCombinationMethod.Add);
                                }
                            }
                        }
                    }, TaskCreationOptions.None);
                },

                SelectFeatureBinding = async (SelectFeatureBindingEventArgs e) => {
                    if (MapView.Active is null)
                        return;
                    await QueuedTask.Run(() => {
                        foreach (var layer in MapView.Active.Map.GetLayersAsFlattenedList().OfType<FeatureLayer>()) {
                            if (layer is FeatureLayer featureLayer) {
                                var name = featureLayer.GetTable().GetName();
                                var select = e.featureId[0] switch {
                                    'P' or 'p' => name.EndsWith("point", StringComparison.OrdinalIgnoreCase) || name.EndsWith("pointset", StringComparison.InvariantCultureIgnoreCase),
                                    'C' or 'c' => name.EndsWith("curve", StringComparison.OrdinalIgnoreCase),
                                    'S' or 's' => name.EndsWith("surface", StringComparison.OrdinalIgnoreCase),
                                    _ => false,
                                };
                                if (!select)
                                    continue;
                                featureLayer.Select(new QueryFilter {
                                    WhereClause = $"upper(name) = '{e.featureId}'"
                                }, SelectionCombinationMethod.Add);
                            }
                        }
                    }, TaskCreationOptions.None);
                },

                SelectInformationAssociation = async (SelectAssociationEventArgs e) => {
                    if (MapView.Active is null)
                        return;
                    await QueuedTask.Run(() => {
                        foreach (var layer in MapView.Active.Map.GetStandaloneTablesAsFlattenedList()) {
                            if (layer is StandaloneTable table) {
                                if (table.GetTable().GetName().EndsWith("informationassociation", StringComparison.OrdinalIgnoreCase)) {
                                    table.Select(new QueryFilter {
                                        WhereClause = $"upper(name) = '{e.associationId}'"
                                    }, SelectionCombinationMethod.Add);
                                }
                            }
                        }
                    }, TaskCreationOptions.None);
                },

                SelectFeatureAssociation = async (SelectAssociationEventArgs e) => {
                    if (MapView.Active is null)
                        return;
                    await QueuedTask.Run(() => {
                        foreach (var layer in MapView.Active.Map.GetStandaloneTablesAsFlattenedList()) {
                            if (layer is StandaloneTable table) {
                                if (table.GetTable().GetName().EndsWith("featureassociation", StringComparison.OrdinalIgnoreCase)) {
                                    table.Select(new QueryFilter {
                                        WhereClause = $"upper(name) = '{e.associationId}'"
                                    }, SelectionCombinationMethod.Add);
                                }
                            }
                        }
                    }, TaskCreationOptions.None);
                },
            };
        }

        private void Current_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == "IsEditingEnabled") {
                this.IsEditingEnabled = Project.Current.IsEditingEnabled;
            }
        }

        protected override void NotifyPropertyChanged([CallerMemberName] string name = "") {
            var inspector = base.Inspector;

            base.NotifyPropertyChanged(name);

            switch (name) {
                case "SelectedSchema": {
                        SelectedModelType = default;
                        IsSelectedModelTypeEnabled = false;

                        if (SelectedSchema != default) {
                            var schema = SelectedSchema;

                            if (!string.IsNullOrEmpty(schema)) {
                                var featureCatalogue = _module.GetFeatureCatalogue(schema);

                                IEnumerable<string> types;
                                if (inspector.HasGeometry) {
                                    var geometryType = inspector.MapMember switch {
                                        FeatureLayer l => l.ShapeType,
                                        _ => throw new InvalidOperationException(),
                                    };

                                    var primitive = geometryType switch {
                                        ArcGIS.Core.CIM.esriGeometryType.esriGeometryPolygon => Primitives.surface,
                                        ArcGIS.Core.CIM.esriGeometryType.esriGeometryPolyline => Primitives.curve,
                                        ArcGIS.Core.CIM.esriGeometryType.esriGeometryPoint => Primitives.point,
                                        ArcGIS.Core.CIM.esriGeometryType.esriGeometryMultipoint => Primitives.pointSet,
                                        _ => throw new InvalidOperationException(),
                                    };

                                    types = _inspectorHandle.Types(featureCatalogue, primitive);
                                }
                                else {
                                    types = _inspectorHandle.Types(featureCatalogue, default);
                                }

                                System.Windows.Application.Current.Dispatcher.Invoke(() => {
                                    ModelTypes.Clear();
                                    ModelTypes.AddRange(types.OrderBy(e => e).Select(e => new SelectedType(e)));
                                });

                                IsSelectedModelTypeEnabled = true;
                            }
                        }
                        _selectedTemplate = SelectedTemplate.Empty;

                        NotifyPropertyChanged(() => IsCreateButtonEnabled);
                    }
                    break;

                case "SelectedModelType": {
                        if (SelectedModelType != default) {
                            var featuretype = SelectedModelType.Code;

                            if (featuretype != default) {
                                var featureCatalogue = _module.GetFeatureCatalogue(SelectedSchema);

                                //var featureType = featureCatalogue.FeatureTypes.Single(e => e.Code.Equals(featuretype));

                                _selectedTemplate = new SelectedTemplate(SelectedSchema, featuretype);

                                NotifyPropertyChanged(() => IsCreateButtonEnabled);
                            }
                        }
                    }
                    break;
            }
        }

        public override bool Applies(MapMember mapMember) {
            return true;
        }

        public override bool IsDefault => true;

        public override async Task LoadFromFeaturesAsync() {
            var inspector = base.Inspector;

            var model = base.Model;

            if (!inspector.HasAttributes)
                return;

            try {
                var uuid = Convert.ToString(inspector["GlobalID"]).ToUpperInvariant();

                var catalogue = await QueuedTask.Run(() => {
                    var fc = inspector.MapMember switch {
                        FeatureLayer l => l.GetFeatureClass(),
                        StandaloneTable t => t.GetTable(),
                        _ => throw new InvalidOperationException(),
                    };

                    using var geodatabase = (Geodatabase)fc.GetDatastore();

                    var syntax = geodatabase.GetSQLSyntax();
                    var tableNames = syntax.ParseTableName(fc.GetName());

                    this._inspectorHandle = tableNames.Item3.ToLowerInvariant() switch {
                        "point" => _inspectorHandleFeature,
                        "pointset" => _inspectorHandleFeature,
                        "curve" => _inspectorHandleFeature,
                        "surface" => _inspectorHandleFeature,
                        "informationtype" => _inspectorHandleInformation,
                        //"associationbinding" => null,
                        "featureassociation" => _inspectorHandleFeatureAssociation,
                        "informationassociation" => _inspectorHandleInformationAssociation,

                        _ => throw new NotImplementedException(),
                    };

                    var ps = Convert.ToString(inspector["ps"]);
                    if (!string.IsNullOrEmpty(ps)) {
                        return [ps.ToUpperInvariant()];
                    }

                    using var configuration = geodatabase.OpenDataset<Table>(syntax.QualifyTableName(tableNames.Item1, tableNames.Item2, "configuration"));

                    string[] catalogues = new string[0];

                    using var cursor = configuration.Search(null, true);
                    while (cursor.MoveNext()) {
                        var settings = JsonSerializer.Deserialize<S100Horizon.Settings.Editor>(Convert.ToString(cursor.Current["json"]));
                        if (!settings.ExcludeInEditor)
                            catalogues = [.. catalogues, Convert.ToString(cursor.Current["ps"]).Split('.').First()];
                    }
                    if (catalogues.Any())
                        return catalogues;
                    return _catalogues;


                    //if (!string.IsNullOrEmpty(tableNames.Item2)) {
                    //    return _catalogues.SingleOrDefault(e => e.Equals(tableNames.Item2, StringComparison.OrdinalIgnoreCase) || e.Replace("-", string.Empty).Equals(tableNames.Item2, StringComparison.OrdinalIgnoreCase));
                    //}

                    //return geodatabase.GetConnector() switch {
                    //    FileGeodatabaseConnectionPath fileGeodatabase => _catalogues.SingleOrDefault(e => e.Equals(IO.Path.GetFileNameWithoutExtension(fileGeodatabase.Path.AbsolutePath), StringComparison.OrdinalIgnoreCase) || e.Replace("-", string.Empty).Equals(IO.Path.GetFileNameWithoutExtension(fileGeodatabase.Path.AbsolutePath), StringComparison.InvariantCultureIgnoreCase)),
                    //    _ => null,
                    //};
                }, TaskCreationOptions.None);

                System.Windows.Application.Current.Dispatcher.Invoke(() => {
                    Schemas.Clear();
                    if (catalogue.Any()) {
                        Schemas.AddRange(catalogue);
                    }
                    //if (!string.IsNullOrEmpty(catalogue)) {
                    //    Schemas.Clear();
                    //    Schemas.Add(catalogue);
                    //}
                    //else {

                    //}
                });

                this.SelectedProperty = await QueuedTask.Run((Func<S100Framework.WPF.ViewModel.ViewModelBase>)(() => {
                    var featureid = Convert.ToString(inspector["GlobalID"]).ToUpperInvariant();
                    var schema = Convert.ToString(inspector["ps"]);

                    if (string.IsNullOrEmpty(schema)) {
                        this.SelectedSchema = default;
                        this.SelectedModelType = default;

                        System.Windows.Application.Current.Dispatcher.Invoke(() => {
                            this.ModelTypes.Clear();
                        });

                        this._selectedTemplate = SelectedTemplate.Empty;
                        return default;
                    }

                    var code = Convert.ToString(inspector["code"]);

                    var name = Convert.ToString(inspector["name"]);

                    var type = this._inspectorHandle.TypeSelector(inspector, schema);

                    if (type is null) {
                        return default;
                    }

                    var viewmodel = this._inspectorHandle.CreateViewModel(schema, code, type.Name, name);

                    object instance;
                    if (DBNull.Value.Equals(inspector["JSON"]) || string.IsNullOrEmpty(Convert.ToString(inspector["JSON"]))) {
                        instance = Activator.CreateInstance(type);
                    }
                    else {
                        var json = Convert.ToString(inspector["JSON"]);
                        instance = System.Text.Json.JsonSerializer.Deserialize(json, type);
                    }

                    var methodInfo = viewmodel.GetType().GetMethod("Load");
                    methodInfo.Invoke(viewmodel, new object[1] { instance });

                    SelectedObjectViewModel selectedObjectViewModel = null;
                    if (instance is IInformationBindingDefinition) {
                        var informationViewModel = (InformationViewModel)viewmodel;

                        if (!inspector.IsNull("informationbindings")) {
                            var informationBindings = System.Text.Json.JsonSerializer.Deserialize<List<informationBinding>>(Convert.ToString(inspector["informationbindings"]));
                            foreach (var e in informationBindings)
                                informationViewModel.InformationBindings.Add(new InformationBindingViewModel().Load(e));
                        }

                        this.SelectedInformationProperty = new SelectedInformationTypeObjectViewModel(informationViewModel);//, (IInformationBindingDefinition)instance);
                        selectedObjectViewModel = this.SelectedInformationProperty;
                    }
                    if (instance is IFeatureBindingDefinition) {
                        var primitive = inspector.Shape.GeometryType switch {
                            ArcGIS.Core.Geometry.GeometryType.Point => Primitives.point,
                            ArcGIS.Core.Geometry.GeometryType.Multipoint => Primitives.pointSet,
                            ArcGIS.Core.Geometry.GeometryType.Polyline => Primitives.curve,
                            ArcGIS.Core.Geometry.GeometryType.Polygon => Primitives.surface,
                            _ => throw new InvalidOperationException()
                        };

                        var featureViewModel = (FeatureViewModel)viewmodel;

                        //  informationBinding
                        if (!inspector.IsNull("informationbindings")) {
                            var informationBindings = System.Text.Json.JsonSerializer.Deserialize<List<informationBinding>>(Convert.ToString(inspector["informationbindings"]));
                            foreach (var e in informationBindings)
                                featureViewModel.InformationBindings.Add(new InformationBindingViewModel().Load(e));
                        }

                        //  featureBinding                        
                        if (!inspector.IsNull("featurebindings")) {
                            var featureBindings = System.Text.Json.JsonSerializer.Deserialize<List<featureBinding>>(Convert.ToString(inspector["featurebindings"]));
                            foreach (var e in featureBindings)
                                featureViewModel.FeatureBindings.Add(new FeatureBindingViewModel().Load(e));
                        }

                        this.SelectedFeatureProperty = new SelectedFeatureTypeObjectViewModel(featureViewModel, primitive);
                        selectedObjectViewModel = this.SelectedFeatureProperty;
                    }
                    if (instance is Association) {
                        var association = (AssociationViewModel)viewmodel;

                        var selectedAssociationproperty = new SelectedAssociationObjectViewModel(association);

                        if (instance is FeatureAssociation) {
                            var associationViewModel = (AssociationViewModel)viewmodel;

                            //  featureBinding
                            {
                                string[] tableNames = ["point", "pointset", "curve", "surface"];

                                var query = new QueryFilter {
                                    WhereClause = $"lower(featurebindings) LIKE '%\"associationid\":%\"{associationViewModel.Name.ToLowerInvariant()}\"%'",
                                };
                                foreach (var tableName in tableNames) {
                                    using var table = inspector.OpenDataset<FeatureClass>(tableName);
                                    using var cursor = table.Search(query, true);
                                    while (cursor.MoveNext()) {
                                        var row = cursor.Current;

                                        var featureBindings = System.Text.Json.JsonSerializer.Deserialize<List<featureBinding>>(Convert.ToString(row["featurebindings"]));
                                        System.Windows.Application.Current.Dispatcher.Invoke(() => {
                                            foreach (var e in featureBindings.Where(e => e.associationId == associationViewModel.Name))
                                                selectedAssociationproperty.FeatureBindings.Add(new FeatureBindingViewModel().Load(e));
                                        }, System.Windows.Threading.DispatcherPriority.Normal);
                                    }

                                }
                            }
                        }

                        if (instance is InformationAssociation) {
                            var associationViewModel = (AssociationViewModel)viewmodel;

                            //  informationBinding
                            {
                                string[] tableNames = ["point", "pointset", "curve", "surface", "informationtype"];

                                var query = new QueryFilter {
                                    WhereClause = $"lower(informationbindings) LIKE '%\"associationid\":%\"{associationViewModel.Name.ToLowerInvariant()}\"%'",
                                };
                                foreach (var tableName in tableNames) {
                                    using var table = inspector.OpenDataset<Table>(tableName);
                                    using var cursor = table.Search(query, true);
                                    while (cursor.MoveNext()) {
                                        var row = cursor.Current;

                                        var informationBindings = System.Text.Json.JsonSerializer.Deserialize<List<informationBinding>>(Convert.ToString(row["informationbindings"]));
                                        System.Windows.Application.Current.Dispatcher.Invoke(() => {
                                            foreach (var e in informationBindings.Where(e => e.associationId == associationViewModel.Name))
                                                selectedAssociationproperty.InformationBindings.Add(new InformationBindingViewModel().Load(e));
                                        }, System.Windows.Threading.DispatcherPriority.Normal);
                                    }

                                }
                            }
                        }

                        this.SelectedAssociationProperty = selectedAssociationproperty;
                        selectedObjectViewModel = this.SelectedAssociationProperty;

                    }

                    if (selectedObjectViewModel != null) {
                        selectedObjectViewModel.PropertyChanged += this.OnPropertyChanged;
                        selectedObjectViewModel.CollectionChanged += this.OnCollectionChanged;
                        selectedObjectViewModel.CollectionItemChanged += this.OnCollectionItemChanged;
                    }
                    return viewmodel;
                }), TaskCreationOptions.None);

                if (SelectedProperty == default) {
                    SelectedSchema = default;
                    SelectedModelType = default;

                    IsSelectedSchemaEnabled = true;
                    IsSelectedModelTypeEnabled = SelectedSchema != default;

                    IsVisible = Visibility.Collapsed;
                }
                else {
                    IsSelectedSchemaEnabled = false;
                    IsSelectedModelTypeEnabled = false;

                    IsVisible = Visibility.Visible;
                }
                NotifyPropertyChanged(() => IsCreateButtonEnabled);
            }
            catch { }
        }

        private async void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            await QueuedTask.Run(() => {
                if (sender is ICollection<FeatureBindingViewModel> featureBindings) {
                    var f = featureBindings.Select(e => new featureBinding {
                        association = e.association,
                        associationId = e.associationId,
                        featureId = e.featureId,
                        role = e.role,
                        roleType = e.roleType.HasValue ? Enum.GetName<roleType>(e.roleType.Value) : default,
                    });
                    Inspector["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(f);
                }
            }, TaskCreationOptions.None);
        }

        private async void OnCollectionItemChanged(object sender, object item, PropertyChangedEventArgs e) {
            await QueuedTask.Run(() => {
                if (sender is ICollection<FeatureBindingViewModel> featureBindings) {
                    var f = featureBindings.Select(e => new featureBinding {
                        association = e.association,
                        associationId = e.associationId,
                        featureId = e.featureId,
                        role = e.role,
                        roleType = e.roleType.HasValue ? Enum.GetName<roleType>(e.roleType.Value) : default,
                    });
                    Inspector["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(f);
                }
            }, TaskCreationOptions.None);
        }

        private async void OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
            await QueuedTask.Run(async () => {
                var updated = false;

                if (sender is ViewModelBase viewModel) {
                    var json = viewModel.Serialize();

                    if (Inspector.IsNull("json")) {
                        Inspector["json"] = json;
                        updated |= true;
                    }
                    else if (string.Compare(json, Convert.ToString(Inspector["json"]), true) != 0) {
                        Inspector["json"] = json;
                        updated |= true;
                    }
                }
                if (sender is InformationBindingViewModel informationBinding) {
                    var informationBindings = Inspector.IsNull("informationbindings") ? new List<informationBinding>() : System.Text.Json.JsonSerializer.Deserialize<List<informationBinding>>(Convert.ToString(Inspector["informationbindings"]));
                    var json = System.Text.Json.JsonSerializer.Serialize(informationBindings);
                    if (Inspector.IsNull("informationbindings") && informationBindings.Any()) {
                        Inspector["informationbindings"] = json;
                        updated |= true;
                    }
                    else if (string.Compare(json, Convert.ToString(Inspector["informationbindings"]), true) != 0) {
                        Inspector["informationbindings"] = json;
                        updated |= true;
                    }
                }
                if (sender is FeatureBindingViewModel featureBinding) {
                    var featureBindings = Inspector.IsNull("featurebindings") ? new List<featureBinding>() : System.Text.Json.JsonSerializer.Deserialize<List<featureBinding>>(Convert.ToString(Inspector["featurebindings"]));
                    var json = System.Text.Json.JsonSerializer.Serialize(featureBindings);
                    if (Inspector.IsNull("featurebindings") && featureBindings.Any()) {
                        Inspector["featurebindings"] = json;
                        updated |= true;
                    }
                    else if (string.Compare(json, Convert.ToString(Inspector["featurebindings"]), true) != 0) {
                        Inspector["featurebindings"] = json;
                        updated |= true;
                    }
                }
            }, TaskCreationOptions.None);
        }

        private Type FeatureTypeSelector(Inspector inspector, string schema) {
            var featureid = Convert.ToString(inspector["GlobalID"]).ToUpperInvariant();

            var featureCatalogue = _module.GetFeatureCatalogue(schema);

            var code = Convert.ToString(inspector["code"]);
            if (string.IsNullOrEmpty(code))
                return null;

            if (!_selectedTemplate.Schema.Equals(schema) || !_selectedTemplate.Code.Equals(code)) {
                SelectedSchema = schema;

                var types = featureCatalogue.FeatureTypes.Select(e => e.Code);

                System.Windows.Application.Current.Dispatcher.Invoke(() => {
                    ModelTypes.Clear();
                    ModelTypes.AddRange(types.OrderBy(e => e).Select(e => new SelectedType(e)));
                });

                SelectedModelType = ModelTypes.Single(e => e.Code == code);
            }

            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace(schema, "FeatureTypes")}.{code}", true);

            return type;
        }

        private Type FeatureAssociationTypeSelector(Inspector inspector, string schema) {
            var featureid = Convert.ToString(inspector["GlobalID"]).ToUpperInvariant();

            var featureCatalogue = _module.GetFeatureCatalogue(schema);

            var code = Convert.ToString(inspector["code"]);
            if (string.IsNullOrEmpty(code))
                return null;

            if (!_selectedTemplate.Schema.Equals(schema) || !_selectedTemplate.Code.Equals(code)) {
                SelectedSchema = schema;

                var types = featureCatalogue.FeatureAssociationTypes.Select(e => e.Code);

                System.Windows.Application.Current.Dispatcher.Invoke(() => {
                    ModelTypes.Clear();
                    ModelTypes.AddRange(types.OrderBy(e => e).Select(e => new SelectedType(e)));
                });

                SelectedModelType = ModelTypes.Single(e => e.Code == code);
            }

            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace(schema, "FeatureAssociations")}.{code}", true);

            return type;
        }

        private Type InformationTypeSelector(Inspector inspector, string schema) {
            var featureid = Convert.ToString(inspector["GlobalID"]).ToUpperInvariant();

            var featureCatalogue = _module.GetFeatureCatalogue(schema);

            var code = Convert.ToString(inspector["code"]);
            if (string.IsNullOrEmpty(code))
                return null;

            if (!_selectedTemplate.Schema.Equals(schema) || !_selectedTemplate.Code.Equals(code)) {
                SelectedSchema = schema;

                var types = featureCatalogue.InformationTypes.Select(e => e.Code);

                System.Windows.Application.Current.Dispatcher.Invoke(() => {
                    ModelTypes.Clear();
                    ModelTypes.AddRange(types.OrderBy(e => e).Select(e => new SelectedType(e)));
                });

                SelectedModelType = ModelTypes.Single(e => e.Code == code);
            }

            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace(schema, "InformationTypes")}.{code}", true);

            return type;
        }

        private Type InformationAssociationTypeSelector(Inspector inspector, string schema) {
            var featureid = Convert.ToString(inspector["GlobalID"]).ToUpperInvariant();

            var featureCatalogue = _module.GetFeatureCatalogue(schema);

            var code = Convert.ToString(inspector["code"]);
            if (string.IsNullOrEmpty(code))
                return null;

            if (!_selectedTemplate.Schema.Equals(schema) || !_selectedTemplate.Code.Equals(code)) {
                SelectedSchema = schema;

                var types = featureCatalogue.InformationAssociationTypes.Select(e => e.Code);

                System.Windows.Application.Current.Dispatcher.Invoke(() => {
                    ModelTypes.Clear();
                    ModelTypes.AddRange(types.OrderBy(e => e).Select(e => new SelectedType(e)));
                });

                SelectedModelType = ModelTypes.Single(e => e.Code == code);
            }

            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace(schema, "InfromationAssociations")}.{code}", true);

            return type;

        }

        public ICommand CreateInstance { get; set; }

        public S100AttributeEditorControlHost Host {
            get => _host;
            set => SetProperty(ref _host, value);
        }

        public ObservableCollection<string> Schemas {
            get => _schemas;
            set => SetProperty(ref _schemas, value);
        }

        public string SelectedSchema {
            get => _selectedSchema;
            set => SetProperty(ref _selectedSchema, value);
        }

        public ObservableCollection<SelectedType> ModelTypes {
            get => _modelTypes;
            set => SetProperty(ref _modelTypes, value);
        }

        public SelectedType SelectedModelType {
            get => _selectedModelType;
            set => SetProperty(ref _selectedModelType, value);
        }

        public object SelectedProperty {
            get => _selectedProperty;
            set => SetProperty(ref _selectedProperty, value);
        }

        public Visibility IsVisible {
            get => _isVisible ? Visibility.Visible : Visibility.Collapsed;
            set => SetProperty(ref _isVisible, value == Visibility.Visible);
        }

        public Boolean IsEditingEnabled {
            get => _isEditingEnabled;
            set => SetProperty(ref _isEditingEnabled, value);
        }

        public SelectedAssociationObjectViewModel SelectedAssociationProperty {
            get => _selectedAssociationProperty;
            set => SetProperty(ref _selectedAssociationProperty, value);
        }

        public SelectedInformationTypeObjectViewModel SelectedInformationProperty {
            get => _selectedInformationProperty;
            set => SetProperty(ref _selectedInformationProperty, value);
        }

        public SelectedFeatureTypeObjectViewModel SelectedFeatureProperty {
            get => _selectedFeatureProperty;
            set => SetProperty(ref _selectedFeatureProperty, value);
        }

        public bool IsSelectedSchemaEnabled {
            get => _isSelectedSchemaEnabled;
            set => SetProperty(ref _isSelectedSchemaEnabled, value);
        }

        public bool IsSelectedModelTypeEnabled {
            get => _isSelectedModelTypeEnabled;
            set => SetProperty(ref _isSelectedModelTypeEnabled, value);
        }

        public bool IsCreateButtonEnabled => IsSelectedSchemaEnabled && IsSelectedModelTypeEnabled && _selectedTemplate != SelectedTemplate.Empty;


        private static JsonNode Unflatten(Dictionary<string, JsonValue> source) {
            var regex = new System.Text.RegularExpressions.Regex(@"(?!\.)([^. ^\[\]]+)|(?!\[)(\d+)(?=\])");
            JsonNode node = JsonNode.Parse("{}");

            foreach (var keyValue in source) {
                var pathSegments = regex.Matches(keyValue.Key).Select(m => m.Value).ToArray();

                for (int i = 0; i < pathSegments.Length; i++) {
                    var currentSegmentType = GetSegmentKind(pathSegments[i]);

                    if (currentSegmentType == JsonValueKind.Object) {
                        if (node[pathSegments[i]] == null) {
                            if (pathSegments[i] == pathSegments[pathSegments.Length - 1]) {
                                node[pathSegments[i]] = keyValue.Value;
                                node = node.Root;
                            }
                            else {
                                var nextSegmentType = GetSegmentKind(pathSegments[i + 1]);

                                if (nextSegmentType == JsonValueKind.Object) {
                                    node[pathSegments[i]] = JsonNode.Parse("{}");
                                }
                                else {
                                    node[pathSegments[i]] = JsonNode.Parse("[]");
                                }
                                node = node[pathSegments[i]];
                            }
                        }
                        else {
                            node = node[pathSegments[i]];
                        }
                    }
                    else {
                        if (!int.TryParse(pathSegments[i], out int index)) {
                            throw new Exception("Cannot parse index");
                        }

                        while (node.AsArray().Count - 1 < index) {
                            node.AsArray().Add(null);
                        }

                        if (i == pathSegments.Length - 1) {
                            node[index] = keyValue.Value;
                            node = node.Root;
                        }
                        else {
                            if (node[index] == null) {
                                var nextSegmentType = GetSegmentKind(pathSegments[i + 1]);

                                if (nextSegmentType == JsonValueKind.Object) {
                                    node[index] = JsonNode.Parse("{}");
                                }
                                else {
                                    node[index] = JsonNode.Parse("[]");
                                }
                            }

                            node = node[index];
                        }
                    }
                }
            }

            return node;
        }

        private static JsonValueKind GetSegmentKind(string pathSegment) => int.TryParse(pathSegment, out _) ? JsonValueKind.Array : JsonValueKind.Object;
    }
}

namespace ArcGIS.Desktop.Editing.Attributes
{
    public static class Extension
    {
        public static T OpenDataset<T>(this Inspector inspector, string name) where T : Dataset {
            using var fc = inspector.MapMember switch {
                FeatureLayer l => l.GetFeatureClass(),
                StandaloneTable t => t.GetTable(),
                _ => throw new InvalidOperationException(),
            };
            using var geodatabase = (Geodatabase)fc.GetDatastore();

            var syntax = geodatabase.GetSQLSyntax();
            var tableNames = syntax.ParseTableName(fc.GetName());

            return geodatabase.OpenDataset<T>(syntax.QualifyTableName(tableNames.Item1, tableNames.Item2, name));
        }
    }
}