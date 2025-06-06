using S100Framework.DomainModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.Applications.Singletons
{

    internal class ConversionAnalytics
    {
        IDictionary<Guid, List<string>> _convertedS57Objects;
        IDictionary<string, IDictionary<Guid, List<string>>> _tableNameToConvertedS57Objects;
        private readonly object _lock = new object();


        private static ConversionAnalytics? _instance;

        private ConversionAnalytics() {
            this._convertedS57Objects = new Dictionary<Guid, List<string>>();
            this._tableNameToConvertedS57Objects = new Dictionary<string, IDictionary<Guid, List<string>>>();
        }

        internal bool IsConverted(Guid globalid) {
            return _convertedS57Objects.ContainsKey(globalid);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param _s101name="tableName"></param>
        /// <param _s101name="guid">S-57 Globalid</param>
        /// <param _s101name="_s101name">S-101 _s101name</param>
        /// <exception cref="ArgumentException"></exception>
        internal void AddConverted(string tableName, Guid guid, string name) {
            lock (_lock) {
                if (!_tableNameToConvertedS57Objects.ContainsKey(tableName.ToLower())) {
                    _tableNameToConvertedS57Objects.Add(tableName.ToLower(), new Dictionary<Guid, List<string>>());
                }


                //if (_tableNameToConvertedS57Objects[tableName].Keys.Contains(guid)) {
                //    throw new ArgumentException($"{guid} for {tableName} already converted.");
                //}

                if (_tableNameToConvertedS57Objects[tableName.ToLower()].ContainsKey(guid)) {
                    _tableNameToConvertedS57Objects[tableName.ToLower()][guid].Add(name);
                }
                else {
                    _tableNameToConvertedS57Objects[tableName.ToLower()].Add(guid, new List<string> { name });
                }

                if (!_convertedS57Objects.ContainsKey(guid)) {
                    _convertedS57Objects[guid] = new List<string> { name };
                }
                else {
                    _convertedS57Objects[guid].Add(name);
                }
            }
        }

        internal void AddConverted(string tableName, IDictionary<Guid, List<string>> guidName) {
            lock (_lock) {
                if (_tableNameToConvertedS57Objects.ContainsKey(tableName.ToLower())) {
                    var commonGuids = _tableNameToConvertedS57Objects[tableName.ToLower()].Keys.Intersect(guidName.Keys).ToList();
                    if (commonGuids.Count > 0) {
                        throw new ArgumentException($"Object already converted {string.Join(",", commonGuids)} in {tableName.ToLower()}.");
                    }
                    _tableNameToConvertedS57Objects[tableName.ToLower()].Union(guidName);
                }
                else {
                    var guidNames = new Dictionary<Guid, List<string>>();
                    guidNames.Union(guidName);
                    _tableNameToConvertedS57Objects[tableName.ToLower()] = guidNames;

                }
                _convertedS57Objects.Union(guidName);
            }
        }

        internal List<(Guid GlobalId, string tableName)> GetTraceBack(string name) {

            var result = _tableNameToConvertedS57Objects
                .SelectMany(table => table.Value, (table, inner) => new { TableName = table.Key, Guid = inner.Key, Strings = inner.Value }) // Flatten the dictionary
                .Where(x => x.Strings.Contains(name)) // Filter for name in the list
                .Select(x => (x.Guid, x.TableName)) // Project to (string, Guid)
                .ToList(); // Convert to List

            return result;

        }


        internal int GetConvertedCount(string tableName) {
            if (!_tableNameToConvertedS57Objects.ContainsKey(tableName.ToLower())) {
                return 0;
            }

            return _tableNameToConvertedS57Objects[tableName.ToLower()].Count;
        }

        public static ConversionAnalytics Instance {
            get {
                    if (_instance == null) {
                        _instance = new ConversionAnalytics();
                    }
                return _instance;
            }
        }
    }
}


