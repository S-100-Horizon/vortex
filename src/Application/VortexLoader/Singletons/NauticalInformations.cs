using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Core.Internal.Geometry;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101.InformationAssociations;
using S100Framework.DomainModel.S101.InformationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace S100Framework.Applications.Singletons
{
    internal sealed class NauticalInformations
    {
        private static NauticalInformations? _instance;
        private static readonly object _lock = new object();
        private static Geodatabase? _destination;

        private readonly Dictionary<string, NauticalInformation> _nauticalInformations = new();
        private readonly Dictionary<string, informationBinding<AdditionalInformation>> _nauticalBindings = new();

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
        public informationBinding<AdditionalInformation> Add(string fileName, NauticalInformation nauticalInformation) {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            if (nauticalInformation == null)
                throw new ArgumentNullException(nameof(nauticalInformation));

            if (!_nauticalInformations.ContainsKey(fileName)) {
                _nauticalInformations.Add(fileName, nauticalInformation);

                // Create informationtype
                _nauticalBindings.Add(fileName, CreateInformationType(_destination!, nauticalInformation));
            }

            return _nauticalBindings[fileName];

        }

        private static informationBinding<AdditionalInformation> CreateInformationType(Geodatabase target, NauticalInformation nauticalInformation) {
            using var informationTypeTable = target.OpenDataset<Table>(target.GetName("informationtype"));            
            using var bufferInformationType = informationTypeTable.CreateRowBuffer();

            bufferInformationType["ps"] = ImporterNIS.ps101;
            bufferInformationType["code"] = nauticalInformation.Code;
            bufferInformationType["edition"] = ImporterNIS.s101version;
            bufferInformationType["json"] = System.Text.Json.JsonSerializer.Serialize(nauticalInformation, ImporterNIS.jsonSerializerOptions);

            var informationTypeRow = informationTypeTable.CreateRow(bufferInformationType);
            var informationName = informationTypeRow.Crc32();

            // create binding
            var informationBinding = new informationBinding<AdditionalInformation> {
                referenceId = informationName,
                //association = nameof(AdditionalInformation),
                informationType = nameof(NauticalInformation),
                role = Enum.GetName<Role>(Role.theInformation)!,
                roleType = roleType.association.ToString()
            };

            return /*informationAssociationName, spatialQuality101,*/ informationBinding;
        }


        /// <summary>
        /// Returns all polygons from the collection that touch the specified geometry.
        /// </summary>
        public bool Bind(string fileName, out NauticalInformation? nauticalInformation) {
            return _nauticalInformations.TryGetValue(fileName, out nauticalInformation);
        }

        internal void Flush(Geodatabase destination) {
            using (Table attachment = destination.OpenDataset<Table>(destination.GetName("attachment"))) {
                // Use InsertCursor to efficiently insert multiple features
                using (var rowBuffer = attachment.CreateRowBuffer())
                using (var insertCursor = attachment.CreateInsertCursor()) {
                    foreach (var nauticalInformation in NauticalInformations.Instance._nauticalInformations.Values) {
                        
                        foreach (var info in nauticalInformation.information) {
                            var supportFile = new S100Horizon.Settings.SupportFile();
                            supportFile.FileName = info.fileReference!;

                            var s57FileName = info.fileReference!.Clone().ToString()!.Replace("101DK00", "DK");

                            string? filePath = Directory.EnumerateFiles(ImporterNIS._notesPath, s57FileName, SearchOption.AllDirectories).FirstOrDefault();

                            if (filePath == default) {
                                Logger.Current.Error($"Cannot find NauticalInformation fileref: {s57FileName} in {ImporterNIS._notesPath}");
                                continue;
                            }

                            rowBuffer["ps"] = "S-100.Horizon";
                            rowBuffer["code"] = "supportfile";
                            rowBuffer["json"] = System.Text.Json.JsonSerializer.Serialize(supportFile, ImporterNIS.jsonSerializerOptions);
                            rowBuffer["data"] = new MemoryStream(File.ReadAllBytes(filePath));

                            insertCursor.Insert(rowBuffer);
                        }
                    }
                }
            };

        }


    }
}


