using ArcGIS.Core.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using S100Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using IO = System.IO;

namespace TestS100Framework
{
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    namespace Patcher {
        public class UnitTestPatcher {
            private readonly ITestOutputHelper _output;

            public UnitTestPatcher(ITestOutputHelper output) {
                this._output = output;

                ArcGIS.Core.Hosting.Host.Initialize();
            }

            record associationbinding(string roleType, string association, string role, string associationID, string foreignID, string primaryID);

            [Fact]
            public void Patch_Associations() {
                var path = Environment.GetEnvironmentVariable("s100ed7.gdb")!;

                using var geodatabase = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(path))));

                var informationAssociationbindings = new List<associationbinding>();
                var featureAssociationbindings = new List<associationbinding>();

                {
                    using var associationbinding = geodatabase.OpenDataset<Table>("associationbinding");

                    using var cursor = associationbinding.Search(new QueryFilter {
                        WhereClause = "upper(ps) = 'S-101'",
                    }, true);

                    while (cursor.MoveNext()) {
                        var row = cursor.Current;

                        var type = Convert.ToString(row["type"])!;

                        if (type.Equals("FeatureBinding", StringComparison.InvariantCultureIgnoreCase)) {
                            featureAssociationbindings.Add(new UnitTestPatcher.associationbinding(
                                    Convert.ToString(row["roleType"])!,
                                    Convert.ToString(row["association"])!,
                                    Convert.ToString(row["role"])!,
                                    Convert.ToString(row["associationID"])!,
                                    Convert.ToString(row["foreignID"])!,
                                    Convert.ToString(row["primaryID"])!
                                ));
                        }
                        else if (type.Equals("InformationBinding", StringComparison.InvariantCultureIgnoreCase)) {
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

                string[] featureclasses = ["point", "pointset", "curve", "surface"];

                var groupFeatureAssociation = featureAssociationbindings.GroupBy(e => e.primaryID);

                foreach (var featureclass in featureclasses) {
                    using var fc = geodatabase.OpenDataset<FeatureClass>(featureclass);

                    using var cursor = fc.CreateUpdateCursor(null, true);
                    while (cursor.MoveNext()) {
                        var f = (Feature)cursor.Current;

                        var name = Convert.ToString(f["name"])!;

                        if (!groupFeatureAssociation.Any(e => e.Key.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
                            continue;

                        var bindings = groupFeatureAssociation.Where(e => e.Key.Equals(name, StringComparison.InvariantCultureIgnoreCase)).SelectMany(e => e.Select(a => new featureBinding {
                            association = a.association,
                            associationId = a.associationID,
                            featureId = a.foreignID,
                            role = a.role,
                            roleType = a.roleType,
                        })).ToList();

                        var json = System.Text.Json.JsonSerializer.Serialize(bindings);

                        f["featurebindings"] = json;
                        f.Store();
                    }
                }

                var groupInformationAssociation = informationAssociationbindings.GroupBy(e => e.primaryID);

                string[] datasets = [.. featureclasses, "informationtype"];

                foreach (var dataset in datasets) {
                    using var table = geodatabase.OpenDataset<Table>(dataset);

                    using var cursor = table.CreateUpdateCursor(null, true);
                    while (cursor.MoveNext()) {
                        var row = (Row)cursor.Current;

                        var name = Convert.ToString(row["name"])!;

                        if (!groupInformationAssociation.Any(e => e.Key.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
                            continue;

                        var bindings = groupInformationAssociation.Where(e => e.Key.Equals(name, StringComparison.InvariantCultureIgnoreCase)).SelectMany(e => e.Select(a => new informationBinding {
                            association = a.association,
                            associationId = a.associationID,
                            informationId = a.foreignID,
                            role = a.role,
                            roleType = a.roleType,
                        })).ToList();

                        var json = System.Text.Json.JsonSerializer.Serialize(bindings);

                        row["informationbindings"] = json;
                        row.Store();
                    }
                }
            }
        }
    }
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
}
