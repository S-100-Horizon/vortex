#define S100ed3

using ActiproSoftware.Windows.Extensions;
using ArcGIS.Core.Data;
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
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using IO = System.IO;

namespace VortexProAppModule
{
    //  https://github.com/esri/arcgis-pro-sdk/wiki/ProConcepts-Editing#customizing-the-attributes-dockpane

    internal class S100AttributeTabViewModel : AttributeTabEmbeddableControl
    {
        private static CultureInfo culture = new("en-GB", false);

        public class InspectorHandle
        {
            public Func<Inspector, string, Type> TypeSelector { get; set; }

            public Func<FeatureCatalogue, IEnumerable<string>> Types { get; set; }

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
            Types = (e) => e.InformationAssociationTypes.Select(e => e.Code),
            CreateViewModel = (schema, code, type, pid) => {
                return S100Framework.WPF.Helper.CreateInformationAssociationViewModel(schema, code, pid);
            },
        };

        private InspectorHandle _inspectorHandleFeatureAssociation => new() {
            TypeSelector = this.FeatureAssociationTypeSelector,
            Types = (e) => e.FeatureAssociationTypes.Select(e => e.Code),
            CreateViewModel = (schema, code, type, pid) => {
                return S100Framework.WPF.Helper.CreateFeatureAssociationViewModel(schema, code, pid);
            },
        };

        private InspectorHandle _inspectorHandleInformation => new() {
            TypeSelector = this.InformationTypeSelector,
            Types = (e) => e.InformationTypes.Select(e => e.Code),
            CreateViewModel = (schema, code, type, pid) => {
                return S100Framework.WPF.Helper.CreateInformationTypeViewModel(schema, type, pid);
            },
        };

        private InspectorHandle _inspectorHandleFeature => new() {
            TypeSelector = this.FeatureTypeSelector,
            Types = (e) => e.FeatureTypes.Select(e => e.Code),
            CreateViewModel = (schema, code, type, pid) => {
                return S100Framework.WPF.Helper.CreateFeatureTypeViewModel(schema, type, pid);
            },
        };



        private SelectedTemplate _selectedTemplate = SelectedTemplate.Empty;

        private SelectedType _selectedModelType = default;

        private ObservableCollection<string> _schemas = new();

        private string _selectedSchema = default;

        private object _selectedProperty = default;

        private S100AttributeEditorViewModel? _viewModel = default;

        private ObservableCollection<SelectedType> _modelTypes = new();

        private bool _isSelectedSchemaEnabled = true;

        private bool _isSelectedModelTypeEnabled = false;

        private string[] _catalogues;

        public S100AttributeTabViewModel(XElement options, bool canChangeOptions) : base(options, canChangeOptions) {
            _module = VortexProAppModule.Module.Current;
            _catalogues = _module.GetFeatureCatalogues();

            Schemas.AddRange(_catalogues);

            CreateInstance = new RelayCommand(async () => {
                var inspector = base.Inspector;

                if (inspector != default) {
                    inspector["ps"] = SelectedSchema;
                    inspector["code"] = SelectedModelType.Code;

                    IsSelectedSchemaEnabled = false;
                    IsSelectedModelTypeEnabled = false;

                    await QueuedTask.Run(() => {
                        inspector.Apply();
                    });
                }
            });

            S100Framework.WPF.ViewModel.Handles.GetFeaturesRefId = async (e) => {
                var featureType = e.FeatureType;
                var associationTypes = e.AssociationTypes;

                var result = await QueuedTask.Run(() => {
                    var mapView = MapView.Active?.Map;
                    if (mapView is null)
                        return [];

                    var inspector = new ArcGIS.Desktop.Editing.Attributes.Inspector();

                    var selection = mapView.GetSelection();

                    var objectid = new List<string>();

                    foreach (var selectionSet in selection.ToDictionary()) {
                        if (!(selectionSet.Key is ArcGIS.Desktop.Mapping.FeatureLayer))
                            continue;
                        foreach (var i in selectionSet.Value) {
                            inspector.Load(selectionSet.Key, i);

                            var code = Convert.ToString(inspector["code"]);
                            if (string.IsNullOrEmpty(code) || !featureType.Equals(code, StringComparison.InvariantCultureIgnoreCase))
                                continue;

                            objectid.Add(Convert.ToString(inspector["name"]));
                        }
                    }

                    return objectid.ToArray();
                });
                return result;
            };

            S100Framework.WPF.ViewModel.Handles.GetInformationsRefId = async (e) => {
                var informationType = e.InformationType;
                var associationTypes = e.AssociationTypes;

                var result = await QueuedTask.Run(() => {
                    var mapView = MapView.Active?.Map;
                    if (mapView is null)
                        return [];

                    var inspector = new ArcGIS.Desktop.Editing.Attributes.Inspector();

                    var selection = mapView.GetSelection();

                    var objectid = new List<string>();

                    foreach (var selectionSet in selection.ToDictionary()) {
                        if (!(selectionSet.Key is ArcGIS.Desktop.Mapping.StandaloneTable))
                            continue;

                        foreach (var i in selectionSet.Value) {
                            inspector.Load(selectionSet.Key, i);

                            var code = Convert.ToString(inspector["code"]);
                            if (string.IsNullOrEmpty(code) || !informationType.Equals(code, StringComparison.InvariantCultureIgnoreCase))
                                continue;

                            objectid.Add(Convert.ToString(inspector["name"]));
                        }
                    }

                    return objectid.ToArray();
                });
                return result;
            };
        }

