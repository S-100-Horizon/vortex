using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using S100Framework.DomainModel.S128.FeatureTypes;
using S100Framework.ProductCatalogue;
using S100Framework.YAML;
using System.Diagnostics;
using System.Text;
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

        ////[ProducesResponseType(typeof(ResponseTypes.ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("export/{name}", Name = "ExportProduct")]
        //[SwaggerOperation(Summary = "Creates an export of the specified electronic product, in YAML format", Description = "")]
        public async Task<IActionResult> Export(string name = "101DK0040349E") {
            var sw = Stopwatch.StartNew();
            var product = productManager.ElectronicProductManager.ElectronicProduct(name);

            if (product == null)
                return StatusCode(StatusCodes.Status404NotFound);

            var cacheKey = $"EXPORT::{name}::{product.updateNumber}::{product.editionNumber}";


            if (!_cache.TryGetValue(cacheKey, out string? yaml)) {
                S100Framework.YAML.Dataset dataset;

                if (product.editionNumber == 1 && product.updateNumber == 0)
                    dataset = await _electronicProductManager.CreateNewDatasetAsync(name);
                else
                    dataset = await _electronicProductManager.ReissueAsync(name);

                yaml = dataset.Serialize();

                _cache.Set(cacheKey, yaml, new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(24)));
            }

            if (string.IsNullOrEmpty(yaml))
                return StatusCode(StatusCodes.Status500InternalServerError);

            var bytes = Encoding.UTF8.GetBytes(yaml);
            return File(bytes, "application/x-yaml", $"{name}.yaml");
        }


        ////[ProducesResponseType(typeof(ResponseTypes.ApiResponse<string[]>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpPost("export", Name = "ExportFull", Order = 3)]
        //public async Task<IActionResult> CreateFullExport() {
        //    var sw = Stopwatch.StartNew();
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

        //            S100Framework.YAML.Dataset dataset;
        //            if (product.editionNumber == 1 && product.updateNumber == 0)
        //                dataset = await _electronicProductManager.CreateNewDatasetAsync(name);
        //            else
        //                dataset = await _electronicProductManager.ReissueAsync(name);

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

        [ProducesResponseType(typeof(ResponseTypes.ApiResponse<ElectronicProduct>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{name}", Name = "GetElectronicProduct")]
        public IActionResult GetElectronicProduct(string name = "101DK0040349E") {
            var sw = Stopwatch.StartNew();

            var product = _electronicProductManager.ElectronicProduct(name);

            return Ok(new ResponseTypes.ApiResponse<ElectronicProduct>() {
                Data = product,
                DurationMs = sw.ElapsedMilliseconds,
                TotalHits = 1
            });
        }


        [ProducesResponseType(typeof(ResponseTypes.ApiResponse<string[]>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(Name = "GetAllElectronicProducts")]
        public IActionResult GetAllElectronicProducts() {
            var sw = Stopwatch.StartNew();

            var productNames = _electronicProductManager.ToArray();

            return Ok(new ResponseTypes.ApiResponse<string[]>() {
                Data = productNames,
                DurationMs = sw.ElapsedMilliseconds,
                TotalHits = productNames.Length
            });
        }

        [ProducesResponseType(typeof(ResponseTypes.ApiResponse<string[]>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("import", Name = "ImportFull")]
        public async Task<IActionResult> ImportElectronicProducts() {
            var sw = Stopwatch.StartNew();
            var s57 = Environment.GetEnvironmentVariable("S100-Horizon-S57-Database");

            if (string.IsNullOrEmpty(s57))
                return StatusCode(StatusCodes.Status500InternalServerError, "No S57 Database found");

            var tasks = new List<Task>();
            await productManager.Dispatch(async () => {
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


            return Ok(new ResponseTypes.ApiResponse<string[]>() {
                Data = products,
                DurationMs = sw.ElapsedMilliseconds,
                TotalHits = products.Length,
            });
        }

        //[ProducesResponseType(typeof(ResponseTypes.ApiResponse<ElectronicProduct>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpPost(Name = "CreateElectronicProduct")]
        //public async Task<IActionResult> CreateElectronicProduct() {
        //    return StatusCode(StatusCodes.Status501NotImplemented);

        //    var sw = Stopwatch.StartNew();
        //    var name = "101DK0040350E";
        //    var specification = new productSpecification() {
        //        editionDate = default,
        //        editionDateField = default,
        //        iSSN = default,
        //        name = default!,
        //        version = default!,
        //    };
        //    var usage = specificUsage.NavigationalPurposeOverview;

        //    var polygon = ArcGIS.Core.Geometry.PolygonBuilderEx.CreatePolygon(new List<MapPoint>());

        //    await _electronicProductManager.CreateElectronicProductAsync(name, specification, usage, polygon);

        //    var product = _electronicProductManager.ElectronicProduct(name);

        //    sw.Stop();
        //    return Ok(new ResponseTypes.ApiResponse<ElectronicProduct>() {
        //        Data = product,
        //        DurationMs = sw.ElapsedMilliseconds,
        //        TotalHits = 1
        //    });
        //}


        //[ProducesResponseType(typeof(ResponseTypes.ApiResponse<string>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpPost("{name}/newedition", Name = "NewEdition")]
        //public async Task<IActionResult> CreateNewEdition(string name = "101DK0040349E") {
        //    var sw = Stopwatch.StartNew();

        //    var dataset = await _electronicProductManager.CreateNewEditionAsync(name);

        //    var yaml = dataset.Serialize();

        //    sw.Stop();
        //    return Ok(new ResponseTypes.ApiResponse<string>() {
        //        Data = yaml,
        //        DurationMs = sw.ElapsedMilliseconds,
        //        TotalHits = 1
        //    });
        //}

        //[ProducesResponseType(typeof(ResponseTypes.ApiResponse<string>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpPost("{name}/reissue", Name = "ReIssue")]
        //public async Task<IActionResult> ReIssue(string name = "101DK0040349E") {
        //    var sw = Stopwatch.StartNew();

        //    var dataset = await _electronicProductManager.ReissueAsync(name);

        //    var yaml = dataset.Serialize();

        //    sw.Stop();
        //    return Ok(new ResponseTypes.ApiResponse<string>() {
        //        Data = yaml,
        //        DurationMs = sw.ElapsedMilliseconds,
        //        TotalHits = 1
        //    });
        //}

        //[ProducesResponseType(typeof(ResponseTypes.ApiResponse<string>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpPost("{name}/newupdate", Name = "NewUpdate")]
        //public async Task<IActionResult> CreateNewUpdate(string name = "101DK0040349E") {
        //    var sw = Stopwatch.StartNew();
        //    var dataset = await _electronicProductManager.CreateNewUpdateAsync(name);

        //    var yaml = dataset.Serialize();

        //    sw.Stop();
        //    return Ok(new ResponseTypes.ApiResponse<string>() {
        //        Data = yaml,
        //        DurationMs = sw.ElapsedMilliseconds,
        //        TotalHits = 1
        //    });
        //}


        //[ProducesResponseType(typeof(ResponseTypes.ApiResponse<string>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpPost("{name}/newdataset", Name = "NewDataset")]
        //public async Task<IActionResult> CreateNewDataset(string name = "101DK0040349E") {
        //    var sw = Stopwatch.StartNew();
        //    var dataset = await productManager.ElectronicProductManager.CreateNewDatasetAsync(name);

        //    var yaml = dataset.Serialize();

        //    sw.Stop();
        //    return Ok(new ResponseTypes.ApiResponse<string>() {
        //        Data = yaml,
        //        DurationMs = sw.ElapsedMilliseconds,
        //        TotalHits = 1
        //    });
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
