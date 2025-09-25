<?xml version="1.0" encoding="UTF-8"?>
<sch:schema xmlns:sch="http://purl.oclc.org/dsdl/schematron" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" queryBinding="xslt2"
    xmlns:sqf="http://www.schematron-quickfix.com/validator/process" schemaVersion="1.0.0-20181129">
<!-- ============================================================================================= -->
<!-- Schematron rules for validation of S-127 GML datasets.                                      -->
<!-- ============================================================================================= -->
    
<!-- =============================================================================================
Draft Copyright, license, and disclaimer
© Copyright 2018 IHO

License
Certain parts of this document refer to or are based on the standards, documents, schemas, or other material
of the International Organization for Standardization (ISO), Open Geospatial Consortium (OGC), International
Hydrographic Organization / Organisation Hydrographique Internationale (IHO/OHI), or International
Association of Marine Aids to Navigation and Lighthouse Authorities / Association Internationale de
Signalisation Maritime (IALA/AISM).
The ISO material can be obtained from any ISO member and from the Web site of the ISO Central Secretariat
at www.iso.org.
The OGC material can be obtained from the OGC Web site at www.opengeospatial.org.
The IHO material can be obtained from the IHO Web site at www.iho.int or from the International Hydrographic
Bureau.
The IALA material can be obtained from the IALA Secretariat or the IALA Web site at www.iala-aism.org.

Permission to copy and distribute this document is hereby granted provided that this notice is retained
on all copies, and that IHO and IALA, and GLA are credited when the material is redistributed or used in
part or whole in derivative works.
Redistributions in binary form must reproduce this notice in the documentation and/or other materials
provided with the distribution.

Disclaimer
This work is provided by the copyright holders and contributors "as is" and any express or implied warranties,
including, but not limited to, the implied warranties of merchantability and fitness for a particular purpose
are disclaimed. In no event shall the copyright owner or contributors be liable for any direct, indirect,
incidental, special, exemplary, or consequential damages (including, but not limited to, procurement of substitute
goods or services; loss of use, data, or profits; or business interruption) however caused and on any theory of
liability, whether in contract, strict liability, or tort (including negligence or otherwise) arising in any way
out of the use of this software, even if advised of the possibility of such damage.

Document history
Version 1.0.0	2018-11-29	Raphael Malyankar	Initial version
================================================================================================== -->
<!-- Note: This is a set of basic tests for restrictions of supertype geometry in sub-types, as well as
    some basic integrity checks. It is not an implementation of the validation tests.
  It is designed for base datasets only.
-->

  <sch:ns prefix="gco" uri="http://www.isotc211.org/2005/gco"/>
  <sch:ns prefix="gmd" uri="http://www.isotc211.org/2005/gmd"/>
  <sch:ns prefix="gmx" uri="http://www.isotc211.org/2005/gmx"/>
  <sch:ns prefix="gml" uri="http://www.opengis.net/gml/3.2"/>
  <sch:ns prefix="S100" uri="http://www.iho.int/s100gml/1.0"/>
  <sch:ns prefix="xlink" uri="http://www.w3.org/1999/xlink"/>
  <sch:ns uri="http://www.iho.int/S127/gml/cs0/1.0" prefix="S127"/>

  <sch:title>Schematron validation rules for basic integrity checks of S-122 datasets</sch:title>

