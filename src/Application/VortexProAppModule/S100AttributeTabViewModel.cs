#define S100ed3

using ActiproSoftware.Windows.Extensions;
using ArcGIS.Core.Data;
using ArcGIS.Desktop.Editing.Attributes;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;
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



namespace VortexProAppModule
{
    //  https://github.com/esri/arcgis-pro-sdk/wiki/ProConcepts-Editing#customizing-the-attributes-dockpane

    internal class S100AttributeTabViewModel : AttributeTabEmbeddableControl
    {
        static CultureInfo culture = new CultureInfo("en-GB", false);

        internal record SelectedTemplate(string Schema, string Code)
        {
            public static SelectedTemplate Empty => new(string.Empty, string.Empty);
        }

        internal record SelectedType(string Code);

        private readonly VortexProAppModule.Module _module;

        private SelectedTemplate _selectedTemplate = SelectedTemplate.Empty;

        private SelectedType _selectedFeatureType = default;

        private ObservableCollection<string> _schemas = new ObservableCollection<string>();

        private string _selectedSchema = default;

        private object _selectedProperty = default;

        private ObservableCollection<SelectedType> _featureTypes = new ObservableCollection<SelectedType>();

        private bool _isSelectedSchemaEnabled = true;

        private bool _isSelectedFeatureTypeEnabled = false;


        public S100AttributeTabViewModel(XElement options, bool canChangeOptions) : base(options, canChangeOptions) {
            _module = VortexProAppModule.Module.Current;

            Schemas.AddRange(_module.GetFeatureCatalogues());

            CreateFeatureType = new RelayCommand(async () => {
                var inspector = base.Inspector;

                if (inspector != default) {
                    inspector["ps"] = SelectedSchema;
                    inspector["code"] = SelectedFeatureType.Code;

                    IsSelectedSchemaEnabled = false;
                    IsSelectedFeatureTypeEnabled = false;

                    await QueuedTask.Run(() => {
                        inspector.Apply();
                    });
                }
            });
        }

