using ArcGIS.Core.Data;
using S100Framework.DomainModel;
using Xunit.Abstractions;
using IO = System.IO;

namespace TestS100Framework
{
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    namespace Patcher
    {
        public class UnitTestPatcher
        {
            private readonly ITestOutputHelper _output;

            public UnitTestPatcher(ITestOutputHelper output) {
                this._output = output;

                ArcGIS.Core.Hosting.Host.Initialize();
            }

            record associationbinding(string roleType, string association, string role, string associationID, string foreignID, string primaryID);

            /// <summary>
            /// Updates feature and information bindings in a geodatabase based on association data.
            /// </summary>
            /// <remarks>This method retrieves association binding data from a geodatabase, processes
            /// it to group associations by their primary IDs, and updates feature classes and tables with serialized
            /// binding information. The method operates on datasets such as "point", "pointset", "curve", "surface",
            /// and "informationtype".</remarks>
            [Fact]
            public void Patch_Associations() {
                var path = Environment.GetEnvironmentVariable("s100ed7.gdb") ?? throw new System.ArgumentNullException();

                using var geodatabase = IO.Path.GetExtension(path) switch {
                    ".sde" or ".SDE" => new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(path)))),
                    ".gdb" or ".GDB" => new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(path)))),
                    _ => throw new System.ArgumentNullException(),
                };

                var informationAssociationbindings = new List<associationbinding>();
                var featureAssociationbindings = new List<associationbinding>();

                var prefix = IO.Path.GetExtension(path).Equals(".sde") ? "s101." : "";

                geodatabase.ApplyEdits(() => {
                    {
                        using var associationbinding = geodatabase.OpenDataset<Table>(prefix + "associationbinding");

                        using var cursor = associationbinding.Search(new QueryFilter {
                            WhereClause = "upper(ps) = 'S-101'",
                        }, true);

                        while (cursor.MoveNext()) {
                            var row = cursor.Current;

                            var type = Convert.ToString(row["type"])!;

                            if (type.Equals("FeatureBinding", StringComparison.OrdinalIgnoreCase)) {
                                featureAssociationbindings.Add(new UnitTestPatcher.associationbinding(
                                        Convert.ToString(row["roleType"])!,
                                        Convert.ToString(row["association"])!,
                                        Convert.ToString(row["role"])!,
                                        Convert.ToString(row["associationID"])!,
                                        Convert.ToString(row["foreignID"])!,
                                        Convert.ToString(row["primaryID"])!
                                    ));
                            }
                            else if (type.Equals("InformationBinding", StringComparison.OrdinalIgnoreCase)) {
                                informationAssociationbindings.Add(new UnitTestPatcher.associationbinding(
                                        Convert.ToString(row["roleType"])!,
                                        Convert.ToString(row["association"])!,
                                        Convert.ToString(row["role"])!,
                                        Convert.ToString(row["associationID"])!,
                                        Convert.ToString(row["foreignID"])!,
                                        Convert.ToString(row["primaryID"])!
                                    ));
                            }
                        }
                    }

                    string[] featureclasses = [prefix + "point", prefix + "pointset", prefix + "curve", prefix + "surface"];

                    var groupFeatureAssociation = featureAssociationbindings.GroupBy(e => e.primaryID);

                    foreach (var featureclass in featureclasses) {
                        using var fc = geodatabase.OpenDataset<FeatureClass>(featureclass);

                        using var cursor = fc.CreateUpdateCursor(null, true);
                        while (cursor.MoveNext()) {
                            var f = (Feature)cursor.Current;

                            var name = $"{f.GetGlobalID():N}";

                            if (!groupFeatureAssociation.Any(e => e.Key.Equals(name, StringComparison.OrdinalIgnoreCase)))
                                continue;

                            var bindings = groupFeatureAssociation.Where(e => e.Key.Equals(name, StringComparison.OrdinalIgnoreCase)).SelectMany(e => e.Select(a => new featureBinding {
                                association = a.association,
                                associationId = a.associationID,
                                featureId = a.foreignID,
                                role = a.role,
                                roleType = a.roleType,
                            })).ToList();

                            var json = System.Text.Json.JsonSerializer.Serialize(bindings);

                            f["featurebindings"] = json;
                            cursor.Update(f);
                        }
                    }

                    var groupInformationAssociation = informationAssociationbindings.GroupBy(e => e.primaryID);

                    string[] datasets = [.. featureclasses, prefix + "informationtype"];

                    foreach (var dataset in datasets) {
                        using var table = geodatabase.OpenDataset<Table>(dataset);

                        using var cursor = table.CreateUpdateCursor(null, true);
                        while (cursor.MoveNext()) {
                            var row = (Row)cursor.Current;

                            var name = $"{row.GetGlobalID():N}";

                            if (!groupInformationAssociation.Any(e => e.Key.Equals(name, StringComparison.OrdinalIgnoreCase)))
                                continue;

                            var bindings = groupInformationAssociation.Where(e => e.Key.Equals(name, StringComparison.OrdinalIgnoreCase)).SelectMany(e => e.Select(a => new informationBinding {
                                association = a.association,
                                associationId = a.associationID,
                                informationId = a.foreignID,
                                role = a.role,
                                roleType = a.roleType,
                            })).ToList();

                            var json = System.Text.Json.JsonSerializer.Serialize(bindings);

                            row["informationbindings"] = json;
                            cursor.Update(row);
                        }
                    }
                });
            }
        }
    }
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
}