<!-- Validation rule to check that references in associations between features and other types of objects exist in the dataset. -->
  <sch:pattern id="VALIDATE_ASSOCIATIONS">
    <!-- Rule permits references as either "#gmlidoftarget" or "gmlidoftarget". -->
    <sch:rule id="CHK_HREFS" context="//member/*/*[@xlink:href]">
      <sch:let name="HREF" value="string(@xlink:href)"/>
      <sch:let name="HREF_FRAG" value="substring-after($HREF, '#')"/>
      <sch:assert test="exists(//*/*[@gml:id = $HREF  or @gml:id = $HREF_FRAG])">Object with ID '<sch:value-of select="$HREF"/>' not found in dataset [idCode '<sch:value-of select="../idCode"/>', gml:id <sch:value-of select="../@gml:id"/>] </sch:assert>
    </sch:rule>
  </sch:pattern>

    <!-- Validation rule to check that references in associations between info types and other types of objects. -->
    <sch:pattern id="VALIDATE_INFOTYPE_ASSOCIATIONS">
      <!-- Rule permits references as either "#gmlidoftarget" or "gmlidoftarget". -->
      <sch:rule id="CHK_INFO_HREFS" context="//imember/*/*[@xlink:href]">
        <sch:let name="HREF" value="string(@xlink:href)"/>
        <sch:let name="HREF_FRAG" value="substring-after($HREF, '#')"/>
        <sch:assert test="exists(//*/*[@gml:id = $HREF  or @gml:id = $HREF_FRAG])">Object with ID '<sch:value-of select="$HREF"/>' not found in dataset [idCode '<sch:value-of select="../idCode"/>', gml:id <sch:value-of select="../@gml:id"/>] </sch:assert>
      </sch:rule>
    </sch:pattern>

    <!-- Rule permits references as either "#gmlidoftarget" or "gmlidoftarget". -->
  <sch:pattern>
    <sch:rule id="CHK_SPATIALQ_HREFS" context="//member/*/geometry//S100:informationAssociation[@xlink:href]">
      <sch:let name="HREF" value="string(@xlink:href)"/>
      <sch:let name="HREF_FRAG" value="substring-after($HREF, '#')"/>
      <sch:assert test="exists(//imember/*[@gml:id = $HREF or @gml:id = $HREF_FRAG])">Spatial Quality with ID '<sch:value-of select="$HREF"/>' not found in dataset</sch:assert>
    </sch:rule>
  </sch:pattern>

  <!-- Components of dateEnd must be a complete date, or year, or year+month. Month+day and day of month do not have a meaning in the context of dateEnd. -->
  <sch:pattern id="DATEND_1">
    <sch:rule id="DATX_TYPE_1" context="//member/*[(count(dateEnd) gt 0)]">
      <sch:let name="DATEND_TYPE" value="local-name(dateEnd/*)"/>
      <sch:assert test="($DATEND_TYPE = 'date' or $DATEND_TYPE = 'gYear' or $DATEND_TYPE = 'gYearMonth')">
        Components of dateEnd (<sch:value-of select="$DATEND_TYPE"/>) must be 'date', 'gYear', or 'gYearMonth' [idCode '<sch:value-of select="idCode"/>', gml:id <sch:value-of select="@gml:id"/>]
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <sch:pattern id="DATEND_2">
    <sch:rule id="DATX_TYPE_1A" context="//surveyDateRange[(count(dateEnd) gt 0)]">
      <sch:let name="DATEND_TYPE" value="local-name(dateEnd/*)"/>
      <sch:assert test="($DATEND_TYPE = 'date' or $DATEND_TYPE = 'gYear' or $DATEND_TYPE = 'gYearMonth')">
        Components of dateEnd (<sch:value-of select="$DATEND_TYPE"/>) must be 'date', 'gYear', or 'gYearMonth' [idCode '<sch:value-of select="ancestor-or-self::idCode"/>', gml:id <sch:value-of select="ancestor-or-self::node()/@gml:id"/>]
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <!-- Components of dateStart must be a complete date, or year, or year+month. Month+day and day of month do not have a meaning in the context of dateStart. -->
  <sch:pattern id="DATSTA_1">
    <sch:rule id="DATX_TYPE_2" context="//member/*[(count(dateStart) gt 0)]">
      <sch:let name="DATSTA_TYPE" value="local-name(dateStart/*)"/>
      <sch:assert test="($DATSTA_TYPE = 'date' or $DATSTA_TYPE = 'gYear' or $DATSTA_TYPE = 'gYearMonth')">
        Components of dateStart (<sch:value-of select="$DATSTA_TYPE"/>) must be 'date', 'gYear', or 'gYearMonth' [idCode '<sch:value-of select="idCode"/>', gml:id <sch:value-of select="@gml:id"/>] </sch:assert>
    </sch:rule>
  </sch:pattern>
  <sch:pattern id="DATSTA_2">
    <sch:rule id="DATX_TYPE_2A" context="//surveyDateRange[(count(dateStart) gt 0)]">
      <sch:let name="DATSTA_TYPE" value="local-name(dateStart/*)"/>
      <sch:assert test="($DATSTA_TYPE = 'date' or $DATSTA_TYPE = 'gYear' or $DATSTA_TYPE = 'gYearMonth')">
        Components of dateEnd (<sch:value-of select="$DATSTA_TYPE"/>) must be 'date', 'gYear', or 'gYearMonth' [idCode '<sch:value-of select="ancestor-or-self::idCode"/>', gml:id <sch:value-of select="ancestor-or-self::node()/@gml:id"/>]
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <!-- Date end must be after date start, if both are present -->
  <sch:pattern id="DATEND_DATSTA">
    <sch:rule id="DATEND_DATSTA_COMP" context="//member/*[(count(dateEnd) gt 0) and (count(dateStart) gt 0)]">
      <sch:let name="DATEND_TYPE" value="local-name(dateEnd/*)"/>
      <sch:let name="DATSTA_TYPE" value="local-name(dateStart/*)"/>
      <!--<sch:report test="$DATEND_TYPE != $DATSTA_TYPE">Attributes dateEnd (<sch:value-of select="$DATEND_TYPE"/>: <sch:value-of select="dateEnd"/>) is not of the same granularity as dateStart (<sch:value-of select="$DATSTA_TYPE"/>: <sch:value-of select="dateStart"/>) [idCode '<sch:value-of select="idCode"/>', gml:id <sch:value-of select="@gml:id"/>] </sch:report>-->
      <sch:assert test="compare(dateEnd/*, dateStart/*) = 1">Value of attribute dateEnd (<sch:value-of select="dateEnd"/>) must be after dateStart (<sch:value-of select="dateStart"/>) [idCode '<sch:value-of select="idCode"/>', gml:id <sch:value-of select="@gml:id"/>] </sch:assert>
    </sch:rule>

    <sch:rule id="SURVEY_DATEND_DATSTA_COMP" context="//surveyDateRange[(count(dateEnd) gt 0) and (count(dateStart) gt 0)]">
      <sch:let name="DATEND_TYPE" value="local-name(dateEnd/*)"/>
      <sch:let name="DATSTA_TYPE" value="local-name(dateStart/*)"/>
      <!--<sch:report test="$DATEND_TYPE != $DATSTA_TYPE">Attributes dateEnd (<sch:value-of select="$DATEND_TYPE"/>: <sch:value-of select="dateEnd"/>) is not of the same granularity as dateStart (<sch:value-of select="$DATSTA_TYPE"/>: <sch:value-of select="dateStart"/>) [idCode '<sch:value-of select="ancestor-or-self::idCode"/>', gml:id <sch:value-of select="ancestor-or-self::node()/@gml:id"/>] </sch:report>-->
      <sch:assert test="compare(dateEnd/*, dateStart/*) = 1">Value of attribute dateEnd (<sch:value-of select="dateEnd"/>) must be after dateStart (<sch:value-of select="dateStart"/>) [idCode '<sch:value-of select="ancestor-or-self::idCode"/>', gml:id <sch:value-of select="ancestor-or-self::node()/@gml:id"/>] </sch:assert>
    </sch:rule>
  </sch:pattern>
  
  <!-- Check that period end and start are both present if either is present. -->
  <sch:pattern id="PERIODCHK1">
    <sch:rule id="PEREND_1" context="//member/*[(count(periodEnd) gt 0) or (count(periodStart) gt 0)]">     
      <sch:assert test="exists(periodEnd) and exists(periodStart) and (count(periodEnd) = count(periodStart))">Start and end of period are both required if one is present [idCode '<sch:value-of select="idCode"/>', gml:id <sch:value-of select="@gml:id"/>]</sch:assert>
    </sch:rule>
  </sch:pattern>

  <!-- Check that period end and start use the same components (they are not comparable otherwise) -->
  <sch:pattern id="PERIODCHK2">
    <!-- (Rule assumes 0 or 1 period end/start) -->
    <sch:rule id="PERIODSTYPE_1" context="//member/*[(count(periodEnd) gt 0) and (count(periodStart) gt 0)]">     
      <sch:assert test="local-name(periodEnd/*) = local-name(periodStart/*)">Attribute periodEnd (<sch:value-of select="local-name(periodEnd/*)"/>: <sch:value-of select="periodEnd"/>) does not have the same components as periodStart (<sch:value-of select="local-name(periodStart/*)"/>: <sch:value-of select="periodStart"/>) [idCode '<sch:value-of select="idCode"/>', gml:id <sch:value-of select="@gml:id"/>]</sch:assert>
    </sch:rule>