        protected override void NotifyPropertyChanged([CallerMemberName] string name = "") {
            base.NotifyPropertyChanged(name);

            switch (name) {
                case "SelectedSchema": {
                        SelectedFeatureType = default;
                        IsSelectedFeatureTypeEnabled = false;

                        if (SelectedSchema != default) {
                            var schema = SelectedSchema;

                            if (!string.IsNullOrEmpty(schema)) {
                                var featureCatalogue = _module.GetFeatureCatalogue(schema);

                                System.Windows.Application.Current.Dispatcher.Invoke(() => {
                                    FeatureTypes.Clear();
                                    //FeatureTypes.AddRange(featureCatalogue.FeatureTypes.OrderBy(e => e.Code));
                                });

                                IsSelectedFeatureTypeEnabled = true;
                            }
                        }
                        _selectedTemplate = SelectedTemplate.Empty;

                        NotifyPropertyChanged(() => IsCreateButtonEnabled);
                    }
                    break;

                case "SelectedFeatureType": {
                        if (SelectedFeatureType != default) {
                            var featuretype = SelectedFeatureType.Code;

                            if (featuretype != default) {
                                var featureCatalogue = _module.GetFeatureCatalogue(SelectedSchema);

                                //var featureType = featureCatalogue.FeatureTypes.Single(e => e.Code.Equals(featuretype));

                                //_selectedTemplate = new SelectedTemplate(SelectedSchema, featureType.Code);

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

#if S100ed1
                if (!inspector.MapMember.Map.Name.Equals("S100ed1"))
                    return;

                var json = await QueuedTask.Run(() => {
                    var fc = inspector.MapMember switch {
                        FeatureLayer l => l.GetFeatureClass(),
                        _ => throw new InvalidOperationException(),
                    };

                    using var geodatabase = (Geodatabase)fc.GetDatastore();

                    var syntax = geodatabase.GetSQLSyntax();
                    var tableNames = syntax.ParseTableName(fc.GetName());

                    var refIds = new Dictionary<string, string>();

                    using var table_feturetype = geodatabase.OpenDataset<Table>(syntax.QualifyTableName(tableNames.Item1, tableNames.Item2, "featuretype"));

                    using var cursor_featuretype = table_feturetype.Search(new QueryFilter {
                        WhereClause = $"geoid = '{uuid}'",
                    }, true);

                    cursor_featuretype.MoveNext();

                    var featureid = Convert.ToString(cursor_featuretype.Current["GlobalID"]).ToUpperInvariant();

                    var flatten = new Dictionary<string, JsonValue>();

                    using var table_complex = geodatabase.OpenDataset<Table>(syntax.QualifyTableName(tableNames.Item1, tableNames.Item2, "node_complex"));

                    using var cursor_complex = table_complex.Search(new QueryFilter {
                        WhereClause = $"refid = '{featureid}' and parentid is null",    //TODO: remove is null
                    }, true);

                    while (cursor_complex.MoveNext()) {
                        var current = cursor_complex.Current;

                        refIds.Add(Convert.ToString(current["code"]), Convert.ToString(current["GlobalID"]).ToUpperInvariant());
                    }

                    using var table_simple = geodatabase.OpenDataset<Table>(syntax.QualifyTableName(tableNames.Item1, tableNames.Item2, "node_simple"));

                    using var cursor_simple = table_simple.Search(new QueryFilter {
                        WhereClause = $"refid = '{featureid}' OR refid in ({string.Join(",", refIds.Values.Select(e => $"'{e}'"))})",
                    }, true);

                    var dictionaryArrays = new Dictionary<string, int>();

                    while (cursor_simple.MoveNext()) {
                        var current = cursor_simple.Current;

                        var refid = Convert.ToString(cursor_simple.Current["refid"]).ToUpperInvariant();

                        var value = current["value"];

                        if (DBNull.Value == value)
                            continue;

                        var root = $"{Convert.ToString(current["code"])}";
                        if (!featureid.Equals(refid, StringComparison.CurrentCultureIgnoreCase)) {
                            var typeName = $"{refIds.Single(e => e.Value.Equals(refid)).Key}";

                            var t = type.GetProperty(typeName);

                            if (t.PropertyType.IsArray) {
                                if (!dictionaryArrays.ContainsKey(typeName))
                                    dictionaryArrays.Add(typeName, 0);
                                else
                                    dictionaryArrays[typeName] += 1;

                                root = $"{refIds.Single(e => e.Value.Equals(refid)).Key}[{dictionaryArrays[typeName]}].{root}";
                            }
                            else
                                root = $"{refIds.Single(e => e.Value.Equals(refid)).Key}.{root}";
                        }
                        else {
                            var t = type.GetProperty(root);

                            if (t.PropertyType.IsArray) {
                                if (!dictionaryArrays.ContainsKey(root))
                                    dictionaryArrays.Add(root, 0);
                                else
                                    dictionaryArrays[root] += 1;

                                root = $"{root}[{dictionaryArrays[root]}]";
                            }
                        }


                        flatten.Add(root, Convert.ToString(current["valuetype"]) switch {
                            "boolean" => JsonValue.Create<Boolean>(Boolean.Parse(Convert.ToString(value))),
                            //"enumeration" => $"\"{Convert.ToString(current["code"])}\": {Convert.ToString(value, culture)}",
                            "real" => JsonValue.Create<decimal>(decimal.Parse(Convert.ToString(value))),
                            "text" => JsonValue.Create<string>(Convert.ToString(value)),
                            //"S100_TruncatedDate" => "",
                            "date" => JsonValue.Create<DateTime>(DateTime.Parse(Convert.ToString(value))),
                            //"time" => "",
                            "integer" => JsonValue.Create<int>(int.Parse(Convert.ToString(value))),
                            "URN" => JsonValue.Create<string>(Convert.ToString(value)),
                            _ => throw new InvalidDataException(),
                        });
                    }

                    return Unflatten(flatten).ToString();
                });
#endif

#if S100ed2
                if (!inspector.MapMember.Map.Name.Equals("S100ed2", StringComparison.CurrentCultureIgnoreCase))
                    return;

                var featuretype = inspector;

                SelectedProperty = await QueuedTask.Run(() => {
                    var fc = inspector.MapMember switch {
                        FeatureLayer l => l.GetFeatureClass(),
                        _ => throw new InvalidOperationException(),
                    };

                    using var geodatabase = (Geodatabase)fc.GetDatastore();

                    var syntax = geodatabase.GetSQLSyntax();
                    var tableNames = syntax.ParseTableName(fc.GetName());

                    var featureid = Convert.ToString(featuretype["GlobalID"]).ToUpperInvariant();
                    var schema = Convert.ToString(featuretype["ps"]);

                    if (string.IsNullOrEmpty(schema)) {
                        SelectedSchema = default;
                        SelectedFeatureType = default;

                        System.Windows.Application.Current.Dispatcher.Invoke(() => {
                            FeatureTypes.Clear();
                        });

                        _selectedTemplate = SelectedTemplate.Empty;
                        return default;
                    }

                    var featureCatalogue = _module.GetFeatureCatalogue(schema);

                    var featureType = featureCatalogue.FeatureTypes.Single(e => e.Code.Equals(Convert.ToString(featuretype["code"])));

                    if (!_selectedTemplate.Schema.Equals(schema) || !_selectedTemplate.Code.Equals(featureType.Code)) {
                        SelectedSchema = schema;

                        System.Windows.Application.Current.Dispatcher.Invoke(() => {
                            FeatureTypes.Clear();
                            FeatureTypes.AddRange(featureCatalogue.FeatureTypes.OrderBy(e => e.Code));
                        });

                        SelectedFeatureType = featureType;

                        _selectedTemplate = new SelectedTemplate(schema, featureType.Code);
                    }

                    var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Roslyn.Namespace}.{featureType.Code}", true);


                    using var attribute = geodatabase.OpenDataset<Table>(syntax.QualifyTableName(tableNames.Item1, tableNames.Item2, "attribute"));

                    using var cursor_attribute = attribute.Search(new QueryFilter {
                        WhereClause = $"schema = '{schema}' AND featureid = '{featureid}'",
                    }, true);

                    var flatten = new Dictionary<string, JsonValue>();

                    while (cursor_attribute.MoveNext()) {
                        var current = cursor_attribute.Current;

                        var code = Convert.ToString(current["code"]);
                        var valuetype = Convert.ToString(current["valuetype"]);
                        var value = Convert.ToString(current["value"]);
                        var path = Convert.ToString(current["path"]);

                        var line = valuetype.ToLowerInvariant() switch {
                            "boolean" => JsonValue.Create<Boolean>(Boolean.Parse(value)),
                            //"enumeration" => $"\"{Convert.ToString(current["code"])}\": {Convert.ToString(value, culture)}",
                            "real" => JsonValue.Create<decimal>(decimal.Parse(value)),
                            "text" => JsonValue.Create<string>(value),
                            //"S100_TruncatedDate" => "",
                            "date" => JsonValue.Create<DateTime>(DateTime.Parse(Convert.ToString(value))),
                            //"time" => "",
                            "integer" => JsonValue.Create<int>(int.Parse(value)),
                            "urn" => JsonValue.Create<string>(value),
                            _ => throw new InvalidDataException(),
                        };

                        flatten.Add(path, line);
                    }

                    if(flatten.Count==0)
                        return Activator.CreateInstance(type);

                    var json = Unflatten(flatten).ToString();

                    var instance = System.Text.Json.JsonSerializer.Deserialize(json, type);                   

                    return instance;
                });

                if (SelectedProperty == default) {
                    SelectedSchema = default;
                    SelectedFeatureType = default;

                    IsSelectedSchemaEnabled = true;
                    IsSelectedFeatureTypeEnabled = SelectedSchema != default;
                }
                else {
                    IsSelectedSchemaEnabled = false;
                    IsSelectedFeatureTypeEnabled = false;
                }
                NotifyPropertyChanged(() => IsCreateButtonEnabled);
#endif

#if S100ed3
                if (!inspector.MapMember.Map.Name.Equals("S100ed3", StringComparison.CurrentCultureIgnoreCase))
                    return;

                SelectedProperty = await QueuedTask.Run(() => {
                    var fc = inspector.MapMember switch {
                        FeatureLayer l => l.GetFeatureClass(),
                        StandaloneTable t => t.GetTable(),
                        _ => throw new InvalidOperationException(),
                    };

                    using var geodatabase = (Geodatabase)fc.GetDatastore();

                    var syntax = geodatabase.GetSQLSyntax();
                    var tableNames = syntax.ParseTableName(fc.GetName());

                    var featureid = Convert.ToString(inspector["GlobalID"]).ToUpperInvariant();
                    var schema = Convert.ToString(inspector["ps"]);

                    if (string.IsNullOrEmpty(schema)) {
                        SelectedSchema = default;
                        SelectedFeatureType = default;

                        System.Windows.Application.Current.Dispatcher.Invoke(() => {
                            FeatureTypes.Clear();
                        });

                        _selectedTemplate = SelectedTemplate.Empty;
                        return default;
                    }

                    var code = Convert.ToString(inspector["code"]);

                    Func<Inspector, string, Type> selector = tableNames.Item3.ToLowerInvariant() switch {
                        "point" => FeatureTypeSelector,
                        "pointset" => FeatureTypeSelector,
                        "curve" => FeatureTypeSelector,
                        "surface" => FeatureTypeSelector,
                        "informationtype" => InformationTypeSelector,
                        "attributebinding" => (Inspector inspector, string schema) => {
                            return null;
                        }
                        ,
                        "informationbinding" => throw new NotImplementedException(),
                        _ => throw new NotImplementedException(),
                    };

                    var type = selector(inspector, schema);

                    if (type is null) {
                        return default;
                    }

                    var viewmodel = S100Framework.WPF.Helper.CreateViewModel(schema, type);

                    object instance;
                    if (DBNull.Value.Equals(inspector["JSON"]) || String.IsNullOrEmpty(Convert.ToString(inspector["JSON"]))) {
                        instance = Activator.CreateInstance(type);
                    }
                    else {
                        var json = Convert.ToString(inspector["JSON"]);

                        instance = System.Text.Json.JsonSerializer.Deserialize(json, type);
                    }

                    var methodInfo = viewmodel.GetType().GetMethod("Load");
                    methodInfo.Invoke(viewmodel, new object[1] { instance });

                    viewmodel.PropertyChanged += (object sender, PropertyChangedEventArgs e) => {
                        var json = ((S100Framework.WPF.ViewModel.ViewModelBase)sender).Serialize();

                        if (DBNull.Value != inspector["json"]) {
                            if (Convert.ToString(inspector["json"]).Equals(json))
                                return;
                        }

                        inspector["json"] = ((S100Framework.WPF.ViewModel.ViewModelBase)sender).Serialize();
                    };

                    return viewmodel;
                });


                if (SelectedProperty == default) {
                    SelectedSchema = default;
                    SelectedFeatureType = default;

                    IsSelectedSchemaEnabled = true;
                    IsSelectedFeatureTypeEnabled = SelectedSchema != default;
                }
                else {
                    IsSelectedSchemaEnabled = false;
                    IsSelectedFeatureTypeEnabled = false;
                }
                NotifyPropertyChanged(() => IsCreateButtonEnabled);
#endif
            }
            catch { }
        }

        private Type FeatureTypeSelector(Inspector inspector, string schema) {
            var featureid = Convert.ToString(inspector["GlobalID"]).ToUpperInvariant();

            var featureCatalogue = _module.GetFeatureCatalogue(schema);

            var code = Convert.ToString(inspector["code"]);

            if (!_selectedTemplate.Schema.Equals(schema) || !_selectedTemplate.Code.Equals(code)) {
                SelectedSchema = schema;

                var types = featureCatalogue.FeatureTypes.Select(e => e.Code);

                System.Windows.Application.Current.Dispatcher.Invoke(() => {
                    FeatureTypes.Clear();
                    FeatureTypes.AddRange(types.OrderBy(e => e).Select(e => new SelectedType(e)));
                });

                SelectedFeatureType = FeatureTypes.Single(e => e.Code == code);

                //    _selectedTemplate = new SelectedTemplate(schema, featureType.Code);
            }

            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace(schema, "FeatureTypes")}.{code}", true);

            return type;
        }

        private Type InformationTypeSelector(Inspector inspector, string schema) {
            var featureid = Convert.ToString(inspector["GlobalID"]).ToUpperInvariant();

            var featureCatalogue = _module.GetFeatureCatalogue(schema);

            var code = Convert.ToString(inspector["code"]);

            if (!_selectedTemplate.Schema.Equals(schema) || !_selectedTemplate.Code.Equals(code)) {
                SelectedSchema = schema;

                var types = featureCatalogue.InformationTypes.Select(e => e.Code);

                System.Windows.Application.Current.Dispatcher.Invoke(() => {
                    FeatureTypes.Clear();
                    FeatureTypes.AddRange(types.OrderBy(e => e).Select(e => new SelectedType(e)));
                });

                SelectedFeatureType = FeatureTypes.Single(e => e.Code == code);

                //    _selectedTemplate = new SelectedTemplate(schema, featureType.Code);
            }

            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace(schema, "InformationTypes")}.{code}", true);

            return type;
        }

