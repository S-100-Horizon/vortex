using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.Applications
{
    internal class ConversionAnalytics
    {
        HashSet<Guid> _convertedS57Objects;
        IDictionary<string,HashSet<Guid>> _tableNameToConvertedS57Objects;

        private static ConversionAnalytics _instance;

        private ConversionAnalytics() {
            this._convertedS57Objects = new HashSet<Guid>();
            this._tableNameToConvertedS57Objects = new Dictionary<string,HashSet<Guid>>();
        }

        internal bool IsConverted(Guid globalid) {
            return _convertedS57Objects.Contains(globalid);
        }

        internal void AddConverted(string tableName, Guid guid) {
            if (_tableNameToConvertedS57Objects.ContainsKey(tableName)) {
                _tableNameToConvertedS57Objects[tableName].Add(guid);
            }
            else {
                _tableNameToConvertedS57Objects[tableName] = new HashSet<Guid> { guid };
            }
            _convertedS57Objects.Add(guid);
        }

        internal void AddConverted(string tableName, IList<Guid> guids) {
            if (_tableNameToConvertedS57Objects.ContainsKey(tableName)) {
                _tableNameToConvertedS57Objects[tableName].UnionWith(guids);
            }
            else {
                var hashSet = new HashSet<Guid>();
                hashSet.UnionWith(guids);
                _tableNameToConvertedS57Objects[tableName] = hashSet;

            }
            _convertedS57Objects.UnionWith(guids);
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


