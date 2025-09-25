<?xml version="1.0" encoding="UTF-8"?>
<!-- ============================================================================================= -->
<!--
  © Copyright 2018 (IHO)
	Prepared under NOAA contract
	
	License
  Certain parts of the text of this document refer to or are based on the standards of the International
  Organization for Standardization (ISO). The ISO standards can be obtained from any ISO member and from the
  Web site of the ISO Central Secretariat at www.iso.org.
    
  Permission to copy and distribute this document is hereby granted provided that this notice is retained
  on all copies, and that IHO & NOAA are credited when the material is redistributed or used in part or
	whole in derivative works.
	
  Certain parts of this work are derived from or were originally prepared as works for the UK Location Programme
  (UKLP) and GEMINI project and are (C) Crown copyright (UK). These parts are included under and subject to the
  terms of the Open Government license.

	Disclaimer	(Draft)
	This work is provided without warranty, expressed or implied, that it is complete or accurate or that it
	is fit for any particular purpose.  All such warranties are expressly disclaimed and excluded.
	
	Document history
	Version 1.0.0	Build 20181129	Initial draft Raphael Malyankar
-->

<!-- 
  This file contains the Schematron rules to enforce constraints on metadata that are specific to S-101.
  It must be used along with the generic S-100 schematron rules file, which enforces generic constraints.
