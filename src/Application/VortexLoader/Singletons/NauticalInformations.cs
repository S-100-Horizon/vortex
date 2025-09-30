using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101.InformationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.Applications.Singletons
{
    internal sealed class NauticalInformations
    {
        private static NauticalInformations? _instance;
        private static readonly object _lock = new object();
        private static Geodatabase? _destination;

        private readonly Dictionary<string,NauticalInformation> _nauticalInformations = new ();

        /// <summary>
        /// Initializes
        /// </summary>
        /// <param name="destination">The S100 destination geodatabase</param>
        /// <exception cref="InvalidOperationException"></exception>
        internal static void Initialize(Geodatabase destination) {
            if (_instance != null) {
                throw new InvalidOperationException("Subtypes has already been initialized.");
            }

            lock (_lock) {
                if (_instance == null) {
                    _destination = destination;
                    _instance = new NauticalInformations();
                }
            }
        }

        private NauticalInformations() {

        }

        public static NauticalInformations Instance {
            get {
                if (_instance == null)
                    throw new Exception("NauticalInformations is not initialized.");

                return _instance!;
            }
        }


        /// <summary>
        /// Adds a polygon geometry to the collection.
        /// </summary>
        public void Add(string fileName, NauticalInformation nauticalInformation) {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            if (nauticalInformation == null)
                throw new ArgumentNullException(nameof(nauticalInformation));

            if (!_nauticalInformations.ContainsKey(fileName)) {
                _nauticalInformations.Add(fileName, nauticalInformation);

                

            }
        }

        /// <summary>
        /// Returns all polygons from the collection that touch the specified geometry.
        /// </summary>
        public bool Bind(string fileName, out NauticalInformation? nauticalInformation) {
            return _nauticalInformations.TryGetValue(fileName, out nauticalInformation);
        }

    }
}


