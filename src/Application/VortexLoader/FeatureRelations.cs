using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace S100Framework.Applications
{

    internal class Slave {
        PLTS_Frel _plts_Frel;
        S57Object _s57Object;

        public Slave(PLTS_Frel plts_Frel) {
            this._plts_Frel = plts_Frel;
        }

        internal S57Object Fetch(Geodatabase geodatabase) {

            S57Object result = null;
            
            var sourceFeatureClass = this._plts_Frel.SRC_FC;

            var queryDef = new QueryDef();
            queryDef.Tables = $"{geodatabase.GetName(sourceFeatureClass)}";

            queryDef.WhereClause = $"globalid = '{this._plts_Frel.DEST_UID}'";

            var cursor = geodatabase.Evaluate(queryDef, true);
            
            while (cursor.MoveNext()) {
                if (sourceFeatureClass.ToLower().Equals("aidstonavigationp")) {
                    result = new AidsToNavigationP((Feature)cursor.Current);
                }
                else {
                    throw new NotSupportedException($"GetRelated: {sourceFeatureClass}");
                }
            };

            return result;
        }


    }


    internal class FeatureRelations
    {
        private Dictionary<Guid, IList<PLTS_Frel>> _srcObjectToFrel = new Dictionary<Guid, IList<PLTS_Frel>>();

        private bool _isInitialized = false;

        // TODO: Create easy access to S57 objects

        public void Initialize(Geodatabase source) {
            LoadPltsFrels(source);
            _isInitialized = true;
        }

        internal IList<PLTS_Frel> GetRelated(Guid uid) {
            if (!_isInitialized)
                throw new ArgumentException("Not initalized. Call intialize.");
            if (!_srcObjectToFrel.ContainsKey(uid))
                return null;

            return _srcObjectToFrel[uid];
        }

        internal bool IsSlave(Guid globalid) {
            if (!_isInitialized)
                throw new ArgumentException("Not initalized. Call intialize.");

            var result = _srcObjectToFrel.Values.SelectMany(list => list)
                                      .FirstOrDefault(obj => obj.GLOBALID == globalid);


            return result != null;
        }

        private void LoadPltsFrels(Geodatabase source) {
            var aidstonavigation = source.OpenDataset<Table>(source.GetName("PLTS_Frel"));
            var frelSourceFeatureClasses = new Dictionary<string, IList<PLTS_Frel>>();

            var cursor = aidstonavigation.Search(null, true);
            Guid uid;

            while (cursor.MoveNext()) {
                var plts_frel = new PLTS_Frel(cursor.Current);
                Guid.TryParse(Convert.ToString(plts_frel.SRC_UID), out uid);
                if (!_srcObjectToFrel.ContainsKey(uid)) {
                    _srcObjectToFrel[uid] = new List<PLTS_Frel>() { plts_frel };

                }
                else {
                    _srcObjectToFrel[uid].Add(plts_frel);

                }
            }

            foreach (var item in _srcObjectToFrel) {
                foreach (var frel in item.Value) {
                    var key = frel.SRC_FC.ToLower();
                    if (frelSourceFeatureClasses.ContainsKey(key)) {
                        frelSourceFeatureClasses[key].Add(frel);
                    }
                    else {
                        frelSourceFeatureClasses[key] = new List<PLTS_Frel>() { frel };
                    }

                }
            }

            // Create repo of all slave objects to be handled



        }
    }
}
