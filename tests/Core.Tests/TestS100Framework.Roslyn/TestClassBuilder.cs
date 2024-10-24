using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestS100Framework
{
    using System;
    using System.Linq;
    public class featureName
    {
        public String language { get; set; }
        public String name { get; set; }
        public Int32 nameUsage { get; set; }
    }



    public class featuresDetected
    {
        public Boolean leastDepthOfDetectedFeaturesMeasured { get; set; }
        public Boolean significantFeaturesDetected { get; set; }
        public Decimal sizeOfFeaturesDetected { get; set; }
    }



    public class fixedDateRange
    {
        public DateOnly dateEnd { get; set; }
        public DateOnly dateStart { get; set; }
    }



    public class frequencyPair
    {
        public Int32 frequencyShoreStationReceives { get; set; }
        public Int32 frequencyShoreStationTransmits { get; set; }
    }



    public class horizontalClearanceFixed
    {
        public Decimal horizontalClearanceValue { get; set; }
        public Decimal horizontalDistanceUncertainty { get; set; }
    }



    public class horizontalClearanceOpen
    {
        public Decimal horizontalClearanceValue { get; set; }
        public Decimal horizontalDistanceUncertainty { get; set; }
    }



    public class horizontalPositionUncertainty
    {
        public Decimal uncertaintyFixed { get; set; }
        public Decimal uncertaintyVariableFactor { get; set; }
    }



    public class information
    {
        public String fileLocator { get; set; }
        public String fileReference { get; set; }
        public String headline { get; set; }
        public String language { get; set; }
        public String text { get; set; }
    }



    public class measuredDistanceValue
    {
        public Int32 distanceUnitOfMeasurement { get; set; }
        public String referenceLocation { get; set; }
        public Decimal waterwayDistance { get; set; }
    }



    public class multiplicityOfFeatures
    {
        public Boolean multiplicityKnown { get; set; }
        public Int32 numberOfFeatures { get; set; }
    }



    public class onlineResource
    {
        public String headline { get; set; }
        public String linkage { get; set; }
        public String nameOfResource { get; set; }
    }



    public class orientation
    {
        public Decimal orientationUncertainty { get; set; }
        public Decimal orientationValue { get; set; }
    }



    public class periodicDateRange
    {
        public DateOnly dateEnd { get; set; }
        public DateOnly dateStart { get; set; }
    }



    public class radarWaveLength
    {
        public String radarBand { get; set; }
        public Decimal waveLengthValue { get; set; }
    }



    public class sectorInformation
    {
        public String language { get; set; }
        public String text { get; set; }
    }



    public class sectorLimitOne
    {
        public Decimal sectorBearing { get; set; }
        public Decimal sectorLineLength { get; set; }
    }



    public class sectorLimitTwo
    {
        public Decimal sectorBearing { get; set; }
        public Decimal sectorLineLength { get; set; }
    }



    public class shapeInformation
    {
        public String language { get; set; }
        public String text { get; set; }
    }



    public class signalSequence
    {
        public Decimal signalDuration { get; set; }
        public Int32 signalStatus { get; set; }
    }



    public class speed
    {
        public Decimal speedMaximum { get; set; }
        public Decimal speedMinimum { get; set; }
    }



    public class surfaceCharacteristics
    {
        public Int32 natureOfSurface { get; set; }
        public Int32[] natureOfSurfaceQualifyingTerms { get; set; }
        public Int32 underlyingLayer { get; set; }
    }



    public class surveyDateRange
    {
        public DateOnly dateEnd { get; set; }
        public DateOnly dateStart { get; set; }
    }



    public class telecommunications
    {
        public String contactInstructions { get; set; }
        public String telecommunicationIdentifier { get; set; }
        public Int32 telecommunicationService { get; set; }
    }



    public class tidalStreamValue
    {
        public orientation orientation { get; set; }
        public Decimal speedMaximum { get; set; }
        public Decimal timeRelativeToTide { get; set; }
    }



    public class timeIntervalsByDayOfWeek
    {
        public Int32[] dayOfWeek { get; set; }
        public Boolean dayOfWeekIsRange { get; set; }
        public TimeOnly[] timeOfDayStart { get; set; }
        public TimeOnly[] timeOfDayEnd { get; set; }
    }



    public class topmark
    {
        public Int32[] colour { get; set; }
        public Int32 colourPattern { get; set; }
        public Int32 topmarkDaymarkShape { get; set; }
        public shapeInformation[] shapeInformation { get; set; }
    }



    public class valueOfLocalMagneticAnomaly
    {
        public Decimal magneticAnomalyValue { get; set; }
        public Int32 referenceDirection { get; set; }
    }



    public class verticalUncertainty
    {
        public Decimal uncertaintyFixed { get; set; }
        public Decimal uncertaintyVariableFactor { get; set; }
    }



    public class vesselSpeedLimit
    {
        public Decimal speedLimit { get; set; }
        public Int32 speedUnits { get; set; }
        public String vesselClass { get; set; }
    }



    public class zoneOfConfidence
    {
        public Int32 categoryOfZoneOfConfidenceInData { get; set; }
        public fixedDateRange fixedDateRange { get; set; }
    }



    public class directionalCharacter
    {
        public Boolean moireEffect { get; set; }
        public orientation orientation { get; set; }
    }



    public class rhythmOfLight
    {
        public Int32 lightCharacteristic { get; set; }
        public String[] signalGroup { get; set; }
        public Decimal signalPeriod { get; set; }
        public signalSequence[] signalSequence { get; set; }
    }



    public class scheduleByDayOfWeek
    {
        public Int32 categoryOfSchedule { get; set; }
        public timeIntervalsByDayOfWeek[] timeIntervalsByDayOfWeek { get; set; }
    }



    public class sectorLimit
    {
        public sectorLimitOne sectorLimitOne { get; set; }
        public sectorLimitTwo sectorLimitTwo { get; set; }
    }



    public class spatialAccuracy
    {
        public fixedDateRange fixedDateRange { get; set; }
        public horizontalPositionUncertainty horizontalPositionUncertainty { get; set; }
        public verticalUncertainty verticalUncertainty { get; set; }
    }



    public class tidalStreamPanelValues
    {
        public Int32 referenceTide { get; set; }
        public Int32 referenceTideType { get; set; }
        public Decimal streamDepth { get; set; }
        public tidalStreamValue[] tidalStreamValue { get; set; }
    }



    public class verticalClearanceClosed
    {
        public Decimal verticalClearanceValue { get; set; }
        public verticalUncertainty verticalUncertainty { get; set; }
    }



    public class verticalClearanceFixed
    {
        public Decimal verticalClearanceValue { get; set; }
        public verticalUncertainty verticalUncertainty { get; set; }
    }



    public class verticalClearanceOpen
    {
        public Boolean verticalClearanceUnlimited { get; set; }
        public Decimal verticalClearanceValue { get; set; }
        public verticalUncertainty verticalUncertainty { get; set; }
    }



    public class verticalClearanceSafe
    {
        public Decimal verticalClearanceValue { get; set; }
        public verticalUncertainty verticalUncertainty { get; set; }
    }



    public class lightSector
    {
        public Int32[] colour { get; set; }
        public directionalCharacter directionalCharacter { get; set; }
        public Int32[] lightVisibility { get; set; }
        public sectorLimit sectorLimit { get; set; }
        public Decimal valueOfNominalRange { get; set; }
        public sectorInformation[] sectorInformation { get; set; }
        public Boolean sectorArcExtension { get; set; }
    }



    public class sectorCharacteristics
    {
        public Int32 lightCharacteristic { get; set; }
        public lightSector[]? lightSector { get; set; }
        public String[] signalGroup { get; set; }
        public Decimal signalPeriod { get; set; }
        public signalSequence[] signalSequence { get; set; }
    }




}