</sch:pattern>

  <!-- At least one sub-attribute of contact address must be present -->
  <sch:pattern id="CADDRESS_NONEMPTY">
    <sch:rule id="CADDRESS.NULLITY" context="//contactAddress">
      <sch:assert test="string-length(normalize-space()) gt 0">
        At least one sub-attribute of contact address must be given. [idCode '<sch:value-of select="../idCode"/>', gml:id <sch:value-of select="../@gml:id"/>]
      </sch:assert>
    </sch:rule>
  </sch:pattern>

  <!-- The following rules check for class-specific restrictions on the allowed values of enumeration attributes -->
  <sch:pattern id="MilitaryPracticeArea.1">
    <sch:let name="MIPARE.restriction" value="'1 : anchoring prohibited|
      2 : anchoring restricted|
      3 : fishing prohibited|
      4 : fishing restricted|
      5 : trawling prohibited|
      6 : trawling restricted|
      7 : entry prohibited|
      8 : entry restricted|
      9 : dredging prohibited|
      10 : dredging restricted|
      11 : diving prohibited|
      12 : diving restricted|
      13 : no wake|
      15 : construction prohibited|
      16 : discharging prohibited|
      17 : discharging restricted|
      18 : industrial or mineral exploration/development prohibited|
      19 : industrial or mineral exploration/development restricted|
      20 : drilling prohibited|
      21 : drilling restricted|
      22 : removal of historical artifacts prohibited|
      23 : cargo transhipment (lightering) prohibited|
      24 : dragging prohibited|
      25 : stopping prohibited|
      26 : landing prohibited|
      27 : speed restricted|
      39 : swimming prohibited'"></sch:let>
    <sch:let name="MIPARE.status" value="'1 : permanent|2 : occasional|5 : periodic/intermittent|6 : reserved|7 : temporary|16 : watched|17 : un-watched|'"></sch:let>
    <sch:rule context="//S127:MilitaryPracticeArea/restriction">
      <sch:report test="not(contains($MIPARE.restriction, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
    <sch:rule context="//S127:MilitaryPracticeArea/status">
      <sch:report test="not(contains($MIPARE.status, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
  </sch:pattern>

  <sch:pattern id="RestrictedAreaRegulatory.1">
    <sch:let name="ResAreaReg.restriction" value="'3 : fishing prohibited|
      4 : fishing restricted|
      5 : trawling prohibited|
      6 : trawling restricted|
      9 : dredging prohibited|
      10 : dredging restricted|
      11 : diving prohibited|
      12 : diving restricted|
      15 : construction prohibited|
      16 : discharging prohibited|
      17 : discharging restricted|
      18 : industrial or mineral exploration/development prohibited|
      19 : industrial or mineral exploration/development restricted|
      20 : drilling prohibited|
      21 : drilling restricted|
      22 : removal of historical artifacts prohibited|
      23 : cargo transhipment (lightering) prohibited|
      24 : dragging prohibited|
      39 : swimming prohibited'"></sch:let>
    <sch:let name="ResAreaReg.status" value="'1 : permanent|2 : occasional|3 : recommended|4 : not in use|5 : periodic/intermittent|6 : reserved|7 : temporary|9 : mandatory|18 : existence doubtful|28 : buoyed'"/>
    <sch:rule context="//S127:RestrictedAreaRegulatory/restriction">
      <sch:report test="not(contains($ResAreaReg.restriction, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
    <sch:rule context="//S127:RestrictedAreaRegulatory/status">
      <sch:report test="not(contains($ResAreaReg.status, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
  </sch:pattern>

  <sch:pattern id="RestrictedAreaNavigational.1">
    <sch:let name="ResAreaNav.restriction" value="'fishing prohibited|fishing restricted|trawling prohibited|trawling restricted|dredging prohibited|dredging restricted|diving prohibited|diving restricted|construction prohibited|discharging prohibited|discharging restricted|industrial or mineral exploration/development prohibited|industrial or mineral exploration/development restricted|drilling prohibited|drilling restricted|removal of historical artifacts prohibited|cargo transhipment (lightering) prohibited|dragging prohibited|swimming prohibited'"></sch:let>
    <sch:let name="ResAreaNav.status" value="'1 : permanent|
      2 : occasional|
      3 : recommended|
      4 : not in use|
      5 : periodic/intermittent|
      6 : reserved|
      7 : temporary|
      9 : mandatory|
      18 : existence doubtful|
      28 : buoyed'"/>
    <sch:rule context="//S127:RestrictedAreaNavigational/restriction" id="RestrictedAreaNavigational.R1">
      <sch:report test="not(contains($ResAreaNav.restriction, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
    <sch:rule context="//S127:RestrictedAreaNavigational/status" >
      <sch:report test="not(contains($ResAreaNav.status, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>

  </sch:pattern>

  <sch:pattern id="CautionArea.1">
    <sch:let name="CTNARE.status" value="'5 : periodic/intermittent|7 : temporary'"/>
    <sch:rule id="CautionArea.status" context="//S127:CautionArea/status">
      <sch:report test="not(contains($CTNARE.status, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
  </sch:pattern>

  <sch:pattern id="ConcShipHazard.1">
    <sch:let name="ConcShipHazard.status" value="'1 : permanent|2 : occasional|5 : periodic/intermittent|7 : temporary|16 : watched|17 : un-watched'"/>
    <sch:rule id="CONSHA.status" context="//S127:ConcentrationOfShippingHazardArea/status">
      <sch:report test="not(contains($ConcShipHazard.status, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
  </sch:pattern>

  <sch:pattern id="PilotBoardingPlace.1">
    <sch:let name="PilotBoardingPlace.status" value="'1 : permanent|2 : occasional|5 : periodic/intermittent|6 : reserved|9 : mandatory|16 : watched|17 : un-watched|28 : buoyed'"/>
    <sch:rule id="PILBOP.status" context="//S127:PilotBoardingPlace/status">
      <sch:report test="not(contains($PilotBoardingPlace.status, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
  </sch:pattern>

  <sch:pattern id="PiracyRiskArea.1">
    <sch:let name="PIRARE.status" value="'1 : permanent|2 : occasional|5 : periodic/intermittent|7 : temporary'"/>
    <sch:let name="PIRARE.restriction" value="'1 : anchoring prohibited|
      2 : anchoring restricted|
      3 : fishing prohibited|
      4 : fishing restricted|
      5 : trawling prohibited|
      6 : trawling restricted|
      7 : entry prohibited|
      8 : entry restricted|
      9 : dredging prohibited|
      10 : dredging restricted|
      11 : diving prohibited|
      12 : diving restricted|
      14 : area to be avoided|
      18 : industrial or mineral exploration/development prohibited|
      19 : industrial or mineral exploration/development restricted|
      20 : drilling prohibited|
      21 : drilling restricted|
      24 : dragging prohibited|
      25 : stopping prohibited|
      26 : landing prohibited|
      27 : speed restricted|
      31 : berthing prohibited|
      32 : berthing restricted|
      33 : making fast prohibited|
      34 : making fast restricted'"></sch:let>
    <sch:rule context="//S127:PiracyRiskArea/restriction">
      <sch:report test="not(contains($PIRARE.restriction, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
    <sch:rule context="//S127:PiracyRiskArea/status">
      <sch:report test="not(contains($PIRARE.status, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
  </sch:pattern>

  <sch:pattern id="PlaceOfRefuge.1">
    <sch:let name="PlaceOfRefuge.status" value="'1 : permanent|2 : occasional|3 : recommended|4 : not in use|5 : periodic/intermittent|6 : reserved|7 : temporary|8 : private|9 : mandatory|28 : buoyed'"/>
    <sch:rule context="//S127:PlaceOfRefuge/status">
      <sch:report test="not(contains($PlaceOfRefuge.status, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
  </sch:pattern>

  <sch:pattern id="RadarRange.1">
    <sch:let name="RadarRange.status" value="'1 : permanent|2 : occasional|4 : not in use|7 : temporary'"/>
    <sch:rule context="//S127:RadarRange/status">
      <sch:report test="not(contains($RadarRange.status, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
  </sch:pattern>

  <sch:pattern id="RadioCallingInPoint.1">
    <sch:let name="RDOCAL.status" value="'1 : permanent|3 : recommended|4 : not in use|5 : periodic/intermittent|6 : reserved|7 : temporary|9 : mandatory'"></sch:let>
    <sch:rule context="//S127:RadioCallingInPoint/status">
      <sch:report test="not(contains($RDOCAL.status, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
  </sch:pattern>

  <sch:pattern id="SignalStationWarning.1">
    <sch:let name="SISTAW.status" value="'1 : permanent|2 : occasional|4 : not in use|5 : periodic/intermittent|7 : temporary|8 : private|12 : illuminated|14 : public|15 : synchronized|16 : watched|17 : un-watched'"/>
    <sch:rule context="//S127:SignalStationWarning/status">
      <sch:report test="not(contains($SISTAW.status, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
  </sch:pattern>

  <sch:pattern id="SignalStationTraffic.1">
    <sch:let name="SISTAT.status" value="'1 : permanent|2 : occasional|4 : not in use|5 : periodic/intermittent|7 : temporary|8 : private|12 : illuminated|14 : public|15 : synchronized|16 : watched|17 : un-watched'"/>
    <sch:rule id="SignalStationTraffic.status" context="//S127:SignalStationTraffic/status">
      <sch:report test="not(contains($SISTAT.status, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
  </sch:pattern>

  <sch:pattern id="WaterwayArea.1">
    <sch:let name="WaterwayArea.status" value="'1 : permanent|2 : occasional|3 : recommended|4 : not in use|5 : periodic/intermittent|6 : reserved|7 : temporary|8 : private|9 : mandatory|28 : buoyed'"/>
    <sch:rule context="//S127:WaterwayArea/status">
      <sch:report test="not(contains($WaterwayArea.status, .))">Warning: Unexpected value "<sch:value-of select="."/>" in <sch:name path="."/> attribute (<sch:name path=".."/>, id=<sch:value-of select="../@gml:id"/>)</sch:report>
    </sch:rule>
  </sch:pattern>


</sch:schema>