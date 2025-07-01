using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        internal static WindTurbine CreateWindturbine(CulturalFeaturesP current, Geodatabase source) {
            var instance = new WindTurbine();

            if (current.COLOUR != default) {
                instance.colour = ImporterNIS.GetColours(current.COLOUR);
            }

            if (current.COLPAT != default) {
                instance.colourPattern = ImporterNIS.GetColourPattern(current.COLPAT);
            }

            if (current.CONDTN.HasValue) {
                instance.condition = ImporterNIS.GetCondition(current.CONDTN.Value);
            }

            if (current.ELEVAT.HasValue) {
                instance.elevation = current.ELEVAT.Value;
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            // TODO: interoperabilityIdentifier

            // TODO: multiplicityOfFeatures

            if (current.NATCON != default) {
                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
            }

            if (current.CONRAD.HasValue) {
                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
            }

            if (current.SORDAT != default) {
                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                    instance.reportedDate = current.SORDAT;
                }
                else {
                    Logger.Current.DataError(current.OBJECTID.GetValueOrDefault(), current.TableName ?? "Unknown tablename", current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                }
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            // TODO: verticalClearanceFixed		

            
            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;

                instance.verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 3);

            }

            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
            }

            if (current.WATLEV.HasValue) {
                if (current.WATLEV.Value == -32767)
                    instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(-1);
                else {
                    instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV);
                }
            }

            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
            }

            return instance;

        }
    }
}