<xsl:stylesheet 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0" 
  xmlns:S100FC="http://www.iho.int/S100FC/5.2" 
  xmlns:S100Base="http://www.iho.int/S100Base/5.0" 
  xmlns:S100CI="http://www.iho.int/S100CI/5.0" 
  xmlns:xlink="http://www.w3.org/1999/xlink" 
  xmlns:S100CD="http://www.iho.int/S100CD/5.0" 
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
  xsi:schemaLocation="http://www.iho.int/S100FC/5.2 https://schemas.s100dev.net/schemas/S100/5.2.0/S100FC/20231214/S100FC.xsd">
  <xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

  <xsl:template match="/">
    <html>
      <head>
        <meta charset="UTF-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <title>FeatureCatalogue</title>
        <style>
          .accordion {
          background-color: #eee;
          color: #444;
          cursor: pointer;
          padding: 18px;
          width: 100%;
          border: none;
          text-align: left;
          outline: none;
          font-size: 15px;
          transition: 0.4s;
          }

          .active, .accordion:hover {
          background-color: #ccc;
          }

          .panel {
          padding: 0 18px;
          display: none;
          background-color: white;
          overflow: hidden;
          }

          details {
          border: 1px solid #aaa;
          border-radius: 4px;
          padding: 0.5em 0.5em 0;
          }

          summary {
          font-weight: bold;
          margin: -0.5em -0.5em 0;
          padding: 0.5em;
          }
          
          details{
          margin-bottom: 8px;
          }
          details[open] {
          padding: 0.5em;
          }

          details[open] summary {
          border-bottom: 1px solid #aaa;
          margin-bottom: 0.5em;
          }

          table th{
          padding-right: 8px;
          }
          table th,td{
          vertical-align: top;
          text-align: left;
          }

          code {
          padding: 0px;
          }
          .listedValues{
          border-spacing: 0px;
          }
          .listedValues td{
          padding-left: 8px;
          }

        </style>
      </head>
      <body>


        <div class="container">
          <h2>FeatureCatalogue</h2>

          <div class="row">
            <div class="col-md-12">
              <table>
                <tr>
                  <th>name</th>
                  <td>
                    <xsl:value-of select="S100FC:S100_FC_FeatureCatalogue/S100FC:productId"/>: <xsl:value-of select="S100FC:S100_FC_FeatureCatalogue/S100FC:name"/>
                  </td>
                </tr>
                <tr>
                  <th>scope</th>
                  <td>
                    <xsl:value-of select="S100FC:S100_FC_FeatureCatalogue/S100FC:scope"/>
                  </td>
                </tr>
                <tr>
                  <th>versionNumber</th>
                  <td>
                    <xsl:value-of select="S100FC:S100_FC_FeatureCatalogue/S100FC:versionNumber"/>
                  </td>
                </tr>
                <tr>
                  <th>versionDate</th>
                  <td>
                    <xsl:value-of select="S100FC:S100_FC_FeatureCatalogue/S100FC:versionDate"/>
                  </td>
                </tr>
              </table>
            </div>
          </div>

          <div class="row">
            <div class="col-md-6">
              <article class="">
                <hr/>
                <h3>Feature types</h3>
                <xsl:for-each select="S100FC:S100_FC_FeatureCatalogue/S100FC:S100_FC_FeatureTypes/S100FC:S100_FC_FeatureType">
                  <xsl:variable name="code" select="S100FC:code" />

                  <a>
                    <xsl:attribute name="id">
                      <xsl:value-of select="S100FC:code"/>
                    </xsl:attribute>
                  </a>

                  <details open="">
                    <summary>

                      <code>
                        <xsl:value-of select="S100FC:code"/>
                      </code>
                    </summary>

                    <table>
                      <tr>
                        <th>
                          code
                        </th>
                        <td>
                          <code>
                            <xsl:value-of select="S100FC:code"/>
                          </code>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          alias
                        </th>
                        <td>
                          <xsl:value-of select="S100FC:alias"/>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          name
                        </th>
                        <td>
                          <xsl:value-of select="S100FC:name"/>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          definition
                        </th>
                        <td>
                          <xsl:value-of select="S100FC:definition"/>
                        </td>
                      </tr>
                      <xsl:for-each select="S100FC:permittedPrimitives">
                        <tr>
                          <th>
                            permittedPrimitives
                          </th>
                          <td>
                            <xsl:value-of select="node()[1]"/>
                          </td>
                        </tr>
                      </xsl:for-each>

                      <xsl:for-each select="S100FC:attributeBinding">
                        <tr>
                          <th>
                          </th>
                          <td>
                            <a>
                              <xsl:attribute name="href">
                                <xsl:value-of select="concat('#', S100FC:attribute/@ref)"/>
                              </xsl:attribute>
                              <xsl:value-of select="S100FC:attribute/@ref"/>
                            </a>
                            <xsl:if test="S100FC:multiplicity/S100Base:upper/@infinite = 'true'">
                              <xsl:value-of select="concat('[', S100FC:multiplicity/S100Base:lower, '..*', ']')"/>
                            </xsl:if>
                            <xsl:if test="S100FC:multiplicity/S100Base:upper/@infinite = 'false'">
                              <xsl:value-of select="concat('[', S100FC:multiplicity/S100Base:lower, '..', S100FC:multiplicity/S100Base:upper, ']')"/>
                            </xsl:if>
                            <xsl:if test="S100FC:permittedValues/S100FC:value">
                              permittedValues: [
                              <xsl:for-each select="S100FC:permittedValues/S100FC:value">
                                <xsl:value-of select="position()"/>,
                              </xsl:for-each>
                              ]
                            </xsl:if>

                          </td>
                        </tr>
                      </xsl:for-each>

                    </table>
                  </details>


                </xsl:for-each>

              </article>
            </div>
          
