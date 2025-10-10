using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using S100Framework.DomainModel.S128.FeatureTypes;
using S100Framework.ProductCatalogue;
using S100Framework.YAML;
using System.Diagnostics;
using System.Text;
using static ProductCatalogueService.RequestTypes;
using static ProductCatalogueService.ResponseTypes;
using IO = System.IO;

namespace ProductCatalogueService.Controllers
{

    //[Authorize]
    [AllowAnonymous] // during development
    [ApiController]
    [Route("[controller]")]
    public class ElectronicProductsController(ILogger<ElectronicProductsController> logger, IMemoryCache cache, IProductManager productManager) : ControllerBase
    {
        private readonly ILogger<ElectronicProductsController> _logger = logger;
        private readonly IElectronicProductManager _electronicProductManager = productManager.ElectronicProductManager;
        private readonly IMemoryCache _cache = cache;

        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost("{name}/newdataset", Name = "NewDataset")]
        //[SwaggerOperation(Summary = "Creates an export of the specified electronic product, in YAML format", Description = "")]
        public async Task<IActionResult> NewDataset(string name = "101DK0040349E") {
            var sw = Stopwatch.StartNew();
            var response = new ApiResponse();
            var product = productManager.ElectronicProductManager.ElectronicProduct(name);

            if (product == null) {
                response.Success = false;
                response.Message = $"No electronic product with name '{name}' was found.";
                response.DurationMs = sw.ElapsedMilliseconds;
                return NotFound(response);
            }

            var cacheKey = $"{nameof(NewDataset)}::{name}::{product.editionNumber}::{product.updateNumber}";


            if (!_cache.TryGetValue(cacheKey, out string? yaml)) {
                var dataset = await _electronicProductManager.CreateNewDatasetAsync(name);

                yaml = dataset.Serialize();

                _cache.Set(cacheKey, yaml, new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(24)));
            }

            if (string.IsNullOrEmpty(yaml)) {
                response.Success = false;
                response.Message = $"An error occured attempting to read dataset '{name}'.";
                response.DurationMs = sw.ElapsedMilliseconds;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }


