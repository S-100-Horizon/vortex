using ArcGIS.Core.Data;
using S100FC;
using S100FC.S101.InformationAssociation;
using S100FC.S101.InformationTypes;

namespace S100Framework.Applications.Singletons
{
    internal sealed class NauticalInformations
    {
        private static NauticalInformations? _instance;
        private static readonly object _lock = new object();
        private static Geodatabase? _destination;

        private readonly Dictionary<string, NauticalInformation> _nauticalInformations = [];
        private readonly Dictionary<string, informationBinding<AdditionalInformation>> _nauticalBindings = [];

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

            if (!this._nauticalInformations.ContainsKey(fileName)) {
                this._nauticalInformations.Add(fileName, nauticalInformation);

                // Create informationtype
                this._nauticalBindings.Add(fileName, CreateInformationType(_destination!, nauticalInformation));
            }

            return this._nauticalBindings[fileName];

        }

        private static informationBinding<AdditionalInformation> CreateInformationType(Geodatabase target, NauticalInformation nauticalInformation) {
            using var informationTypeTable = target.OpenDataset<Table>(target.GetName("informationtype"));
            using var bufferInformationType = informationTypeTable.CreateRowBuffer();

            bufferInformationType["ps"] = ImporterNIS.ps101;
            bufferInformationType["code"] = nauticalInformation.S100FC_code;
            bufferInformationType["flatten"] = nauticalInformation.Flatten();

            var informationTypeRow = informationTypeTable.CreateRow(bufferInformationType);
            var informationName = informationTypeRow.UID();

            // create binding
            var informationBinding = new informationBinding<AdditionalInformation> {
                informationId = informationName,
                //association = nameof(AdditionalInformation),
                informationType = nameof(NauticalInformation),
                role = "theInformation",
                roleType = "association",
            };

            return /*informationAssociationName, spatialQuality101,*/ informationBinding;
        }


        /// <summary>
        /// Returns all polygons from the collection that touch the specified geometry.
        /// </summary>
        public bool Bind(string fileName, out NauticalInformation? nauticalInformation) {
            return this._nauticalInformations.TryGetValue(fileName, out nauticalInformation);
        }


        internal void Flush(Geodatabase destination) {
            var fileCount = 0;
            Logger.Current.Information($"Flushing Nautical Information support files");
            using (Table attachment = destination.OpenDataset<Table>(destination.GetName("attachment"))) {
                // Use InsertCursor to efficiently insert multiple features
                using (var rowBuffer = attachment.CreateRowBuffer())
                using (var insertCursor = attachment.CreateInsertCursor()) {
                    foreach (var nauticalInformation in NauticalInformations.Instance._nauticalInformations.Values) {

                        foreach (var info in nauticalInformation.information) {
                            var supportFile = new S100Horizon.Settings.SupportFile {
                                FileName = info!.fileReference!
                            };

                            var s57FileName = info.fileReference!.Clone().ToString()!.Replace("101DK00", "DK");

                            string? filePath = default;

                            if (!string.IsNullOrEmpty(ImporterNIS._notesPath)) {
                                filePath = Directory.EnumerateFiles(ImporterNIS._notesPath, s57FileName, SearchOption.AllDirectories).FirstOrDefault();
                            }

                            if (filePath == default) {
                                Logger.Current.Error($"Cannot find NauticalInformation fileref: {s57FileName} in {ImporterNIS._notesPath}");
                                continue;
                            }

                            // Log if file is found in a subfolder in the notes folder
                            string fileDirectory = Path.GetDirectoryName(Path.GetFullPath(filePath))!;
                            string targetFolder = Path.GetFullPath(ImporterNIS._notesPath).TrimEnd(Path.DirectorySeparatorChar);
                            bool isFileInProductionFolderRoot = string.Equals(fileDirectory, targetFolder, StringComparison.OrdinalIgnoreCase);
                            if (!isFileInProductionFolderRoot) {
                                Logger.Current.DataError(-1, "", "", $"NauticalInformation fileref: {s57FileName} found in subfolder in notes folder: {fileDirectory}");
                            }

                            supportFile.date = DateOnly.FromDateTime(File.GetLastWriteTimeUtc(filePath));

                            supportFile.s100_SupportFileFormat = Path.GetExtension(filePath).ToLower() switch {
                                ".txt" => S100FC.S100.S100_SupportFileFormat.TXT,
                                ".mp4" => S100FC.S100.S100_SupportFileFormat.VIDEO,
                                ".mov" => S100FC.S100.S100_SupportFileFormat.VIDEO,
                                ".avi" => S100FC.S100.S100_SupportFileFormat.VIDEO,
                                ".flv" => S100FC.S100.S100_SupportFileFormat.VIDEO,
                                ".webm" => S100FC.S100.S100_SupportFileFormat.VIDEO,
                                ".mkv" => S100FC.S100.S100_SupportFileFormat.VIDEO,
                                ".mpeg" => S100FC.S100.S100_SupportFileFormat.VIDEO,
                                ".mpg" => S100FC.S100.S100_SupportFileFormat.VIDEO,
                                ".xml" => S100FC.S100.S100_SupportFileFormat.XML,
                                ".xslt" => S100FC.S100.S100_SupportFileFormat.XSLT,
                                _ => throw new NotSupportedException($"Illegal file extension for support files: {Path.GetExtension(filePath).ToLower()}")
                            };

                            rowBuffer["ps"] = "S-100.Horizon";
                            rowBuffer["code"] = "supportfile";
                            rowBuffer["json"] = System.Text.Json.JsonSerializer.Serialize(supportFile, ImporterNIS.jsonSerializerOptions);
                            rowBuffer["data_size"] = new FileInfo(filePath).Length;
                            rowBuffer["data"] = new MemoryStream(File.ReadAllBytes(filePath));
                            insertCursor.Insert(rowBuffer);
                            fileCount++;



                        }
                    }
                }
            }
            ;
            Logger.Current.Information($"Flushed {fileCount} nautical information support file references");
        }


    }
}