<div class="col-md-6">
              <article class="">
                <hr/>
                <h3>Information types</h3>
                <xsl:for-each select="S100FC:S100_FC_FeatureCatalogue/S100FC:S100_FC_InformationTypes/S100FC:S100_FC_InformationType">
                  <xsl:variable name="code" select="S100FC:code" />

                  <a>
                    <xsl:attribute name="id">
                      <xsl:value-of select="S100FC:code"/>
                    </xsl:attribute>
                  </a>

                  <details open="">
                    <summary>

                      <code>
                        <xsl:value-of select="S100FC:code"/>
                      </code>
                    </summary>

                    <table>
                      <tr>
                        <th>
                          code
                        </th>
                        <td>
                          <code>
                            <xsl:value-of select="S100FC:code"/>
                          </code>
                        </td>
                      </tr>                      
                      <tr>
                        <th>
                          name
                        </th>
                        <td>
                          <xsl:value-of select="S100FC:name"/>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          definition
                        </th>
                        <td>
                          <xsl:value-of select="S100FC:definition"/>
                        </td>
                      </tr>                      

                      <xsl:for-each select="S100FC:attributeBinding">
                        <tr>
                          <th>
                          </th>
                          <td>
                            <a>
                              <xsl:attribute name="href">
                                <xsl:value-of select="concat('#', S100FC:attribute/@ref)"/>
                              </xsl:attribute>
                              <xsl:value-of select="S100FC:attribute/@ref"/>
                            </a>
                            <xsl:if test="S100FC:multiplicity/S100Base:upper/@infinite = 'true'">
                              <xsl:value-of select="concat('[', S100FC:multiplicity/S100Base:lower, '..*', ']')"/>
                            </xsl:if>
                            <xsl:if test="S100FC:multiplicity/S100Base:upper/@infinite = 'false'">
                              <xsl:value-of select="concat('[', S100FC:multiplicity/S100Base:lower, '..', S100FC:multiplicity/S100Base:upper, ']')"/>
                            </xsl:if>
                            <xsl:if test="S100FC:permittedValues/S100FC:value">
                              permittedValues: [
                              <xsl:for-each select="S100FC:permittedValues/S100FC:value">
                                <xsl:value-of select="position()"/>,
                              </xsl:for-each>
                              ]
                            </xsl:if>

                          </td>
                        </tr>
                      </xsl:for-each>

                    </table>
                  </details>


                </xsl:for-each>

              </article>
            </div>          
          </div>

          <div class="row">
            <div class="col-md-6">
              <article class="">
                <hr/>
                <h3>Complex attributes</h3>
                <xsl:for-each select="S100FC:S100_FC_FeatureCatalogue/S100FC:S100_FC_ComplexAttributes/S100FC:S100_FC_ComplexAttribute">
                  <xsl:variable name="code" select="S100FC:code" />

                  <a>
                    <xsl:attribute name="id">
                      <xsl:value-of select="S100FC:code"/>
                    </xsl:attribute>
                  </a>
                  <details open="">
                    <summary>

                      <code>
                        <xsl:value-of select="S100FC:code"/>
                      </code>
                    </summary>

                    <table>
                      <tr>
                        <th>
                          code
                        </th>
                        <td>
                          <code>
                            <xsl:value-of select="S100FC:code"/>
                          </code>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          name
                        </th>
                        <td>
                          <xsl:value-of select="S100FC:name"/>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          definition
                        </th>
                        <td>
                          <xsl:value-of select="S100FC:definition"/>
                        </td>
                      </tr>

                      <xsl:for-each select="S100FC:subAttributeBinding">
                        <tr>
                          <th>
                          </th>
                          <td>
                            <a>
                              <xsl:attribute name="href">
                                <xsl:value-of select="concat('#', S100FC:attribute/@ref)"/>
                              </xsl:attribute>
                              <xsl:value-of select="S100FC:attribute/@ref"/>
                            </a>
                            <xsl:if test="S100FC:multiplicity/S100Base:upper/@infinite = 'true'">
                              <xsl:value-of select="concat('[', S100FC:multiplicity/S100Base:lower, '..*', ']')"/>
                            </xsl:if>
                            <xsl:if test="S100FC:multiplicity/S100Base:upper/@infinite = 'false'">
                              <xsl:value-of select="concat('[', S100FC:multiplicity/S100Base:lower, '..', S100FC:multiplicity/S100Base:upper, ']')"/>
                            </xsl:if>
                            <xsl:if test="S100FC:permittedValues/S100FC:value">
                              permittedValues: [
                              <xsl:for-each select="S100FC:permittedValues/S100FC:value">
                                <xsl:value-of select="position()"/>,
                              </xsl:for-each>
                              ]
                            </xsl:if>

                          </td>
                        </tr>
                      </xsl:for-each>

                    </table>
                  </details>


                </xsl:for-each>
              </article>
            </div>
            <div class="col-md-6">
              <article class="">
                <hr/>
                <h3>Simple attributes</h3>
                <xsl:for-each select="S100FC:S100_FC_FeatureCatalogue/S100FC:S100_FC_SimpleAttributes/S100FC:S100_FC_SimpleAttribute">
                  <xsl:variable name="code" select="S100FC:code" />

                  <a>
                    <xsl:attribute name="id">
                      <xsl:value-of select="S100FC:code"/>
                    </xsl:attribute>
                  </a>
                  <details open="">
                    <summary>
                      <code>
                        <xsl:value-of select="S100FC:code"/>
                      </code>: <xsl:value-of select="S100FC:valueType"/>
                    </summary>
                    <table>
                      <tr>
                        <th>
                          code
                        </th>
                        <td>
                          <code>
                            <xsl:value-of select="S100FC:code"/>
                          </code>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          alias
                        </th>
                        <td>
                          <xsl:value-of select="S100FC:alias"/>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          name
                        </th>
                        <td>
                          <xsl:value-of select="S100FC:name"/>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          definition
                        </th>
                        <td>
                          <xsl:value-of select="S100FC:definition"/>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          valueType
                        </th>
                        <td>
                          <xsl:value-of select="S100FC:valueType"/>
                        </td>
                      </tr>
                      <xsl:if test="S100FC:valueType = 'enumeration'">
                        <tr>
                          <th>
                            listedValues
                          </th>
                          <td>
                            <table class="listedValues">
                              <xsl:for-each select="S100FC:listedValues/S100FC:listedValue">
                                <tr>
                                  <th>
                                    <code>
                                      <xsl:value-of select="S100FC:label"/>
                                    </code>
                                  </th>
                                  <td>
                                    <xsl:value-of select="S100FC:code"/>
                                  </td>
                                  <td>
                                    <xsl:value-of select="S100FC:definitionReference/S100FC:definitionSource/@ref"/>
                                  </td>
                                  <td>
                                    <xsl:value-of select="S100FC:definition"/>
                                  </td>
                                </tr>
                              </xsl:for-each>
                            </table>
                          </td>
                        </tr>
                      </xsl:if>
                    </table>
                  </details>
                </xsl:for-each>
              </article>
            </div>
          </div>
        </div>
        <script>
          <![CDATA[
   var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
    acc[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var panel = this.nextElementSibling;
        if (panel.style.display === "block") {
            panel.style.display = "none";
        } else {
            panel.style.display = "block";
        }
    });
}
          ]]>
        </script>

      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>