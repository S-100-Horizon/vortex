<?xml version="1.0" encoding="UTF-8"?>
<S201:Dataset xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:gml="http://www.opengis.net/gml/3.2" xmlns:S100="http://www.iho.int/s100gml/5.0" xmlns:S201="http://www.iho.int/S201/gml/cs0/1.0" xmlns="http://www.iho.int/S201/gml/cs0/1.0" gml:id="ds">
  <gml:boundedBy>
    <gml:Envelope srsName="http://www.opengis.net/def/crs/EPSG/0/4326">
      <gml:lowerCorner>50.0030816 -66.8357905</gml:lowerCorner>
      <gml:upperCorner>50.0157839 -66.8219951</gml:upperCorner>
    </gml:Envelope>
  </gml:boundedBy>
  <S100:DatasetIdentificationInformation>
    <S100:encodingSpecification>S-100 Part 10b</S100:encodingSpecification>
    <S100:encodingSpecificationEdition>1.0</S100:encodingSpecificationEdition>
    <S100:productIdentifier>INT.IHO.S-201.1.0</S100:productIdentifier>
    <S100:productEdition>1.0.0</S100:productEdition>
    <S100:applicationProfile>1</S100:applicationProfile>
    <S100:datasetFileIdentifier>201CAtestgml.gml</S100:datasetFileIdentifier>
    <S100:datasetTitle>201CAtestgml</S100:datasetTitle>
    <S100:datasetReferenceDate>2022-03-31</S100:datasetReferenceDate>
    <S100:datasetLanguage>eng</S100:datasetLanguage>
    <S100:datasetTopicCategory>oceans</S100:datasetTopicCategory>
    <S100:datasetTopicCategory>transportation</S100:datasetTopicCategory>
    <S100:datasetPurpose>base</S100:datasetPurpose>
    <S100:updateNumber>0</S100:updateNumber>
  </S100:DatasetIdentificationInformation>
  <members>
    <MooringShackle gml:id="f6">
      <idCode>568</idCode>
      <connectedTo xlink:href="#f5" xlink:arcrole="http://www.iho.net/S-201/roles/connectedTo" xlink:title="ShackleConnection"/>
    </MooringShackle>
    <BuoyInstallation gml:id="f5">
      <idCode>567</idCode>
      <aidAvailabilityCategory  code="1">Category 1</aidAvailabilityCategory>
      <buoyShape  code="2">can (cylindrical)</buoyShape>
      <colour  code="3">red</colour>
      <categoryOfInstallationBuoy  code="2">single buoy mooring (SBM or SPM)</categoryOfInstallationBuoy>
      <child xlink:href="#f4" xlink:arcrole="http://www.iho.net/S-201/roles/child" xlink:title="StructureEquipment"/>
      <connected xlink:href="#f6" xlink:arcrole="http://www.iho.net/S-201/roles/connected" xlink:title="ShackleConnection"/>
      <geometry>
        <S100:pointProperty >
          <S100:Point srsName="http://www.opengis.net/def/crs/EPSG/0/4326" gml:id="f5_p2">
            <gml:pos>50.0108085 -66.8290813</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </BuoyInstallation>
    <Topmark gml:id="f4">
      <idCode>555</idCode>
      <colour  code="6">yellow</colour>
      <topmarkDaymarkShape  code="3">sphere</topmarkDaymarkShape>
      <parent xlink:href="#f5" xlink:arcrole="http://www.iho.net/S-201/roles/parent" xlink:title="StructureEquipment"/>
      <geometry>
        <S100:pointProperty scaleMinimum="50000" >
          <S100:Point srsName="http://www.opengis.net/def/crs/EPSG/0/4326" gml:id="f4_p2">
            <gml:pos>50.0108085 -66.8290813</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Topmark>
    <OffshorePlatform gml:id="f3">
      <idCode>777</idCode>
      <featureName>
        <displayName>true</displayName>
        <language>eng</language>
        <name>Bigfoot</name>
      </featureName>
      <aidAvailabilityCategory  code="2">Category 2</aidAvailabilityCategory>
      <mannedStructure>true</mannedStructure>
      <geometry>
        <S100:surfaceProperty >
          <S100:Surface srsName="http://www.opengis.net/def/crs/EPSG/0/4326" gml:id="f3_s1">
            <gml:patches>
              <gml:PolygonPatch>
                <gml:exterior>
                  <gml:Ring>
                    <gml:curveMember>
                      <S100:CompositeCurve srsName="http://www.opengis.net/def/crs/EPSG/0/4326" gml:id="f3_s1_cc2">
                      <gml:curveMember>
                        <S100:OrientableCurve srsName="http://www.opengis.net/def/crs/EPSG/0/4326" gml:id="f3_s1_cc2_oc2" orientation="+">
                          <gml:baseCurve>
                          <S100:Curve srsName="http://www.opengis.net/def/crs/EPSG/0/4326" gml:id="f3_s1_cc2_oc2_c2">
                            <gml:segments>
                              <gml:LineStringSegment>
                                <gml:posList>50.0140123 -66.8270083 50.0157839 -66.8256137 50.0153692 -66.8230506 50.0128816 -66.8251237 50.0140123 -66.8270083</gml:posList>
                              </gml:LineStringSegment>
                            </gml:segments>
                          </S100:Curve>
                          </gml:baseCurve>
                        </S100:OrientableCurve>
                        </gml:curveMember>
                      </S100:CompositeCurve>
                    </gml:curveMember>
                  </gml:Ring>
                </gml:exterior>
              </gml:PolygonPatch>
            </gml:patches>
          </S100:Surface>
        </S100:surfaceProperty>
      </geometry>
    </OffshorePlatform>
    <Landmark gml:id="f2">
      <idCode>123</idCode>
      <aidAvailabilityCategory  code="1">Category 1</aidAvailabilityCategory>
      <categoryOfLandmark  code="19">windmotor</categoryOfLandmark>
      <visualProminence  code="1">visually conspicuous</visualProminence>
      <geometry>
        <S100:pointProperty >
          <S100:Point srsName="http://www.opengis.net/def/crs/EPSG/0/4326" gml:id="f2_p1">
            <gml:pos>50.0120146 -66.8219952</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Landmark>
    <Landmark gml:id="f1">
      <idCode>234</idCode>
      <aidAvailabilityCategory  code="1">Category 1</aidAvailabilityCategory>
      <categoryOfLandmark  code="9">monument</categoryOfLandmark>
      <visualProminence  code="1">visually conspicuous</visualProminence>
      <geometry>
        <S100:curveProperty >
          <S100:maskReference xlink:href="#f1_cc1_oc1_c1" xlink:role="suppressed"/>
          <S100:CompositeCurve srsName="http://www.opengis.net/def/crs/EPSG/0/4326" gml:id="f1_cc1">
            <gml:curveMember>
            <S100:OrientableCurve srsName="http://www.opengis.net/def/crs/EPSG/0/4326" gml:id="f1_cc1_oc1" orientation="+">
              <gml:baseCurve>
              <S100:Curve srsName="http://www.opengis.net/def/crs/EPSG/0/4326" gml:id="f1_cc1_oc1_c1">
                <gml:segments>
                  <gml:LineStringSegment>
                    <gml:posList>50.00964 -66.8357905 50.0030816 -66.8308906</gml:posList>
                  </gml:LineStringSegment>
                </gml:segments>
              </S100:Curve>
              </gml:baseCurve>
            </S100:OrientableCurve>
            </gml:curveMember>
          </S100:CompositeCurve>
        </S100:curveProperty>
      </geometry>
    </Landmark>
  </members>
</S201:Dataset>
