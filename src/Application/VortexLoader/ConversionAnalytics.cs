using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.Applications
{
    internal class ConversionAnalytics
    {
        IDictionary<Guid,List<string>> _convertedS57Objects;
        IDictionary<string,IDictionary<Guid,List<string>>> _tableNameToConvertedS57Objects;

        private static ConversionAnalytics _instance;

        private ConversionAnalytics() {
            this._convertedS57Objects = new Dictionary<Guid,List<string>>();
            this._tableNameToConvertedS57Objects = new Dictionary<string,IDictionary<Guid,List<string>>>();
        }

        internal bool IsConverted(Guid globalid) {
            return _convertedS57Objects.ContainsKey(globalid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="guid">S-57 Globalid</param>
        /// <param name="name">S-101 name</param>
        /// <exception cref="ArgumentException"></exception>
        internal void AddConverted(string tableName, Guid guid, string name) {
            if (!_tableNameToConvertedS57Objects.ContainsKey(tableName)) {
                _tableNameToConvertedS57Objects.Add(tableName, new Dictionary<Guid, List<string>>());
            }


            //if (_tableNameToConvertedS57Objects[tableName].Keys.Contains(guid)) {
            //    throw new ArgumentException($"{guid} for {tableName} already converted.");
            //}

            if (_tableNameToConvertedS57Objects[tableName].ContainsKey(guid)) {
                _tableNameToConvertedS57Objects[tableName][guid].Add(name);
            }
            else {
                _tableNameToConvertedS57Objects[tableName].Add(guid, new List<string> { name }); 
            }

            if (!_convertedS57Objects.ContainsKey(guid)) {
                _convertedS57Objects[guid] = new List<string> { name };
            } else {
                _convertedS57Objects[guid].Add(name);
            }
        }

        internal void AddConverted(string tableName, IDictionary<Guid,List<string>> guidName) {
            if (_tableNameToConvertedS57Objects.ContainsKey(tableName)) {
                var commonGuids = _tableNameToConvertedS57Objects[tableName].Keys.Intersect(guidName.Keys).ToList();
                if (commonGuids.Count > 0) {
                    throw new ArgumentException($"Object already converted {string.Join(",", commonGuids)} in {tableName}.");
                }
                _tableNameToConvertedS57Objects[tableName].Union(guidName);
            }
            else {
                var guidNames = new Dictionary<Guid,List<string>>();
                guidNames.Union(guidName);
                _tableNameToConvertedS57Objects[tableName] = guidNames;

            }
            _convertedS57Objects.Union(guidName);
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