        protected override void NotifyPropertyChanged([CallerMemberName] string name = "") {
            base.NotifyPropertyChanged(name);

            switch (name) {
                case "SelectedSchema": {
                        SelectedModelType = default;
                        IsSelectedModelTypeEnabled = false;

                        if (SelectedSchema != default) {
                            var schema = SelectedSchema;

                            if (!string.IsNullOrEmpty(schema)) {
                                var featureCatalogue = _module.GetFeatureCatalogue(schema);

                                var types = _inspectorHandle.Types(featureCatalogue);

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
                        "featureassociation" => _inspectorHandleFeatureAssociation,
                        "informationassociation" => _inspectorHandleInformationAssociation,
                        _ => throw new NotImplementedException(),
                    };


                    if (!string.IsNullOrEmpty(tableNames.Item2)) {
                        var catalogue = _catalogues.SingleOrDefault(e => e.Equals(tableNames.Item2, StringComparison.InvariantCultureIgnoreCase) || e.Replace("-", string.Empty).Equals(tableNames.Item2, StringComparison.InvariantCultureIgnoreCase));

                        return catalogue;

                    }

                    return geodatabase.GetConnector() switch {
                        FileGeodatabaseConnectionPath fileGeodatabase => _catalogues.SingleOrDefault(e => e.Equals(IO.Path.GetFileNameWithoutExtension(fileGeodatabase.Path.AbsolutePath), StringComparison.InvariantCultureIgnoreCase) || e.Replace("-", string.Empty).Equals(IO.Path.GetFileNameWithoutExtension(fileGeodatabase.Path.AbsolutePath), StringComparison.InvariantCultureIgnoreCase)),
                        _ => null,
                    };
                });

                System.Windows.Application.Current.Dispatcher.Invoke(() => {
                    if (!string.IsNullOrEmpty(catalogue)) {
                        Schemas.Clear();
                        Schemas.Add(catalogue);
                    }
                    else {

                    }
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


                    this.S100AttributeEditorViewModel = instance switch {
                        InformationNode m => new S100AttributeEditorViewModel(m, (InformationViewModel)viewmodel),
                        FeatureNode m => new S100AttributeEditorViewModel(m, (FeatureViewModel)viewmodel),
                        _ => throw new NotImplementedException(),
                    };
                    
                    

                    //viewmodel.PropertyChanged += (object sender, PropertyChangedEventArgs e) => {
                    //    var json = ((S100Framework.WPF.ViewModel.ViewModelBase)sender).Serialize();

                    //    if (DBNull.Value != inspector["json"]) {
                    //        if (Convert.ToString(inspector["json"]).Equals(json))
                    //            return;
                    //    }

                    //    inspector["json"] = ((S100Framework.WPF.ViewModel.ViewModelBase)sender).Serialize();
                    //};
                    
                    return viewmodel;
                }));

                if (SelectedProperty == default) {
                    SelectedSchema = default;
                    SelectedModelType = default;

                    IsSelectedSchemaEnabled = true;
                    IsSelectedModelTypeEnabled = SelectedSchema != default;
                }
                else {                    
                    IsSelectedSchemaEnabled = false;
                    IsSelectedModelTypeEnabled = false;
                }
                NotifyPropertyChanged(() => IsCreateButtonEnabled);
            }
            catch { }
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

            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace(schema, "Associations.FeatureAssociations")}.{code}", true);

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

            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace(schema, "Associations.InfromationAssociations")}.{code}", true);

            return type;

        }

        public ICommand CreateInstance { get; set; }

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

        public S100AttributeEditorViewModel? S100AttributeEditorViewModel {
            get => _viewModel;
            set => SetProperty(ref _viewModel, value);
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


        public void S100AttributeEditor_QueryAssociations(object sender, QueryAssociationsEventArgs e) {
            var r = new Random(DateTime.Now.Microsecond);
            foreach (var i in Enumerable.Range(0, r.Next(1, 8))) {
                e.associations.Add(new AssociationId($"A{r.Next(1, 1000):0000}"));
            }
        }

        static Dictionary<int, string[]> featureTypes = new Dictionary<int, string[]> {
            { 0, ["LandArea", "Sounding"] },
            { 1, ["Coastline"] },
            { 2, ["LandArea", "Lake"] },
        };

        public void S100AttributeEditor_QueryFeatures(object sender, QueryFeaturesEventArgs e) {
            var r = new Random(DateTime.Now.Microsecond);
            foreach (var i in Enumerable.Range(0, r.Next(1, 8))) {
                e.features.Add(r.Next(0, 2) switch {
                    0 => new FeatureId(featureTypes[0][r.Next(0, featureTypes[0].Count() - 1)], $"P{r.Next(1, 1000):0000}"),
                    1 => new FeatureId(featureTypes[1][r.Next(0, featureTypes[1].Count() - 1)], $"C{r.Next(1, 1000):0000}"),
                    2 => new FeatureId(featureTypes[2][r.Next(0, featureTypes[2].Count() - 1)], $"S{r.Next(1, 1000):0000}"),
                });
            }
        }

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