        public ICommand CreateFeatureType { get; set; }

        public ObservableCollection<string> Schemas {
            get => _schemas;
            set => SetProperty(ref _schemas, value);
        }

        public string SelectedSchema {
            get => _selectedSchema;
            set => SetProperty(ref _selectedSchema, value);
        }

        public ObservableCollection<SelectedType> FeatureTypes {
            get => _featureTypes;
            set => SetProperty(ref _featureTypes, value);
        }

        public SelectedType SelectedFeatureType {
            get => _selectedFeatureType;
            set => SetProperty(ref _selectedFeatureType, value);
        }

        public object SelectedProperty {
            get => _selectedProperty;
            set => SetProperty(ref _selectedProperty, value);
        }

        public bool IsSelectedSchemaEnabled {
            get => _isSelectedSchemaEnabled;
            set => SetProperty(ref _isSelectedSchemaEnabled, value);
        }

        public bool IsSelectedFeatureTypeEnabled {
            get => _isSelectedFeatureTypeEnabled;
            set => SetProperty(ref _isSelectedFeatureTypeEnabled, value);
        }

        public bool IsCreateButtonEnabled => IsSelectedSchemaEnabled && IsSelectedFeatureTypeEnabled && _selectedTemplate != SelectedTemplate.Empty;


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