-->
<!-- ============================================================================================= -->
<sch:schema xmlns:sch="http://purl.oclc.org/dsdl/schematron" schemaVersion="1.0.0-20181129">
  <!--<sch:ns prefix="fn" uri="http://www.w3.org/2005/xpath-functions"/>-->
  <sch:ns prefix="cat" uri="http://standards.iso.org/iso/19115/-3/cat/1.0"/>
  <sch:ns prefix="cit" uri="http://standards.iso.org/iso/19115/-3/cit/2.0"/>
  <sch:ns prefix="gco" uri="http://standards.iso.org/iso/19115/-3/gco/1.0"/>
  <sch:ns prefix="gcx" uri="http://standards.iso.org/iso/19115/-3/gcx/1.0"/>
  <sch:ns prefix="gex" uri="http://standards.iso.org/iso/19115/-3/gex/1.0"/>
  <sch:ns prefix="gmw" uri="http://standards.iso.org/iso/19115/-3/gmw/1.0"/>
  <sch:ns prefix="lan" uri="http://standards.iso.org/iso/19115/-3/lan/1.0"/>
  <sch:ns prefix="mac" uri="http://standards.iso.org/iso/19115/-3/mac/1.0"/>
  <sch:ns prefix="mas" uri="http://standards.iso.org/iso/19115/-3/mas/1.0"/>
  <sch:ns prefix="mcc" uri="http://standards.iso.org/iso/19115/-3/mcc/1.0"/>
  <sch:ns prefix="mco" uri="http://standards.iso.org/iso/19115/-3/mco/1.0"/>
  <sch:ns prefix="mdb" uri="http://standards.iso.org/iso/19115/-3/mdb/1.0"/>
  <sch:ns prefix="mex" uri="http://standards.iso.org/iso/19115/-3/mex/1.0"/>
  <sch:ns prefix="mmi" uri="http://standards.iso.org/iso/19115/-3/mmi/1.0"/>
  <sch:ns prefix="mpc" uri="http://standards.iso.org/iso/19115/-3/mpc/1.0"/>
  <sch:ns prefix="mrc" uri="http://standards.iso.org/iso/19115/-3/mrc/2.0"/>
  <sch:ns prefix="mrd" uri="http://standards.iso.org/iso/19115/-3/mrd/1.0"/>
  <sch:ns prefix="mri" uri="http://standards.iso.org/iso/19115/-3/mri/1.0"/>
  <sch:ns prefix="mrl" uri="http://standards.iso.org/iso/19115/-3/mrl/2.0"/>
  <sch:ns prefix="mrs" uri="http://standards.iso.org/iso/19115/-3/mrs/1.0"/>
  <sch:ns prefix="msr" uri="http://standards.iso.org/iso/19115/-3/msr/2.0"/>
  <sch:ns prefix="srv" uri="http://standards.iso.org/iso/19115/-3/srv/2.0"/>
  
  <sch:ns prefix="mds" uri="http://standards.iso.org/iso/19115/-3/mds/1.0"/>
  <sch:ns prefix="md1" uri="http://standards.iso.org/iso/19115/-3/md1/1.0"/>
  <sch:ns prefix="mda" uri="http://standards.iso.org/iso/19115/-3/mda/2.0"/>
  <sch:ns prefix="mdt" uri="http://standards.iso.org/iso/19115/-3/mdt/2.0"/>
  <sch:ns prefix="md2" uri="http://standards.iso.org/iso/19115/-3/md2/1.0"/>
  
  <sch:ns prefix="gml" uri="http://www.opengis.net/gml/3.2"/>
  <!--<sch:ns uri="http://www.isotc211.org/2005/gmi" prefix="gmi"/>-->
  <sch:ns uri="http://www.iho.int/s100/xc" prefix="S100XC"/>
    
  <sch:title>Schematron validation rules for S-127 Exchange Catalogues</sch:title>

  <sch:pattern fpi="S127_14.2.1.1">
    <sch:title>Omission of scale attributes in dataset discovery metadata</sch:title>
    <sch:rule context="//S100XC:S100_DatasetDiscoveryMetadata">
      <sch:assert test="count(S100XC:minimumDisplayScale|S100XC:maximumDisplayScale|S100XC:optimumDisplayScale) = 0">
        min/max/optimum display scales are not allowed in S-127 dataset discovery metadata. (<sch:value-of select="count(S100XC:minimumDisplayScale|S100XC:maximumDisplayScale|S100XC:optimumDisplayScale)"/> occurrences)
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <sch:pattern fpi="S127_14.2.1.2">
    <sch:title>Omission of vertical and sounding datum attributes in dataset discovery metadata</sch:title>
    <sch:rule context="//S100XC:S100_DatasetDiscoveryMetadata">
      <sch:assert test="count(S100XC:verticalDatum|S100XC:soundingDatum) = 0">
        Vertical and sounding datum are not allowed in S-127 dataset discovery metadata. (<sch:value-of select="count(S100XC:verticalDatum|S100XC:soundingDatum)"/> occurrences)
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <sch:pattern fpi="S127_14.2.1.3">
    <sch:title>Omission of scale attributes in dataCoverage attributes of discovery metadata</sch:title>
    <sch:rule context="//S100XC:S100_DatasetDiscoveryMetadata/S100XC:dataCoverage">
      <sch:assert test="count(S100XC:minimumDisplayScale|S100XC:maximumDisplayScale|S100XC:optimumDisplayScale) = 0">
        min/max/optimum display scales are not allowed in S-127 dataCoverage attributes of discovery metadata. (<sch:value-of select="count(S100XC:minimumDisplayScale|S100XC:maximumDisplayScale|S100XC:optimumDisplayScale)"/> occurrences)
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <sch:pattern fpi="S127_14.2.1.4">
    <sch:title>Datatype must be "GML"</sch:title>
    <sch:rule context="//S100XC:S100_DatasetDiscoveryMetadata/S100XC:dataType">
      <sch:assert test="text() = 'GML'">
        Dataset datatype must be GML (Actual value: <sch:value-of select="."/>)
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <sch:pattern fpi="S127_14.2.1.5">
    <sch:title>Support file datatype must be ASCII, HTML, XML, XSLT, TIFF, LUA</sch:title>
    <sch:rule context="//S100XC:supportFileDiscoveryMetadata/S100XC:dataType">
      <sch:assert test="contains('ASCII|HTML|XML|XSLT|TIFF|LUA', text())">
        Dataset datatype must be ASCII, HTML, XML, XSLT, TIFF, LUA (Actual value: <sch:value-of select="."/>)
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <sch:pattern fpi="S127_MD_L.1">
    <sch:title>Files referenced in dataset discovery metadata must be described by a supportFileMetadata element</sch:title>
    <sch:rule context="//S100XC:supportFileDiscoveryMetadataReference">
      <sch:let name="FNAME" value="text()"/>
      <sch:assert test="//S100XC:supportFileDiscoveryMetadata/S100XC:fileName[text() = $FNAME]">
        File referenced by dataset discovery metadata must be described in support file metadata element (Actual value: <sch:value-of select="."/>)
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <!-- Rules to test validity of bounding box coordinates (if any). Assumes lat/lon in decimal degrees, ranges +/-90.0 and +/-180.0. -->
  <sch:pattern is-a="S100_ValidBBoxPattern" fpi="S100_XC_ValidBBox">
    <sch:title>Validity of bounding box corners</sch:title>
      <sch:param name="bbox" value="//S100XC:boundingBox | //*[@gco:isoType = 'gmd:EX_GeographicBoundingBox']"/>
  </sch:pattern>

  <sch:pattern id="S100_ValidBBoxPattern" abstract="true" fpi="S100_BBox_LLDD_MinMax">
    <sch:title>Check the values of the bounding box min/max. Assumes values are latitude and longitude in decimal degrees in +/-90 or +/-180 range respectively.</sch:title>
    <sch:rule context="$bbox">
      <sch:assert test="gex:westBoundLongitude and (string-length(gex:westBoundLongitude) > 0) and (gex:westBoundLongitude >= -180.0) and (gex:westBoundLongitude &lt;= 180.0)" flag="badWB">
          westBoundLongitude must be present and in the range [-180.0, 180.0].
      </sch:assert>
      <sch:assert test="gex:eastBoundLongitude and (string-length(gex:eastBoundLongitude) > 0) and (gex:eastBoundLongitude >= -180.0) and (gex:eastBoundLongitude &lt;= 180.0)" flag="badEB">
          eastBoundLongitude must be present and in the range [-180.0, 180.0].
      </sch:assert>
      <sch:assert test="gex:southBoundLatitude and (string-length(gex:southBoundLatitude) > 0) and (gex:southBoundLatitude >= -90.0) and (gex:southBoundLatitude &lt;= 90.0)" flag="badSB">
          southBoundLatitude must be present and in the range [-90.0, 90.0].
      </sch:assert>
      <sch:assert test="gex:northBoundLatitude and (string-length(gex:northBoundLatitude) > 0) and (gex:northBoundLatitude >= -90.0) and (gex:northBoundLatitude &lt;= 90.0)" flag="badNB">
          northBoundLatitude must be present and in the range [-90.0, 90.0].
      </sch:assert>
      <sch:assert test="not(badEB or badWB) and (gex:westBoundLongitude &lt; gex:eastBoundLongitude)">
        westBoundLongitude (<sch:value-of select="gex:westBoundLongitude"/>) must be less than eastBoundLongitude (<sch:value-of select="gex:eastBoundLongitude"/>)
      </sch:assert>
      <sch:assert test="not(badNB or badSB) and (gex:southBoundLatitude &lt; gex:northBoundLatitude)">
        northBoundLatitude (<sch:value-of select="gex:northBoundLatitude"/>) must be greater than southBoundLatitude (<sch:value-of select="gex:southBoundLatitude"/>)
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <!-- Test for availability or nilling of reference to ISO 19115 metadata file -->
  <sch:pattern fpi="S100_XC_ISO19115Filename">
    <sch:rule context="//S100XC:S100_DatasetDiscoveryMetadata/S100XC:S100_19115DatasetMetadata">
      <sch:assert test="@gco:nilReason or gcx:FileName[string-length(normalize-space(@src)) > 0]">
        Reference to ISO 19115 metadata file must be nilled or have the gcx:FileName@src attribute populated.
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <!-- Tests that mandatory elements with string types are non-empty / non-blank.    -->
  <!-- Test for identifier sub-element of exchange catalogue. -->
  <sch:pattern fpi="S100_XC_cString_generic_exchangecatalog">
    <sch:title>Rule to check for presence of mandatory elements of type string</sch:title>
    <sch:rule context="/S100XC:S100_ExchangeCatalogue/S100XC:identifier/S100XC:identifier 
      | /S100XC:S100_ExchangeCatalogue/S100XC:identifier/S100XC:editionNumber
      | /S100XC:S100_ExchangeCatalogue/S100XC:exchangeCatalogueName
      | /S100XC:S100_ExchangeCatalogue/S100XC:exchangeCatalogueDescription|/S100XC:S100_ExchangeCatalogue/S100XC:metadataLanguage">
      <sch:assert test="string-length(normalize-space())"><sch:name/> must contain a string value that is not all whitespace</sch:assert>
    </sch:rule>
  </sch:pattern>


  <!-- Test for sub-elements of product specification sub-element of dataset discovery -->
  <sch:pattern fpi="S100_XC_cString_generic_productSpecification">
    <sch:title>Rule to check for presence of mandatory elements of type string</sch:title>
    <sch:rule context="//S100XC:datasetDiscoveryMetadata/S100XC:productSpecification/S100XC:name 
      | //S100XC:datasetDiscoveryMetadata/S100XC:productSpecification/S100XC:version">
      <sch:assert test="string-length(normalize-space())"><sch:name/> must contain a string value that is not all whitespace</sch:assert>
    </sch:rule>
  </sch:pattern>

  <!-- rule to check that role is either nilled or not empty -->
  <sch:pattern fpi="S100_XC_DSMD_role_Nillable">
    <sch:rule context="/S100XC:S100_ExchangeCatalogue/S100XC:datasetDiscoveryMetadata//cit:role">
    <sch:assert test="(count(*) > 0) or (@gco:nilReason = 'inapplicable' or
      @gco:nilReason = 'missing' or 
      @gco:nilReason = 'template' or
      @gco:nilReason = 'unknown' or
      @gco:nilReason = 'withheld' or
      starts-with(@gco:nilReason, 'other:'))" flag="isNilled">
      The <sch:name/> element shall have a value or a valid Nil Reason.
    </sch:assert>
      <sch:assert test="isNilled or (cit:CI_RoleCode and (string-length(cit:CI_RoleCode/@codeListValue) > 0))">
        The codeListValue attribute does not have a value.
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <!-- 
    Rule to require support file name to be populated in S100_SupportFileDiscoveryMetadata.
  -->
  <sch:pattern fpi="S100_XC_productSpecification">
    <sch:rule context="//S100XC:supportFileDiscoveryMetadata/S100XC:supportFileSpecification">
      <sch:assert test="string-length(normalize-space(S100XC:name)) > 0">
        The name element of support file discovery metadata must be populated.
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <!-- Rule to require support file specification date and version to be populated in S100_SupportFileDiscoveryMetadata if dataType is not Text, text, or ASCII -->
  <sch:pattern fpi="S100_XC_productSpecification_1">
    <sch:rule context="//S100XC:supportFileDiscoveryMetadata" role="warn">
      <sch:report test="not(contains('Text,text,ASCII', S100XC:dataType) or (string-length(normalize-space(S100XC:supportFileSpecification/S100XC:date)) > 0) and ((string-length(normalize-space(S100XC:supportFileSpecification/S100XC:version)) > 0)))">
        Warning: Support file discovery metadata element for non-text support files should contain a supportFileSpecification element with date and version populated
      </sch:report>
    </sch:rule>
  </sch:pattern>
  
  
  <!-- ========================================================================================== -->
  <!-- Abstract Patterns                                                                          -->
  <!-- ========================================================================================== -->
  <!-- none -->

</sch:schema>