            var bytes = Encoding.UTF8.GetBytes(yaml);
            return File(bytes, "application/x-yaml", $"{name}.yaml");
        }

        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost("{name}/newedition", Name = "NewEdition")]
        public async Task<IActionResult> NewEdition(string name = "101DK0040349E") {
            var sw = Stopwatch.StartNew();
            var response = new ApiResponse();

            var product = productManager.ElectronicProductManager.ElectronicProduct(name);

            if (product == null) {
                response.Success = false;
                response.Message = $"No electronic product with name '{name}' was found.";
                response.DurationMs = sw.ElapsedMilliseconds;
                return NotFound(response);
            }

            var cacheKey = $"{nameof(NewEdition)}::{name}::{product.editionNumber}::{product.updateNumber}";

            if (!_cache.TryGetValue(cacheKey, out string? yaml)) {
                var dataset = await _electronicProductManager.CreateNewEditionAsync(name);

                yaml = dataset.Serialize();

                _cache.Set(cacheKey, yaml, new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(24)));
            }

            if (string.IsNullOrEmpty(yaml)) {
                response.Success = false;
                response.Message = $"An error occured attempting to read dataset '{name}'.";
                response.DurationMs = sw.ElapsedMilliseconds;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            var bytes = Encoding.UTF8.GetBytes(yaml);
            return File(bytes, "application/x-yaml", $"{name}.yaml");
        }

        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost("{name}/newupdate", Name = "NewUpdate")]
        public async Task<IActionResult> NewUpdate(string name = "101DK0040349E") {
            return StatusCode(StatusCodes.Status501NotImplemented, new ApiResponse() { Success = false, Message = "Not yet implemented" });

            var sw = Stopwatch.StartNew();
            var response = new ApiResponse();
            var product = productManager.ElectronicProductManager.ElectronicProduct(name);

            if (product == null) {
                response.Success = false;
                response.Message = $"No electronic product with name '{name}' was found.";
                response.DurationMs = sw.ElapsedMilliseconds;
                return NotFound(response);
            }

            var dataset = await _electronicProductManager.CreateNewUpdateAsync(name);

            var yaml = dataset.Serialize();


            if (string.IsNullOrEmpty(yaml)) {
                response.Success = false;
                response.Message = $"An error occured attempting to read dataset '{name}'.";
                response.DurationMs = sw.ElapsedMilliseconds;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            var bytes = Encoding.UTF8.GetBytes(yaml);
            return File(bytes, "application/x-yaml", $"{name}.yaml");
        }


        [ProducesResponseType(typeof(ApiResponse<ElectronicProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet("{name}", Name = "GetElectronicProduct")]
        public IActionResult GetElectronicProduct(string name = "101DK0040349E") {
            var sw = Stopwatch.StartNew();
            var response = new ApiResponse<ElectronicProductResponse>();
            var product = _electronicProductManager.ElectronicProduct(name);

            if (product == null) {
                response.Success = false;
                response.Message = $"No electronic product with name '{name}' was found.";
                response.DurationMs = sw.ElapsedMilliseconds;
                return NotFound(response);
            }

            var responseObj = new ElectronicProductResponse() {
                CompressionFlag = product.compressionFlag,
                DatasetName = product.datasetName,
                IssueDate = product.issueDate,
                IssueTime = product.issueTime,
                ProductSpecification = product.productSpecification,
                TypeOfProductFormat = product.typeOfProductFormat
            };

            response.Data = responseObj;
            response.TotalHits = 1;
            response.DurationMs = sw.ElapsedMilliseconds;

            return Ok(response);
        }

        [ProducesResponseType(typeof(ApiResponse<string[]>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet(Name = "GetAllElectronicProducts")]
        public IActionResult GetAllElectronicProducts() {
            var sw = Stopwatch.StartNew();
            var response = new ApiResponse<string[]>();

            var productNames = _electronicProductManager.ToArray();

            response.Data = productNames;
            response.TotalHits = productNames.Length;
            response.DurationMs = sw.ElapsedMilliseconds;

            return Ok(response);
        }

        [ProducesResponseType(typeof(ApiResponse<string[]>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost("import", Name = "ImportFull")]
        public async Task<IActionResult> ImportElectronicProducts() {
            var response = new ApiResponse<string[]>();
            var sw = Stopwatch.StartNew();
            var s57 = Environment.GetEnvironmentVariable("S100-Horizon-S57-Database");

            if (string.IsNullOrEmpty(s57)) {
                response.Success = false;
                response.Message = $"No S-57 database was configured";
                response.DurationMs = sw.ElapsedMilliseconds;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            var tasks = new List<Task>();
            await productManager.Dispatch(() => {
                var connectionFile = new Uri(IO.Path.GetFullPath(s57));

                Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };

                if (IO.File.Exists(s57) && ".sde".Equals(IO.Path.GetExtension(s57), StringComparison.InvariantCultureIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new DatabaseConnectionFile(connectionFile)); };
                }
                else if (IO.Directory.Exists(s57) && ".gdb".Equals(IO.Path.GetExtension(s57), StringComparison.InvariantCultureIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new FileGeodatabaseConnectionPath(connectionFile)); };
                }

                var productSpecification = new S100Framework.DomainModel.S128.ComplexAttributes.productSpecification {
                    editionDate = S100Framework.DomainModel.S101.Summary.VersionDate,
                    name = S100Framework.DomainModel.S101.Summary.ProductId,
                    version = S100Framework.DomainModel.S101.Summary.Version.ToString(),
                };



                using var geodatabase = createGeodatabase();

                var definitionTables = geodatabase.GetDefinitions<TableDefinition>();
                var definitionFeatureClasses = geodatabase.GetDefinitions<FeatureClassDefinition>();

                using var tableProductCoverage = geodatabase.OpenDataset<FeatureClass>(definitionFeatureClasses.Single(e => e.GetName().EndsWith("ProductCoverage")).GetName());

                using var tableProductDefinitions = geodatabase.OpenDataset<Table>(definitionTables.Single(e => e.GetName().EndsWith("ProductDefinitions")).GetName());
                using var cursor = tableProductDefinitions.Search(new QueryFilter {
                    //WhereClause = "upper(ExportType) <> 'CANCEL'",
                    WhereClause = "1 = 1",
                }, true);

                while (cursor.MoveNext()) {
                    var c = cursor.Current;

                    var series = Convert.ToString(c["series"])!.ToString();

                    var name = "101DK00" + Convert.ToString(c["DSNM"])!.Substring(2);
                    var specificUsage = name[7] switch {
                        '5' => S100Framework.DomainModel.S128.specificUsage.NavigationalPurposeHarbour,
                        '4' => S100Framework.DomainModel.S128.specificUsage.NavigationalPurposeApproach,
                        '3' => S100Framework.DomainModel.S128.specificUsage.NavigationalPurposeCoastal,
                        '2' => S100Framework.DomainModel.S128.specificUsage.NavigationalPurposeGeneral,
                        '1' => S100Framework.DomainModel.S128.specificUsage.NavigationalPurposeOverview,
                        _ => throw new InvalidDataException(),
                    };

                    using var coverage = tableProductCoverage.Search(new QueryFilter {
                        WhereClause = $"DSNM = '{Convert.ToString(c["DSNM"])}'",
                    }, true);

                    var polygons = new List<ArcGIS.Core.Geometry.Polygon>();
                    while (coverage.MoveNext()) {
                        var current = (ArcGIS.Core.Data.Feature)coverage.Current;
                        var polygon = (ArcGIS.Core.Geometry.Polygon)current.GetShape();

                        polygons.Add(polygon);
                        continue;
                    }
                    Debug.Assert(polygons.Any());

                    var cover = (ArcGIS.Core.Geometry.Polygon)GeometryEngine.Instance.Union(polygons);

                    // todo: kald med s57
                    tasks.Add(productManager.ElectronicProductManager.CreateElectronicProductAsync(name, productSpecification, specificUsage, cover));
                }
            });

            await Task.WhenAll([.. tasks]);

            var products = _electronicProductManager.ToArray();

            response.Data = products;
            response.DurationMs = sw.ElapsedMilliseconds;
            response.TotalHits = products.Length;

            return Ok(response);
        }


        //[ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        //[HttpPost("export", Name = "ExportFull")]
        //public async Task<IActionResult> CreateFullExport() {
        //    return StatusCode(StatusCodes.Status501NotImplemented, "Not yet implemented");
        //    var sw = Stopwatch.StartNew();
        //    var response = new ApiResponse();
        //    var productNames = _electronicProductManager.ToArray();

        //    var cacheKey = $"FULLEXPORT::{productNames.Length}";

        //    var yamls = new Dictionary<string, string>();

        //    if (!_cache.TryGetValue(cacheKey, out yamls)) {
        //        yamls = new Dictionary<string, string>();
        //        int count = 0;
        //        foreach (var name in productNames) {
        //            count++;
        //            if (count > 2)
        //                continue;
        //            var product = productManager.ElectronicProductManager.ElectronicProduct(name);

        //            var dataset = await _electronicProductManager.CreateNewDatasetAsync(name);
        //            //if (product.editionNumber == 1 && product.updateNumber == 0)

        //            var yaml = dataset.Serialize();
        //            yamls!.Add(name, yaml);
        //        }

        //        _cache.Set(cacheKey, yamls, new MemoryCacheEntryOptions()
        //         .SetAbsoluteExpiration(TimeSpan.FromHours(24)));
        //    }

        //    using var ms = new MemoryStream();
        //    using var zipStream = new ZipOutputStream(ms);
        //    zipStream.SetLevel(9);

        //    foreach (var kvp in yamls) {
        //        var bytes = Encoding.UTF8.GetBytes(kvp.Value);
        //        var entry = new ZipEntry($"{kvp.Key}.yaml") {
        //            DateTime = DateTime.Now,
        //            Size = bytes.Length
        //        };

        //        zipStream.PutNextEntry(entry);
        //        zipStream.Write(bytes, 0, bytes.Length);
        //        zipStream.CloseEntry();
        //    }

        //    zipStream.Finish();
        //    zipStream.IsStreamOwner = false;
        //    zipStream.Close();


        //    ms.Position = 0;
        //    return File(ms.ToArray(), "application/zip", "datasets.zip");
        //}
        //[ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpPost("{name}/reissue", Name = "Reissue")]
        //public async Task<IActionResult> Reissue(string name = "101DK0040349E") {
        //    var sw = Stopwatch.StartNew();
        //    var product = productManager.ElectronicProductManager.ElectronicProduct(name);

        //    if (product == null)
        //        return StatusCode(StatusCodes.Status404NotFound);

        //    var cacheKey = $"{nameof(Reissue)}::{name}::{product.editionNumber}::{product.updateNumber}";

        //    if (!_cache.TryGetValue(cacheKey, out string? yaml)) {
        //        var dataset = await _electronicProductManager.CreateNewEditionAsync(name);

        //        yaml = dataset.Serialize();

        //        _cache.Set(cacheKey, yaml, new MemoryCacheEntryOptions()
        //            .SetAbsoluteExpiration(TimeSpan.FromHours(24)));
        //    }

        //    if (string.IsNullOrEmpty(yaml))
        //        return StatusCode(StatusCodes.Status500InternalServerError);

        //    var bytes = Encoding.UTF8.GetBytes(yaml);
        //    return File(bytes, "application/x-yaml", $"{name}.yaml");
        //}
    }
}




//Task CreateElectronicProductAsync(string name, DomainModel.S128.ComplexAttributes.productSpecification productSpecification, S100Framework.DomainModel.S128.specificUsage specificUsage, ArcGIS.Core.Geometry.Polygon boundary);

//Task CreateElectronicProductAsync(string name, DomainModel.S128.ComplexAttributes.productSpecification productSpecification, S100Framework.DomainModel.S128.specificUsage specificUsage, ArcGIS.Core.Geometry.Polygon boundary, int edition, int update, byte[] zipfile);

//Task<YAML.Dataset> CreateNewDatasetAsync(string name);

//Task<YAML.Dataset> CreateNewEditionAsync(string name);

//Task<YAML.Dataset> CreateNewUpdateAsync(string name);

//Task<YAML.Dataset> ReissueAsync(string name);

//Task<bool> QueryUpdatesAsync(string name, Action<object> action);

//Task<bool> IsDirtyAsync(string name);

//ElectronicProduct ElectronicProduct(string name);
