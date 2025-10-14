<?xml version="1.0"?>
<Dataset xmlns="http://www.iho.int/S-101/gml/cs0/1.0" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:gml="http://www.opengis.net/gml/3.2" xmlns:S100="http://www.iho.int/s100gml/5.0" xmlns:s100_profile="http://www.iho.int/S-100/profile/s100_gmlProfile" xmlns:xlink="http://www.w3.org/1999/xlink" gml:id="FIHO.GML.68e6491d3951e">
  <gml:boundedBy>
    <gml:Envelope srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
      <gml:lowerCorner>58 19</gml:lowerCorner>
      <gml:upperCorner>61 22</gml:upperCorner>
    </gml:Envelope>
  </gml:boundedBy>
  <S100:DatasetIdentificationInformation>
    <S100:encodingSpecification>S-100 Part 10b</S100:encodingSpecification>
    <S100:encodingSpecificationEdition>1.0</S100:encodingSpecificationEdition>
    <S100:productIdentifier>INT.IHO.S101.X.X</S100:productIdentifier>
    <S100:productEdition>X.X</S100:productEdition>
    <S100:applicationProfile>1.0</S100:applicationProfile>
    <S100:datasetFileIdentifier>FIHO_S101_TEST_2025-10-03.gml</S100:datasetFileIdentifier>
    <S100:datasetTitle>S101 test dataset, FINLAND</S100:datasetTitle>
    <S100:datasetReferenceDate>2025-10-08</S100:datasetReferenceDate>
    <S100:datasetLanguage>eng</S100:datasetLanguage>
    <S100:datasetAbstract>Test dataset NOT FOR NAVIGATION by stefan.engstrom@traficom.fi, TRAFICOM, FINLAND</S100:datasetAbstract>
    <S100:datasetTopicCategory>transportation</S100:datasetTopicCategory>
    <S100:datasetPurpose>base</S100:datasetPurpose>
    <S100:updateNumber>0</S100:updateNumber>
  </S100:DatasetIdentificationInformation>
  <members>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.0025">
      <interoperabilityIdentifier>urn:mrn:fin:aton:20126LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>251.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>259.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Stora Bj&#xF6;rnholm alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0001_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2077223093 21.6075420569</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.0002">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Stora Bj&#xF6;rnholm alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:20126</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Stora Bj&#xF6;rnholm alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0001" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2077223093 21.6075420569</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.0125">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:20127LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Santjers</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0065_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1823336353 21.4699147559</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.0066">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Santjers</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:20127</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Santjers</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0065" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1823336353 21.4699147559</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.0202">
      <interoperabilityIdentifier>urn:mrn:fin:aton:20128LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="8">Occulting</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>271</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>321.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>321.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>326</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>326</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>24</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Tupalahti</headline>
        <language>EN</language>
        <text>Light characteristic:Oc 2,5 s Sectors: 3</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0178_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4559685945 22.0568227855</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.0179">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Tupalahti</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:20128</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Tupalahti</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0178" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4559685945 22.0568227855</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.0266">
      <interoperabilityIdentifier>urn:mrn:fin:aton:20124LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="7">Isophased</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>0</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>19</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Ut&#xF6; ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:Iso 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0242_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7881425552 21.35978262</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.0243">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Ut&#xF6; ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:20124</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Ut&#xF6; ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0242" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7881425552 21.35978262</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.0366">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5896LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Kallisaari</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (3) 5 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0306_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2920622785 21.741946115</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.0307">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kallisaari</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5896</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Kallisaari</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0306" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2920622785 21.741946115</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.0481">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5900LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : Fregattgrund </headline>
        <language>EN</language>
        <text>Light characteristic:VQ Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0419_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8246069997 21.3671005765</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBeacon gml:id="fiho.s100.S101.CardinalBeacon.0420">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfCardinalMark code="1">North Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Fregattgrund </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5900</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Fregattgrund </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0419" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8246069997 21.3671005765</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.0594">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5901LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Bokulla</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (9) 10 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0534_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8484014551 21.4122261554</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.0535">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="4">West Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Bokulla</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5901</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Bokulla</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0534" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8484014551 21.4122261554</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.0707">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5890LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Matinmatala</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (3) 5 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0647_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.6821616251 21.0259496192</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.0648">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Matinmatala</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5890</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Matinmatala</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0647" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.6821616251 21.0259496192</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.0822">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5892LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : Isoletto </headline>
        <language>EN</language>
        <text>Light characteristic:VQ (3) 5 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0760_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4688614386 21.4703348163</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBeacon gml:id="fiho.s100.S101.CardinalBeacon.0761">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Isoletto </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5892</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Isoletto </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0760" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4688614386 21.4703348163</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.0937">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5894LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : R&#xE5;klobb </headline>
        <language>EN</language>
        <text>Light characteristic:VQ (3) 5 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0875_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4078992972 21.5180930133</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBeacon gml:id="fiho.s100.S101.CardinalBeacon.0876">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>R&#xE5;klobb </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5894</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : R&#xE5;klobb </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0875" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4078992972 21.5180930133</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.1052">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5895LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : Vasikkasaari </headline>
        <language>EN</language>
        <text>Light characteristic:VQ (6) + LFl 10 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0990_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3395779624 21.6168900565</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBeacon gml:id="fiho.s100.S101.CardinalBeacon.0991">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfCardinalMark code="3">South Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Vasikkasaari </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5895</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Vasikkasaari </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.0990" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3395779624 21.6168900565</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.1167">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5960LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : Korsholm </headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1105_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1853847504 21.4787832263</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBeacon gml:id="fiho.s100.S101.LateralBeacon.1106">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Korsholm </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5960</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Korsholm </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1105" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1853847504 21.4787832263</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.1280">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5961LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Keitsor</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1220_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1890734255 21.4962868271</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.1221">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Keitsor</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5961</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Keitsor</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1220" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1890734255 21.4962868271</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.1395">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5972LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : Kyrkog&#xE5;rdsgrund </headline>
        <language>EN</language>
        <text>Light characteristic:VQ (6) + LFl 10 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1333_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2246184567 21.7514194062</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBeacon gml:id="fiho.s100.S101.CardinalBeacon.1334">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfCardinalMark code="3">South Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kyrkog&#xE5;rdsgrund </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5972</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Kyrkog&#xE5;rdsgrund </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1333" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2246184567 21.7514194062</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.1508">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6035LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Kyrkosk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (9) 10 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1448_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2243427476 21.7175203136</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.1449">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="4">West Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kyrkosk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6035</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Kyrkosk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1448" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2243427476 21.7175203136</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.1621">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6042LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Bondsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (3) 5 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1561_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9946519441 21.6957120721</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.1562">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Bondsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6042</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Bondsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1561" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9946519441 21.6957120721</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <CardinalBeacon gml:id="fiho.s100.S101.CardinalBeacon.1675">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Satukari </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6045</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Satukari </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1674" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.350555954 21.5882448467</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.1757">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5942LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Kummelkl&#xE4;ppen</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1697_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9289117309 21.2283819279</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.1698">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Kummelkl&#xE4;ppen</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5942</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Kummelkl&#xE4;ppen</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1697" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9289117309 21.2283819279</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.1873">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5944LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : K&#xF6;karsfj&#xE4;rden </headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1811_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9478273808 21.194985717</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBeacon gml:id="fiho.s100.S101.LateralBeacon.1812">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>K&#xF6;karsfj&#xE4;rden </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5944</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : K&#xF6;karsfj&#xE4;rden </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1811" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9478273808 21.194985717</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.1986">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5947LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Getkl&#xE4;pp</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1926_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9712335609 21.1628392284</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.1927">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Getkl&#xE4;pp</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5947</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Getkl&#xE4;pp</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.1926" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9712335609 21.1628392284</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.2099">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5950LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : L&#xE4;nggadd</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2039_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0204913372 21.1211808414</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.2040">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>L&#xE4;nggadd</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5950</interoperabilityIdentifier>
      <information>
        <headline>Poiju : L&#xE4;nggadd</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2039" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0204913372 21.1211808414</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.2214">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5935LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : Stenkl&#xE4;pparna</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2152_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8574194607 21.3452851273</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBeacon gml:id="fiho.s100.S101.LateralBeacon.2153">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Stenkl&#xE4;pparna</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5935</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Stenkl&#xE4;pparna</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2152" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8574194607 21.3452851273</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.2327">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5937LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Vitf&#xE5;gelsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2267_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8739865803 21.3283857214</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.2268">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Vitf&#xE5;gelsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5937</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Vitf&#xE5;gelsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2267" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8739865803 21.3283857214</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.2440">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5938LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : S&#xF6;derb&#xE5;dan</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2380_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8789625379 21.3370353376</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.2381">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>S&#xF6;derb&#xE5;dan</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5938</interoperabilityIdentifier>
      <information>
        <headline>Poiju : S&#xF6;derb&#xE5;dan</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2380" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8789625379 21.3370353376</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.2553">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5939LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : B&#xE4;ssharun</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2493_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8871492941 21.3006077094</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.2494">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>B&#xE4;ssharun</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5939</interoperabilityIdentifier>
      <information>
        <headline>Poiju : B&#xE4;ssharun</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2493" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8871492941 21.3006077094</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.2668">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5940LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : V&#xF6;rpeln </headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2606_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8931708781 21.3104185467</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBeacon gml:id="fiho.s100.S101.LateralBeacon.2607">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>V&#xF6;rpeln </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5940</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : V&#xF6;rpeln </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2606" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8931708781 21.3104185467</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.2781">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5926LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Svartb&#xE5;dan 1</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2721_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7407165146 21.3591121627</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.2722">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Svartb&#xE5;dan 1</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5926</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Svartb&#xE5;dan 1</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2721" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7407165146 21.3591121627</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.2894">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5927LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Svartb&#xE5;dan 2</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2834_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7452928302 21.3340947677</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.2835">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Svartb&#xE5;dan 2</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5927</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Svartb&#xE5;dan 2</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2834" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7452928302 21.3340947677</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.3007">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5929LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : K&#xE5;rharu</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2947_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.789821596 21.3340945411</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.2948">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>K&#xE5;rharu</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5929</interoperabilityIdentifier>
      <information>
        <headline>Poiju : K&#xE5;rharu</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.2947" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.789821596 21.3340945411</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.3120">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5930LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Finnsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3060_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7939149354 21.3480933095</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.3061">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Finnsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5930</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Finnsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3060" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7939149354 21.3480933095</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.3233">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5934LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Torvsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3173_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8457402339 21.3487122349</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.3174">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Torvsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5934</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Torvsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3173" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8457402339 21.3487122349</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.3346">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5632LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Kaskisgrundet</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3286_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2490246796 21.8230804437</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.3287">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Kaskisgrundet</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5632</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Kaskisgrundet</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3286" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2490246796 21.8230804437</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.3459">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5614LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Nk 3</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3399_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4437345476 22.0734776102</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.3400">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Nk 3</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5614</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Nk 3</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3399" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4437345476 22.0734776102</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.3572">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5615LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Nk 10</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3512_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4452122769 22.0755225647</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.3513">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Nk 10</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5615</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Nk 10</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3512" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4452122769 22.0755225647</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.3685">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5616LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Nk 4</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3625_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.446928928 22.0656755432</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.3626">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Nk 4</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5616</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Nk 4</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3625" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.446928928 22.0656755432</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.3801">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6059LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : H&#xF6;grundet 2</headline>
        <language>EN</language>
        <text>Light characteristic:VQ Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3741_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2366494707 21.7746232434</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.3742">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="1">North Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>H&#xF6;grundet 2</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6059</interoperabilityIdentifier>
      <information>
        <headline>Poiju : H&#xF6;grundet 2</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3741" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2366494707 21.7746232434</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.3914">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6061LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Skorvkobben</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3854_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8531269796 21.346150536</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.3855">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Skorvkobben</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6061</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Skorvkobben</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3854" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8531269796 21.346150536</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.4027">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6063LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Lilla Hamnsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3967_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9243183534 21.2501900726</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.3968">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Lilla Hamnsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6063</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Lilla Hamnsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.3967" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9243183534 21.2501900726</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.4140">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6067LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : &#xC5;nsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (3) 5 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4080_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1951888059 21.7023455095</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.4081">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>&#xC5;nsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6067</interoperabilityIdentifier>
      <information>
        <headline>Poiju : &#xC5;nsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4080" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1951888059 21.7023455095</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.4254">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5642LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Nordlingsgrund</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4194_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4068296619 22.0948086525</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.4195">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Nordlingsgrund</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5642</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Nordlingsgrund</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4194" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4068296619 22.0948086525</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.4308">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="4">West Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Harun</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5766</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Harun</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4307" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.5944492243 21.1089794287</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.4390">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5644LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Koljankari</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4330_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4147363004 22.0891294323</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.4331">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Koljankari</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5644</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Koljankari</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4330" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4147363004 22.0891294323</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.4503">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5633LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : &#xC4;ggsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4443_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2523380448 21.8492278181</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.4444">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>&#xC4;ggsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5633</interoperabilityIdentifier>
      <information>
        <headline>Poiju : &#xC4;ggsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4443" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2523380448 21.8492278181</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.4616">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5634LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : V&#xE4;&#xE4;r&#xE4;maankivi</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4556_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2598660939 21.8710000561</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.4557">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>V&#xE4;&#xE4;r&#xE4;maankivi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5634</interoperabilityIdentifier>
      <information>
        <headline>Poiju : V&#xE4;&#xE4;r&#xE4;maankivi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4556" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2598660939 21.8710000561</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.4729">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5635LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Purhanruskea</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4669_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2699233743 21.9344422174</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.4670">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Purhanruskea</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5635</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Purhanruskea</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4669" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2699233743 21.9344422174</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.4842">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5636LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Orhiluoto</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4782_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2687921947 21.946013947</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.4783">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Orhiluoto</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5636</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Orhiluoto</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4782" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2687921947 21.946013947</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.4955">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5638LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Orhisaari</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4895_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2758306796 21.98981982</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.4896">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Orhisaari</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5638</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Orhisaari</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.4895" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2758306796 21.98981982</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.5068">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5631LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Hepokari</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5008_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2479479472 21.8080970789</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.5009">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Hepokari</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5631</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Hepokari</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5008" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2479479472 21.8080970789</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.5122">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="3">South Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kenk&#xE4;maa</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5751</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Kenk&#xE4;maa</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5121" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3273601527 21.656900006</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.5143">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="1">North Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Hevoskaakki</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5752</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Hevoskaakki</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5142" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3340838596 21.6227798913</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.5224">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5765LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : L&#xE5;ng&#xF6;rsklobb</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (3) 5 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5164_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.5755805437 21.1244428952</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.5165">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>L&#xE5;ng&#xF6;rsklobb</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5765</interoperabilityIdentifier>
      <information>
        <headline>Poiju : L&#xE5;ng&#xF6;rsklobb</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5164" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.5755805437 21.1244428952</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.5339">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5611LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Nk 1</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5279_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4396836519 22.0778522376</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.5280">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Nk 1</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5611</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Nk 1</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5279" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4396836519 22.0778522376</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.5452">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5612LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Nk 9</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5392_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4395006992 22.0834040485</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.5393">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Nk 9</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5612</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Nk 9</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5392" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4395006992 22.0834040485</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.5565">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5613LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Nk 2</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5505_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4411258408 22.0766916419</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.5506">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Nk 2</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5613</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Nk 2</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5505" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4411258408 22.0766916419</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.5619">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="3">South Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Korpinkarinkivi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5604</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Korpinkarinkivi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5618" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2692910969 21.8562945581</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.5728">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:4872LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Svartklubb</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (6) + LFl 10 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5668_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4004838213 21.5371703711</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.5669">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="3">South Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Svartklubb</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:4872</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Svartklubb</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5668" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4004838213 21.5371703711</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.5842">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:4875LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : G&#xE5;ssk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (6) + LFl 10 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5782_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.475580247 21.3138581415</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.5783">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="3">South Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>G&#xE5;ssk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:4875</interoperabilityIdentifier>
      <information>
        <headline>Poiju : G&#xE5;ssk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5782" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.475580247 21.3138581415</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.5960">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:4673LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Knivsk&#xE4;r v&#xE4;stra</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (9) 10 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5900_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8187738475 21.3557582623</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.5901">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="4">West Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Knivsk&#xE4;r v&#xE4;stra</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:4673</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Knivsk&#xE4;r v&#xE4;stra</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.5900" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8187738475 21.3557582623</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.6075">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6090LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Hevosluoto</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (3) 5 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6015_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3615859826 21.5866643758</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.6016">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Hevosluoto</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6090</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Hevosluoto</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6015" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3615859826 21.5866643758</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.6188">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6091LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : D&#xE5;nasten</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (9) 10 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6128_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1216148794 21.6806238421</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.6129">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="4">West Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>D&#xE5;nasten</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6091</interoperabilityIdentifier>
      <information>
        <headline>Poiju : D&#xE5;nasten</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6128" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1216148794 21.6806238421</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.6301">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6092LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Keitsorsten</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6241_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1957033162 21.5157984528</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.6242">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Keitsorsten</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6092</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Keitsorsten</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6241" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1957033162 21.5157984528</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.6355">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="4">West Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Bondsten</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5647</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Bondsten</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6354" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.998969945 21.7033130126</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.6376">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="4">West Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Lydarudd</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5652</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Lydarudd</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6375" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1884149972 21.7085635112</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.6397">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="3">South Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>H&#xF6;grundet 1</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5656</interoperabilityIdentifier>
      <information>
        <headline>Poiju : H&#xF6;grundet 1</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6396" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2375646193 21.7685073369</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.6477">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5639LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : V&#xE4;h&#xE4; Tervi</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6417_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3621014284 22.0841319406</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.6418">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>V&#xE4;h&#xE4; Tervi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5639</interoperabilityIdentifier>
      <information>
        <headline>Poiju : V&#xE4;h&#xE4; Tervi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6417" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3621014284 22.0841319406</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.6590">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5640LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Rajakari</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6530_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3775799808 22.0984937263</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.6531">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Rajakari</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5640</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Rajakari</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6530" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3775799808 22.0984937263</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.6703">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5641LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Veljesmatala</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6643_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.401660599 22.0973405579</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.6644">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Veljesmatala</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5641</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Veljesmatala</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6643" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.401660599 22.0973405579</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.6816">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5742LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Volot</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6756_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1743991094 21.4286261502</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.6757">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Volot</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5742</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Volot</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6756" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1743991094 21.4286261502</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.6929">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5743LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Sm&#xF6;rgrund</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6869_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1781186326 21.4414469797</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.6870">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Sm&#xF6;rgrund</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5743</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Sm&#xF6;rgrund</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6869" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1781186326 21.4414469797</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.7044">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5744LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : Sm&#xF6;rgrund </headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6982_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.176301581 21.4451299867</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBeacon gml:id="fiho.s100.S101.LateralBeacon.6983">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Sm&#xF6;rgrund </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5744</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Sm&#xF6;rgrund </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.6982" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.176301581 21.4451299867</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBeacon>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.7098">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Flat&#xF6;n</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5691</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Flat&#xF6;n</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7097" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9482416154 21.6612420893</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.7180">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5698LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : Formansb&#xE5;dan </headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7118_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.707059952 21.3182229336</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBeacon gml:id="fiho.s100.S101.LateralBeacon.7119">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Formansb&#xE5;dan </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5698</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Formansb&#xE5;dan </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7118" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.707059952 21.3182229336</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.7293">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5680LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Svartholm</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7233_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2170259065 21.6913361212</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.7234">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Svartholm</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5680</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Svartholm</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7233" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2170259065 21.6913361212</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.7406">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5681LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Gr&#xE5;sk&#xE4;ren</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7346_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2222883497 21.7104124562</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.7347">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Gr&#xE5;sk&#xE4;ren</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5681</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Gr&#xE5;sk&#xE4;ren</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7346" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2222883497 21.7104124562</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.7519">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5682LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Baggisgrundet</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7459_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2225914824 21.7224357196</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.7460">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Baggisgrundet</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5682</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Baggisgrundet</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7459" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2225914824 21.7224357196</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.7596">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3621RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7572" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0654155565 21.162183824</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.7640">
      <colour code="7">Grey</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3621LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Tutkamerkki : Sn&#xF6;kobb</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (5) 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7572_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0654155565 21.162183824</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <Pile gml:id="fiho.s100.S101.Pile.7573">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Sn&#xF6;kobb</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3621</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Sn&#xF6;kobb</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7572" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0654155565 21.162183824</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.7717">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3606LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>14.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>22.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Vandrock ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7693_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2142671419 21.7220683131</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.7694">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Vandrock ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3606</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Vandrock ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7693" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2142671419 21.7220683131</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.7781">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3608LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>24</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>32</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Kr&#xE5;kholm ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7757_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2468322321 21.7392524715</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.7758">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kr&#xE5;kholm ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3608</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Kr&#xE5;kholm ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7757" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2468322321 21.7392524715</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.7845">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3609LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>41</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>61</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Korsholm alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7821_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1833266346 21.4567600635</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.7822">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Korsholm alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3609</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Korsholm alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7821" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1833266346 21.4567600635</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.7909">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3604LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>189</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>221</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Svartgrund alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7885_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8295177923 21.3886973722</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.7886">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Svartgrund alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3604</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Svartgrund alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7885" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8295177923 21.3886973722</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.7973">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3295LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>235</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>100</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Merimajakka : Ut&#xF6;</headline>
        <language>EN</language>
        <text>Light characteristic:Fl (2) 12 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7949_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7809279331 21.3688947773</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.7950">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Ut&#xF6;</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3295</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Merimajakka : Ut&#xF6;</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.7949" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7809279331 21.3688947773</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.8073">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:4296LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : NK 6</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8013_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4528265969 22.0499803557</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.8014">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>NK 6</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:4296</interoperabilityIdentifier>
      <information>
        <headline>Poiju : NK 6</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8013" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4528265969 22.0499803557</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8150">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3581LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>180</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>197</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>197</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>208</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>208</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>271</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>271</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>297</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>297</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>299</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>299</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>29</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Kalvholm</headline>
        <language>EN</language>
        <text>Light characteristic:Q (2) 6 s Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8126_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.086438094 21.6838288825</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8127">
      <colour code="1">White</colour>
      <colour code="11">Orange</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kalvholm</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3581</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Kalvholm</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8126" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.086438094 21.6838288825</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8214">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3583LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>140</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>187</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>187</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>251</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>251</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>140</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : R&#xF6;db&#xE5;dan alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 3</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8190_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1998590289 21.7071502674</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8191">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>R&#xF6;db&#xE5;dan alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3583</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : R&#xF6;db&#xE5;dan alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8190" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1998590289 21.7071502674</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8278">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3587LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>348.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>356.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : J&#xE4;nisholm ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8254_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2231042224 21.6967930286</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8255">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>J&#xE4;nisholm ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3587</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : J&#xE4;nisholm ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8254" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2231042224 21.6967930286</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8342">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3590LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>35</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>45.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>45.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>51</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>51</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>57</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>57</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>69.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>69.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>74</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>74</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>156</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>156</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>219</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>219</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>226</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>226</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>240</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : R&#xF6;dsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 5 s Sectors: 9</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8318_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1164209317 21.3122393591</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8319">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>R&#xF6;dsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3590</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : R&#xF6;dsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8318" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1164209317 21.3122393591</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8406">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3577LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>228</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>236</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Stenharun alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8382_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8084733711 21.3209246193</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8383">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Stenharun alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3577</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Stenharun alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8382" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8084733711 21.3209246193</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8470">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3578LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>31</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>35</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Skogsflisan alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8446_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9877664367 21.7182537662</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8447">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Skogsflisan alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3578</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Skogsflisan alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8446" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9877664367 21.7182537662</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8534">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3579LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>176</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>184</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Trutkl&#xE4;pp ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8510_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9130233657 21.7001732269</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8511">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Trutkl&#xE4;pp ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3579</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Trutkl&#xE4;pp ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8510" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9130233657 21.7001732269</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8598">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3508LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>67</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>76</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>76</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>84</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>264</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>280</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>280</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>288</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>288</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>353</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>353</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>67</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Iso Muna alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8574_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4809387651 21.4022398678</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8575">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Iso Muna alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3508</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Iso Muna alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8574" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4809387651 21.4022398678</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8662">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3509LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>146.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>154.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Satamaa ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8638_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3810914431 21.553552655</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8639">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Satamaa ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3509</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Satamaa ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8638" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3810914431 21.553552655</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8726">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3510LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>354</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>2</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Kojukari ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8702_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4107610637 21.5880930657</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8703">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kojukari ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3510</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Kojukari ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8702" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4107610637 21.5880930657</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8790">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3512LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>107</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>121</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>121</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>123.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>123.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>196</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>196</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>307</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>307</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>310</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>310</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>333</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Mustaluoto</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 5 s Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8766_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3074612435 21.7139785382</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8767">
      <colour code="1">White</colour>
      <colour code="2">Black</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Mustaluoto</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3512</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Mustaluoto</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8766" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3074612435 21.7139785382</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8854">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3146LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>354</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>2</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Kojukari alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8830_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4044019921 21.5885813328</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8831">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kojukari alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3146</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Kojukari alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8830" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4044019921 21.5885813328</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8918">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3135LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>100</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>104</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Vargklobb alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8894_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4681057144 21.368224711</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8895">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Vargklobb alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3135</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Vargklobb alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8894" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4681057144 21.368224711</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.8982">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3570LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>65</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>78</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>78</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>82</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>82</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>90</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>90</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>240</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>240</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>245</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>245</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>270</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Kaasluoto</headline>
        <language>EN</language>
        <text>Light characteristic:Q (2) 6 s Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8958_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2284270274 21.8190449445</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.8959">
      <colour code="1">White</colour>
      <featureName>
        <language>EN</language>
        <name>Kaasluoto</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3570</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Kaasluoto</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.8958" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2284270274 21.8190449445</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.9046">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3571LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>43</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>51</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Purha alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9022_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.273021525 21.9355475569</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.9023">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Purha alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3571</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Purha alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9022" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.273021525 21.9355475569</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.9110">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3561LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>280</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>284</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Borg&#xE5;sten ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9086_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4948166971 21.1125719288</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.9087">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Borg&#xE5;sten ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3561</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Borg&#xE5;sten ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9086" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4948166971 21.1125719288</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.9174">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3214LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>261</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>26</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Apuloisto : Grisselborg alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9150_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0709716433 21.6686591724</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.9151">
      <colour code="1">White</colour>
      <featureName>
        <language>EN</language>
        <name>Grisselborg alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3214</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Apuloisto : Grisselborg alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9150" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0709716433 21.6686591724</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.9238">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3216LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>183</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>191</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : B&#xE4;sskubb alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9214_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0182362421 21.675779574</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.9215">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>B&#xE4;sskubb alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3216</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : B&#xE4;sskubb alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9214" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0182362421 21.675779574</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.9302">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3482LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>43</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>51</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : V&#xE4;&#xE4;r&#xE4;maa alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9278_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2611099119 21.8407868575</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.9279">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>V&#xE4;&#xE4;r&#xE4;maa alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3482</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : V&#xE4;&#xE4;r&#xE4;maa alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9278" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2611099119 21.8407868575</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.9366">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3483LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>192.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>200.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Svartholm ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9342_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2001503031 21.6900023075</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.9343">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Svartholm ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3483</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Svartholm ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9342" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2001503031 21.6900023075</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.9466">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5746LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : R&#xF6;nn&#xF6;ren</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9406_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1788201242 21.4608390604</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.9407">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>R&#xF6;nn&#xF6;ren</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5746</interoperabilityIdentifier>
      <information>
        <headline>Poiju : R&#xF6;nn&#xF6;ren</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9406" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1788201242 21.4608390604</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.9579">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5734LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Sn&#xF6;dgaddarna</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9519_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9922520669 21.1070653136</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.9520">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Sn&#xF6;dgaddarna</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5734</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Sn&#xF6;dgaddarna</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9519" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9922520669 21.1070653136</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.9692">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5735LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Pattonsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9632_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9939428412 21.1266889484</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.9633">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Pattonsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5735</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Pattonsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9632" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9939428412 21.1266889484</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.9805">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5738LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : B&#xE4;ssl&#xE5;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9745_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1263754091 21.3082940272</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.9746">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>B&#xE4;ssl&#xE5;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5738</interoperabilityIdentifier>
      <information>
        <headline>Poiju : B&#xE4;ssl&#xE5;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9745" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1263754091 21.3082940272</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.9918">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5740LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Rosk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9858_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1525306719 21.3707780656</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.9859">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Rosk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5740</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Rosk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9858" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1525306719 21.3707780656</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.10031">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5705LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Eglonsk&#xE4;ren</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9971_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.825497516 21.3422792182</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.9972">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Eglonsk&#xE4;ren</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5705</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Eglonsk&#xE4;ren</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.9971" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.825497516 21.3422792182</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.10145">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5683LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : L&#xF6;vsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10085_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2207672979 21.7227432878</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.10086">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>L&#xF6;vsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5683</interoperabilityIdentifier>
      <information>
        <headline>Poiju : L&#xF6;vsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10085" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2207672979 21.7227432878</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.10258">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5676LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Kokombrink</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10198_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2031996551 21.5396291491</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.10199">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Kokombrink</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5676</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Kokombrink</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10198" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2031996551 21.5396291491</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.10371">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5678LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Sk&#xF6;ldholm</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10311_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2170556867 21.6358917242</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.10312">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Sk&#xF6;ldholm</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5678</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Sk&#xF6;ldholm</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10311" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2170556867 21.6358917242</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.10425">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="3">South Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>J&#xE4;rviluodot</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5660</interoperabilityIdentifier>
      <information>
        <headline>Poiju : J&#xE4;rviluodot</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10424" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3159207861 21.7010084496</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.10446">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Korvet Koillinen</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5661</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Korvet Koillinen</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10445" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2476027493 21.7098407026</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.10490">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3479LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>24</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>32</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Kaita alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10466_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2415999039 21.7336439654</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.10467">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kaita alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3479</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Kaita alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10466" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2415999039 21.7336439654</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.10554">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3480LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>347.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>355.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Skatask&#xE4;r alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10530_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8461209028 21.3263287436</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.10531">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Skatask&#xE4;r alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3480</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Skatask&#xE4;r alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10530" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8461209028 21.3263287436</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.10654">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5707LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : V&#xE4;stergaddarna</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10594_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8422449704 21.3432534816</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.10595">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>V&#xE4;stergaddarna</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5707</interoperabilityIdentifier>
      <information>
        <headline>Poiju : V&#xE4;stergaddarna</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10594" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8422449704 21.3432534816</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.10767">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5687LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Riskholmen</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10707_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2347797154 21.7806727633</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.10708">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Riskholmen</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5687</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Riskholmen</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10707" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2347797154 21.7806727633</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.10880">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5688LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Knivsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (6) + LFl 10 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10820_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8238995947 21.3532440165</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.10821">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="3">South Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Knivsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5688</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Knivsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10820" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8238995947 21.3532440165</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.10993">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5646LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Iso Kaskinen</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10933_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4285076394 22.0833013446</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.10934">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Iso Kaskinen</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5646</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Iso Kaskinen</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.10933" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4285076394 22.0833013446</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.11071">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3161RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11047" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.4726679659 20.8131477772</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.11115">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3161LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Tutkamerkki : Suomen Leijona</headline>
        <language>EN</language>
        <text>Light characteristic:FI (2) 12 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11047_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.4726679659 20.8131477772</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <VirtualAISAidToNavigation gml:id="fiho.s100.S101.VirtualAISAidToNavigation.11168">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3161.AIS</interoperabilityIdentifier>
      <mMSICode>992304001</mMSICode>
      <virtualAISAidToNavigationType code="11">Special Purpose</virtualAISAidToNavigationType>
    </VirtualAISAidToNavigation>
    <Pile gml:id="fiho.s100.S101.Pile.11048">
      <colour code="1">White</colour>
      <featureName>
        <language>EN</language>
        <name>Suomen Leijona</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3161</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Suomen Leijona</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11047" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.4726679659 20.8131477772</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.11200">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3290LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>40</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>48</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>48</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>129</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>129</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>247</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>247</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>252</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>252</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>351</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>351</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>40</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Eglonsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Q (2) 6 s Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11176_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8363626892 21.3842472933</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.11177">
      <colour code="1">White</colour>
      <featureName>
        <language>EN</language>
        <name>Eglonsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3290</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Eglonsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11176" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8363626892 21.3842472933</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.11264">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3225LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="7">Isophased</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>183.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>213.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Retais ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:Iso 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11240_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.166871281 21.6898847294</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.11241">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Retais ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3225</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Retais ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11240" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.166871281 21.6898847294</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.11328">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3226LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>178.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>186.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Lydarudd alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11304_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.191000902 21.7118100287</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.11305">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Lydarudd alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3226</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Lydarudd alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11304" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.191000902 21.7118100287</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.11392">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3227LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>178.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>186.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Lydarudd ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11368_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1761698975 21.7105114861</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.11369">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Lydarudd ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3227</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Lydarudd ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11368" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1761698975 21.7105114861</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.11456">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3228LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>0</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>197</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>197</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>254</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>254</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>258</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>258</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>360</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : L&#xF6;vsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (5) 6 s Sectors: 4</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11432_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2201656543 21.7238083594</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.11433">
      <colour code="1">White</colour>
      <featureName>
        <language>EN</language>
        <name>L&#xF6;vsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3228</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : L&#xF6;vsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11432" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2201656543 21.7238083594</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.11520">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3221LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>191</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>199</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Lohm ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11496_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1033564295 21.6666820172</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.11497">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Lohm ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3221</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Lohm ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11496" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1033564295 21.6666820172</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.11584">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3223LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>3.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>11.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Tallholm ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11560_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2061937526 21.7087838306</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.11561">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Tallholm ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3223</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Tallholm ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11560" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2061937526 21.7087838306</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.11648">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3212LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>176</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>184</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Trutkl&#xE4;pp alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11624_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9348898862 21.6998822141</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.11625">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Trutkl&#xE4;pp alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3212</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Trutkl&#xE4;pp alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11624" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9348898862 21.6998822141</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.11712">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3213LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>9</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>24</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>24</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>138</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>138</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>161</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>161</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>167</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>167</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>184</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>318</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>9</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Bondsten</headline>
        <language>EN</language>
        <text>Light characteristic:Q (2) 6 s Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11688_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9976955609 21.7069212081</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.11689">
      <colour code="1">White</colour>
      <colour code="2">Black</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Bondsten</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3213</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Bondsten</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11688" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9976955609 21.7069212081</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.11777">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3136LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>100</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>104</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Vargklobb ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11753_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4645119233 21.4011761366</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.11754">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Vargklobb ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3136</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Vargklobb ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11753" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4645119233 21.4011761366</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.11841">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3137LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>10</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>15.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>15.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>23.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>23.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>48</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>48</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>87</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>87</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>90</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>90</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>131</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>349</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>10</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Laupunen</headline>
        <language>EN</language>
        <text>Light characteristic:Q (4) 6 s Sectors: 7</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11817_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.477901523 21.46736027</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.11818">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Laupunen</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3137</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Laupunen</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11817" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.477901523 21.46736027</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.11905">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3147LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>4.1</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>80</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>80</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>164</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>164</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>175</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>175</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>219</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>306</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>331</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>331</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>4.1</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Saukkoletto</headline>
        <language>EN</language>
        <text>Light characteristic:Q (2) 6 s Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11881_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3559229558 21.5975406593</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.11882">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Saukkoletto</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3147</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Saukkoletto</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11881" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3559229558 21.5975406593</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.11969">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3148LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>321</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>329</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Tallgrund alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11945_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3757132186 21.561164065</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.11946">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Tallgrund alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3148</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Tallgrund alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.11945" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3757132186 21.561164065</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12033">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3150LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>296</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>304</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Kekoluoto ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12009_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3518437082 21.567924711</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12010">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kekoluoto ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3150</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Kekoluoto ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12009" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3518437082 21.567924711</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12097">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3152LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>94</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>135</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>135</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>140</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>140</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>189</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>235</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>309.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>309.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>322.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>322.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>94</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : R&#xF6;nngrund</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (2) 6 s Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12073_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2758186763 21.7860956386</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12074">
      <colour code="1">White</colour>
      <featureName>
        <language>EN</language>
        <name>R&#xF6;nngrund</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3152</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : R&#xF6;nngrund</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12073" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2758186763 21.7860956386</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12161">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3142LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>146.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>154.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Satamaa alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12137_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3904175248 21.5428109303</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12138">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Satamaa alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3142</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Satamaa alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12137" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3904175248 21.5428109303</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12225">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3145LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>50</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>330</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>330</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>344</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>344</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>351</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>351</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>50</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Ykskari</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 4</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12201_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3755534535 21.5829692749</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12202">
      <colour code="1">White</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Ykskari</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3145</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Ykskari</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12201" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3755534535 21.5829692749</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12289">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3140LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>156</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>164</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Ingastholm alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12265_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3887774 21.5353767407</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12266">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Ingastholm alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3140</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Ingastholm alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12265" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3887774 21.5353767407</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12353">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3132LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>311</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>319</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Jurmo ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12329_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.5345566879 21.0977793729</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12330">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Jurmo ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3132</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Jurmo ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12329" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.5345566879 21.0977793729</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12417">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3133LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>37</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>60</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>60</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>67</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>67</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>93</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>93</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>116</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>116</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>124</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>124</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>136</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>294</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>318</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>318</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>344</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>344</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>37</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Kungsholm</headline>
        <language>EN</language>
        <text>Light characteristic:Q (2) 6 s Sectors: 9</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12393_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4961563198 21.1879242691</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12394">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kungsholm</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3133</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Kungsholm</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12393" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4961563198 21.1879242691</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12481">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3126LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>340</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>344</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Isokari alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12457_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.708955729 21.0177656225</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12458">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Isokari alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3126</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Isokari alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12457" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.708955729 21.0177656225</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12545">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3127LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>160</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>164</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Hamnsk&#xE4;r ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12521_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.5624577191 21.1155873075</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12522">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Hamnsk&#xE4;r ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3127</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Hamnsk&#xE4;r ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12521" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.5624577191 21.1155873075</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12611">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3207LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>52</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>56</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : N&#xF6;t&#xF6; alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 2 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12587_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9537782375 21.7165872132</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12588">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>N&#xF6;t&#xF6; alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3207</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : N&#xF6;t&#xF6; alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12587" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9537782375 21.7165872132</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12675">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3210LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>50</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>68</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>195</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>216</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>216</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>50</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Flat&#xF6;kubb</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 5 s Sectors: 3</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12651_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9367161023 21.64550551</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12652">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Flat&#xF6;kubb</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3210</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Flat&#xF6;kubb</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12651" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9367161023 21.64550551</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12739">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3211LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>31</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>35</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Skogsflisan ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12715_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0050695065 21.740768641</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12716">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Skogsflisan ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3211</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Skogsflisan ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12715" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0050695065 21.740768641</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12807">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3204LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>189</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>221</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Svartgrund ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12783_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8184334926 21.3784468006</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12784">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Svartgrund ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3204</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Svartgrund ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12783" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8184334926 21.3784468006</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.12871">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3205LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>9</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>50</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>50</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>54</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>54</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>165</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>165</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>232.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>232.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>236.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>236.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>9</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Bokullankivi</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 5 s Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12847_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8470528101 21.4189044283</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.12848">
      <colour code="1">White</colour>
      <colour code="2">Black</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Bokullankivi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3205</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Bokullankivi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12847" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8470528101 21.4189044283</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.12936">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3613RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12912" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4722419779 21.3742986803</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.12980">
      <colour code="7">Grey</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3613LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Tutkamerkki : Anckargrund</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (5) 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12912_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4722419779 21.3742986803</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <Pile gml:id="fiho.s100.S101.Pile.12913">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Anckargrund</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3613</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Anckargrund</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.12912" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4722419779 21.3742986803</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.13057">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3620RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13033" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0114432022 21.1169067667</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.13101">
      <colour code="7">Grey</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3620LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Tutkamerkki : L&#xE4;nggadd</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (5) 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13033_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0114432022 21.1169067667</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <Pile gml:id="fiho.s100.S101.Pile.13034">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>L&#xE4;nggadd</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3620</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : L&#xE4;nggadd</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13033" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0114432022 21.1169067667</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13184">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3580LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>333</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>353</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>353</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>357</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>357</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>200</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : L&#xE5;ng Ljussk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 5 s Sectors: 3</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13160_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.035799102 21.6922197662</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.13161">
      <colour code="1">White</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>L&#xE5;ng Ljussk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3580</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : L&#xE5;ng Ljussk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13160" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.035799102 21.6922197662</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13248">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3340LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>177</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>190</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>190</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>197</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>197</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>218</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : &#xC5;nsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (2) 3 s Sectors: 3</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13224_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1950396543 21.6985659019</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.13225">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>&#xC5;nsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3340</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : &#xC5;nsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13224" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1950396543 21.6985659019</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13312">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3341LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>145</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>171.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>171.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>174</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>174</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>191</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Strandbyh&#xE4;ll</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 3</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13288_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1710581138 21.7103160823</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.13289">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Strandbyh&#xE4;ll</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3341</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Strandbyh&#xE4;ll</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13288" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1710581138 21.7103160823</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13376">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3334LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>16</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>20.1</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>20.1</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>31</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>166</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>172</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>172</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>173</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>173</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>194</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>194</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>202.4</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>202.4</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>204</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>204</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>257</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>257</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>16</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Rajakari</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 4 s Sectors: 9</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13352_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3779681078 22.0966588942</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.13353">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Rajakari</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3334</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Rajakari</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13352" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3779681078 22.0966588942</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13440">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3337LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>344</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>16</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Viheri&#xE4;inen alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13416_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4495725468 22.0808085988</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.13417">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Viheri&#xE4;inen alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3337</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Viheri&#xE4;inen alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13416" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4495725468 22.0808085988</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13504">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3330LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>248</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>256</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Haapaluoto ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13480_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2441405707 21.7826108434</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.13481">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Haapaluoto ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3330</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Haapaluoto ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13480" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2441405707 21.7826108434</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13568">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3331LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>19</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>78</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>78</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>80</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>80</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>210</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>210</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>217</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>217</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>232</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>232</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>246</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>246</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>266</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>266</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>284</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Orhisaari</headline>
        <language>EN</language>
        <text>Light characteristic:Q (2) 6 s Sectors: 8</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13544_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2752622364 21.9962691453</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.13545">
      <colour code="1">White</colour>
      <featureName>
        <language>EN</language>
        <name>Orhisaari</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3331</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Orhisaari</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13544" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2752622364 21.9962691453</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13632">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3333LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>194</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>214</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Seili ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13608_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2376663301 21.9787477482</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13672">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3333LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>200</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>208</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Seili ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13608_copy_2" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2376663301 21.9787477482</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.13609">
      <colour code="7">Grey</colour>
      <featureName>
        <language>EN</language>
        <name>Seili ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3333</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Seili ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13608" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2376663301 21.9787477482</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13736">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3312LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>237.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>269.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Julholm alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13712_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.173489405 21.4168300927</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.13713">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Julholm alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3312</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Julholm alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13712" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.173489405 21.4168300927</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13800">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3313LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>57.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>89.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Finn&#xF6; alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13776_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1841343628 21.4896764301</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.13777">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Finn&#xF6; alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3313</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Finn&#xF6; alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13776" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1841343628 21.4896764301</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13864">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3314LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>57.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>89.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Finn&#xF6; ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13840_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1847135111 21.4936545222</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.13841">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Finn&#xF6; ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3314</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Finn&#xF6; ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13840" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1847135111 21.4936545222</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13928">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3303LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>265.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>269.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Hagaudden ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13904_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2630817154 21.7191151894</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.13905">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Hagaudden ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3303</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Hagaudden ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13904" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2630817154 21.7191151894</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.13992">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3304LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>257.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>265.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : J&#xE4;rvisaari alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13968_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2589161359 21.71676613</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.13969">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>J&#xE4;rvisaari alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3304</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : J&#xE4;rvisaari alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.13968" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2589161359 21.71676613</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14056">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3305LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>257.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>265.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : J&#xE4;rvisaari ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14032_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2582748498 21.7081773987</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14033">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>J&#xE4;rvisaari ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3305</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : J&#xE4;rvisaari ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14032" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2582748498 21.7081773987</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14120">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3307LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>45.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>77.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Iso Tammenkanto ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14096_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2666945492 21.7584653914</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14097">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Iso Tammenkanto ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3307</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Iso Tammenkanto ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14096" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2666945492 21.7584653914</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14184">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3298LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>167</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>181</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>181</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>192</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>192</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>356</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Tratten</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 3</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14160_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7758353182 21.3347609851</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14161">
      <colour code="2">Black</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Tratten</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3298</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Tratten</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14160" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7758353182 21.3347609851</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14248">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3300LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>187</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>191</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Hamnsk&#xE4;r ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14224_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.767639124 21.3214341162</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14225">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Hamnsk&#xE4;r ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3300</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Hamnsk&#xE4;r ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14224" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.767639124 21.3214341162</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14312">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3301LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>265.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>269.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Tammennokka alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14288_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2640481465 21.762305628</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14289">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Tammennokka alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3301</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Tammennokka alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14288" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2640481465 21.762305628</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14376">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3302LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>39</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>133</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>133</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>136</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>136</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>160</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>293</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>318.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>318.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>321</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>321</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>39</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : S&#xF6;derkobb</headline>
        <language>EN</language>
        <text>Light characteristic:Q (3) 6 s Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14352_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9338378701 21.2335848883</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14353">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>S&#xF6;derkobb</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3302</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : S&#xF6;derkobb</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14352" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9338378701 21.2335848883</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14440">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3292LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>12.8</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>15</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>15</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>189</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>355</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>12.8</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Kaitkivi</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 4 s Sectors: 3</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14416_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2354678946 21.7192653845</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14417">
      <colour code="1">White</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kaitkivi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3292</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Kaitkivi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14416" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2354678946 21.7192653845</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14504">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3294LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>66.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>74.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Kaskisgrundet ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14480_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2500783487 21.8442679398</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14481">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kaskisgrundet ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3294</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Kaskisgrundet ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14480" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2500783487 21.8442679398</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14568">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3325LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>67.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>99.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Puotuis alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14544_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2269954387 21.8155227051</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14545">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Puotuis alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3325</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Puotuis alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14544" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2269954387 21.8155227051</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14632">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3326LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>67.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>99.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Puotuis ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 8 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14608_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2274784104 21.8240736</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14609">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Puotuis ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3326</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Puotuis ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14608" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2274784104 21.8240736</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14696">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3327LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>30</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>51</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>51</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>56.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>56.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>130</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>130</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>211</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>211</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>230</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>230</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>240</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Pet&#xE4;is</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14672_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2388124727 21.7970486368</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14673">
      <colour code="1">White</colour>
      <featureName>
        <language>EN</language>
        <name>Pet&#xE4;is</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3327</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Pet&#xE4;is</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14672" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2388124727 21.7970486368</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14760">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3316LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>213.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>245.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : R&#xF6;nn&#xF6;ren ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14736_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1757677757 21.4613213311</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14737">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>R&#xF6;nn&#xF6;ren ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3316</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : R&#xF6;nn&#xF6;ren ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14736" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1757677757 21.4613213311</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14824">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3317LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>45.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>53.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : &#xC5;tlot alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14800_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2125183092 21.5477897755</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14801">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>&#xC5;tlot alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3317</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : &#xC5;tlot alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14800" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2125183092 21.5477897755</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14888">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3318LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>45.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>53.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : &#xC5;tlot ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14864_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2148259665 21.5532304451</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14865">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>&#xC5;tlot ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3318</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : &#xC5;tlot ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14864" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2148259665 21.5532304451</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.14952">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3319LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>247</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>255</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Tr&#xE4;skholm alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14928_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1907579973 21.4741812215</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14929">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Tr&#xE4;skholm alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3319</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Tr&#xE4;skholm alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14928" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1907579973 21.4741812215</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15016">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3320LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>247</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>255</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Tr&#xE4;skholm ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14992_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1880427047 21.4584705043</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.14993">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Tr&#xE4;skholm ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3320</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Tr&#xE4;skholm ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.14992" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1880427047 21.4584705043</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15080">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3563LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>335</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>343</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Laupunen ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15056_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4825205501 21.4637506933</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15057">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Laupunen ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3563</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Laupunen ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15056" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4825205501 21.4637506933</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.15144">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3564RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15120" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4016099678 21.5387010471</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <Pile gml:id="fiho.s100.S101.Pile.15121">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Svartklubb</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3564</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Svartklubb</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15120" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4016099678 21.5387010471</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15173">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3522LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>237.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>269.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Julholm ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15149_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1716791231 21.4044614582</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15150">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Julholm ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3522</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Julholm ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15149" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1716791231 21.4044614582</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15237">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3557LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>160</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>164</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Hamnsk&#xE4;r alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15213_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.5735238622 21.1084063396</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15214">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Hamnsk&#xE4;r alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3557</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Hamnsk&#xE4;r alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15213" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.5735238622 21.1084063396</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15301">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3560LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>7</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>7</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>78</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>78</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>175</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>175</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>180</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>180</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>212</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>212</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>286</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>286</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>289</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>289</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>348</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>348</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : B&#xE5;dan</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 5 s Sectors: 9</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15277_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4978762692 21.1407853012</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15278">
      <colour code="2">Black</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>B&#xE5;dan</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3560</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : B&#xE5;dan</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15277" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4978762692 21.1407853012</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15365">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3544LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>184</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>329</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>329</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>333</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>333</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>4</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Kopph&#xE4;ll</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (2) 3 s Sectors: 3</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15341_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1270311065 21.6715816861</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15342">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kopph&#xE4;ll</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3544</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Kopph&#xE4;ll</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15341" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1270311065 21.6715816861</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15429">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3170LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>43</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>55</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>55</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>79</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>79</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>96.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>96.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>100</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>100</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>121</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>121</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>232</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>232</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>236</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>236</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>246</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>359</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>43</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Seilinriutta</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 5 s Sectors: 9</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15405_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2529715414 21.896562282</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15406">
      <colour code="1">White</colour>
      <featureName>
        <language>EN</language>
        <name>Seilinriutta</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3170</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Seilinriutta</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15405" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2529715414 21.896562282</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15493">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3171LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>30.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>62.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Purha ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15469_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2769472107 21.9440174537</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15470">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Purha ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3171</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Purha ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15469" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2769472107 21.9440174537</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15557">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3338LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>344</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>16</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Viheri&#xE4;inen ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15533_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4505459106 22.0808077619</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15534">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Viheri&#xE4;inen ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3338</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Viheri&#xE4;inen ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15533" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4505459106 22.0808077619</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15621">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3328LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>43</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>51</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : V&#xE4;&#xE4;r&#xE4;maa ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15597_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2813903943 21.8847151485</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15598">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>V&#xE4;&#xE4;r&#xE4;maa ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3328</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : V&#xE4;&#xE4;r&#xE4;maa ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15597" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2813903943 21.8847151485</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15685">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3329LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>248</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>256</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Haapaluoto alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15661_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2461717051 21.7950772581</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15662">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Haapaluoto alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3329</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Haapaluoto alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15661" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2461717051 21.7950772581</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.15749">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3626RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15725" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4749687622 21.3360843094</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <Pile gml:id="fiho.s100.S101.Pile.15726">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Santasaari</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3626</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Santasaari</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15725" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4749687622 21.3360843094</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15778">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3630LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>341</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>349</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Apuloisto : Lilla Korpsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl (2) 5 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15754_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0431528707 21.0891964539</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15755">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Lilla Korpsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3630</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Apuloisto : Lilla Korpsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15754" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0431528707 21.0891964539</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15842">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3310LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>63.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>72</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>236</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>246</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>246</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>63.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Sk&#xE4;lgrund</headline>
        <language>EN</language>
        <text>Light characteristic:Q (2) 6 s Sectors: 3</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15818_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1168949464 21.2673227384</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15819">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Sk&#xE4;lgrund</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3310</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Sk&#xE4;lgrund</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15818" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1168949464 21.2673227384</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15906">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3311LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>41</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>61</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Korsholm ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15882_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1874091092 21.4669691149</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15883">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Korsholm ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3311</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Korsholm ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15882" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1874091092 21.4669691149</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.15970">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3562LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>271.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>303.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Iso Muna ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15946_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.482421833 21.3926873761</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.15947">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Iso Muna ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3562</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Iso Muna ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.15946" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.482421833 21.3926873761</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.16034">
      <interoperabilityIdentifier>urn:mrn:fin:aton:21754RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16010" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.6766724844 21.4958093427</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <Pile gml:id="fiho.s100.S101.Pile.16011">
      <colour code="13">Pink</colour>
      <featureName>
        <language>EN</language>
        <name>Grims&#xF6;rar</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:21754</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Grims&#xF6;rar</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16010" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.6766724844 21.4958093427</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.16063">
      <interoperabilityIdentifier>urn:mrn:fin:aton:21762RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16039" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9287113889 21.2222266817</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <Pile gml:id="fiho.s100.S101.Pile.16040">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kummelkl&#xE4;ppen</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:21762</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Kummelkl&#xE4;ppen</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16039" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9287113889 21.2222266817</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.16093">
      <interoperabilityIdentifier>urn:mrn:fin:aton:21521RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16069" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3586033437 22.0762533625</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <Pile gml:id="fiho.s100.S101.Pile.16070">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Tervi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:21521</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Tervi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16069" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3586033437 22.0762533625</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.16160">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:21707LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : Kyrkog&#xE5;rdsgrund</headline>
        <language>EN</language>
        <text>Light characteristic:VQ Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16098_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2282679374 21.7282511586</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBeacon gml:id="fiho.s100.S101.CardinalBeacon.16099">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfCardinalMark code="1">North Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kyrkog&#xE5;rdsgrund</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:21707</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Kyrkog&#xE5;rdsgrund</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16098" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2282679374 21.7282511586</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBeacon>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.16240">
      <interoperabilityIdentifier>urn:mrn:fin:aton:21780RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16216" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9709339793 21.1456522995</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <Pile gml:id="fiho.s100.S101.Pile.16217">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Norrharun</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:21780</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Norrharun</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16216" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9709339793 21.1456522995</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.16269">
      <interoperabilityIdentifier>urn:mrn:fin:aton:21795RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16245" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1944489719 21.5168769436</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <Pile gml:id="fiho.s100.S101.Pile.16246">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Keitsorinkivi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:21795</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Keitsorinkivi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16245" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1944489719 21.5168769436</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.16334">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5941LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Storrevet</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16274_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9154662434 21.2493442213</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.16275">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Storrevet</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5941</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Storrevet</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16274" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9154662434 21.2493442213</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.16414">
      <interoperabilityIdentifier>urn:mrn:fin:aton:21885RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16390" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4693153175 21.4539999177</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <Pile gml:id="fiho.s100.S101.Pile.16391">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Isoletto</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:21885</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Isoletto</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16390" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4693153175 21.4539999177</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.16479">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5645LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Ruskiakari</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16419_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4168556738 22.083704552</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.16420">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Ruskiakari</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5645</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Ruskiakari</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16419" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4168556738 22.083704552</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.16592">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5946LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Norrharun</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16532_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9707379249 21.1492383162</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.16533">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Norrharun</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5946</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Norrharun</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16532" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9707379249 21.1492383162</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.16646">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="3">South Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Ristiluoto</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5755</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Ristiluoto</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16645" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.390648984 21.5652302198</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.16726">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5931LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Stenharu</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16666_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8074972636 21.331076791</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.16667">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Stenharu</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5931</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Stenharu</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16666" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8074972636 21.331076791</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.16839">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5677LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Lilla Bj&#xF6;rnholm</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16779_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2101206495 21.5944534589</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.16780">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Lilla Bj&#xF6;rnholm</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5677</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Lilla Bj&#xF6;rnholm</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16779" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2101206495 21.5944534589</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.16916">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3322LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>83</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>91</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Halsholmarna alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16892_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2144766781 21.6815845984</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.16893">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Halsholmarna alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3322</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Halsholmarna alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16892" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2144766781 21.6815845984</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.16980">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3336LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>342</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>350</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Tupavuori ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16956_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4550873104 22.066413026</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.16957">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Tupavuori ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3336</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Tupavuori ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.16956" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4550873104 22.066413026</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.17044">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3143LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>118.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>126.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : V&#xE4;h&#xE4;-Ristiluoto alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17020_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3727559609 21.6175846748</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.17021">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>V&#xE4;h&#xE4;-Ristiluoto alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3143</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : V&#xE4;h&#xE4;-Ristiluoto alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17020" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3727559609 21.6175846748</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.17108">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3206LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>59.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>63.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Norparsk&#xE4;rssten ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17084_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.916180069 21.6478471941</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.17085">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Norparsk&#xE4;rssten ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3206</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Norparsk&#xE4;rssten ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17084" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.916180069 21.6478471941</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.17172">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3131LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>160</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>180.6</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>180.6</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>188</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>188</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>295</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>295</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>314</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>314</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>317</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>317</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>340</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Jurmo alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17148_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.5211220871 21.1245275447</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.17149">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Jurmo alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3131</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Jurmo alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17148" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.5211220871 21.1245275447</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.17236">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3139LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>335</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>343</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Laupunen alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17212_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.478416481 21.4669571153</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.17213">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Laupunen alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3139</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Laupunen alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17212" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.478416481 21.4669571153</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.17300">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3144LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>118.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>126.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : V&#xE4;h&#xE4;-Ristiluoto ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17276_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3702810256 21.6253970535</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.17277">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>V&#xE4;h&#xE4;-Ristiluoto ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3144</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : V&#xE4;h&#xE4;-Ristiluoto ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17276" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3702810256 21.6253970535</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.17364">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3511LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>321</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>329</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Tallgrund ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17340_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3810750227 21.5535753841</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.17341">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Tallgrund ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3511</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Tallgrund ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17340" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3810750227 21.5535753841</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.17428">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3565LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>321</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>329</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Kuiva Kalsaari alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17404_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3082446978 21.7352101016</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.17405">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kuiva Kalsaari alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3565</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Kuiva Kalsaari alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17404" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3082446978 21.7352101016</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.17492">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3584LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>14.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>22.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Vandrock alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17468_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2118006579 21.7203962003</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.17469">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Vandrock alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3584</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Vandrock alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17468" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2118006579 21.7203962003</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.17594">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5902LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : H&#xE5;llers </headline>
        <language>EN</language>
        <text>Light characteristic:VQ (9) 10 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17532_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0944947469 21.697716729</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBeacon gml:id="fiho.s100.S101.CardinalBeacon.17533">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfCardinalMark code="4">West Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>H&#xE5;llers </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5902</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : H&#xE5;llers </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17532" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0944947469 21.697716729</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBeacon>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.17671">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3293LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>66.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>74.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Kaskisgrundet alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17647_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2470154108 21.8267680274</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.17648">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kaskisgrundet alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3293</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Kaskisgrundet alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17647" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2470154108 21.8267680274</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.17773">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5679LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : V&#xE4;stra J&#xE4;nisholm</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17713_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2191556431 21.6876503321</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.17714">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>V&#xE4;stra J&#xE4;nisholm</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5679</interoperabilityIdentifier>
      <information>
        <headline>Poiju : V&#xE4;stra J&#xE4;nisholm</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17713" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2191556431 21.6876503321</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.17850">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3481LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>278</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>209</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : R&#xE5;tgrund alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17826_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2635577884 21.7465199603</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.17827">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>R&#xE5;tgrund alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3481</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : R&#xE5;tgrund alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17826" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2635577884 21.7465199603</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.17914">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3218LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>3.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>12</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>12</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>57</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>57</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>99</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>99</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>139</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>139</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>171</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>348.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>3.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Fagerholm alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17890_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1111988196 21.698022859</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.17891">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Fagerholm alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3218</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Fagerholm alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17890" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1111988196 21.698022859</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.17978">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3151LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>321</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>329</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Kuiva Kalsaari ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17954_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3185536774 21.7201342464</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.17955">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kuiva Kalsaari ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3151</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Kuiva Kalsaari ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.17954" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3185536774 21.7201342464</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.18042">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3224LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>136.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>192</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>192</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>203</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>203</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>262</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Retais alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 3</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18018_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1752042235 21.6955379597</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.18019">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Retais alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3224</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Retais alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18018" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1752042235 21.6955379597</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.18106">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3217LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>183</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>191</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : B&#xE4;sskubb ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18082_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0051378368 21.6725949741</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.18083">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>B&#xE4;sskubb ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3217</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : B&#xE4;sskubb ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18082" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0051378368 21.6725949741</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.18170">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3614RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18146" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9952226137 21.692926294</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <Pile gml:id="fiho.s100.S101.Pile.18147">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Bondsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3614</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Bondsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18146" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9952226137 21.692926294</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.18199">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3296LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>45</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>101</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>101</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>148</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>148</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>155</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>155</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>172</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>262</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>340</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>340</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>45</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Lillharun</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 7 s Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18175_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7276809294 21.4007175919</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.18176">
      <colour code="1">White</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Lillharun</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3296</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Lillharun</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18175" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7276809294 21.4007175919</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.18264">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3149LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>296</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>304</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Kekoluoto alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18240_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3469592735 21.5848502325</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.18241">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kekoluoto alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3149</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Kekoluoto alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18240" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3469592735 21.5848502325</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.18328">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3605LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>60</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>69.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>69.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>127</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>127</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>222</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>222</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>228</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>228</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>260</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Norparsk&#xE4;rssten alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 5</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18304_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8985387242 21.5822231533</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.18305">
      <colour code="1">White</colour>
      <featureName>
        <language>EN</language>
        <name>Norparsk&#xE4;rssten alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3605</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Norparsk&#xE4;rssten alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18304" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8985387242 21.5822231533</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.18392">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3299LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>185</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>193</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Hamnsk&#xE4;r alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18368_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7749211645 21.3237566294</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.18369">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Hamnsk&#xE4;r alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3299</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Hamnsk&#xE4;r alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18368" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7749211645 21.3237566294</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.18457">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3215LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>341</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>349</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Grisselborg ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18433_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0826336613 21.6625530861</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.18434">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Grisselborg ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3215</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Grisselborg ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18433" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0826336613 21.6625530861</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.18523">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3308LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>161</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>169</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : S&#xF6;derharun ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18499_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9456367032 21.1417825237</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.18500">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>S&#xF6;derharun ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3308</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : S&#xF6;derharun ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18499" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9456367032 21.1417825237</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.18624">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:77630LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Kalvholmskobben</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (3) 5 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18564_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2241442919 21.7126322923</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.18565">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kalvholmskobben</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:77630</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Kalvholmskobben</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18564" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2241442919 21.7126322923</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.18704">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3315LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>213.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>245.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : R&#xF6;nn&#xF6;ren alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18680_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1771564377 21.4645803231</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.18681">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>R&#xF6;nn&#xF6;ren alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3315</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : R&#xF6;nn&#xF6;ren alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18680" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1771564377 21.4645803231</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.18809">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:74876LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Noy 4</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18749_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.450362125 22.0707181054</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.18750">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Noy 4</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:74876</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Noy 4</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18749" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.450362125 22.0707181054</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.18891">
      <interoperabilityIdentifier>urn:mrn:fin:aton:81416LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>348.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>356.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : J&#xE4;nisholm alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18867_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2151614106 21.698875679</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.18868">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>J&#xE4;nisholm alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:81416</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : J&#xE4;nisholm alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18867" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2151614106 21.698875679</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.18957">
      <interoperabilityIdentifier>urn:mrn:fin:aton:21533RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18933" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2624778166 21.8680197326</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <Pile gml:id="fiho.s100.S101.Pile.18934">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>V&#xE4;&#xE4;r&#xE4;maankivi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:21533</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : V&#xE4;&#xE4;r&#xE4;maankivi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18933" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2624778166 21.8680197326</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.19022">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5741LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Hummelsk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18962_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1534828193 21.3908892751</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.18963">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Hummelsk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5741</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Hummelsk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.18962" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1534828193 21.3908892751</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.19099">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3582LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>90</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>193</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>193</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>198.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>198.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>259</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : T&#xE4;rngrundet  alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 3</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19075_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1112337346 21.6709271312</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.19076">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>T&#xE4;rngrundet  alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3582</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : T&#xE4;rngrundet  alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19075" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1112337346 21.6709271312</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.19199">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5684LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Kristinaklippan</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19139_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2233565944 21.7362558607</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.19140">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Kristinaklippan</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5684</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Kristinaklippan</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19139" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2233565944 21.7362558607</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.19276">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3323LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>83</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>91</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Halsholmarna ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19252_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2146620118 21.6893738323</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.19253">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Halsholmarna ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3323</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Halsholmarna ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19252" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2146620118 21.6893738323</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.19340">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3321LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>67</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>75</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Sk&#xF6;ldholmarna alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19316_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2233670248 21.662983942</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.19317">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Sk&#xF6;ldholmarna alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3321</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Sk&#xF6;ldholmarna alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19316" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2233670248 21.662983942</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.19404">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3523LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>67</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>75</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Sk&#xF6;ldholmarna ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19380_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2252130802 21.6737372873</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.19381">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Sk&#xF6;ldholmarna ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3523</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Sk&#xF6;ldholmarna ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19380" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2252130802 21.6737372873</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.19468">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3558LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>85</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>85</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>123</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>123</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>135</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>135</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>195</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>341</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>357</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>357</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Korra</headline>
        <language>EN</language>
        <text>Light characteristic:Q (2) 6 s Sectors: 6</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19444_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.5764415817 21.1429787024</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.19445">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Korra</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3558</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Korra</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19444" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.5764415817 21.1429787024</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.19532">
      <interoperabilityIdentifier>urn:mrn:fin:aton:20125LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>1</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>14</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>14</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>19</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>90</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>156</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>156</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>165.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>165.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>176</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>176</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>242</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>344</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>1</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Ut&#xF6; alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 7</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19508_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7821029352 21.3577615501</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.19572">
      <interoperabilityIdentifier>urn:mrn:fin:aton:20125LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>0</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>19</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Ut&#xF6; alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19508_copy_2" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7821029352 21.3577615501</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.19509">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Ut&#xF6; alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:20125</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Ut&#xF6; alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19508" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7821029352 21.3577615501</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.19674">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5891LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : Finnklobb </headline>
        <language>EN</language>
        <text>Light characteristic:VQ (3) 5 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19612_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.497924627 21.1667829231</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBeacon gml:id="fiho.s100.S101.CardinalBeacon.19613">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Finnklobb </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5891</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Finnklobb </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19612" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.497924627 21.1667829231</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBeacon>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.19751">
      <interoperabilityIdentifier>urn:mrn:fin:aton:21774RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19727" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7494121741 21.322900537</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <Pile gml:id="fiho.s100.S101.Pile.19728">
      <colour code="1">White</colour>
      <colour code="11">Orange</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Svartb&#xE5;dan</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:21774</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Svartb&#xE5;dan</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19727" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7494121741 21.322900537</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.19817">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5637LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Pitk&#xE4;niemi</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19757_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2748809565 21.9604583833</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.19758">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Pitk&#xE4;niemi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5637</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Pitk&#xE4;niemi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19757" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2748809565 21.9604583833</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <CardinalBeacon gml:id="fiho.s100.S101.CardinalBeacon.19871">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfCardinalMark code="4">West Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kungsholm </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5763</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Kungsholm </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19870" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4946555282 21.1856066125</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBeacon>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.19919">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3332LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>194</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>214</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Seili alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19895_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2465726706 21.986732369</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.19959">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3332LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>200</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>208</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Seili alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19895_copy_2" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2465726706 21.986732369</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.19896">
      <colour code="7">Grey</colour>
      <featureName>
        <language>EN</language>
        <name>Seili alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3332</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Seili alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19895" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2465726706 21.986732369</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.20059">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5924LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Kolkan</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (6) + LFl 10 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19999_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2357183531 21.7570923667</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBuoy gml:id="fiho.s100.S101.CardinalBuoy.20000">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfCardinalMark code="3">South Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Kolkan</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5924</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Kolkan</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.19999" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2357183531 21.7570923667</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBuoy>
    <RadarReflector gml:id="fiho.s100.S101.RadarReflector.20136">
      <interoperabilityIdentifier>urn:mrn:fin:aton:21552RADREF001</interoperabilityIdentifier>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20112" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4106729887 22.084575175</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </RadarReflector>
    <Pile gml:id="fiho.s100.S101.Pile.20113">
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Porokari</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:21552</interoperabilityIdentifier>
      <information>
        <headline>Tutkamerkki : Porokari</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20112" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4106729887 22.084575175</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.20203">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5745LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : K&#xE4;risk&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20143_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1768564776 21.4474028909</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.20144">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>K&#xE4;risk&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5745</interoperabilityIdentifier>
      <information>
        <headline>Poiju : K&#xE4;risk&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20143" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1768564776 21.4474028909</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.20317">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5685LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : F&#xE5;gelholmen</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20257_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2214282353 21.7366644387</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.20258">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>F&#xE5;gelholmen</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5685</interoperabilityIdentifier>
      <information>
        <headline>Poiju : F&#xE5;gelholmen</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20257" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2214282353 21.7366644387</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.20395">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3222LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>8</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>12</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="3">Red</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>12</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>24</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>172</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>8</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Sektoriloisto : Holstasn&#xE4;s</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 3</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20371_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.155889492 21.6900794501</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.20372">
      <colour code="1">White</colour>
      <featureName>
        <language>EN</language>
        <name>Holstasn&#xE4;s</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3222</interoperabilityIdentifier>
      <visualProminence code="1">Visually Conspicuous</visualProminence>
      <information>
        <headline>Sektoriloisto : Holstasn&#xE4;s</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20371" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.155889492 21.6900794501</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.20459">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3141LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>156</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>164</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Ingastholm ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20435_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3852049043 21.538036539</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.20436">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Ingastholm ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3141</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Ingastholm ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20435" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3852049043 21.538036539</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.20523">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3134LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>280</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>284</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Borg&#xE5;sten alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20499_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4912637976 21.1474029747</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.20500">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Borg&#xE5;sten alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3134</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Borg&#xE5;sten alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20499" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4912637976 21.1474029747</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.20587">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3208LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>52</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>56</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : N&#xF6;t&#xF6; ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 8 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20563_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9645150803 21.7461489041</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.20564">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>N&#xF6;t&#xF6; ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3208</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : N&#xF6;t&#xF6; ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20563" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9645150803 21.7461489041</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.20652">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3306LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>161</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>169</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : S&#xF6;derharun alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20628_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.954569564 21.1369768527</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.20629">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>S&#xF6;derharun alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3306</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : S&#xF6;derharun alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20628" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.954569564 21.1369768527</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.20716">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3324LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="7">Grey</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>251.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>259.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Stora Bj&#xF6;rnholm ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20692_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2066008037 21.5987793346</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.20693">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Stora Bj&#xF6;rnholm ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3324</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Stora Bj&#xF6;rnholm ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20692" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2066008037 21.5987793346</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.20818">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5893LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : Satamaa </headline>
        <language>EN</language>
        <text>Light characteristic:VQ Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20756_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3920914849 21.5503345502</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBeacon gml:id="fiho.s100.S101.CardinalBeacon.20757">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfCardinalMark code="1">North Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Satamaa </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5893</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Satamaa </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20756" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.3920914849 21.5503345502</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.20931">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5951LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Gr&#xE5;sk&#xE4;rskobb</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20871_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0398294494 21.1572677533</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.20872">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Gr&#xE5;sk&#xE4;rskobb</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5951</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Gr&#xE5;sk&#xE4;rskobb</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20871" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0398294494 21.1572677533</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.21044">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5936LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Skatask&#xE4;r</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20984_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8617562133 21.3445797908</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.20985">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Skatask&#xE4;r</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5936</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Skatask&#xE4;r</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.20984" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8617562133 21.3445797908</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.21157">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5928LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : V&#xE4;sterudden</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21097_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7813196037 21.3514682388</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.21098">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>V&#xE4;sterudden</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5928</interoperabilityIdentifier>
      <information>
        <headline>Poiju : V&#xE4;sterudden</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21097" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7813196037 21.3514682388</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.21274">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6062LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : S&#xF6;derb&#xE5;dan</headline>
        <language>EN</language>
        <text>Light characteristic:VQ (6) + LFl 10 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21212_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8718739185 21.3517500032</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBeacon gml:id="fiho.s100.S101.CardinalBeacon.21213">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfCardinalMark code="3">South Cardinal Mark</categoryOfCardinalMark>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>S&#xF6;derb&#xE5;dan</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6062</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : S&#xF6;derb&#xE5;dan</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21212" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8718739185 21.3517500032</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.21387">
      <colour code="3">Red</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5643LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : Vuojasenkari</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21327_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.409024048 22.0877012274</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.21328">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="1">Port-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="3">Red</colour>
      <featureName>
        <language>EN</language>
        <name>Vuojasenkari</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5643</interoperabilityIdentifier>
      <information>
        <headline>Poiju : Vuojasenkari</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21327" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.409024048 22.0877012274</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.21465">
      <interoperabilityIdentifier>urn:mrn:fin:aton:37003LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>192.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>200.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Svartholm alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21441_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2151698134 21.6988808184</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.21442">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Svartholm alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:37003</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Svartholm alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21441" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.2151698134 21.6988808184</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.21566">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5945LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Poiju : M&#xE4;rsen</headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21506_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9573007994 21.1953577276</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBuoy gml:id="fiho.s100.S101.LateralBuoy.21507">
      <buoyShape code="1">Conical</buoyShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>M&#xE4;rsen</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5945</interoperabilityIdentifier>
      <information>
        <headline>Poiju : M&#xE4;rsen</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21506" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.9573007994 21.1953577276</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBuoy>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.21682">
      <colour code="1">White</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6081LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="5">Very Quick-Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : B&#xE4;sskubb </headline>
        <language>EN</language>
        <text>Light characteristic:VQ (3) 5 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21620_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0171758934 21.691101925</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <CardinalBeacon gml:id="fiho.s100.S101.CardinalBeacon.21621">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfCardinalMark code="2">East Cardinal Mark</categoryOfCardinalMark>
      <colour code="2">Black</colour>
      <colour code="6">Yellow</colour>
      <colour code="2">Black</colour>
      <colourPattern code="1">Horizontal Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>B&#xE4;sskubb </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:6081</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : B&#xE4;sskubb </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21620" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.0171758934 21.691101925</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </CardinalBeacon>
    <LightAllAround gml:id="fiho.s100.S101.LightAllAround.21797">
      <colour code="4">Green</colour>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5706LIGHT</interoperabilityIdentifier>
      <rhythmOfLight>
        <lightCharacteristic code="2">Flashing</lightCharacteristic>
      </rhythmOfLight>
      <information>
        <headline>Reunamerkki : Torvsk&#xE4;r </headline>
        <language>EN</language>
        <text>Light characteristic:Fl 3 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21735_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8354931413 21.3455098326</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightAllAround>
    <LateralBeacon gml:id="fiho.s100.S101.LateralBeacon.21736">
      <beaconShape code="1">Stake, Pole, Perch, Post</beaconShape>
      <categoryOfLateralMark code="2">Starboard-Hand Lateral Mark</categoryOfLateralMark>
      <colour code="4">Green</colour>
      <featureName>
        <language>EN</language>
        <name>Torvsk&#xE4;r </name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:5706</interoperabilityIdentifier>
      <information>
        <headline>Reunamerkki : Torvsk&#xE4;r </headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21735" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8354931413 21.3455098326</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LateralBeacon>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.21874">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3219LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>3</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>11</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Fagerholm ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21850_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1190801442 21.6999242476</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.21851">
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Fagerholm ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3219</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Fagerholm ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21850" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.1190801442 21.6999242476</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.21938">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3202LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>228</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>236</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Stenharun ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21914_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7965998928 21.2908473364</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.21915">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Stenharun ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3202</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Stenharun ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21914" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.7965998928 21.2908473364</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.22003">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3335LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="4">Quick-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="4">Green</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>342</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>350</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Tupavuori alempi</headline>
        <language>EN</language>
        <text>Light characteristic:Q Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21979_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4413869698 22.0734557568</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.21980">
      <colour code="3">Red</colour>
      <colour code="6">Yellow</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Tupavuori alempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3335</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Tupavuori alempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.21979" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>60.4413869698 22.0734557568</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
    <LightSectored gml:id="fiho.s100.S101.LightSectored.22067">
      <interoperabilityIdentifier>urn:mrn:fin:aton:3297LIGHT</interoperabilityIdentifier>
      <sectorCharacteristics>
        <lightCharacteristic code="3">Long-Flashing</lightCharacteristic>
        <lightSector>
          <colour code="1">White</colour>
          <sectorLimit>
            <sectorLimitOne>
              <sectorBearing>347.5</sectorBearing>
            </sectorLimitOne>
            <sectorLimitTwo>
              <sectorBearing>355.5</sectorBearing>
            </sectorLimitTwo>
          </sectorLimit>
        </lightSector>
      </sectorCharacteristics>
      <information>
        <headline>Linjamerkki : Skatask&#xE4;r ylempi</headline>
        <language>EN</language>
        <text>Light characteristic:LFl 6 s Sectors: 1</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.22043_copy_1" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8540797256 21.3239444275</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </LightSectored>
    <Pile gml:id="fiho.s100.S101.Pile.22044">
      <colour code="3">Red</colour>
      <colour code="1">White</colour>
      <colour code="3">Red</colour>
      <colourPattern code="2">Vertical Stripes</colourPattern>
      <featureName>
        <language>EN</language>
        <name>Skatask&#xE4;r ylempi</name>
      </featureName>
      <interoperabilityIdentifier>urn:mrn:fin:aton:3297</interoperabilityIdentifier>
      <information>
        <headline>Linjamerkki : Skatask&#xE4;r ylempi</headline>
        <language>EN</language>
        <text>Type</text>
      </information>
      <geometry>
        <S100:pointProperty>
          <S100:Point gml:id="fiho.s100.Geometry.22043" srsDimension="2" srsName="urn:ogc:def:crs:EPSG:4326">
            <gml:pos>59.8540797256 21.3239444275</gml:pos>
          </S100:Point>
        </S100:pointProperty>
      </geometry>
    </Pile>
  </members>
</Dataset>