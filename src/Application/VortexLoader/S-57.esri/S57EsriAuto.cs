using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using System.ComponentModel;
namespace VortexLoader.S57Auto.esri
{
	internal class PLTS_SpatialAttributeL {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Quality of position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal datum")]
		internal int? P_HORDAT = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public PLTS_SpatialAttributeL (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class TidesAndVariationsA {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Reference year for magnetic variation")]
		internal string? RYRMGV = default;
		[Description("Value of local magnetic anomaly")]
		internal decimal? VALLMA = default;
		[Description("Value of annual change in magnetic variation")]
		internal decimal? VALACM = default;
		[Description("Value of magnetic variation")]
		internal decimal? VALMAG = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of Tidal stream")]
		internal int? CAT_TS = default;
		[Description("Current velocity")]
		internal decimal? CURVEL = default;
		[Description("Orientation")]
		internal decimal? ORIENT = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Time end")]
		internal string? TIMEND = default;
		[Description("Time start")]
		internal string? TIMSTA = default;
		[Description("Tide - accuracy of water level")]
		internal int? T_ACWL = default;
		[Description("Tide - high and low water values")]
		internal string? T_HWLW = default;
		[Description("Tide - method of tidal prediction")]
		internal int? T_MTOD = default;
		[Description("Tide - time and height differences")]
		internal string? T_THDF = default;
		[Description("Tide - time interval of values")]
		internal int? T_TINT = default;
		[Description("Tide - time series values")]
		internal string? T_TSVL = default;
		[Description("Tide - value of harmonic constituents")]
		internal string? T_VAHC = default;
		[Description("Tidal stream - panel values")]
		internal string? TS_TSP = default;
		[Description("Tidal stream - time series values")]
		internal string? TS_TSV = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public TidesAndVariationsA (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["RYRMGV"] && feature["RYRMGV"] is not null) {
				RYRMGV = Convert.ToString(feature["RYRMGV"]);
			}
			if (DBNull.Value != feature["VALLMA"] && feature["VALLMA"] is not null) {
				VALLMA = Convert.ToDecimal(feature["VALLMA"]);
			}
			if (DBNull.Value != feature["VALACM"] && feature["VALACM"] is not null) {
				VALACM = Convert.ToDecimal(feature["VALACM"]);
			}
			if (DBNull.Value != feature["VALMAG"] && feature["VALMAG"] is not null) {
				VALMAG = Convert.ToDecimal(feature["VALMAG"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CAT_TS"] && feature["CAT_TS"] is not null) {
				CAT_TS = Convert.ToInt32(feature["CAT_TS"]);
			}
			if (DBNull.Value != feature["CURVEL"] && feature["CURVEL"] is not null) {
				CURVEL = Convert.ToDecimal(feature["CURVEL"]);
			}
			if (DBNull.Value != feature["ORIENT"] && feature["ORIENT"] is not null) {
				ORIENT = Convert.ToDecimal(feature["ORIENT"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["TIMEND"] && feature["TIMEND"] is not null) {
				TIMEND = Convert.ToString(feature["TIMEND"]);
			}
			if (DBNull.Value != feature["TIMSTA"] && feature["TIMSTA"] is not null) {
				TIMSTA = Convert.ToString(feature["TIMSTA"]);
			}
			if (DBNull.Value != feature["T_ACWL"] && feature["T_ACWL"] is not null) {
				T_ACWL = Convert.ToInt32(feature["T_ACWL"]);
			}
			if (DBNull.Value != feature["T_HWLW"] && feature["T_HWLW"] is not null) {
				T_HWLW = Convert.ToString(feature["T_HWLW"]);
			}
			if (DBNull.Value != feature["T_MTOD"] && feature["T_MTOD"] is not null) {
				T_MTOD = Convert.ToInt32(feature["T_MTOD"]);
			}
			if (DBNull.Value != feature["T_THDF"] && feature["T_THDF"] is not null) {
				T_THDF = Convert.ToString(feature["T_THDF"]);
			}
			if (DBNull.Value != feature["T_TINT"] && feature["T_TINT"] is not null) {
				T_TINT = Convert.ToInt32(feature["T_TINT"]);
			}
			if (DBNull.Value != feature["T_TSVL"] && feature["T_TSVL"] is not null) {
				T_TSVL = Convert.ToString(feature["T_TSVL"]);
			}
			if (DBNull.Value != feature["T_VAHC"] && feature["T_VAHC"] is not null) {
				T_VAHC = Convert.ToString(feature["T_VAHC"]);
			}
			if (DBNull.Value != feature["TS_TSP"] && feature["TS_TSP"] is not null) {
				TS_TSP = Convert.ToString(feature["TS_TSP"]);
			}
			if (DBNull.Value != feature["TS_TSV"] && feature["TS_TSV"] is not null) {
				TS_TSV = Convert.ToString(feature["TS_TSV"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class TidesAndVariationsL {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Reference year for magnetic variation")]
		internal string? RYRMGV = default;
		[Description("Value of local magnetic anomaly")]
		internal decimal? VALLMA = default;
		[Description("Value of annual change in magnetic variation")]
		internal decimal? VALACM = default;
		[Description("Value of magnetic variation")]
		internal decimal? VALMAG = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public TidesAndVariationsL (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["RYRMGV"] && feature["RYRMGV"] is not null) {
				RYRMGV = Convert.ToString(feature["RYRMGV"]);
			}
			if (DBNull.Value != feature["VALLMA"] && feature["VALLMA"] is not null) {
				VALLMA = Convert.ToDecimal(feature["VALLMA"]);
			}
			if (DBNull.Value != feature["VALACM"] && feature["VALACM"] is not null) {
				VALACM = Convert.ToDecimal(feature["VALACM"]);
			}
			if (DBNull.Value != feature["VALMAG"] && feature["VALMAG"] is not null) {
				VALMAG = Convert.ToDecimal(feature["VALMAG"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class TidesAndVariationsP {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Reference year for magnetic variation")]
		internal string? RYRMGV = default;
		[Description("Value of local magnetic anomaly")]
		internal decimal? VALLMA = default;
		[Description("Value of annual change in magnetic variation")]
		internal decimal? VALACM = default;
		[Description("Value of magnetic variation")]
		internal decimal? VALMAG = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of Tidal stream")]
		internal int? CAT_TS = default;
		[Description("Current velocity")]
		internal decimal? CURVEL = default;
		[Description("Orientation")]
		internal decimal? ORIENT = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Time end")]
		internal string? TIMEND = default;
		[Description("Time start")]
		internal string? TIMSTA = default;
		[Description("Tide - accuracy of water level")]
		internal int? T_ACWL = default;
		[Description("Tide - high and low water values")]
		internal string? T_HWLW = default;
		[Description("Tide - method of tidal prediction")]
		internal int? T_MTOD = default;
		[Description("Tide - time and height differences")]
		internal string? T_THDF = default;
		[Description("Tide - time interval of values")]
		internal int? T_TINT = default;
		[Description("Tide - time series values")]
		internal string? T_TSVL = default;
		[Description("Tide - value of harmonic constituents")]
		internal string? T_VAHC = default;
		[Description("Tidal stream - panel values")]
		internal string? TS_TSP = default;
		[Description("Tidal stream - time series values")]
		internal string? TS_TSV = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		public TidesAndVariationsP (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["RYRMGV"] && feature["RYRMGV"] is not null) {
				RYRMGV = Convert.ToString(feature["RYRMGV"]);
			}
			if (DBNull.Value != feature["VALLMA"] && feature["VALLMA"] is not null) {
				VALLMA = Convert.ToDecimal(feature["VALLMA"]);
			}
			if (DBNull.Value != feature["VALACM"] && feature["VALACM"] is not null) {
				VALACM = Convert.ToDecimal(feature["VALACM"]);
			}
			if (DBNull.Value != feature["VALMAG"] && feature["VALMAG"] is not null) {
				VALMAG = Convert.ToDecimal(feature["VALMAG"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CAT_TS"] && feature["CAT_TS"] is not null) {
				CAT_TS = Convert.ToInt32(feature["CAT_TS"]);
			}
			if (DBNull.Value != feature["CURVEL"] && feature["CURVEL"] is not null) {
				CURVEL = Convert.ToDecimal(feature["CURVEL"]);
			}
			if (DBNull.Value != feature["ORIENT"] && feature["ORIENT"] is not null) {
				ORIENT = Convert.ToDecimal(feature["ORIENT"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["TIMEND"] && feature["TIMEND"] is not null) {
				TIMEND = Convert.ToString(feature["TIMEND"]);
			}
			if (DBNull.Value != feature["TIMSTA"] && feature["TIMSTA"] is not null) {
				TIMSTA = Convert.ToString(feature["TIMSTA"]);
			}
			if (DBNull.Value != feature["T_ACWL"] && feature["T_ACWL"] is not null) {
				T_ACWL = Convert.ToInt32(feature["T_ACWL"]);
			}
			if (DBNull.Value != feature["T_HWLW"] && feature["T_HWLW"] is not null) {
				T_HWLW = Convert.ToString(feature["T_HWLW"]);
			}
			if (DBNull.Value != feature["T_MTOD"] && feature["T_MTOD"] is not null) {
				T_MTOD = Convert.ToInt32(feature["T_MTOD"]);
			}
			if (DBNull.Value != feature["T_THDF"] && feature["T_THDF"] is not null) {
				T_THDF = Convert.ToString(feature["T_THDF"]);
			}
			if (DBNull.Value != feature["T_TINT"] && feature["T_TINT"] is not null) {
				T_TINT = Convert.ToInt32(feature["T_TINT"]);
			}
			if (DBNull.Value != feature["T_TSVL"] && feature["T_TSVL"] is not null) {
				T_TSVL = Convert.ToString(feature["T_TSVL"]);
			}
			if (DBNull.Value != feature["T_VAHC"] && feature["T_VAHC"] is not null) {
				T_VAHC = Convert.ToString(feature["T_VAHC"]);
			}
			if (DBNull.Value != feature["TS_TSP"] && feature["TS_TSP"] is not null) {
				TS_TSP = Convert.ToString(feature["TS_TSP"]);
			}
			if (DBNull.Value != feature["TS_TSV"] && feature["TS_TSV"] is not null) {
				TS_TSV = Convert.ToString(feature["TS_TSV"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
		}
	}
	internal class SeabedL {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Nature of surface - qualifying terms")]
		internal string? NATQUA = default;
		[Description("Nature of surface")]
		internal string? NATSUR = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public SeabedL (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["NATQUA"] && feature["NATQUA"] is not null) {
				NATQUA = Convert.ToString(feature["NATQUA"]);
			}
			if (DBNull.Value != feature["NATSUR"] && feature["NATSUR"] is not null) {
				NATSUR = Convert.ToString(feature["NATSUR"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class SeabedP {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Nature of surface - qualifying terms")]
		internal string? NATQUA = default;
		[Description("Nature of surface")]
		internal string? NATSUR = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of weed/kelp")]
		internal int? CATWED = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		public SeabedP (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["NATQUA"] && feature["NATQUA"] is not null) {
				NATQUA = Convert.ToString(feature["NATQUA"]);
			}
			if (DBNull.Value != feature["NATSUR"] && feature["NATSUR"] is not null) {
				NATSUR = Convert.ToString(feature["NATSUR"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATWED"] && feature["CATWED"] is not null) {
				CATWED = Convert.ToInt32(feature["CATWED"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
		}
	}
	internal class SeabedA {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Nature of surface - qualifying terms")]
		internal string? NATQUA = default;
		[Description("Nature of surface")]
		internal string? NATSUR = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of weed/kelp")]
		internal int? CATWED = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public SeabedA (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["NATQUA"] && feature["NATQUA"] is not null) {
				NATQUA = Convert.ToString(feature["NATQUA"]);
			}
			if (DBNull.Value != feature["NATSUR"] && feature["NATSUR"] is not null) {
				NATSUR = Convert.ToString(feature["NATSUR"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATWED"] && feature["CATWED"] is not null) {
				CATWED = Convert.ToInt32(feature["CATWED"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class DangersL {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of fishing facility")]
		internal int? CATFIF = default;
		[Description("Category of obstruction")]
		internal int? CATOBS = default;
		[Description("Category of water turbulence")]
		internal int? CATWAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Exposition of sounding")]
		internal int? EXPSOU = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Nature of surface - qualifying terms")]
		internal string? NATQUA = default;
		[Description("Nature of surface")]
		internal string? NATSUR = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Product")]
		internal string? PRODCT = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Technique of sounding measurement")]
		internal string? TECSOU = default;
		[Description("Value of sounding")]
		internal decimal? VALSOU = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of oil barrier")]
		internal int? CATOLB = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public DangersL (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATFIF"] && feature["CATFIF"] is not null) {
				CATFIF = Convert.ToInt32(feature["CATFIF"]);
			}
			if (DBNull.Value != feature["CATOBS"] && feature["CATOBS"] is not null) {
				CATOBS = Convert.ToInt32(feature["CATOBS"]);
			}
			if (DBNull.Value != feature["CATWAT"] && feature["CATWAT"] is not null) {
				CATWAT = Convert.ToInt32(feature["CATWAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["EXPSOU"] && feature["EXPSOU"] is not null) {
				EXPSOU = Convert.ToInt32(feature["EXPSOU"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["NATQUA"] && feature["NATQUA"] is not null) {
				NATQUA = Convert.ToString(feature["NATQUA"]);
			}
			if (DBNull.Value != feature["NATSUR"] && feature["NATSUR"] is not null) {
				NATSUR = Convert.ToString(feature["NATSUR"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["PRODCT"] && feature["PRODCT"] is not null) {
				PRODCT = Convert.ToString(feature["PRODCT"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["TECSOU"] && feature["TECSOU"] is not null) {
				TECSOU = Convert.ToString(feature["TECSOU"]);
			}
			if (DBNull.Value != feature["VALSOU"] && feature["VALSOU"] is not null) {
				VALSOU = Convert.ToDecimal(feature["VALSOU"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATOLB"] && feature["CATOLB"] is not null) {
				CATOLB = Convert.ToInt32(feature["CATOLB"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class DangersP {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of fishing facility")]
		internal int? CATFIF = default;
		[Description("Category of obstruction")]
		internal int? CATOBS = default;
		[Description("Category of water turbulence")]
		internal int? CATWAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Exposition of sounding")]
		internal int? EXPSOU = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Nature of surface - qualifying terms")]
		internal string? NATQUA = default;
		[Description("Nature of surface")]
		internal string? NATSUR = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Product")]
		internal string? PRODCT = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Technique of sounding measurement")]
		internal string? TECSOU = default;
		[Description("Value of sounding")]
		internal decimal? VALSOU = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of wreck")]
		internal int? CATWRK = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		public DangersP (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATFIF"] && feature["CATFIF"] is not null) {
				CATFIF = Convert.ToInt32(feature["CATFIF"]);
			}
			if (DBNull.Value != feature["CATOBS"] && feature["CATOBS"] is not null) {
				CATOBS = Convert.ToInt32(feature["CATOBS"]);
			}
			if (DBNull.Value != feature["CATWAT"] && feature["CATWAT"] is not null) {
				CATWAT = Convert.ToInt32(feature["CATWAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["EXPSOU"] && feature["EXPSOU"] is not null) {
				EXPSOU = Convert.ToInt32(feature["EXPSOU"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["NATQUA"] && feature["NATQUA"] is not null) {
				NATQUA = Convert.ToString(feature["NATQUA"]);
			}
			if (DBNull.Value != feature["NATSUR"] && feature["NATSUR"] is not null) {
				NATSUR = Convert.ToString(feature["NATSUR"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["PRODCT"] && feature["PRODCT"] is not null) {
				PRODCT = Convert.ToString(feature["PRODCT"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["TECSOU"] && feature["TECSOU"] is not null) {
				TECSOU = Convert.ToString(feature["TECSOU"]);
			}
			if (DBNull.Value != feature["VALSOU"] && feature["VALSOU"] is not null) {
				VALSOU = Convert.ToDecimal(feature["VALSOU"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATWRK"] && feature["CATWRK"] is not null) {
				CATWRK = Convert.ToInt32(feature["CATWRK"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
		}
	}
	internal class DangersA {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of fishing facility")]
		internal int? CATFIF = default;
		[Description("Category of obstruction")]
		internal int? CATOBS = default;
		[Description("Category of water turbulence")]
		internal int? CATWAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Exposition of sounding")]
		internal int? EXPSOU = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Nature of surface - qualifying terms")]
		internal string? NATQUA = default;
		[Description("Nature of surface")]
		internal string? NATSUR = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Product")]
		internal string? PRODCT = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Technique of sounding measurement")]
		internal string? TECSOU = default;
		[Description("Value of sounding")]
		internal decimal? VALSOU = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of wreck")]
		internal int? CATWRK = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public DangersA (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATFIF"] && feature["CATFIF"] is not null) {
				CATFIF = Convert.ToInt32(feature["CATFIF"]);
			}
			if (DBNull.Value != feature["CATOBS"] && feature["CATOBS"] is not null) {
				CATOBS = Convert.ToInt32(feature["CATOBS"]);
			}
			if (DBNull.Value != feature["CATWAT"] && feature["CATWAT"] is not null) {
				CATWAT = Convert.ToInt32(feature["CATWAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["EXPSOU"] && feature["EXPSOU"] is not null) {
				EXPSOU = Convert.ToInt32(feature["EXPSOU"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["NATQUA"] && feature["NATQUA"] is not null) {
				NATQUA = Convert.ToString(feature["NATQUA"]);
			}
			if (DBNull.Value != feature["NATSUR"] && feature["NATSUR"] is not null) {
				NATSUR = Convert.ToString(feature["NATSUR"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["PRODCT"] && feature["PRODCT"] is not null) {
				PRODCT = Convert.ToString(feature["PRODCT"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["TECSOU"] && feature["TECSOU"] is not null) {
				TECSOU = Convert.ToString(feature["TECSOU"]);
			}
			if (DBNull.Value != feature["VALSOU"] && feature["VALSOU"] is not null) {
				VALSOU = Convert.ToDecimal(feature["VALSOU"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATWRK"] && feature["CATWRK"] is not null) {
				CATWRK = Convert.ToInt32(feature["CATWRK"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class DepthsL {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Depth range value 1")]
		internal decimal? DRVAL1 = default;
		[Description("Depth range value 2")]
		internal decimal? DRVAL2 = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Value of depth contour")]
		internal decimal? VALDCO = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public DepthsL (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["DRVAL1"] && feature["DRVAL1"] is not null) {
				DRVAL1 = Convert.ToDecimal(feature["DRVAL1"]);
			}
			if (DBNull.Value != feature["DRVAL2"] && feature["DRVAL2"] is not null) {
				DRVAL2 = Convert.ToDecimal(feature["DRVAL2"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["VALDCO"] && feature["VALDCO"] is not null) {
				VALDCO = Convert.ToDecimal(feature["VALDCO"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class OffshoreInstallationsL {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of pipeline/pipe")]
		internal string? CATPIP = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Product")]
		internal string? PRODCT = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Buried depth")]
		internal decimal? BURDEP = default;
		[Description("Depth range value 1")]
		internal decimal? DRVAL1 = default;
		[Description("Depth range value 2")]
		internal decimal? DRVAL2 = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of cable")]
		internal int? CATCBL = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public OffshoreInstallationsL (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATPIP"] && feature["CATPIP"] is not null) {
				CATPIP = Convert.ToString(feature["CATPIP"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["PRODCT"] && feature["PRODCT"] is not null) {
				PRODCT = Convert.ToString(feature["PRODCT"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["BURDEP"] && feature["BURDEP"] is not null) {
				BURDEP = Convert.ToDecimal(feature["BURDEP"]);
			}
			if (DBNull.Value != feature["DRVAL1"] && feature["DRVAL1"] is not null) {
				DRVAL1 = Convert.ToDecimal(feature["DRVAL1"]);
			}
			if (DBNull.Value != feature["DRVAL2"] && feature["DRVAL2"] is not null) {
				DRVAL2 = Convert.ToDecimal(feature["DRVAL2"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATCBL"] && feature["CATCBL"] is not null) {
				CATCBL = Convert.ToInt32(feature["CATCBL"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class OffshoreInstallationsA {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of pipeline/pipe")]
		internal string? CATPIP = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Product")]
		internal string? PRODCT = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of cable")]
		internal int? CATCBL = default;
		[Description("Category of offshore platform")]
		internal string? CATOFP = default;
		[Description("Category of production area")]
		internal int? CATPRA = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Restriction")]
		internal string? RESTRN = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public OffshoreInstallationsA (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATPIP"] && feature["CATPIP"] is not null) {
				CATPIP = Convert.ToString(feature["CATPIP"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["PRODCT"] && feature["PRODCT"] is not null) {
				PRODCT = Convert.ToString(feature["PRODCT"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATCBL"] && feature["CATCBL"] is not null) {
				CATCBL = Convert.ToInt32(feature["CATCBL"]);
			}
			if (DBNull.Value != feature["CATOFP"] && feature["CATOFP"] is not null) {
				CATOFP = Convert.ToString(feature["CATOFP"]);
			}
			if (DBNull.Value != feature["CATPRA"] && feature["CATPRA"] is not null) {
				CATPRA = Convert.ToInt32(feature["CATPRA"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["RESTRN"] && feature["RESTRN"] is not null) {
				RESTRN = Convert.ToString(feature["RESTRN"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class MetaDataP {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Publication reference")]
		internal string? PUBREF = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		public MetaDataP (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["PUBREF"] && feature["PUBREF"] is not null) {
				PUBREF = Convert.ToString(feature["PUBREF"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
		}
	}
	internal class TracksAndRoutesA {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Communication channel")]
		internal string? COMCHA = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Orientation")]
		internal decimal? ORIENT = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Traffic flow")]
		internal int? TRAFIC = default;
		[Description("Category of ferry")]
		internal int? CATFRY = default;
		[Description("Category of navigation line")]
		internal int? CATNAV = default;
		[Description("Category of recommended track")]
		internal int? CATTRK = default;
		[Description("Category of Traffic Separation Scheme")]
		internal int? CATTSS = default;
		[Description("Depth range value 1")]
		internal decimal? DRVAL1 = default;
		[Description("Depth range value 2")]
		internal decimal? DRVAL2 = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Technique of sounding measurement")]
		internal string? TECSOU = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Restriction")]
		internal string? RESTRN = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public TracksAndRoutesA (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["COMCHA"] && feature["COMCHA"] is not null) {
				COMCHA = Convert.ToString(feature["COMCHA"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["ORIENT"] && feature["ORIENT"] is not null) {
				ORIENT = Convert.ToDecimal(feature["ORIENT"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["TRAFIC"] && feature["TRAFIC"] is not null) {
				TRAFIC = Convert.ToInt32(feature["TRAFIC"]);
			}
			if (DBNull.Value != feature["CATFRY"] && feature["CATFRY"] is not null) {
				CATFRY = Convert.ToInt32(feature["CATFRY"]);
			}
			if (DBNull.Value != feature["CATNAV"] && feature["CATNAV"] is not null) {
				CATNAV = Convert.ToInt32(feature["CATNAV"]);
			}
			if (DBNull.Value != feature["CATTRK"] && feature["CATTRK"] is not null) {
				CATTRK = Convert.ToInt32(feature["CATTRK"]);
			}
			if (DBNull.Value != feature["CATTSS"] && feature["CATTSS"] is not null) {
				CATTSS = Convert.ToInt32(feature["CATTSS"]);
			}
			if (DBNull.Value != feature["DRVAL1"] && feature["DRVAL1"] is not null) {
				DRVAL1 = Convert.ToDecimal(feature["DRVAL1"]);
			}
			if (DBNull.Value != feature["DRVAL2"] && feature["DRVAL2"] is not null) {
				DRVAL2 = Convert.ToDecimal(feature["DRVAL2"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["TECSOU"] && feature["TECSOU"] is not null) {
				TECSOU = Convert.ToString(feature["TECSOU"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["RESTRN"] && feature["RESTRN"] is not null) {
				RESTRN = Convert.ToString(feature["RESTRN"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class TracksAndRoutesL {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Communication channel")]
		internal string? COMCHA = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Orientation")]
		internal decimal? ORIENT = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Traffic flow")]
		internal int? TRAFIC = default;
		[Description("Category of ferry")]
		internal int? CATFRY = default;
		[Description("Category of navigation line")]
		internal int? CATNAV = default;
		[Description("Category of recommended track")]
		internal int? CATTRK = default;
		[Description("Category of Traffic Separation Scheme")]
		internal int? CATTSS = default;
		[Description("Depth range value 1")]
		internal decimal? DRVAL1 = default;
		[Description("Depth range value 2")]
		internal decimal? DRVAL2 = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Technique of sounding measurement")]
		internal string? TECSOU = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public TracksAndRoutesL (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["COMCHA"] && feature["COMCHA"] is not null) {
				COMCHA = Convert.ToString(feature["COMCHA"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["ORIENT"] && feature["ORIENT"] is not null) {
				ORIENT = Convert.ToDecimal(feature["ORIENT"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["TRAFIC"] && feature["TRAFIC"] is not null) {
				TRAFIC = Convert.ToInt32(feature["TRAFIC"]);
			}
			if (DBNull.Value != feature["CATFRY"] && feature["CATFRY"] is not null) {
				CATFRY = Convert.ToInt32(feature["CATFRY"]);
			}
			if (DBNull.Value != feature["CATNAV"] && feature["CATNAV"] is not null) {
				CATNAV = Convert.ToInt32(feature["CATNAV"]);
			}
			if (DBNull.Value != feature["CATTRK"] && feature["CATTRK"] is not null) {
				CATTRK = Convert.ToInt32(feature["CATTRK"]);
			}
			if (DBNull.Value != feature["CATTSS"] && feature["CATTSS"] is not null) {
				CATTSS = Convert.ToInt32(feature["CATTSS"]);
			}
			if (DBNull.Value != feature["DRVAL1"] && feature["DRVAL1"] is not null) {
				DRVAL1 = Convert.ToDecimal(feature["DRVAL1"]);
			}
			if (DBNull.Value != feature["DRVAL2"] && feature["DRVAL2"] is not null) {
				DRVAL2 = Convert.ToDecimal(feature["DRVAL2"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["TECSOU"] && feature["TECSOU"] is not null) {
				TECSOU = Convert.ToString(feature["TECSOU"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class TracksAndRoutesP {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Communication channel")]
		internal string? COMCHA = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Orientation")]
		internal decimal? ORIENT = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Traffic flow")]
		internal int? TRAFIC = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Restriction")]
		internal string? RESTRN = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		public TracksAndRoutesP (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["COMCHA"] && feature["COMCHA"] is not null) {
				COMCHA = Convert.ToString(feature["COMCHA"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["ORIENT"] && feature["ORIENT"] is not null) {
				ORIENT = Convert.ToDecimal(feature["ORIENT"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["TRAFIC"] && feature["TRAFIC"] is not null) {
				TRAFIC = Convert.ToInt32(feature["TRAFIC"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["RESTRN"] && feature["RESTRN"] is not null) {
				RESTRN = Convert.ToString(feature["RESTRN"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
		}
	}
	internal class AidsToNavigationP {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Buoy shape")]
		internal int? BOYSHP = default;
		[Description("Beacon shape")]
		internal int? BCNSHP = default;
		[Description("Call sign")]
		internal string? CALSGN = default;
		[Description("Category of cardinal mark")]
		internal int? CATCAM = default;
		[Description("Category of fog signal")]
		internal int? CATFOG = default;
		[Description("Category of installation buoy")]
		internal int? CATINB = default;
		[Description("Category of lateral mark")]
		internal int? CATLAM = default;
		[Description("Category of light")]
		internal string? CATLIT = default;
		[Description("Category of radar station")]
		internal int? CATRAS = default;
		[Description("Category of radio station")]
		internal string? CATROS = default;
		[Description("Category of radar transponder beacon")]
		internal int? CATRTB = default;
		[Description("Category of special purpose mark")]
		internal string? CATSPM = default;
		[Description("Communication channel")]
		internal string? COMCHA = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Elevation")]
		internal decimal? ELEVAT = default;
		[Description("Estimated range of transmission")]
		internal decimal? ESTRNG = default;
		[Description("Exhibition condition of light")]
		internal int? EXCLIT = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Horizontal accuracy")]
		internal decimal? HORACC = default;
		[Description("Horizontal length")]
		internal decimal? HORLEN = default;
		[Description("Horizontal width")]
		internal decimal? HORWID = default;
		[Description("Light characteristic")]
		internal int? LITCHR = default;
		[Description("Light visibility")]
		internal string? LITVIS = default;
		[Description("Marks navigational - System of")]
		internal int? MARSYS = default;
		[Description("Mulitiplicity of lights")]
		internal int? MLTYLT = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Orientation")]
		internal decimal? ORIENT = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Product")]
		internal string? PRODCT = default;
		[Description("Radar wave length")]
		internal string? RADWAL = default;
		[Description("Sector limit one")]
		internal decimal? SECTR1 = default;
		[Description("Sector limit two")]
		internal decimal? SECTR2 = default;
		[Description("Signal frequency")]
		internal int? SIGFRQ = default;
		[Description("Signal generation")]
		internal int? SIGGEN = default;
		[Description("Signal group")]
		internal string? SIGGRP = default;
		[Description("Signal period")]
		internal decimal? SIGPER = default;
		[Description("Signal sequence")]
		internal string? SIGSEQ = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Topmark/daymark shape")]
		internal int? TOPSHP = default;
		[Description("Value of maximum range")]
		internal decimal? VALMXR = default;
		[Description("Value of nominal range")]
		internal decimal? VALNMR = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		public AidsToNavigationP (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["BOYSHP"] && feature["BOYSHP"] is not null) {
				BOYSHP = Convert.ToInt32(feature["BOYSHP"]);
			}
			if (DBNull.Value != feature["BCNSHP"] && feature["BCNSHP"] is not null) {
				BCNSHP = Convert.ToInt32(feature["BCNSHP"]);
			}
			if (DBNull.Value != feature["CALSGN"] && feature["CALSGN"] is not null) {
				CALSGN = Convert.ToString(feature["CALSGN"]);
			}
			if (DBNull.Value != feature["CATCAM"] && feature["CATCAM"] is not null) {
				CATCAM = Convert.ToInt32(feature["CATCAM"]);
			}
			if (DBNull.Value != feature["CATFOG"] && feature["CATFOG"] is not null) {
				CATFOG = Convert.ToInt32(feature["CATFOG"]);
			}
			if (DBNull.Value != feature["CATINB"] && feature["CATINB"] is not null) {
				CATINB = Convert.ToInt32(feature["CATINB"]);
			}
			if (DBNull.Value != feature["CATLAM"] && feature["CATLAM"] is not null) {
				CATLAM = Convert.ToInt32(feature["CATLAM"]);
			}
			if (DBNull.Value != feature["CATLIT"] && feature["CATLIT"] is not null) {
				CATLIT = Convert.ToString(feature["CATLIT"]);
			}
			if (DBNull.Value != feature["CATRAS"] && feature["CATRAS"] is not null) {
				CATRAS = Convert.ToInt32(feature["CATRAS"]);
			}
			if (DBNull.Value != feature["CATROS"] && feature["CATROS"] is not null) {
				CATROS = Convert.ToString(feature["CATROS"]);
			}
			if (DBNull.Value != feature["CATRTB"] && feature["CATRTB"] is not null) {
				CATRTB = Convert.ToInt32(feature["CATRTB"]);
			}
			if (DBNull.Value != feature["CATSPM"] && feature["CATSPM"] is not null) {
				CATSPM = Convert.ToString(feature["CATSPM"]);
			}
			if (DBNull.Value != feature["COMCHA"] && feature["COMCHA"] is not null) {
				COMCHA = Convert.ToString(feature["COMCHA"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["ELEVAT"] && feature["ELEVAT"] is not null) {
				ELEVAT = Convert.ToDecimal(feature["ELEVAT"]);
			}
			if (DBNull.Value != feature["ESTRNG"] && feature["ESTRNG"] is not null) {
				ESTRNG = Convert.ToDecimal(feature["ESTRNG"]);
			}
			if (DBNull.Value != feature["EXCLIT"] && feature["EXCLIT"] is not null) {
				EXCLIT = Convert.ToInt32(feature["EXCLIT"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["HORACC"] && feature["HORACC"] is not null) {
				HORACC = Convert.ToDecimal(feature["HORACC"]);
			}
			if (DBNull.Value != feature["HORLEN"] && feature["HORLEN"] is not null) {
				HORLEN = Convert.ToDecimal(feature["HORLEN"]);
			}
			if (DBNull.Value != feature["HORWID"] && feature["HORWID"] is not null) {
				HORWID = Convert.ToDecimal(feature["HORWID"]);
			}
			if (DBNull.Value != feature["LITCHR"] && feature["LITCHR"] is not null) {
				LITCHR = Convert.ToInt32(feature["LITCHR"]);
			}
			if (DBNull.Value != feature["LITVIS"] && feature["LITVIS"] is not null) {
				LITVIS = Convert.ToString(feature["LITVIS"]);
			}
			if (DBNull.Value != feature["MARSYS"] && feature["MARSYS"] is not null) {
				MARSYS = Convert.ToInt32(feature["MARSYS"]);
			}
			if (DBNull.Value != feature["MLTYLT"] && feature["MLTYLT"] is not null) {
				MLTYLT = Convert.ToInt32(feature["MLTYLT"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["ORIENT"] && feature["ORIENT"] is not null) {
				ORIENT = Convert.ToDecimal(feature["ORIENT"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["PRODCT"] && feature["PRODCT"] is not null) {
				PRODCT = Convert.ToString(feature["PRODCT"]);
			}
			if (DBNull.Value != feature["RADWAL"] && feature["RADWAL"] is not null) {
				RADWAL = Convert.ToString(feature["RADWAL"]);
			}
			if (DBNull.Value != feature["SECTR1"] && feature["SECTR1"] is not null) {
				SECTR1 = Convert.ToDecimal(feature["SECTR1"]);
			}
			if (DBNull.Value != feature["SECTR2"] && feature["SECTR2"] is not null) {
				SECTR2 = Convert.ToDecimal(feature["SECTR2"]);
			}
			if (DBNull.Value != feature["SIGFRQ"] && feature["SIGFRQ"] is not null) {
				SIGFRQ = Convert.ToInt32(feature["SIGFRQ"]);
			}
			if (DBNull.Value != feature["SIGGEN"] && feature["SIGGEN"] is not null) {
				SIGGEN = Convert.ToInt32(feature["SIGGEN"]);
			}
			if (DBNull.Value != feature["SIGGRP"] && feature["SIGGRP"] is not null) {
				SIGGRP = Convert.ToString(feature["SIGGRP"]);
			}
			if (DBNull.Value != feature["SIGPER"] && feature["SIGPER"] is not null) {
				SIGPER = Convert.ToDecimal(feature["SIGPER"]);
			}
			if (DBNull.Value != feature["SIGSEQ"] && feature["SIGSEQ"] is not null) {
				SIGSEQ = Convert.ToString(feature["SIGSEQ"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["TOPSHP"] && feature["TOPSHP"] is not null) {
				TOPSHP = Convert.ToInt32(feature["TOPSHP"]);
			}
			if (DBNull.Value != feature["VALMXR"] && feature["VALMXR"] is not null) {
				VALMXR = Convert.ToDecimal(feature["VALMXR"]);
			}
			if (DBNull.Value != feature["VALNMR"] && feature["VALNMR"] is not null) {
				VALNMR = Convert.ToDecimal(feature["VALNMR"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
		}
	}
	internal class IceFeaturesA {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of ice")]
		internal int? CATICE = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Elevation")]
		internal decimal? ELEVAT = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public IceFeaturesA (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATICE"] && feature["CATICE"] is not null) {
				CATICE = Convert.ToInt32(feature["CATICE"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["ELEVAT"] && feature["ELEVAT"] is not null) {
				ELEVAT = Convert.ToDecimal(feature["ELEVAT"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class MilitaryFeaturesA {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of military practice area")]
		internal string? CATMPA = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Restriction")]
		internal string? RESTRN = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public MilitaryFeaturesA (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATMPA"] && feature["CATMPA"] is not null) {
				CATMPA = Convert.ToString(feature["CATMPA"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["RESTRN"] && feature["RESTRN"] is not null) {
				RESTRN = Convert.ToString(feature["RESTRN"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class MilitaryFeaturesP {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of military practice area")]
		internal string? CATMPA = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Restriction")]
		internal string? RESTRN = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		public MilitaryFeaturesP (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATMPA"] && feature["CATMPA"] is not null) {
				CATMPA = Convert.ToString(feature["CATMPA"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["RESTRN"] && feature["RESTRN"] is not null) {
				RESTRN = Convert.ToString(feature["RESTRN"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
		}
	}
	internal class UserDefinedFeaturesA {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Object Class Definition")]
		internal string? CLSDEF = default;
		[Description("Object Class Name")]
		internal string? CLSNAM = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Nationality")]
		internal string? NATION = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Restriction")]
		internal string? RESTRN = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Symbol Instruction")]
		internal string? SYMINS = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public UserDefinedFeaturesA (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CLSDEF"] && feature["CLSDEF"] is not null) {
				CLSDEF = Convert.ToString(feature["CLSDEF"]);
			}
			if (DBNull.Value != feature["CLSNAM"] && feature["CLSNAM"] is not null) {
				CLSNAM = Convert.ToString(feature["CLSNAM"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["NATION"] && feature["NATION"] is not null) {
				NATION = Convert.ToString(feature["NATION"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["RESTRN"] && feature["RESTRN"] is not null) {
				RESTRN = Convert.ToString(feature["RESTRN"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["SYMINS"] && feature["SYMINS"] is not null) {
				SYMINS = Convert.ToString(feature["SYMINS"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class UserDefinedFeaturesP {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Object Class Definition")]
		internal string? CLSDEF = default;
		[Description("Object Class Name")]
		internal string? CLSNAM = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Nationality")]
		internal string? NATION = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Restriction")]
		internal string? RESTRN = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Symbol Instruction")]
		internal string? SYMINS = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		public UserDefinedFeaturesP (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CLSDEF"] && feature["CLSDEF"] is not null) {
				CLSDEF = Convert.ToString(feature["CLSDEF"]);
			}
			if (DBNull.Value != feature["CLSNAM"] && feature["CLSNAM"] is not null) {
				CLSNAM = Convert.ToString(feature["CLSNAM"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["NATION"] && feature["NATION"] is not null) {
				NATION = Convert.ToString(feature["NATION"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["RESTRN"] && feature["RESTRN"] is not null) {
				RESTRN = Convert.ToString(feature["RESTRN"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["SYMINS"] && feature["SYMINS"] is not null) {
				SYMINS = Convert.ToString(feature["SYMINS"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
		}
	}
	internal class UserDefinedFeaturesL {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Object Class Definition")]
		internal string? CLSDEF = default;
		[Description("Object Class Name")]
		internal string? CLSNAM = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Nationality")]
		internal string? NATION = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Restriction")]
		internal string? RESTRN = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Symbol Instruction")]
		internal string? SYMINS = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public UserDefinedFeaturesL (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CLSDEF"] && feature["CLSDEF"] is not null) {
				CLSDEF = Convert.ToString(feature["CLSDEF"]);
			}
			if (DBNull.Value != feature["CLSNAM"] && feature["CLSNAM"] is not null) {
				CLSNAM = Convert.ToString(feature["CLSNAM"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["NATION"] && feature["NATION"] is not null) {
				NATION = Convert.ToString(feature["NATION"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["RESTRN"] && feature["RESTRN"] is not null) {
				RESTRN = Convert.ToString(feature["RESTRN"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["SYMINS"] && feature["SYMINS"] is not null) {
				SYMINS = Convert.ToString(feature["SYMINS"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class DepthsA {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Depth range value 1")]
		internal decimal? DRVAL1 = default;
		[Description("Depth range value 2")]
		internal decimal? DRVAL2 = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Restriction")]
		internal string? RESTRN = default;
		[Description("Technique of sounding measurement")]
		internal string? TECSOU = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public DepthsA (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["DRVAL1"] && feature["DRVAL1"] is not null) {
				DRVAL1 = Convert.ToDecimal(feature["DRVAL1"]);
			}
			if (DBNull.Value != feature["DRVAL2"] && feature["DRVAL2"] is not null) {
				DRVAL2 = Convert.ToDecimal(feature["DRVAL2"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["RESTRN"] && feature["RESTRN"] is not null) {
				RESTRN = Convert.ToString(feature["RESTRN"]);
			}
			if (DBNull.Value != feature["TECSOU"] && feature["TECSOU"] is not null) {
				TECSOU = Convert.ToString(feature["TECSOU"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class SoundingsP {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Depth")]
		internal decimal? DEPTH = default;
		[Description("Exposition of sounding")]
		internal int? EXPSOU = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Technique of sounding measurement")]
		internal string? TECSOU = default;
		[Description("Quality of position")]
		internal int? P_QUAPOS = default;
		[Description("Entry date")]
		internal decimal? ENTRY_DATE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		public SoundingsP (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["DEPTH"] && feature["DEPTH"] is not null) {
				DEPTH = Convert.ToDecimal(feature["DEPTH"]);
			}
			if (DBNull.Value != feature["EXPSOU"] && feature["EXPSOU"] is not null) {
				EXPSOU = Convert.ToInt32(feature["EXPSOU"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["TECSOU"] && feature["TECSOU"] is not null) {
				TECSOU = Convert.ToString(feature["TECSOU"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["ENTRY_DATE"] && feature["ENTRY_DATE"] is not null) {
				ENTRY_DATE = Convert.ToDecimal(feature["ENTRY_DATE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
		}
	}
	internal class PortsAndServicesP {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Buoy shape")]
		internal int? BOYSHP = default;
		[Description("Category of gate")]
		internal int? CATGAT = default;
		[Description("Category of mooring/warping facility")]
		internal int? CATMOR = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Depth range value 1")]
		internal decimal? DRVAL1 = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Horizontal accuracy")]
		internal decimal? HORACC = default;
		[Description("Horizontal clearance")]
		internal decimal? HORCLR = default;
		[Description("Horizontal length")]
		internal decimal? HORLEN = default;
		[Description("Horizontal width")]
		internal decimal? HORWID = default;
		[Description("Lifting capacity")]
		internal decimal? LIFCAP = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical clearance")]
		internal decimal? VERCLR = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of checkpoint")]
		internal int? CATCHP = default;
		[Description("Category of crane")]
		internal int? CATCRN = default;
		[Description("Category of distance mark")]
		internal int? CATDIS = default;
		[Description("Category of harbour facility")]
		internal string? CATHAF = default;
		[Description("Category of hulk")]
		internal string? CATHLK = default;
		[Description("Category of pilot boarding place")]
		internal int? CATPIL = default;
		[Description("Category of pile")]
		internal int? CATPLE = default;
		[Description("Category of rescue station")]
		internal string? CATRSC = default;
		[Description("Category of small craft facility")]
		internal string? CATSCF = default;
		[Description("Category of signal station, traffic")]
		internal string? CATSIT = default;
		[Description("Category of signal station, warning")]
		internal string? CATSIW = default;
		[Description("Communication channel")]
		internal string? COMCHA = default;
		[Description("Pilot district in national language")]
		internal string? NPLDST = default;
		[Description("Orientation")]
		internal decimal? ORIENT = default;
		[Description("Pilot district")]
		internal string? PILDST = default;
		[Description("Radius")]
		internal decimal? RADIUS = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		public PortsAndServicesP (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["BOYSHP"] && feature["BOYSHP"] is not null) {
				BOYSHP = Convert.ToInt32(feature["BOYSHP"]);
			}
			if (DBNull.Value != feature["CATGAT"] && feature["CATGAT"] is not null) {
				CATGAT = Convert.ToInt32(feature["CATGAT"]);
			}
			if (DBNull.Value != feature["CATMOR"] && feature["CATMOR"] is not null) {
				CATMOR = Convert.ToInt32(feature["CATMOR"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["DRVAL1"] && feature["DRVAL1"] is not null) {
				DRVAL1 = Convert.ToDecimal(feature["DRVAL1"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["HORACC"] && feature["HORACC"] is not null) {
				HORACC = Convert.ToDecimal(feature["HORACC"]);
			}
			if (DBNull.Value != feature["HORCLR"] && feature["HORCLR"] is not null) {
				HORCLR = Convert.ToDecimal(feature["HORCLR"]);
			}
			if (DBNull.Value != feature["HORLEN"] && feature["HORLEN"] is not null) {
				HORLEN = Convert.ToDecimal(feature["HORLEN"]);
			}
			if (DBNull.Value != feature["HORWID"] && feature["HORWID"] is not null) {
				HORWID = Convert.ToDecimal(feature["HORWID"]);
			}
			if (DBNull.Value != feature["LIFCAP"] && feature["LIFCAP"] is not null) {
				LIFCAP = Convert.ToDecimal(feature["LIFCAP"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERCLR"] && feature["VERCLR"] is not null) {
				VERCLR = Convert.ToDecimal(feature["VERCLR"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATCHP"] && feature["CATCHP"] is not null) {
				CATCHP = Convert.ToInt32(feature["CATCHP"]);
			}
			if (DBNull.Value != feature["CATCRN"] && feature["CATCRN"] is not null) {
				CATCRN = Convert.ToInt32(feature["CATCRN"]);
			}
			if (DBNull.Value != feature["CATDIS"] && feature["CATDIS"] is not null) {
				CATDIS = Convert.ToInt32(feature["CATDIS"]);
			}
			if (DBNull.Value != feature["CATHAF"] && feature["CATHAF"] is not null) {
				CATHAF = Convert.ToString(feature["CATHAF"]);
			}
			if (DBNull.Value != feature["CATHLK"] && feature["CATHLK"] is not null) {
				CATHLK = Convert.ToString(feature["CATHLK"]);
			}
			if (DBNull.Value != feature["CATPIL"] && feature["CATPIL"] is not null) {
				CATPIL = Convert.ToInt32(feature["CATPIL"]);
			}
			if (DBNull.Value != feature["CATPLE"] && feature["CATPLE"] is not null) {
				CATPLE = Convert.ToInt32(feature["CATPLE"]);
			}
			if (DBNull.Value != feature["CATRSC"] && feature["CATRSC"] is not null) {
				CATRSC = Convert.ToString(feature["CATRSC"]);
			}
			if (DBNull.Value != feature["CATSCF"] && feature["CATSCF"] is not null) {
				CATSCF = Convert.ToString(feature["CATSCF"]);
			}
			if (DBNull.Value != feature["CATSIT"] && feature["CATSIT"] is not null) {
				CATSIT = Convert.ToString(feature["CATSIT"]);
			}
			if (DBNull.Value != feature["CATSIW"] && feature["CATSIW"] is not null) {
				CATSIW = Convert.ToString(feature["CATSIW"]);
			}
			if (DBNull.Value != feature["COMCHA"] && feature["COMCHA"] is not null) {
				COMCHA = Convert.ToString(feature["COMCHA"]);
			}
			if (DBNull.Value != feature["NPLDST"] && feature["NPLDST"] is not null) {
				NPLDST = Convert.ToString(feature["NPLDST"]);
			}
			if (DBNull.Value != feature["ORIENT"] && feature["ORIENT"] is not null) {
				ORIENT = Convert.ToDecimal(feature["ORIENT"]);
			}
			if (DBNull.Value != feature["PILDST"] && feature["PILDST"] is not null) {
				PILDST = Convert.ToString(feature["PILDST"]);
			}
			if (DBNull.Value != feature["RADIUS"] && feature["RADIUS"] is not null) {
				RADIUS = Convert.ToDecimal(feature["RADIUS"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
		}
	}
	internal class PortsAndServicesL {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Buoy shape")]
		internal int? BOYSHP = default;
		[Description("Category of gate")]
		internal int? CATGAT = default;
		[Description("Category of mooring/warping facility")]
		internal int? CATMOR = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Depth range value 1")]
		internal decimal? DRVAL1 = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Horizontal accuracy")]
		internal decimal? HORACC = default;
		[Description("Horizontal clearance")]
		internal decimal? HORCLR = default;
		[Description("Horizontal length")]
		internal decimal? HORLEN = default;
		[Description("Horizontal width")]
		internal decimal? HORWID = default;
		[Description("Lifting capacity")]
		internal decimal? LIFCAP = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical clearance")]
		internal decimal? VERCLR = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of canal")]
		internal int? CATCAN = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public PortsAndServicesL (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["BOYSHP"] && feature["BOYSHP"] is not null) {
				BOYSHP = Convert.ToInt32(feature["BOYSHP"]);
			}
			if (DBNull.Value != feature["CATGAT"] && feature["CATGAT"] is not null) {
				CATGAT = Convert.ToInt32(feature["CATGAT"]);
			}
			if (DBNull.Value != feature["CATMOR"] && feature["CATMOR"] is not null) {
				CATMOR = Convert.ToInt32(feature["CATMOR"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["DRVAL1"] && feature["DRVAL1"] is not null) {
				DRVAL1 = Convert.ToDecimal(feature["DRVAL1"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["HORACC"] && feature["HORACC"] is not null) {
				HORACC = Convert.ToDecimal(feature["HORACC"]);
			}
			if (DBNull.Value != feature["HORCLR"] && feature["HORCLR"] is not null) {
				HORCLR = Convert.ToDecimal(feature["HORCLR"]);
			}
			if (DBNull.Value != feature["HORLEN"] && feature["HORLEN"] is not null) {
				HORLEN = Convert.ToDecimal(feature["HORLEN"]);
			}
			if (DBNull.Value != feature["HORWID"] && feature["HORWID"] is not null) {
				HORWID = Convert.ToDecimal(feature["HORWID"]);
			}
			if (DBNull.Value != feature["LIFCAP"] && feature["LIFCAP"] is not null) {
				LIFCAP = Convert.ToDecimal(feature["LIFCAP"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERCLR"] && feature["VERCLR"] is not null) {
				VERCLR = Convert.ToDecimal(feature["VERCLR"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATCAN"] && feature["CATCAN"] is not null) {
				CATCAN = Convert.ToInt32(feature["CATCAN"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class PortsAndServicesA {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Buoy shape")]
		internal int? BOYSHP = default;
		[Description("Category of gate")]
		internal int? CATGAT = default;
		[Description("Category of mooring/warping facility")]
		internal int? CATMOR = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Depth range value 1")]
		internal decimal? DRVAL1 = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Horizontal accuracy")]
		internal decimal? HORACC = default;
		[Description("Horizontal clearance")]
		internal decimal? HORCLR = default;
		[Description("Horizontal length")]
		internal decimal? HORLEN = default;
		[Description("Horizontal width")]
		internal decimal? HORWID = default;
		[Description("Lifting capacity")]
		internal decimal? LIFCAP = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical clearance")]
		internal decimal? VERCLR = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of canal")]
		internal int? CATCAN = default;
		[Description("Category of checkpoint")]
		internal int? CATCHP = default;
		[Description("Category of crane")]
		internal int? CATCRN = default;
		[Description("Category of dock")]
		internal int? CATDOC = default;
		[Description("Category of harbour facility")]
		internal string? CATHAF = default;
		[Description("Category of hulk")]
		internal string? CATHLK = default;
		[Description("Category of pilot boarding place")]
		internal int? CATPIL = default;
		[Description("Category of small craft facility")]
		internal string? CATSCF = default;
		[Description("Communication channel")]
		internal string? COMCHA = default;
		[Description("Pilot district in national language")]
		internal string? NPLDST = default;
		[Description("Orientation")]
		internal decimal? ORIENT = default;
		[Description("Pilot district")]
		internal string? PILDST = default;
		[Description("Radius")]
		internal decimal? RADIUS = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public PortsAndServicesA (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["BOYSHP"] && feature["BOYSHP"] is not null) {
				BOYSHP = Convert.ToInt32(feature["BOYSHP"]);
			}
			if (DBNull.Value != feature["CATGAT"] && feature["CATGAT"] is not null) {
				CATGAT = Convert.ToInt32(feature["CATGAT"]);
			}
			if (DBNull.Value != feature["CATMOR"] && feature["CATMOR"] is not null) {
				CATMOR = Convert.ToInt32(feature["CATMOR"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["DRVAL1"] && feature["DRVAL1"] is not null) {
				DRVAL1 = Convert.ToDecimal(feature["DRVAL1"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["HORACC"] && feature["HORACC"] is not null) {
				HORACC = Convert.ToDecimal(feature["HORACC"]);
			}
			if (DBNull.Value != feature["HORCLR"] && feature["HORCLR"] is not null) {
				HORCLR = Convert.ToDecimal(feature["HORCLR"]);
			}
			if (DBNull.Value != feature["HORLEN"] && feature["HORLEN"] is not null) {
				HORLEN = Convert.ToDecimal(feature["HORLEN"]);
			}
			if (DBNull.Value != feature["HORWID"] && feature["HORWID"] is not null) {
				HORWID = Convert.ToDecimal(feature["HORWID"]);
			}
			if (DBNull.Value != feature["LIFCAP"] && feature["LIFCAP"] is not null) {
				LIFCAP = Convert.ToDecimal(feature["LIFCAP"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERCLR"] && feature["VERCLR"] is not null) {
				VERCLR = Convert.ToDecimal(feature["VERCLR"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATCAN"] && feature["CATCAN"] is not null) {
				CATCAN = Convert.ToInt32(feature["CATCAN"]);
			}
			if (DBNull.Value != feature["CATCHP"] && feature["CATCHP"] is not null) {
				CATCHP = Convert.ToInt32(feature["CATCHP"]);
			}
			if (DBNull.Value != feature["CATCRN"] && feature["CATCRN"] is not null) {
				CATCRN = Convert.ToInt32(feature["CATCRN"]);
			}
			if (DBNull.Value != feature["CATDOC"] && feature["CATDOC"] is not null) {
				CATDOC = Convert.ToInt32(feature["CATDOC"]);
			}
			if (DBNull.Value != feature["CATHAF"] && feature["CATHAF"] is not null) {
				CATHAF = Convert.ToString(feature["CATHAF"]);
			}
			if (DBNull.Value != feature["CATHLK"] && feature["CATHLK"] is not null) {
				CATHLK = Convert.ToString(feature["CATHLK"]);
			}
			if (DBNull.Value != feature["CATPIL"] && feature["CATPIL"] is not null) {
				CATPIL = Convert.ToInt32(feature["CATPIL"]);
			}
			if (DBNull.Value != feature["CATSCF"] && feature["CATSCF"] is not null) {
				CATSCF = Convert.ToString(feature["CATSCF"]);
			}
			if (DBNull.Value != feature["COMCHA"] && feature["COMCHA"] is not null) {
				COMCHA = Convert.ToString(feature["COMCHA"]);
			}
			if (DBNull.Value != feature["NPLDST"] && feature["NPLDST"] is not null) {
				NPLDST = Convert.ToString(feature["NPLDST"]);
			}
			if (DBNull.Value != feature["ORIENT"] && feature["ORIENT"] is not null) {
				ORIENT = Convert.ToDecimal(feature["ORIENT"]);
			}
			if (DBNull.Value != feature["PILDST"] && feature["PILDST"] is not null) {
				PILDST = Convert.ToString(feature["PILDST"]);
			}
			if (DBNull.Value != feature["RADIUS"] && feature["RADIUS"] is not null) {
				RADIUS = Convert.ToDecimal(feature["RADIUS"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class CulturalFeaturesA {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Buried depth")]
		internal decimal? BURDEP = default;
		[Description("Category of bridge")]
		internal string? CATBRG = default;
		[Description("Category of dam")]
		internal int? CATDAM = default;
		[Description("Category of fortified structure")]
		internal int? CATFOR = default;
		[Description("Category of landmark")]
		internal string? CATLMK = default;
		[Description("Category of road")]
		internal int? CATROD = default;
		[Description("Category of runway")]
		internal int? CATRUN = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Elevation")]
		internal decimal? ELEVAT = default;
		[Description("Function")]
		internal string? FUNCTN = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Horizontal accuracy")]
		internal decimal? HORACC = default;
		[Description("Horizontal clearance")]
		internal decimal? HORCLR = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Product")]
		internal string? PRODCT = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical clearance, closed")]
		internal decimal? VERCCL = default;
		[Description("Vertical clearance")]
		internal decimal? VERCLR = default;
		[Description("Vertical clearance, open")]
		internal decimal? VERCOP = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Building shape")]
		internal int? BUISHP = default;
		[Description("Category of airport/airfield")]
		internal string? CATAIR = default;
		[Description("Category of built-up area")]
		internal int? CATBUA = default;
		[Description("Category of conveyor")]
		internal int? CATCON = default;
		[Description("Category of production area")]
		internal int? CATPRA = default;
		[Description("Category of pylon")]
		internal int? CATPYL = default;
		[Description("Category of silo/tank")]
		internal int? CATSIL = default;
		[Description("Lifting capacity")]
		internal decimal? LIFCAP = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public CulturalFeaturesA (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["BURDEP"] && feature["BURDEP"] is not null) {
				BURDEP = Convert.ToDecimal(feature["BURDEP"]);
			}
			if (DBNull.Value != feature["CATBRG"] && feature["CATBRG"] is not null) {
				CATBRG = Convert.ToString(feature["CATBRG"]);
			}
			if (DBNull.Value != feature["CATDAM"] && feature["CATDAM"] is not null) {
				CATDAM = Convert.ToInt32(feature["CATDAM"]);
			}
			if (DBNull.Value != feature["CATFOR"] && feature["CATFOR"] is not null) {
				CATFOR = Convert.ToInt32(feature["CATFOR"]);
			}
			if (DBNull.Value != feature["CATLMK"] && feature["CATLMK"] is not null) {
				CATLMK = Convert.ToString(feature["CATLMK"]);
			}
			if (DBNull.Value != feature["CATROD"] && feature["CATROD"] is not null) {
				CATROD = Convert.ToInt32(feature["CATROD"]);
			}
			if (DBNull.Value != feature["CATRUN"] && feature["CATRUN"] is not null) {
				CATRUN = Convert.ToInt32(feature["CATRUN"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["ELEVAT"] && feature["ELEVAT"] is not null) {
				ELEVAT = Convert.ToDecimal(feature["ELEVAT"]);
			}
			if (DBNull.Value != feature["FUNCTN"] && feature["FUNCTN"] is not null) {
				FUNCTN = Convert.ToString(feature["FUNCTN"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["HORACC"] && feature["HORACC"] is not null) {
				HORACC = Convert.ToDecimal(feature["HORACC"]);
			}
			if (DBNull.Value != feature["HORCLR"] && feature["HORCLR"] is not null) {
				HORCLR = Convert.ToDecimal(feature["HORCLR"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["PRODCT"] && feature["PRODCT"] is not null) {
				PRODCT = Convert.ToString(feature["PRODCT"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERCCL"] && feature["VERCCL"] is not null) {
				VERCCL = Convert.ToDecimal(feature["VERCCL"]);
			}
			if (DBNull.Value != feature["VERCLR"] && feature["VERCLR"] is not null) {
				VERCLR = Convert.ToDecimal(feature["VERCLR"]);
			}
			if (DBNull.Value != feature["VERCOP"] && feature["VERCOP"] is not null) {
				VERCOP = Convert.ToDecimal(feature["VERCOP"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["BUISHP"] && feature["BUISHP"] is not null) {
				BUISHP = Convert.ToInt32(feature["BUISHP"]);
			}
			if (DBNull.Value != feature["CATAIR"] && feature["CATAIR"] is not null) {
				CATAIR = Convert.ToString(feature["CATAIR"]);
			}
			if (DBNull.Value != feature["CATBUA"] && feature["CATBUA"] is not null) {
				CATBUA = Convert.ToInt32(feature["CATBUA"]);
			}
			if (DBNull.Value != feature["CATCON"] && feature["CATCON"] is not null) {
				CATCON = Convert.ToInt32(feature["CATCON"]);
			}
			if (DBNull.Value != feature["CATPRA"] && feature["CATPRA"] is not null) {
				CATPRA = Convert.ToInt32(feature["CATPRA"]);
			}
			if (DBNull.Value != feature["CATPYL"] && feature["CATPYL"] is not null) {
				CATPYL = Convert.ToInt32(feature["CATPYL"]);
			}
			if (DBNull.Value != feature["CATSIL"] && feature["CATSIL"] is not null) {
				CATSIL = Convert.ToInt32(feature["CATSIL"]);
			}
			if (DBNull.Value != feature["LIFCAP"] && feature["LIFCAP"] is not null) {
				LIFCAP = Convert.ToDecimal(feature["LIFCAP"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class CulturalFeaturesL {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Buried depth")]
		internal decimal? BURDEP = default;
		[Description("Category of bridge")]
		internal string? CATBRG = default;
		[Description("Category of dam")]
		internal int? CATDAM = default;
		[Description("Category of fortified structure")]
		internal int? CATFOR = default;
		[Description("Category of landmark")]
		internal string? CATLMK = default;
		[Description("Category of road")]
		internal int? CATROD = default;
		[Description("Category of runway")]
		internal int? CATRUN = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Elevation")]
		internal decimal? ELEVAT = default;
		[Description("Function")]
		internal string? FUNCTN = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Horizontal accuracy")]
		internal decimal? HORACC = default;
		[Description("Horizontal clearance")]
		internal decimal? HORCLR = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Product")]
		internal string? PRODCT = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical clearance, closed")]
		internal decimal? VERCCL = default;
		[Description("Vertical clearance")]
		internal decimal? VERCLR = default;
		[Description("Vertical clearance, open")]
		internal decimal? VERCOP = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of cable")]
		internal int? CATCBL = default;
		[Description("Category of conveyor")]
		internal int? CATCON = default;
		[Description("Category of fence/wall")]
		internal int? CATFNC = default;
		[Description("Category of pipeline/pipe")]
		internal string? CATPIP = default;
		[Description("Ice factor")]
		internal decimal? ICEFAC = default;
		[Description("Lifting capacity")]
		internal decimal? LIFCAP = default;
		[Description("Vertical clearance, safe")]
		internal decimal? VERCSA = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public CulturalFeaturesL (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["BURDEP"] && feature["BURDEP"] is not null) {
				BURDEP = Convert.ToDecimal(feature["BURDEP"]);
			}
			if (DBNull.Value != feature["CATBRG"] && feature["CATBRG"] is not null) {
				CATBRG = Convert.ToString(feature["CATBRG"]);
			}
			if (DBNull.Value != feature["CATDAM"] && feature["CATDAM"] is not null) {
				CATDAM = Convert.ToInt32(feature["CATDAM"]);
			}
			if (DBNull.Value != feature["CATFOR"] && feature["CATFOR"] is not null) {
				CATFOR = Convert.ToInt32(feature["CATFOR"]);
			}
			if (DBNull.Value != feature["CATLMK"] && feature["CATLMK"] is not null) {
				CATLMK = Convert.ToString(feature["CATLMK"]);
			}
			if (DBNull.Value != feature["CATROD"] && feature["CATROD"] is not null) {
				CATROD = Convert.ToInt32(feature["CATROD"]);
			}
			if (DBNull.Value != feature["CATRUN"] && feature["CATRUN"] is not null) {
				CATRUN = Convert.ToInt32(feature["CATRUN"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["ELEVAT"] && feature["ELEVAT"] is not null) {
				ELEVAT = Convert.ToDecimal(feature["ELEVAT"]);
			}
			if (DBNull.Value != feature["FUNCTN"] && feature["FUNCTN"] is not null) {
				FUNCTN = Convert.ToString(feature["FUNCTN"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["HORACC"] && feature["HORACC"] is not null) {
				HORACC = Convert.ToDecimal(feature["HORACC"]);
			}
			if (DBNull.Value != feature["HORCLR"] && feature["HORCLR"] is not null) {
				HORCLR = Convert.ToDecimal(feature["HORCLR"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["PRODCT"] && feature["PRODCT"] is not null) {
				PRODCT = Convert.ToString(feature["PRODCT"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERCCL"] && feature["VERCCL"] is not null) {
				VERCCL = Convert.ToDecimal(feature["VERCCL"]);
			}
			if (DBNull.Value != feature["VERCLR"] && feature["VERCLR"] is not null) {
				VERCLR = Convert.ToDecimal(feature["VERCLR"]);
			}
			if (DBNull.Value != feature["VERCOP"] && feature["VERCOP"] is not null) {
				VERCOP = Convert.ToDecimal(feature["VERCOP"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATCBL"] && feature["CATCBL"] is not null) {
				CATCBL = Convert.ToInt32(feature["CATCBL"]);
			}
			if (DBNull.Value != feature["CATCON"] && feature["CATCON"] is not null) {
				CATCON = Convert.ToInt32(feature["CATCON"]);
			}
			if (DBNull.Value != feature["CATFNC"] && feature["CATFNC"] is not null) {
				CATFNC = Convert.ToInt32(feature["CATFNC"]);
			}
			if (DBNull.Value != feature["CATPIP"] && feature["CATPIP"] is not null) {
				CATPIP = Convert.ToString(feature["CATPIP"]);
			}
			if (DBNull.Value != feature["ICEFAC"] && feature["ICEFAC"] is not null) {
				ICEFAC = Convert.ToDecimal(feature["ICEFAC"]);
			}
			if (DBNull.Value != feature["LIFCAP"] && feature["LIFCAP"] is not null) {
				LIFCAP = Convert.ToDecimal(feature["LIFCAP"]);
			}
			if (DBNull.Value != feature["VERCSA"] && feature["VERCSA"] is not null) {
				VERCSA = Convert.ToDecimal(feature["VERCSA"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class CulturalFeaturesP {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Buried depth")]
		internal decimal? BURDEP = default;
		[Description("Category of bridge")]
		internal string? CATBRG = default;
		[Description("Category of dam")]
		internal int? CATDAM = default;
		[Description("Category of fortified structure")]
		internal int? CATFOR = default;
		[Description("Category of landmark")]
		internal string? CATLMK = default;
		[Description("Category of road")]
		internal int? CATROD = default;
		[Description("Category of runway")]
		internal int? CATRUN = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Elevation")]
		internal decimal? ELEVAT = default;
		[Description("Function")]
		internal string? FUNCTN = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Horizontal accuracy")]
		internal decimal? HORACC = default;
		[Description("Horizontal clearance")]
		internal decimal? HORCLR = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Product")]
		internal string? PRODCT = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical clearance, closed")]
		internal decimal? VERCCL = default;
		[Description("Vertical clearance")]
		internal decimal? VERCLR = default;
		[Description("Vertical clearance, open")]
		internal decimal? VERCOP = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Building shape")]
		internal int? BUISHP = default;
		[Description("Category of airport/airfield")]
		internal string? CATAIR = default;
		[Description("Category of built-up area")]
		internal int? CATBUA = default;
		[Description("Category of control point")]
		internal int? CATCTR = default;
		[Description("Category of production area")]
		internal int? CATPRA = default;
		[Description("Category of pylon")]
		internal int? CATPYL = default;
		[Description("Category of silo/tank")]
		internal int? CATSIL = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		public CulturalFeaturesP (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["BURDEP"] && feature["BURDEP"] is not null) {
				BURDEP = Convert.ToDecimal(feature["BURDEP"]);
			}
			if (DBNull.Value != feature["CATBRG"] && feature["CATBRG"] is not null) {
				CATBRG = Convert.ToString(feature["CATBRG"]);
			}
			if (DBNull.Value != feature["CATDAM"] && feature["CATDAM"] is not null) {
				CATDAM = Convert.ToInt32(feature["CATDAM"]);
			}
			if (DBNull.Value != feature["CATFOR"] && feature["CATFOR"] is not null) {
				CATFOR = Convert.ToInt32(feature["CATFOR"]);
			}
			if (DBNull.Value != feature["CATLMK"] && feature["CATLMK"] is not null) {
				CATLMK = Convert.ToString(feature["CATLMK"]);
			}
			if (DBNull.Value != feature["CATROD"] && feature["CATROD"] is not null) {
				CATROD = Convert.ToInt32(feature["CATROD"]);
			}
			if (DBNull.Value != feature["CATRUN"] && feature["CATRUN"] is not null) {
				CATRUN = Convert.ToInt32(feature["CATRUN"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["ELEVAT"] && feature["ELEVAT"] is not null) {
				ELEVAT = Convert.ToDecimal(feature["ELEVAT"]);
			}
			if (DBNull.Value != feature["FUNCTN"] && feature["FUNCTN"] is not null) {
				FUNCTN = Convert.ToString(feature["FUNCTN"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["HORACC"] && feature["HORACC"] is not null) {
				HORACC = Convert.ToDecimal(feature["HORACC"]);
			}
			if (DBNull.Value != feature["HORCLR"] && feature["HORCLR"] is not null) {
				HORCLR = Convert.ToDecimal(feature["HORCLR"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["PRODCT"] && feature["PRODCT"] is not null) {
				PRODCT = Convert.ToString(feature["PRODCT"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERCCL"] && feature["VERCCL"] is not null) {
				VERCCL = Convert.ToDecimal(feature["VERCCL"]);
			}
			if (DBNull.Value != feature["VERCLR"] && feature["VERCLR"] is not null) {
				VERCLR = Convert.ToDecimal(feature["VERCLR"]);
			}
			if (DBNull.Value != feature["VERCOP"] && feature["VERCOP"] is not null) {
				VERCOP = Convert.ToDecimal(feature["VERCOP"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["BUISHP"] && feature["BUISHP"] is not null) {
				BUISHP = Convert.ToInt32(feature["BUISHP"]);
			}
			if (DBNull.Value != feature["CATAIR"] && feature["CATAIR"] is not null) {
				CATAIR = Convert.ToString(feature["CATAIR"]);
			}
			if (DBNull.Value != feature["CATBUA"] && feature["CATBUA"] is not null) {
				CATBUA = Convert.ToInt32(feature["CATBUA"]);
			}
			if (DBNull.Value != feature["CATCTR"] && feature["CATCTR"] is not null) {
				CATCTR = Convert.ToInt32(feature["CATCTR"]);
			}
			if (DBNull.Value != feature["CATPRA"] && feature["CATPRA"] is not null) {
				CATPRA = Convert.ToInt32(feature["CATPRA"]);
			}
			if (DBNull.Value != feature["CATPYL"] && feature["CATPYL"] is not null) {
				CATPYL = Convert.ToInt32(feature["CATPYL"]);
			}
			if (DBNull.Value != feature["CATSIL"] && feature["CATSIL"] is not null) {
				CATSIL = Convert.ToInt32(feature["CATSIL"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
		}
	}
	internal class NaturalFeaturesP {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of slope")]
		internal int? CATSLO = default;
		[Description("Category of vegetation")]
		internal string? CATVEG = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Elevation")]
		internal decimal? ELEVAT = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Nature of surface - qualifying terms")]
		internal string? NATQUA = default;
		[Description("Nature of surface")]
		internal string? NATSUR = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of land region")]
		internal string? CATLND = default;
		[Description("Category of sea area")]
		internal int? CATSEA = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		public NaturalFeaturesP (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATSLO"] && feature["CATSLO"] is not null) {
				CATSLO = Convert.ToInt32(feature["CATSLO"]);
			}
			if (DBNull.Value != feature["CATVEG"] && feature["CATVEG"] is not null) {
				CATVEG = Convert.ToString(feature["CATVEG"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["ELEVAT"] && feature["ELEVAT"] is not null) {
				ELEVAT = Convert.ToDecimal(feature["ELEVAT"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["NATQUA"] && feature["NATQUA"] is not null) {
				NATQUA = Convert.ToString(feature["NATQUA"]);
			}
			if (DBNull.Value != feature["NATSUR"] && feature["NATSUR"] is not null) {
				NATSUR = Convert.ToString(feature["NATSUR"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATLND"] && feature["CATLND"] is not null) {
				CATLND = Convert.ToString(feature["CATLND"]);
			}
			if (DBNull.Value != feature["CATSEA"] && feature["CATSEA"] is not null) {
				CATSEA = Convert.ToInt32(feature["CATSEA"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
		}
	}
	internal class NaturalFeaturesL {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of slope")]
		internal int? CATSLO = default;
		[Description("Category of vegetation")]
		internal string? CATVEG = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Elevation")]
		internal decimal? ELEVAT = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Nature of surface - qualifying terms")]
		internal string? NATQUA = default;
		[Description("Nature of surface")]
		internal string? NATSUR = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public NaturalFeaturesL (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATSLO"] && feature["CATSLO"] is not null) {
				CATSLO = Convert.ToInt32(feature["CATSLO"]);
			}
			if (DBNull.Value != feature["CATVEG"] && feature["CATVEG"] is not null) {
				CATVEG = Convert.ToString(feature["CATVEG"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["ELEVAT"] && feature["ELEVAT"] is not null) {
				ELEVAT = Convert.ToDecimal(feature["ELEVAT"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["NATQUA"] && feature["NATQUA"] is not null) {
				NATQUA = Convert.ToString(feature["NATQUA"]);
			}
			if (DBNull.Value != feature["NATSUR"] && feature["NATSUR"] is not null) {
				NATSUR = Convert.ToString(feature["NATSUR"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class NaturalFeaturesA {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of slope")]
		internal int? CATSLO = default;
		[Description("Category of vegetation")]
		internal string? CATVEG = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Elevation")]
		internal decimal? ELEVAT = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Nature of surface - qualifying terms")]
		internal string? NATQUA = default;
		[Description("Nature of surface")]
		internal string? NATSUR = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of land region")]
		internal string? CATLND = default;
		[Description("Category of sea area")]
		internal int? CATSEA = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public NaturalFeaturesA (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATSLO"] && feature["CATSLO"] is not null) {
				CATSLO = Convert.ToInt32(feature["CATSLO"]);
			}
			if (DBNull.Value != feature["CATVEG"] && feature["CATVEG"] is not null) {
				CATVEG = Convert.ToString(feature["CATVEG"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["ELEVAT"] && feature["ELEVAT"] is not null) {
				ELEVAT = Convert.ToDecimal(feature["ELEVAT"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["NATQUA"] && feature["NATQUA"] is not null) {
				NATQUA = Convert.ToString(feature["NATQUA"]);
			}
			if (DBNull.Value != feature["NATSUR"] && feature["NATSUR"] is not null) {
				NATSUR = Convert.ToString(feature["NATSUR"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATLND"] && feature["CATLND"] is not null) {
				CATLND = Convert.ToString(feature["CATLND"]);
			}
			if (DBNull.Value != feature["CATSEA"] && feature["CATSEA"] is not null) {
				CATSEA = Convert.ToInt32(feature["CATSEA"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class CoastlineL {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of shoreline construction")]
		internal int? CATSLC = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Horizontal accuracy")]
		internal decimal? HORACC = default;
		[Description("Horizontal clearance")]
		internal decimal? HORCLR = default;
		[Description("Horizontal length")]
		internal decimal? HORLEN = default;
		[Description("Horizontal width")]
		internal decimal? HORWID = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of coastline")]
		internal int? CATCOA = default;
		[Description("Elevation")]
		internal decimal? ELEVAT = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public CoastlineL (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATSLC"] && feature["CATSLC"] is not null) {
				CATSLC = Convert.ToInt32(feature["CATSLC"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["HORACC"] && feature["HORACC"] is not null) {
				HORACC = Convert.ToDecimal(feature["HORACC"]);
			}
			if (DBNull.Value != feature["HORCLR"] && feature["HORCLR"] is not null) {
				HORCLR = Convert.ToDecimal(feature["HORCLR"]);
			}
			if (DBNull.Value != feature["HORLEN"] && feature["HORLEN"] is not null) {
				HORLEN = Convert.ToDecimal(feature["HORLEN"]);
			}
			if (DBNull.Value != feature["HORWID"] && feature["HORWID"] is not null) {
				HORWID = Convert.ToDecimal(feature["HORWID"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATCOA"] && feature["CATCOA"] is not null) {
				CATCOA = Convert.ToInt32(feature["CATCOA"]);
			}
			if (DBNull.Value != feature["ELEVAT"] && feature["ELEVAT"] is not null) {
				ELEVAT = Convert.ToDecimal(feature["ELEVAT"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class CoastlineP {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of shoreline construction")]
		internal int? CATSLC = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Horizontal accuracy")]
		internal decimal? HORACC = default;
		[Description("Horizontal clearance")]
		internal decimal? HORCLR = default;
		[Description("Horizontal length")]
		internal decimal? HORLEN = default;
		[Description("Horizontal width")]
		internal decimal? HORWID = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		public CoastlineP (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATSLC"] && feature["CATSLC"] is not null) {
				CATSLC = Convert.ToInt32(feature["CATSLC"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["HORACC"] && feature["HORACC"] is not null) {
				HORACC = Convert.ToDecimal(feature["HORACC"]);
			}
			if (DBNull.Value != feature["HORCLR"] && feature["HORCLR"] is not null) {
				HORCLR = Convert.ToDecimal(feature["HORCLR"]);
			}
			if (DBNull.Value != feature["HORLEN"] && feature["HORLEN"] is not null) {
				HORLEN = Convert.ToDecimal(feature["HORLEN"]);
			}
			if (DBNull.Value != feature["HORWID"] && feature["HORWID"] is not null) {
				HORWID = Convert.ToDecimal(feature["HORWID"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
		}
	}
	internal class CoastlineA {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of shoreline construction")]
		internal int? CATSLC = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Horizontal accuracy")]
		internal decimal? HORACC = default;
		[Description("Horizontal clearance")]
		internal decimal? HORCLR = default;
		[Description("Horizontal length")]
		internal decimal? HORLEN = default;
		[Description("Horizontal width")]
		internal decimal? HORWID = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public CoastlineA (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATSLC"] && feature["CATSLC"] is not null) {
				CATSLC = Convert.ToInt32(feature["CATSLC"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["HORACC"] && feature["HORACC"] is not null) {
				HORACC = Convert.ToDecimal(feature["HORACC"]);
			}
			if (DBNull.Value != feature["HORCLR"] && feature["HORCLR"] is not null) {
				HORCLR = Convert.ToDecimal(feature["HORCLR"]);
			}
			if (DBNull.Value != feature["HORLEN"] && feature["HORLEN"] is not null) {
				HORLEN = Convert.ToDecimal(feature["HORLEN"]);
			}
			if (DBNull.Value != feature["HORWID"] && feature["HORWID"] is not null) {
				HORWID = Convert.ToDecimal(feature["HORWID"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class RegulatedAreasAndLimitsL {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category marine farm/culture")]
		internal int? CATMFA = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Exposition of sounding")]
		internal int? EXPSOU = default;
		[Description("Nationality")]
		internal string? NATION = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Restriction")]
		internal string? RESTRN = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Value of sounding")]
		internal decimal? VALSOU = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public RegulatedAreasAndLimitsL (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATMFA"] && feature["CATMFA"] is not null) {
				CATMFA = Convert.ToInt32(feature["CATMFA"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["EXPSOU"] && feature["EXPSOU"] is not null) {
				EXPSOU = Convert.ToInt32(feature["EXPSOU"]);
			}
			if (DBNull.Value != feature["NATION"] && feature["NATION"] is not null) {
				NATION = Convert.ToString(feature["NATION"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["RESTRN"] && feature["RESTRN"] is not null) {
				RESTRN = Convert.ToString(feature["RESTRN"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VALSOU"] && feature["VALSOU"] is not null) {
				VALSOU = Convert.ToDecimal(feature["VALSOU"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class RegulatedAreasAndLimitsP {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category marine farm/culture")]
		internal int? CATMFA = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Exposition of sounding")]
		internal int? EXPSOU = default;
		[Description("Nationality")]
		internal string? NATION = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Restriction")]
		internal string? RESTRN = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Value of sounding")]
		internal decimal? VALSOU = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of anchorage")]
		internal string? CATACH = default;
		[Description("Category of dumping ground")]
		internal string? CATDPG = default;
		[Description("Radius")]
		internal decimal? RADIUS = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		public RegulatedAreasAndLimitsP (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATMFA"] && feature["CATMFA"] is not null) {
				CATMFA = Convert.ToInt32(feature["CATMFA"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["EXPSOU"] && feature["EXPSOU"] is not null) {
				EXPSOU = Convert.ToInt32(feature["EXPSOU"]);
			}
			if (DBNull.Value != feature["NATION"] && feature["NATION"] is not null) {
				NATION = Convert.ToString(feature["NATION"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["RESTRN"] && feature["RESTRN"] is not null) {
				RESTRN = Convert.ToString(feature["RESTRN"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VALSOU"] && feature["VALSOU"] is not null) {
				VALSOU = Convert.ToDecimal(feature["VALSOU"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATACH"] && feature["CATACH"] is not null) {
				CATACH = Convert.ToString(feature["CATACH"]);
			}
			if (DBNull.Value != feature["CATDPG"] && feature["CATDPG"] is not null) {
				CATDPG = Convert.ToString(feature["CATDPG"]);
			}
			if (DBNull.Value != feature["RADIUS"] && feature["RADIUS"] is not null) {
				RADIUS = Convert.ToDecimal(feature["RADIUS"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
		}
	}
	internal class RegulatedAreasAndLimitsA {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category marine farm/culture")]
		internal int? CATMFA = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Exposition of sounding")]
		internal int? EXPSOU = default;
		[Description("Nationality")]
		internal string? NATION = default;
		[Description("Periodic date end")]
		internal string? PEREND = default;
		[Description("Periodic date start")]
		internal string? PERSTA = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Restriction")]
		internal string? RESTRN = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Value of sounding")]
		internal decimal? VALSOU = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Water level effect")]
		internal int? WATLEV = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of anchorage")]
		internal string? CATACH = default;
		[Description("Category of dumping ground")]
		internal string? CATDPG = default;
		[Description("Category of restricted area")]
		internal string? CATREA = default;
		[Description("Jurisdiction")]
		internal int? JRSDTN = default;
		[Description("Radius")]
		internal decimal? RADIUS = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public RegulatedAreasAndLimitsA (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATMFA"] && feature["CATMFA"] is not null) {
				CATMFA = Convert.ToInt32(feature["CATMFA"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["EXPSOU"] && feature["EXPSOU"] is not null) {
				EXPSOU = Convert.ToInt32(feature["EXPSOU"]);
			}
			if (DBNull.Value != feature["NATION"] && feature["NATION"] is not null) {
				NATION = Convert.ToString(feature["NATION"]);
			}
			if (DBNull.Value != feature["PEREND"] && feature["PEREND"] is not null) {
				PEREND = Convert.ToString(feature["PEREND"]);
			}
			if (DBNull.Value != feature["PERSTA"] && feature["PERSTA"] is not null) {
				PERSTA = Convert.ToString(feature["PERSTA"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["RESTRN"] && feature["RESTRN"] is not null) {
				RESTRN = Convert.ToString(feature["RESTRN"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VALSOU"] && feature["VALSOU"] is not null) {
				VALSOU = Convert.ToDecimal(feature["VALSOU"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["WATLEV"] && feature["WATLEV"] is not null) {
				WATLEV = Convert.ToInt32(feature["WATLEV"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATACH"] && feature["CATACH"] is not null) {
				CATACH = Convert.ToString(feature["CATACH"]);
			}
			if (DBNull.Value != feature["CATDPG"] && feature["CATDPG"] is not null) {
				CATDPG = Convert.ToString(feature["CATDPG"]);
			}
			if (DBNull.Value != feature["CATREA"] && feature["CATREA"] is not null) {
				CATREA = Convert.ToString(feature["CATREA"]);
			}
			if (DBNull.Value != feature["JRSDTN"] && feature["JRSDTN"] is not null) {
				JRSDTN = Convert.ToInt32(feature["JRSDTN"]);
			}
			if (DBNull.Value != feature["RADIUS"] && feature["RADIUS"] is not null) {
				RADIUS = Convert.ToDecimal(feature["RADIUS"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class MetaDataA {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Quality of position")]
		internal int? QUAPOS = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Scale value one")]
		internal int? SCVAL1 = default;
		[Description("Scale value two")]
		internal int? SCVAL2 = default;
		[Description("Sounding distance - minimum")]
		internal decimal? SDISMN = default;
		[Description("Sounding distance - maximum")]
		internal decimal? SDISMX = default;
		[Description("Survey authority")]
		internal string? SURATH = default;
		[Description("Survey date - end")]
		internal string? SUREND = default;
		[Description("Survey date - start")]
		internal string? SURSTA = default;
		[Description("Survey type")]
		internal string? SURTYP = default;
		[Description("Technique of sounding measurement")]
		internal string? TECSOU = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of quality of data")]
		internal int? CATQUA = default;
		[Description("Category of zone of confidence in data")]
		internal int? CATZOC = default;
		[Description("Compilation scale of data")]
		internal int? CSCALE = default;
		[Description("Depth range value 1")]
		internal decimal? DRVAL1 = default;
		[Description("Depth range value 2")]
		internal decimal? DRVAL2 = default;
		[Description("Horizontal accuracy")]
		internal decimal? HORACC = default;
		[Description("Horizontal datum")]
		internal int? HORDAT = default;
		[Description("Marks navigational - System of")]
		internal int? MARSYS = default;
		[Description("Orientation")]
		internal decimal? ORIENT = default;
		[Description("Publication reference")]
		internal string? PUBREF = default;
		[Description("Positional Accuracy")]
		internal decimal? POSACC = default;
		[Description("Shift parameters")]
		internal string? SHIPAM = default;
		[Description("Sounding accuracy")]
		internal decimal? SOUACC = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public MetaDataA (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["QUAPOS"] && feature["QUAPOS"] is not null) {
				QUAPOS = Convert.ToInt32(feature["QUAPOS"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["SCVAL1"] && feature["SCVAL1"] is not null) {
				SCVAL1 = Convert.ToInt32(feature["SCVAL1"]);
			}
			if (DBNull.Value != feature["SCVAL2"] && feature["SCVAL2"] is not null) {
				SCVAL2 = Convert.ToInt32(feature["SCVAL2"]);
			}
			if (DBNull.Value != feature["SDISMN"] && feature["SDISMN"] is not null) {
				SDISMN = Convert.ToDecimal(feature["SDISMN"]);
			}
			if (DBNull.Value != feature["SDISMX"] && feature["SDISMX"] is not null) {
				SDISMX = Convert.ToDecimal(feature["SDISMX"]);
			}
			if (DBNull.Value != feature["SURATH"] && feature["SURATH"] is not null) {
				SURATH = Convert.ToString(feature["SURATH"]);
			}
			if (DBNull.Value != feature["SUREND"] && feature["SUREND"] is not null) {
				SUREND = Convert.ToString(feature["SUREND"]);
			}
			if (DBNull.Value != feature["SURSTA"] && feature["SURSTA"] is not null) {
				SURSTA = Convert.ToString(feature["SURSTA"]);
			}
			if (DBNull.Value != feature["SURTYP"] && feature["SURTYP"] is not null) {
				SURTYP = Convert.ToString(feature["SURTYP"]);
			}
			if (DBNull.Value != feature["TECSOU"] && feature["TECSOU"] is not null) {
				TECSOU = Convert.ToString(feature["TECSOU"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATQUA"] && feature["CATQUA"] is not null) {
				CATQUA = Convert.ToInt32(feature["CATQUA"]);
			}
			if (DBNull.Value != feature["CATZOC"] && feature["CATZOC"] is not null) {
				CATZOC = Convert.ToInt32(feature["CATZOC"]);
			}
			if (DBNull.Value != feature["CSCALE"] && feature["CSCALE"] is not null) {
				CSCALE = Convert.ToInt32(feature["CSCALE"]);
			}
			if (DBNull.Value != feature["DRVAL1"] && feature["DRVAL1"] is not null) {
				DRVAL1 = Convert.ToDecimal(feature["DRVAL1"]);
			}
			if (DBNull.Value != feature["DRVAL2"] && feature["DRVAL2"] is not null) {
				DRVAL2 = Convert.ToDecimal(feature["DRVAL2"]);
			}
			if (DBNull.Value != feature["HORACC"] && feature["HORACC"] is not null) {
				HORACC = Convert.ToDecimal(feature["HORACC"]);
			}
			if (DBNull.Value != feature["HORDAT"] && feature["HORDAT"] is not null) {
				HORDAT = Convert.ToInt32(feature["HORDAT"]);
			}
			if (DBNull.Value != feature["MARSYS"] && feature["MARSYS"] is not null) {
				MARSYS = Convert.ToInt32(feature["MARSYS"]);
			}
			if (DBNull.Value != feature["ORIENT"] && feature["ORIENT"] is not null) {
				ORIENT = Convert.ToDecimal(feature["ORIENT"]);
			}
			if (DBNull.Value != feature["PUBREF"] && feature["PUBREF"] is not null) {
				PUBREF = Convert.ToString(feature["PUBREF"]);
			}
			if (DBNull.Value != feature["POSACC"] && feature["POSACC"] is not null) {
				POSACC = Convert.ToDecimal(feature["POSACC"]);
			}
			if (DBNull.Value != feature["SHIPAM"] && feature["SHIPAM"] is not null) {
				SHIPAM = Convert.ToString(feature["SHIPAM"]);
			}
			if (DBNull.Value != feature["SOUACC"] && feature["SOUACC"] is not null) {
				SOUACC = Convert.ToDecimal(feature["SOUACC"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class MetaDataL {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Quality of position")]
		internal int? QUAPOS = default;
		[Description("Quality of sounding measurement")]
		internal string? QUASOU = default;
		[Description("Scale value one")]
		internal int? SCVAL1 = default;
		[Description("Scale value two")]
		internal int? SCVAL2 = default;
		[Description("Sounding distance - minimum")]
		internal decimal? SDISMN = default;
		[Description("Sounding distance - maximum")]
		internal decimal? SDISMX = default;
		[Description("Survey authority")]
		internal string? SURATH = default;
		[Description("Survey date - end")]
		internal string? SUREND = default;
		[Description("Survey date - start")]
		internal string? SURSTA = default;
		[Description("Survey type")]
		internal string? SURTYP = default;
		[Description("Technique of sounding measurement")]
		internal string? TECSOU = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public MetaDataL (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["QUAPOS"] && feature["QUAPOS"] is not null) {
				QUAPOS = Convert.ToInt32(feature["QUAPOS"]);
			}
			if (DBNull.Value != feature["QUASOU"] && feature["QUASOU"] is not null) {
				QUASOU = Convert.ToString(feature["QUASOU"]);
			}
			if (DBNull.Value != feature["SCVAL1"] && feature["SCVAL1"] is not null) {
				SCVAL1 = Convert.ToInt32(feature["SCVAL1"]);
			}
			if (DBNull.Value != feature["SCVAL2"] && feature["SCVAL2"] is not null) {
				SCVAL2 = Convert.ToInt32(feature["SCVAL2"]);
			}
			if (DBNull.Value != feature["SDISMN"] && feature["SDISMN"] is not null) {
				SDISMN = Convert.ToDecimal(feature["SDISMN"]);
			}
			if (DBNull.Value != feature["SDISMX"] && feature["SDISMX"] is not null) {
				SDISMX = Convert.ToDecimal(feature["SDISMX"]);
			}
			if (DBNull.Value != feature["SURATH"] && feature["SURATH"] is not null) {
				SURATH = Convert.ToString(feature["SURATH"]);
			}
			if (DBNull.Value != feature["SUREND"] && feature["SUREND"] is not null) {
				SUREND = Convert.ToString(feature["SUREND"]);
			}
			if (DBNull.Value != feature["SURSTA"] && feature["SURSTA"] is not null) {
				SURSTA = Convert.ToString(feature["SURSTA"]);
			}
			if (DBNull.Value != feature["SURTYP"] && feature["SURTYP"] is not null) {
				SURTYP = Convert.ToString(feature["SURTYP"]);
			}
			if (DBNull.Value != feature["TECSOU"] && feature["TECSOU"] is not null) {
				TECSOU = Convert.ToString(feature["TECSOU"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class OffshoreInstallationsP {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Data set name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("Nautical Object ID")]
		internal string? NOID = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Textual description in national language")]
		internal string? NTXTDS = default;
		[Description("Pictorial representation")]
		internal string? PICREP = default;
		[Description("Textual description")]
		internal string? TXTDSC = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("Object name")]
		internal string? OBJNAM = default;
		[Description("Object name in national language")]
		internal string? NOBJNM = default;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified date")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("Category of pipeline/pipe")]
		internal string? CATPIP = default;
		[Description("Condition")]
		internal int? CONDTN = default;
		[Description("Date end")]
		internal string? DATEND = default;
		[Description("Date start")]
		internal string? DATSTA = default;
		[Description("Product")]
		internal string? PRODCT = default;
		[Description("Status")]
		internal string? STATUS = default;
		[Description("Vertical accuracy")]
		internal decimal? VERACC = default;
		[Description("Vertical datum")]
		internal int? VERDAT = default;
		[Description("Vertical length")]
		internal decimal? VERLEN = default;
		[Description("Buried depth")]
		internal decimal? BURDEP = default;
		[Description("Depth range value 1")]
		internal decimal? DRVAL1 = default;
		[Description("Depth range value 2")]
		internal decimal? DRVAL2 = default;
		[Description("FCSubtype")]
		internal int? FCSUBTYPE = default;
		[Description("Category of offshore platform")]
		internal string? CATOFP = default;
		[Description("Colour")]
		internal string? COLOUR = default;
		[Description("Colour pattern")]
		internal string? COLPAT = default;
		[Description("Conspicuous, radar")]
		internal int? CONRAD = default;
		[Description("Conspicuous, visually")]
		internal int? CONVIS = default;
		[Description("Height")]
		internal decimal? HEIGHT = default;
		[Description("Nature of construction")]
		internal string? NATCON = default;
		[Description("Restriction")]
		internal string? RESTRN = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("Quality of Position")]
		internal int? P_QUAPOS = default;
		[Description("Positional Accuracy")]
		internal decimal? P_POSACC = default;
		[Description("Horizontal Datum")]
		internal int? P_HORDAT = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		public OffshoreInstallationsP (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["NOID"] && feature["NOID"] is not null) {
				NOID = Convert.ToString(feature["NOID"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["NTXTDS"] && feature["NTXTDS"] is not null) {
				NTXTDS = Convert.ToString(feature["NTXTDS"]);
			}
			if (DBNull.Value != feature["PICREP"] && feature["PICREP"] is not null) {
				PICREP = Convert.ToString(feature["PICREP"]);
			}
			if (DBNull.Value != feature["TXTDSC"] && feature["TXTDSC"] is not null) {
				TXTDSC = Convert.ToString(feature["TXTDSC"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["OBJNAM"] && feature["OBJNAM"] is not null) {
				OBJNAM = Convert.ToString(feature["OBJNAM"]);
			}
			if (DBNull.Value != feature["NOBJNM"] && feature["NOBJNM"] is not null) {
				NOBJNM = Convert.ToString(feature["NOBJNM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["CATPIP"] && feature["CATPIP"] is not null) {
				CATPIP = Convert.ToString(feature["CATPIP"]);
			}
			if (DBNull.Value != feature["CONDTN"] && feature["CONDTN"] is not null) {
				CONDTN = Convert.ToInt32(feature["CONDTN"]);
			}
			if (DBNull.Value != feature["DATEND"] && feature["DATEND"] is not null) {
				DATEND = Convert.ToString(feature["DATEND"]);
			}
			if (DBNull.Value != feature["DATSTA"] && feature["DATSTA"] is not null) {
				DATSTA = Convert.ToString(feature["DATSTA"]);
			}
			if (DBNull.Value != feature["PRODCT"] && feature["PRODCT"] is not null) {
				PRODCT = Convert.ToString(feature["PRODCT"]);
			}
			if (DBNull.Value != feature["STATUS"] && feature["STATUS"] is not null) {
				STATUS = Convert.ToString(feature["STATUS"]);
			}
			if (DBNull.Value != feature["VERACC"] && feature["VERACC"] is not null) {
				VERACC = Convert.ToDecimal(feature["VERACC"]);
			}
			if (DBNull.Value != feature["VERDAT"] && feature["VERDAT"] is not null) {
				VERDAT = Convert.ToInt32(feature["VERDAT"]);
			}
			if (DBNull.Value != feature["VERLEN"] && feature["VERLEN"] is not null) {
				VERLEN = Convert.ToDecimal(feature["VERLEN"]);
			}
			if (DBNull.Value != feature["BURDEP"] && feature["BURDEP"] is not null) {
				BURDEP = Convert.ToDecimal(feature["BURDEP"]);
			}
			if (DBNull.Value != feature["DRVAL1"] && feature["DRVAL1"] is not null) {
				DRVAL1 = Convert.ToDecimal(feature["DRVAL1"]);
			}
			if (DBNull.Value != feature["DRVAL2"] && feature["DRVAL2"] is not null) {
				DRVAL2 = Convert.ToDecimal(feature["DRVAL2"]);
			}
			if (DBNull.Value != feature["FCSUBTYPE"] && feature["FCSUBTYPE"] is not null) {
				FCSUBTYPE = Convert.ToInt32(feature["FCSUBTYPE"]);
			}
			if (DBNull.Value != feature["CATOFP"] && feature["CATOFP"] is not null) {
				CATOFP = Convert.ToString(feature["CATOFP"]);
			}
			if (DBNull.Value != feature["COLOUR"] && feature["COLOUR"] is not null) {
				COLOUR = Convert.ToString(feature["COLOUR"]);
			}
			if (DBNull.Value != feature["COLPAT"] && feature["COLPAT"] is not null) {
				COLPAT = Convert.ToString(feature["COLPAT"]);
			}
			if (DBNull.Value != feature["CONRAD"] && feature["CONRAD"] is not null) {
				CONRAD = Convert.ToInt32(feature["CONRAD"]);
			}
			if (DBNull.Value != feature["CONVIS"] && feature["CONVIS"] is not null) {
				CONVIS = Convert.ToInt32(feature["CONVIS"]);
			}
			if (DBNull.Value != feature["HEIGHT"] && feature["HEIGHT"] is not null) {
				HEIGHT = Convert.ToDecimal(feature["HEIGHT"]);
			}
			if (DBNull.Value != feature["NATCON"] && feature["NATCON"] is not null) {
				NATCON = Convert.ToString(feature["NATCON"]);
			}
			if (DBNull.Value != feature["RESTRN"] && feature["RESTRN"] is not null) {
				RESTRN = Convert.ToString(feature["RESTRN"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["P_QUAPOS"] && feature["P_QUAPOS"] is not null) {
				P_QUAPOS = Convert.ToInt32(feature["P_QUAPOS"]);
			}
			if (DBNull.Value != feature["P_POSACC"] && feature["P_POSACC"] is not null) {
				P_POSACC = Convert.ToDecimal(feature["P_POSACC"]);
			}
			if (DBNull.Value != feature["P_HORDAT"] && feature["P_HORDAT"] is not null) {
				P_HORDAT = Convert.ToInt32(feature["P_HORDAT"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
		}
	}
	internal class ClosingLinesL {
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last modified")]
		internal DateTime? LAST_MOD = default;
		[Description("Editor comments")]
		internal string? EDITOR_COMMENT = default;
		[Description("Verified state")]
		internal int? VERIFIED = default;
		[Description("Verifier")]
		internal string? VERIFIER = default;
		[Description("Verified date")]
		internal DateTime? VERIFIED_DATE = default;
		[Description("Delete comment")]
		internal string? DELETE_COMMENT = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("SCAMIN step")]
		internal int? SCAMIN_STEP = default;
		[Description("NIS Verified state")]
		internal int? NIS_VERIFIED = default;
		[Description("NIS Verifier")]
		internal string? NIS_VERIFIER = default;
		[Description("NIS Verified date")]
		internal DateTime? NIS_VERIFY_DATE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("NIS editor comments")]
		internal string? NIS_EDITOR_COMMENT = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		public ClosingLinesL (Feature feature) {
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["EDITOR_COMMENT"] && feature["EDITOR_COMMENT"] is not null) {
				EDITOR_COMMENT = Convert.ToString(feature["EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["VERIFIED"] && feature["VERIFIED"] is not null) {
				VERIFIED = Convert.ToInt32(feature["VERIFIED"]);
			}
			if (DBNull.Value != feature["VERIFIER"] && feature["VERIFIER"] is not null) {
				VERIFIER = Convert.ToString(feature["VERIFIER"]);
			}
			if (DBNull.Value != feature["VERIFIED_DATE"] && feature["VERIFIED_DATE"] is not null) {
				VERIFIED_DATE = Convert.ToDateTime(feature["VERIFIED_DATE"]);
			}
			if (DBNull.Value != feature["DELETE_COMMENT"] && feature["DELETE_COMMENT"] is not null) {
				DELETE_COMMENT = Convert.ToString(feature["DELETE_COMMENT"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["SCAMIN_STEP"] && feature["SCAMIN_STEP"] is not null) {
				SCAMIN_STEP = Convert.ToInt32(feature["SCAMIN_STEP"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIED"] && feature["NIS_VERIFIED"] is not null) {
				NIS_VERIFIED = Convert.ToInt32(feature["NIS_VERIFIED"]);
			}
			if (DBNull.Value != feature["NIS_VERIFIER"] && feature["NIS_VERIFIER"] is not null) {
				NIS_VERIFIER = Convert.ToString(feature["NIS_VERIFIER"]);
			}
			if (DBNull.Value != feature["NIS_VERIFY_DATE"] && feature["NIS_VERIFY_DATE"] is not null) {
				NIS_VERIFY_DATE = Convert.ToDateTime(feature["NIS_VERIFY_DATE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR_COMMENT"] && feature["NIS_EDITOR_COMMENT"] is not null) {
				NIS_EDITOR_COMMENT = Convert.ToString(feature["NIS_EDITOR_COMMENT"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
		}
	}
	internal class ProductCoverage {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("Shape")]
		internal Geometry? SHAPE = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Dataset Name")]
		internal string? DSNM = default;
		[Description("Long name")]
		internal string? LNAM = default;
		[Description("EDITOR")]
		internal string? EDITOR = default;
		[Description("LAST_MOD")]
		internal DateTime? LAST_MOD = default;
		[Description("Product_GUID")]
		internal Guid? PRODUCT_GUID = Guid.Empty;
		[Description("Category of coverage")]
		internal int? CATCOV = default;
		[Description("Information")]
		internal string? INFORM = default;
		[Description("Information in national language")]
		internal string? NINFOM = default;
		[Description("Source date")]
		internal string? SORDAT = default;
		[Description("Source indication")]
		internal string? SORIND = default;
		[Description("PLTS compilation scale")]
		internal int? PLTS_COMP_SCALE = default;
		[Description("Is Conflate")]
		internal int? IS_CONFLATE = default;
		[Description("NIS product type")]
		internal int? NIS_PRODUCTS = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		[Description("Shape_Length")]
		internal decimal? SHAPE_LENGTH = default;
		[Description("Shape_Area")]
		internal decimal? SHAPE_AREA = default;
		public ProductCoverage (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["SHAPE"] && feature["SHAPE"] is not null) {
				SHAPE = (Geometry?)(feature["SHAPE"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["LNAM"] && feature["LNAM"] is not null) {
				LNAM = Convert.ToString(feature["LNAM"]);
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["PRODUCT_GUID"] && feature["PRODUCT_GUID"] is not null) {
				PRODUCT_GUID = Guid.Parse(Convert.ToString(feature["PRODUCT_GUID"]));
			}
			if (DBNull.Value != feature["CATCOV"] && feature["CATCOV"] is not null) {
				CATCOV = Convert.ToInt32(feature["CATCOV"]);
			}
			if (DBNull.Value != feature["INFORM"] && feature["INFORM"] is not null) {
				INFORM = Convert.ToString(feature["INFORM"]);
			}
			if (DBNull.Value != feature["NINFOM"] && feature["NINFOM"] is not null) {
				NINFOM = Convert.ToString(feature["NINFOM"]);
			}
			if (DBNull.Value != feature["SORDAT"] && feature["SORDAT"] is not null) {
				SORDAT = Convert.ToString(feature["SORDAT"]);
			}
			if (DBNull.Value != feature["SORIND"] && feature["SORIND"] is not null) {
				SORIND = Convert.ToString(feature["SORIND"]);
			}
			if (DBNull.Value != feature["PLTS_COMP_SCALE"] && feature["PLTS_COMP_SCALE"] is not null) {
				PLTS_COMP_SCALE = Convert.ToInt32(feature["PLTS_COMP_SCALE"]);
			}
			if (DBNull.Value != feature["IS_CONFLATE"] && feature["IS_CONFLATE"] is not null) {
				IS_CONFLATE = Convert.ToInt32(feature["IS_CONFLATE"]);
			}
			if (DBNull.Value != feature["NIS_PRODUCTS"] && feature["NIS_PRODUCTS"] is not null) {
				NIS_PRODUCTS = Convert.ToInt32(feature["NIS_PRODUCTS"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
			if (DBNull.Value != feature["SHAPE_LENGTH"] && feature["SHAPE_LENGTH"] is not null) {
				SHAPE_LENGTH = Convert.ToDecimal(feature["SHAPE_LENGTH"]);
			}
			if (DBNull.Value != feature["SHAPE_AREA"] && feature["SHAPE_AREA"] is not null) {
				SHAPE_AREA = Convert.ToDecimal(feature["SHAPE_AREA"]);
			}
		}
	}
	internal class ProductDefinitions {
		[Description("OBJECTID")]
		internal int? OBJECTID = default;
		[Description("GlobalID")]
		internal Guid GLOBALID = Guid.Empty;
		[Description("Editor")]
		internal string? EDITOR = default;
		[Description("Last Modified Date")]
		internal DateTime? LAST_MOD = default;
		[Description("Compilation Scale")]
		internal int? CSCL = default;
		[Description("Dataset Name")]
		internal string? DSNM = default;
		[Description("Export Type")]
		internal string? EXPORTTYPE = default;
		[Description("Edition Number")]
		internal int? EDTN = default;
		[Description("Update Number")]
		internal int? UPDN = default;
		[Description("Application Profile")]
		internal int? PROF = default;
		[Description("INTU")]
		internal int? INTU = default;
		[Description("Update Application Date")]
		internal DateTime? UADT = default;
		[Description("Issue Date")]
		internal DateTime? ISDT = default;
		[Description("S-57 Edition")]
		internal string? STED = default;
		[Description("Product Specification")]
		internal int? PRSP = default;
		[Description("Product Spec Description")]
		internal string? PSDN = default;
		[Description("Product Spec Edition")]
		internal string? PRED = default;
		[Description("Agency")]
		internal string? AGEN = default;
		[Description("Comment")]
		internal string? COMT = default;
		[Description("ATTF Lexical Level")]
		internal int? AALL = default;
		[Description("NATF Lexical Level")]
		internal int? NALL = default;
		[Description("Horizontal Geodetic Datum")]
		internal int? HDAT = default;
		[Description("Vertical Datum")]
		internal int? VDAT = default;
		[Description("Sounding Datum")]
		internal int? SDAT = default;
		[Description("Depth Units")]
		internal int? DUNI = default;
		[Description("Height Units")]
		internal int? HUNI = default;
		[Description("Precision Units")]
		internal int? PUNI = default;
		[Description("Coordinate Units")]
		internal int? COUN = default;
		[Description("Coordinate Multiplication Factor")]
		internal int? COMF = default;
		[Description("Sounding Multiplication Factor")]
		internal int? SOMF = default;
		[Description("DSPM Comment")]
		internal string? DSPM_COMT = default;
		[Description("Series")]
		internal string? SERIES = default;
		[Description("Where Clause")]
		internal string? WHERECLAUSE = default;
		[Description("NIS_EDITOR")]
		internal string? NIS_EDITOR = default;
		[Description("NIS_LAST_MOD")]
		internal DateTime? NIS_LAST_MOD = default;
		public ProductDefinitions (Feature feature) {
			if (DBNull.Value != feature["OBJECTID"] && feature["OBJECTID"] is not null) {
				OBJECTID = Convert.ToInt32(feature["OBJECTID"]);
			}
			if (DBNull.Value != feature["GLOBALID"] && feature["GLOBALID"] is not null) {
				GLOBALID = Guid.Parse(Convert.ToString(feature["GLOBALID"]));
			}
			if (DBNull.Value != feature["EDITOR"] && feature["EDITOR"] is not null) {
				EDITOR = Convert.ToString(feature["EDITOR"]);
			}
			if (DBNull.Value != feature["LAST_MOD"] && feature["LAST_MOD"] is not null) {
				LAST_MOD = Convert.ToDateTime(feature["LAST_MOD"]);
			}
			if (DBNull.Value != feature["CSCL"] && feature["CSCL"] is not null) {
				CSCL = Convert.ToInt32(feature["CSCL"]);
			}
			if (DBNull.Value != feature["DSNM"] && feature["DSNM"] is not null) {
				DSNM = Convert.ToString(feature["DSNM"]);
			}
			if (DBNull.Value != feature["EXPORTTYPE"] && feature["EXPORTTYPE"] is not null) {
				EXPORTTYPE = Convert.ToString(feature["EXPORTTYPE"]);
			}
			if (DBNull.Value != feature["EDTN"] && feature["EDTN"] is not null) {
				EDTN = Convert.ToInt32(feature["EDTN"]);
			}
			if (DBNull.Value != feature["UPDN"] && feature["UPDN"] is not null) {
				UPDN = Convert.ToInt32(feature["UPDN"]);
			}
			if (DBNull.Value != feature["PROF"] && feature["PROF"] is not null) {
				PROF = Convert.ToInt32(feature["PROF"]);
			}
			if (DBNull.Value != feature["INTU"] && feature["INTU"] is not null) {
				INTU = Convert.ToInt32(feature["INTU"]);
			}
			if (DBNull.Value != feature["UADT"] && feature["UADT"] is not null) {
				UADT = Convert.ToDateTime(feature["UADT"]);
			}
			if (DBNull.Value != feature["ISDT"] && feature["ISDT"] is not null) {
				ISDT = Convert.ToDateTime(feature["ISDT"]);
			}
			if (DBNull.Value != feature["STED"] && feature["STED"] is not null) {
				STED = Convert.ToString(feature["STED"]);
			}
			if (DBNull.Value != feature["PRSP"] && feature["PRSP"] is not null) {
				PRSP = Convert.ToInt32(feature["PRSP"]);
			}
			if (DBNull.Value != feature["PSDN"] && feature["PSDN"] is not null) {
				PSDN = Convert.ToString(feature["PSDN"]);
			}
			if (DBNull.Value != feature["PRED"] && feature["PRED"] is not null) {
				PRED = Convert.ToString(feature["PRED"]);
			}
			if (DBNull.Value != feature["AGEN"] && feature["AGEN"] is not null) {
				AGEN = Convert.ToString(feature["AGEN"]);
			}
			if (DBNull.Value != feature["COMT"] && feature["COMT"] is not null) {
				COMT = Convert.ToString(feature["COMT"]);
			}
			if (DBNull.Value != feature["AALL"] && feature["AALL"] is not null) {
				AALL = Convert.ToInt32(feature["AALL"]);
			}
			if (DBNull.Value != feature["NALL"] && feature["NALL"] is not null) {
				NALL = Convert.ToInt32(feature["NALL"]);
			}
			if (DBNull.Value != feature["HDAT"] && feature["HDAT"] is not null) {
				HDAT = Convert.ToInt32(feature["HDAT"]);
			}
			if (DBNull.Value != feature["VDAT"] && feature["VDAT"] is not null) {
				VDAT = Convert.ToInt32(feature["VDAT"]);
			}
			if (DBNull.Value != feature["SDAT"] && feature["SDAT"] is not null) {
				SDAT = Convert.ToInt32(feature["SDAT"]);
			}
			if (DBNull.Value != feature["DUNI"] && feature["DUNI"] is not null) {
				DUNI = Convert.ToInt32(feature["DUNI"]);
			}
			if (DBNull.Value != feature["HUNI"] && feature["HUNI"] is not null) {
				HUNI = Convert.ToInt32(feature["HUNI"]);
			}
			if (DBNull.Value != feature["PUNI"] && feature["PUNI"] is not null) {
				PUNI = Convert.ToInt32(feature["PUNI"]);
			}
			if (DBNull.Value != feature["COUN"] && feature["COUN"] is not null) {
				COUN = Convert.ToInt32(feature["COUN"]);
			}
			if (DBNull.Value != feature["COMF"] && feature["COMF"] is not null) {
				COMF = Convert.ToInt32(feature["COMF"]);
			}
			if (DBNull.Value != feature["SOMF"] && feature["SOMF"] is not null) {
				SOMF = Convert.ToInt32(feature["SOMF"]);
			}
			if (DBNull.Value != feature["DSPM_COMT"] && feature["DSPM_COMT"] is not null) {
				DSPM_COMT = Convert.ToString(feature["DSPM_COMT"]);
			}
			if (DBNull.Value != feature["SERIES"] && feature["SERIES"] is not null) {
				SERIES = Convert.ToString(feature["SERIES"]);
			}
			if (DBNull.Value != feature["WHERECLAUSE"] && feature["WHERECLAUSE"] is not null) {
				WHERECLAUSE = Convert.ToString(feature["WHERECLAUSE"]);
			}
			if (DBNull.Value != feature["NIS_EDITOR"] && feature["NIS_EDITOR"] is not null) {
				NIS_EDITOR = Convert.ToString(feature["NIS_EDITOR"]);
			}
			if (DBNull.Value != feature["NIS_LAST_MOD"] && feature["NIS_LAST_MOD"] is not null) {
				NIS_LAST_MOD = Convert.ToDateTime(feature["NIS_LAST_MOD"]);
			}
		}
	}
}

