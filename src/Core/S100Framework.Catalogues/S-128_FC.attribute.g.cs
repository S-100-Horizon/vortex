using System;
using System.Text.Json.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace S100Framework.AttributeModel.S128.SimpleAttributes
{
	/// <summary>
	/// A generic term for an administrative region within a country at a level below that of the sovereign state.
	/// </summary>
	public class administrativeDivision : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(administrativeDivision);
		[JsonIgnore]
		public override string S100FC_name => "Administrative Division";

		public static implicit operator administrativeDivision(String? value) => new administrativeDivision { value = value };
	}

	/// <summary>
	/// The name of an agency, entity or organization.
	/// </summary>
	public class agencyName : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(agencyName);
		[JsonIgnore]
		public override string S100FC_name => "Agency Name";

		public static implicit operator agencyName(String? value) => new agencyName { value = value };
	}

	/// <summary>
	/// Identifies the agency which produced the data.
	/// </summary>
	public class agencyResponsibleForProduction : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(agencyResponsibleForProduction);
		[JsonIgnore]
		public override string S100FC_name => "Agency Responsible for Production";

		public static implicit operator agencyResponsibleForProduction(String? value) => new agencyResponsibleForProduction { value = value };
	}

	/// <summary>
	/// Name of an application profile that can be used with the online resource.
	/// </summary>
	public class applicationProfile : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(applicationProfile);
		[JsonIgnore]
		public override string S100FC_name => "Application Profile";

		public static implicit operator applicationProfile(String? value) => new applicationProfile { value = value };
	}

	/// <summary>
	/// Approximate grid resolution for nautical products.
	/// </summary>
	public class approximateGridResolution : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(approximateGridResolution);
		[JsonIgnore]
		public override string S100FC_name => "Approximate Grid Resolution";

		public static implicit operator approximateGridResolution(double? value) => new approximateGridResolution { value = value };
	}

	/// <summary>
	/// Classification of a catalogue element.
	/// </summary>
	public class catalogueElementClassification : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(catalogueElementClassification);
		[JsonIgnore]
		public override string S100FC_name => "Catalogue Element Classification";
		public static listedValue[] listedValues => [
				new listedValue("ENC", "Electronic Navigational Chart",1),
				new listedValue("Bathymetric Chart", "A topographic chart of the bed of a body of water, or a part of it. Generally, bathymetric charts show depths by contour lines and gradient tints.",2),
				new listedValue("Water Level Product", "Water Level Information for Surface Navigation",3),
				new listedValue("Surface Current Product", "A product representing the water velocity at one or more geographic locations down to a given depth.",4),
				new listedValue("MSI Service", "An outage of a maritime safety information broadcast service (satellite or terrestrial system).",5),
				new listedValue("AtoN Information", "A service providing information related to Marine Aids to Navigation.",6),
				new listedValue("Catalogue Service", "A service providing structured records of items.",7),
				new listedValue("Routeing Service", "Services associated with Ships Routeing.",8),
				new listedValue("Ice Information", "Newly discovered icebergs, changes to ice conditions and ice related information likely to impact navigation.",9),
				new listedValue("Routeing Information", "Information associated with Ships Routeing.",10),
				new listedValue("Special Purpose Chart", "Any chart designed primarily to meet specific requirements.",11),
				new listedValue("Nautical Publication", "A (nautical chart or) nautical publication is a \"a special-purpose map or book, or a specially compiled database from which such a map or book is derived, that is issued officially by or on the authority of a Government, authorized Hydrographic Office or other relevant government institution and is designed to meet the requirements of marine navigation\".",12),
				new listedValue("Printed Nautical Chart", "A printed nautical chart is a \"a special-purpose map , that is issued officially by or on the authority of a Government, authorized Hydrographic Office or other relevant government institution and is designed to meet the requirements of marine navigation\".",13),
			];

		public static implicit operator catalogueElementClassification(int? value) => new catalogueElementClassification { value = value };
	}

	/// <summary>
	/// Identifier of a catalogue element.
	/// </summary>
	public class catalogueElementIdentifier : S100Framework.AttributeModel.UrnTimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(catalogueElementIdentifier);
		[JsonIgnore]
		public override string S100FC_name => "Catalogue Element Identifier";

		public static implicit operator catalogueElementIdentifier(String? value) => new catalogueElementIdentifier { value = value };
	}

	/// <summary>
	/// A number identifying a section within a catalogue.
	/// </summary>
	public class catalogueSectionNumber : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(catalogueSectionNumber);
		[JsonIgnore]
		public override string S100FC_name => "Catalogue Section Number";

		public static implicit operator catalogueSectionNumber(int? value) => new catalogueSectionNumber { value = value };
	}

	/// <summary>
	/// The catalogue section title.
	/// </summary>
	public class catalogueSectionTitle : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(catalogueSectionTitle);
		[JsonIgnore]
		public override string S100FC_name => "Catalogue Section Title";

		public static implicit operator catalogueSectionTitle(String? value) => new catalogueSectionTitle { value = value };
	}

	/// <summary>
	/// The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.
	/// </summary>
	public class categoryOfAuthority : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfAuthority);
		[JsonIgnore]
		public override string S100FC_name => "Category of Authority";
		public static listedValue[] listedValues => [
				new listedValue("Border Control", "The administration to prevent or detect and prosecute violations of rules and regulations at international boundaries.",2),
				new listedValue("Police", "The department of government, or civil force, charged with maintaining public order.",3),
				new listedValue("Port", "Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.",4),
				new listedValue("Immigration", "The authority controlling people entering a country.",5),
				new listedValue("Health", "The authority with responsibility for checking the validity of the health declaration of a vessel and for declaring free pratique.",6),
				new listedValue("Coast Guard", "Organization keeping watch on shipping and coastal waters according to governmental law; normally the authority with responsibility for search and rescue.",7),
				new listedValue("Agricultural", "The authority with responsibility for preventing infection of the agriculture of a country and for the protection of the agricultural interests of a country.",8),
				new listedValue("Military", "A military authority which provides control of access to or approval for transit through designated areas or airspace.",9),
				new listedValue("Private Company", "A private or publicly owned company or commercial enterprise which exercises control of facilities, for example a calibration area.",10),
				new listedValue("Maritime Police", "A governmental or military force with jurisdiction in territorial waters. Examples could include Gendarmerie Maritime, Carabinierie, and Guardia Civil.",11),
				new listedValue("Environmental", "An authority with responsibility for the protection of the environment.",12),
				new listedValue("Fishery", "An authority with responsibility for the control of fisheries.",13),
				new listedValue("Finance", "An authority with responsibility for the control and movement of money.",14),
				new listedValue("Maritime", "A national or regional authority charged with administration of maritime affairs.",15),
				new listedValue("Customs", "The agency or establishment for collecting duties, tolls.",16),
				new listedValue("Hydrographic Office", "State agency in charge of marine surveys and hydrography.",17),
				new listedValue("RENC", "Regional ENC Coordination Centre.",18),
				new listedValue("VARs", "Value Added Resellers (VARs), who are able to offer comprehensive end-use services that bring together various navigational products into one package.",19),
			];

		public static implicit operator categoryOfAuthority(int? value) => new categoryOfAuthority { value = value };
	}

	/// <summary>
	/// Designation of the character set to be used to encode the textual value of the locale.
	/// </summary>
	public class characterEncoding : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(characterEncoding);
		[JsonIgnore]
		public override string S100FC_name => "Character Encoding";

		public static implicit operator characterEncoding(String? value) => new characterEncoding { value = value };
	}

	/// <summary>
	/// The name of a town or city.
	/// </summary>
	public class cityName : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(cityName);
		[JsonIgnore]
		public override string S100FC_name => "City Name";

		public static implicit operator cityName(String? value) => new cityName { value = value };
	}

	/// <summary>
	/// Indicates a classification.
	/// </summary>
	public class classification : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(classification);
		[JsonIgnore]
		public override string S100FC_name => "Classification";

		public static implicit operator classification(String? value) => new classification { value = value };
	}

	/// <summary>
	/// Comment regarding an entity obvious from context.
	/// </summary>
	public class comment : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(comment);
		[JsonIgnore]
		public override string S100FC_name => "Comment";

		public static implicit operator comment(String? value) => new comment { value = value };
	}

	/// <summary>
	/// In ECDIS, the scale at which the data was compiled.
	/// </summary>
	public class compilationScale : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(compilationScale);
		[JsonIgnore]
		public override string S100FC_name => "Compilation Scale";

		public static implicit operator compilationScale(int? value) => new compilationScale { value = value };
	}

	/// <summary>
	/// Indicates if the resource is compressed.
	/// </summary>
	public class compressionFlag : S100Framework.AttributeModel.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(compressionFlag);
		[JsonIgnore]
		public override string S100FC_name => "Compression Flag";

		public static implicit operator compressionFlag(Boolean? value) => new compressionFlag { value = value };
	}

	/// <summary>
	/// Instructions provided on how to contact a particular person, organisation or service.
	/// </summary>
	public class contactInstructions : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(contactInstructions);
		[JsonIgnore]
		public override string S100FC_name => "Contact Instructions";

		public static implicit operator contactInstructions(String? value) => new contactInstructions { value = value };
	}

	/// <summary>
	/// Definition of a period when a contract is valid.
	/// </summary>
	public class contractPeriod : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(contractPeriod);
		[JsonIgnore]
		public override string S100FC_name => "Contract Period";

		public static implicit operator contractPeriod(String? value) => new contractPeriod { value = value };
	}

	/// <summary>
	/// The name of a nation.
	/// </summary>
	public class countryName : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(countryName);
		[JsonIgnore]
		public override string S100FC_name => "Country Name";

		public static implicit operator countryName(String? value) => new countryName { value = value };
	}

	/// <summary>
	/// Something (such as coins, treasury notes, and banknotes) that is in circulation as a medium of exchange.
	/// </summary>
	public class currency : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(currency);
		[JsonIgnore]
		public override string S100FC_name => "Currency";

		public static implicit operator currency(String? value) => new currency { value = value };
	}

	/// <summary>
	/// The name or identification of a dataset.
	/// </summary>
	public class datasetName : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(datasetName);
		[JsonIgnore]
		public override string S100FC_name => "Dataset Name";

		public static implicit operator datasetName(String? value) => new datasetName { value = value };
	}

	/// <summary>
	/// The latest date on which an object (for example a buoy) will be present.
	/// </summary>
	public class dateEnd : S100Framework.AttributeModel.S100_TruncatedDateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(dateEnd);
		[JsonIgnore]
		public override string S100FC_name => "Date End";

		public static implicit operator dateEnd(String? value) => new dateEnd { value = value };
	}

	/// <summary>
	/// The earliest date on which an object (for example a buoy) will be present.
	/// </summary>
	public class dateStart : S100Framework.AttributeModel.S100_TruncatedDateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(dateStart);
		[JsonIgnore]
		public override string S100FC_name => "Date Start";

		public static implicit operator dateStart(String? value) => new dateStart { value = value };
	}

	/// <summary>
	/// Details of where post can be delivered such as the apartment, name and/or number of a street, building or PO Box.
	/// </summary>
	public class deliveryPoint : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(deliveryPoint);
		[JsonIgnore]
		public override string S100FC_name => "Delivery Point";

		public static implicit operator deliveryPoint(String? value) => new deliveryPoint { value = value };
	}

	/// <summary>
	/// Value derived from the digital signature.
	/// </summary>
	public class digitalSignatureValue : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(digitalSignatureValue);
		[JsonIgnore]
		public override string S100FC_name => "Digital Signature Value";
		public static listedValue[] listedValues => [
				new listedValue("ID", "Meta data record identifier for QualityOfBathymetric Coverage",1),
				new listedValue("Digital Signature Reference", "Specifies the algorithm used to compute digital signature value.",2),
			];

		public static implicit operator digitalSignatureValue(int? value) => new digitalSignatureValue { value = value };
	}

	/// <summary>
	/// Classification of the type and display level of the name of a feature in an end-user system.
	/// </summary>
	public class nameUsage : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(nameUsage);
		[JsonIgnore]
		public override string S100FC_name => "Name Usage";
		public static listedValue[] listedValues => [
				new listedValue("Default Name Display", "The name is intended to be displayed when the end-user system is set to the default name/text display setting.",1),
				new listedValue("Alternate Name Display", "The name is intended to be displayed when the end-user system is set to an alternate name/text display setting, for example an alternate language.",2),
				new listedValue("No Chart Display", "The name or text is not intended to be displayed.",3),
			];

		public static implicit operator nameUsage(int? value) => new nameUsage { value = value };
	}

	/// <summary>
	/// Supply status of nautical products.
	/// </summary>
	public class distributionStatus : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(distributionStatus);
		[JsonIgnore]
		public override string S100FC_name => "Distribution Status";
		public static listedValue[] listedValues => [
				new listedValue("Production", "A product or service that is currently in production.",1),
				new listedValue("Withdrawn", "A product or service that has been withdrawn.",2),
			];

		public static implicit operator distributionStatus(int? value) => new distributionStatus { value = value };
	}

	/// <summary>
	/// Name of the distributor.
	/// </summary>
	public class distributorName : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(distributorName);
		[JsonIgnore]
		public override string S100FC_name => "Distributor Name";

		public static implicit operator distributorName(String? value) => new distributorName { value = value };
	}

	/// <summary>
	/// A carriage requirement that is specific to a country or region and is based on domestic legislation or regulation.
	/// </summary>
	public class domesticCarriageRequirements : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(domesticCarriageRequirements);
		[JsonIgnore]
		public override string S100FC_name => "Domestic Carriage Requirements";

		public static implicit operator domesticCarriageRequirements(String? value) => new domesticCarriageRequirements { value = value };
	}

	/// <summary>
	/// Date of publishing for example of a publication, chart, or product.
	/// </summary>
	public class editionDate : S100Framework.AttributeModel.DateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(editionDate);
		[JsonIgnore]
		public override string S100FC_name => "Edition Date";

		public static implicit operator editionDate(DateOnly? value) => new editionDate { value = value };
	}

	/// <summary>
	/// Edition of the ENC being referenced.
	/// </summary>
	public class editionNumber : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(editionNumber);
		[JsonIgnore]
		public override string S100FC_name => "Edition Number";

		public static implicit operator editionNumber(int? value) => new editionNumber { value = value };
	}

	/// <summary>
	/// Expiration date of a product or service
	/// </summary>
	public class expirationDate : S100Framework.AttributeModel.DateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(expirationDate);
		[JsonIgnore]
		public override string S100FC_name => "Expiration Date";

		public static implicit operator expirationDate(DateOnly? value) => new expirationDate { value = value };
	}

	/// <summary>
	/// The location of a fragment of text or other information in a support file.
	/// </summary>
	public class fileLocator : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(fileLocator);
		[JsonIgnore]
		public override string S100FC_name => "File Locator";

		public static implicit operator fileLocator(String? value) => new fileLocator { value = value };
	}

	/// <summary>
	/// The name of a file within a system.
	/// </summary>
	public class fileName : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(fileName);
		[JsonIgnore]
		public override string S100FC_name => "File Name";

		public static implicit operator fileName(String? value) => new fileName { value = value };
	}

	/// <summary>
	/// The file name of an externally referenced text file.
	/// </summary>
	public class fileReference : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(fileReference);
		[JsonIgnore]
		public override string S100FC_name => "File Reference";

		public static implicit operator fileReference(String? value) => new fileReference { value = value };
	}

	/// <summary>
	/// Words set at the head of a passage or page to introduce or categorize.
	/// </summary>
	public class headline : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(headline);
		[JsonIgnore]
		public override string S100FC_name => "Headline";

		public static implicit operator headline(String? value) => new headline { value = value };
	}

	/// <summary>
	/// A maritime service as identified by the International Maritime Organization (IMO).
	/// </summary>
	public class iMOMaritimeService : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(iMOMaritimeService);
		[JsonIgnore]
		public override string S100FC_name => "IMO Maritime Service";
		public static listedValue[] listedValues => [
				new listedValue("Vessel Traffic Service", "Any service implemented by a relevant authority primarily designed to improve safety and efficiency of traffic flow and the protection of the environment. It may range from simple information messages, to extensive organization of the traffic involving national or regional schemes.",1),
				new listedValue("Aids to Navigation Service", "A service providing up-to-date information of Aids to Navigation.",2),
				new listedValue("Reserved for Future Use", "An option that is reserved for future use",3),
				new listedValue("Port Support Service", "A service that provides information necessary to organize and support port calls and varies depending on the local needs.",4),
				new listedValue("Maritime Safety Information Service", "A service providing navigational and meteorological warnings, meteorological forecasts and other urgent safety-related messages broadcast to ships.",5),
				new listedValue("Pilotage Service", "The services of a person who directs the movements of a vessel through pilot waters, usually a person who has demonstrated extensive knowledge of channels, aids to navigation, dangers to navigation, etc., in a particular area and is licensed for that area, are available.",6),
				new listedValue("Tug Service", "A service that contributes to the safety of navigation, protection of the marine environment, and efficiency of marine transportation by conducting different types of operations including tugboats, such as ship assistance, salvalge, towage, escort etc.",7),
				new listedValue("Vessel Shore Reporting", "A service providing information related to Vessel Shore Reporting and Ship reporting systems.",8),
				new listedValue("Telemedical Assistance Service", "A service to provide decision support and advice to the seafarer on board responsible for medical care.",9),
				new listedValue("Maritime Assistance Service", "A service to manage communications between the coastal State, ships' officers requiring assistance and other responsible maritime organizations: fleet owners, salvage companies, port authorities, brokers, etc.",10),
				new listedValue("Nautical Chart Service", "A service that provides geospatial information (in digital and / or printed format) to support safe maritime navigation with the aim to fulfill SOLAS regulation V/19.2.1.4 requirements for ships to carry \"nautical charts and nautical publications to plan and display the ship's route for the intended voyage and to plot and monitor positions throughout the voyage\".",11),
				new listedValue("Nautical Publications Service", "A service to provide information as a support to the navigation process. This comprises information to complement nautical charts, such as information on ports and sea areas, as well as the contact information of authorities and services for a sea area or port. It further describes regulations, restrictions, recommendations and other nautical information applicable in these areas, and aim to fulfill  SOLAS regulation V/19.2.1.4 requirements for ships to carry \"nautical charts and nautical publications to plan and display the ship's route for the intended voyage and to plot and monitor positions throughout the voyage\".",12),
				new listedValue("Ice Navigation Service", "A service to provide ice navigation information to ships in and in the vicinity of possible ice infested regions.",13),
				new listedValue("Meteorological Information Service", "A service to provide meteorological information (digitally) to ships.",14),
				new listedValue("Real-Time Hydrographic and Environmental Information Service", "A service providing hydrographic and environmental observations and forecasts, such as water level and surface current information.",15),
				new listedValue("Search and Rescue Service", "A service aimed at providing information about and assist with Search and Rescue functions.",16),
			];

		public static implicit operator iMOMaritimeService(int? value) => new iMOMaritimeService { value = value };
	}

	/// <summary>
	/// International Carriage requirements are carriage requirements based on the SOLAS-convention or similar international regulation.
	/// </summary>
	public class internationalCarriageRequirements : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(internationalCarriageRequirements);
		[JsonIgnore]
		public override string S100FC_name => "International Carriage Requirements";

		public static implicit operator internationalCarriageRequirements(String? value) => new internationalCarriageRequirements { value = value };
	}

	/// <summary>
	/// International Standard Book Number.
	/// </summary>
	public class iSBN : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(iSBN);
		[JsonIgnore]
		public override string S100FC_name => "ISBN";

		public static implicit operator iSBN(String? value) => new iSBN { value = value };
	}

	/// <summary>
	/// ISO 216 is a paper-size standard established by the International Organization for Standardization (ISO).
	/// </summary>
	public class iSO216 : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(iSO216);
		[JsonIgnore]
		public override string S100FC_name => "ISO 216";
		public static listedValue[] listedValues => [
				new listedValue("A0", "The paper size A0, as defined in ISO 216.",1),
				new listedValue("A1", "The first size as output size on nautical paper chart. Referring to ISO 216.",2),
				new listedValue("A2", "The paper size A2, as defined in ISO 216.",3),
				new listedValue("A3", "The fourth size as output size on nautical paper chart. Referring to ISO 216.",4),
				new listedValue("A4", "The fifth size as output size on nautical paper chart. Referring to ISO 216.",5),
				new listedValue("A5", "The sixth size as output size on nautical paper chart. Referring to ISO 216.",6),
				new listedValue("A6", "The seventh size as output size on nautical paper chart. Referring to ISO 216.",7),
				new listedValue("A7", "The eighth size as output size on nautical paper chart. Referring to ISO 216.",8),
			];

		public static implicit operator iSO216(int? value) => new iSO216 { value = value };
	}

	/// <summary>
	/// International Standard Serial Number.
	/// </summary>
	public class iSSN : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(iSSN);
		[JsonIgnore]
		public override string S100FC_name => "ISSN";

		public static implicit operator iSSN(String? value) => new iSSN { value = value };
	}

	/// <summary>
	/// Date up to which the data was made available by the Data Producer.
	/// </summary>
	public class issueDate : S100Framework.AttributeModel.DateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(issueDate);
		[JsonIgnore]
		public override string S100FC_name => "Issue Date";

		public static implicit operator issueDate(DateOnly? value) => new issueDate { value = value };
	}

	/// <summary>
	/// Time of day at which the data was made available by the Data Producer.
	/// </summary>
	public class issueTime : S100Framework.AttributeModel.TimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(issueTime);
		[JsonIgnore]
		public override string S100FC_name => "Issue Time";

		public static implicit operator issueTime(S100Framework.DomainModel.S100.Time? value) => new issueTime { value = value };
	}

	/// <summary>
	/// The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.
	/// </summary>
	public class language : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(language);
		[JsonIgnore]
		public override string S100FC_name => "Language";

		public static implicit operator language(String? value) => new language { value = value };
	}

	/// <summary>
	/// Location (address) for online access using a URL/URI address or similar addressing scheme.
	/// </summary>
	public class linkage : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(linkage);
		[JsonIgnore]
		public override string S100FC_name => "Linkage";

		public static implicit operator linkage(String? value) => new linkage { value = value };
	}

	/// <summary>
	/// A classification of the internal relationships between products and services.
	/// </summary>
	public class categoryOfProductMapping : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfProductMapping);
		[JsonIgnore]
		public override string S100FC_name => "Category Of Product Mapping";
		public static listedValue[] listedValues => [
				new listedValue("Higher Priority Alternative", "A higher prioritized or recommended alternative product or service, that can fully replace another.",1),
				new listedValue("Lower Priority Alternative", "A lower prioritized or not recommended alternative product or service, that can fully replace another.",2),
				new listedValue("Recommended Enhancement Provider", "A recommended additional product or service, that provides added value to another.",3),
				new listedValue("Recommended Enhancement User", "A product or service, that is recommended to make use of added value provided by another product or service.",4),
			];

		public static implicit operator categoryOfProductMapping(int? value) => new categoryOfProductMapping { value = value };
	}

	/// <summary>
	/// The value considered by the Data Producer to be the maximum (largest) scale at which the data is to be displayed before it can be considered to be “grossly overscaled”.
	/// </summary>
	public class maximumDisplayScale : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(maximumDisplayScale);
		[JsonIgnore]
		public override string S100FC_name => "Maximum Display Scale";

		public static implicit operator maximumDisplayScale(int? value) => new maximumDisplayScale { value = value };
	}

	/// <summary>
	/// The smallest intended viewing scale for the data.
	/// </summary>
	public class minimumDisplayScale : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(minimumDisplayScale);
		[JsonIgnore]
		public override string S100FC_name => "Minimum Display Scale";

		public static implicit operator minimumDisplayScale(int? value) => new minimumDisplayScale { value = value };
	}

	/// <summary>
	/// The individual name of a feature.
	/// </summary>
	public class name : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(name);
		[JsonIgnore]
		public override string S100FC_name => "Name";

		public static implicit operator name(String? value) => new name { value = value };
	}

	/// <summary>
	/// Name of the online resource.
	/// </summary>
	public class nameOfResource : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(nameOfResource);
		[JsonIgnore]
		public override string S100FC_name => "Name of Resource";

		public static implicit operator nameOfResource(String? value) => new nameOfResource { value = value };
	}

	/// <summary>
	/// Indicates the dataset is not intended to be used for navigation.
	/// </summary>
	public class notForNavigation : S100Framework.AttributeModel.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(notForNavigation);
		[JsonIgnore]
		public override string S100FC_name => "Not For Navigation";

		public static implicit operator notForNavigation(Boolean? value) => new notForNavigation { value = value };
	}

	/// <summary>
	/// Description of online resources.
	/// </summary>
	public class onlineDescription : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(onlineDescription);
		[JsonIgnore]
		public override string S100FC_name => "Online Description";

		public static implicit operator onlineDescription(String? value) => new onlineDescription { value = value };
	}

	/// <summary>
	/// The largest intended viewing scale for the data.
	/// </summary>
	public class optimumDisplayScale : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(optimumDisplayScale);
		[JsonIgnore]
		public override string S100FC_name => "Optimum Display Scale";

		public static implicit operator optimumDisplayScale(int? value) => new optimumDisplayScale { value = value };
	}

	/// <summary>
	/// The original identification of a product that has been re-branded or distributed under multiple identification schemes.
	/// </summary>
	public class originalProductNumber : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(originalProductNumber);
		[JsonIgnore]
		public override string S100FC_name => "Original Product Number";

		public static implicit operator originalProductNumber(String? value) => new originalProductNumber { value = value };
	}

	/// <summary>
	/// Description of a support file format other than those listed.
	/// </summary>
	public class otherDataTypeDescription : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(otherDataTypeDescription);
		[JsonIgnore]
		public override string S100FC_name => "Other Data Type Description";

		public static implicit operator otherDataTypeDescription(String? value) => new otherDataTypeDescription { value = value };
	}

	/// <summary>
	/// Known in various countries as a postcode, or ZIP code, the postal code is a series of letters and/or digits that identifies each postal delivery area.
	/// </summary>
	public class postalCode : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(postalCode);
		[JsonIgnore]
		public override string S100FC_name => "Postal Code";

		public static implicit operator postalCode(String? value) => new postalCode { value = value };
	}

	/// <summary>
	/// The amount of money expected, required, or given in payment for something.
	/// </summary>
	public class price : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(price);
		[JsonIgnore]
		public override string S100FC_name => "Price";

		public static implicit operator price(double? value) => new price { value = value };
	}

	/// <summary>
	/// Name of the publishing institution of the paper chart for navigation.
	/// </summary>
	public class printAgency : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(printAgency);
		[JsonIgnore]
		public override string S100FC_name => "Print Agency";

		public static implicit operator printAgency(String? value) => new printAgency { value = value };
	}

	/// <summary>
	/// The authority who printed a nautical paper chart.
	/// </summary>
	public class printNation : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(printNation);
		[JsonIgnore]
		public override string S100FC_name => "Print Nation";

		public static implicit operator printNation(String? value) => new printNation { value = value };
	}

	/// <summary>
	/// The authority who produced a nautical product.
	/// </summary>
	public class producerNation : S100Framework.AttributeModel.UrnTimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(producerNation);
		[JsonIgnore]
		public override string S100FC_name => "Producer Nation";

		public static implicit operator producerNation(String? value) => new producerNation { value = value };
	}

	/// <summary>
	/// Product number of a product or service.
	/// </summary>
	public class productNumber : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(productNumber);
		[JsonIgnore]
		public override string S100FC_name => "Product Number";

		public static implicit operator productNumber(String? value) => new productNumber { value = value };
	}

	/// <summary>
	/// A reference to another product.
	/// </summary>
	public class productReference : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(productReference);
		[JsonIgnore]
		public override string S100FC_name => "Product Reference";

		public static implicit operator productReference(String? value) => new productReference { value = value };
	}

	/// <summary>
	/// Connection protocol to be used. Example: ftp, http get KVP, http POST, etc.
	/// </summary>
	public class protocol : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(protocol);
		[JsonIgnore]
		public override string S100FC_name => "Protocol";

		public static implicit operator protocol(String? value) => new protocol { value = value };
	}

	/// <summary>
	/// Request used to access the resource. Structure and content depend on the protocol and standard used by the online resource, such as Web Feature Service standard.
	/// </summary>
	public class protocolRequest : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(protocolRequest);
		[JsonIgnore]
		public override string S100FC_name => "Protocol Request";

		public static implicit operator protocolRequest(String? value) => new protocolRequest { value = value };
	}

	/// <summary>
	/// Publication number of a nautical product.
	/// </summary>
	public class publicationNumber : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(publicationNumber);
		[JsonIgnore]
		public override string S100FC_name => "Publication Number";

		public static implicit operator publicationNumber(String? value) => new publicationNumber { value = value };
	}

	/// <summary>
	/// Reprinted version of nautical paper chart.
	/// </summary>
	public class reprintEdition : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(reprintEdition);
		[JsonIgnore]
		public override string S100FC_name => "Reprint Edition";

		public static implicit operator reprintEdition(String? value) => new reprintEdition { value = value };
	}

	/// <summary>
	/// The authority who reprinted a nautical paper chart.
	/// </summary>
	public class reprintNation : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(reprintNation);
		[JsonIgnore]
		public override string S100FC_name => "Reprint Nation";

		public static implicit operator reprintNation(String? value) => new reprintNation { value = value };
	}

	/// <summary>
	/// The date that the item was observed, done, or investigated.
	/// </summary>
	public class reportedDate : S100Framework.AttributeModel.DateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(reportedDate);
		[JsonIgnore]
		public override string S100FC_name => "Reported Date";

		public static implicit operator reportedDate(DateOnly? value) => new reportedDate { value = value };
	}

	/// <summary>
	/// Specifies the algorithm used to compute digital signature value.
	/// </summary>
	public class digitalSignatureReference : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(digitalSignatureReference);
		[JsonIgnore]
		public override string S100FC_name => "Digital Signature Reference";
		public static listedValue[] listedValues => [
				new listedValue("ECDSA-384-SHA2", "Elliptic Curve Digital Signature Algorithm (ECDSA) that uses signatures based on the issuing certificate and generated using the issuer’s P-384 elliptic curve key.",8),
			];

		public static implicit operator digitalSignatureReference(int? value) => new digitalSignatureReference { value = value };
	}

	/// <summary>
	/// The navigational purpose of the dataset.
	/// </summary>
	public class navigationPurpose : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(navigationPurpose);
		[JsonIgnore]
		public override string S100FC_name => "Navigation Purpose";
		public static listedValue[] listedValues => [
				new listedValue("Port", "For port and near shore operations.",1),
				new listedValue("Transit", "For coast and planning purposes.",2),
				new listedValue("Overview", "For ocean crossing and planning purposes.",3),
			];

		public static implicit operator navigationPurpose(int? value) => new navigationPurpose { value = value };
	}

	/// <summary>
	/// The format used for the support file.
	/// </summary>
	public class supportFileFormat : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(supportFileFormat);
		[JsonIgnore]
		public override string S100FC_name => "Support File Format";
		public static listedValue[] listedValues => [
				new listedValue("ASCII", "UTF-8 text excluding control codes.",1),
				new listedValue("JPEG2000", "JPEG2000 format.",2),
				new listedValue("HTML", "Hypertext Markup Language.",3),
				new listedValue("XML", "Extensible Markup Language.",4),
				new listedValue("XSLT", "Extensible Stylesheet Language Transformations.",5),
				new listedValue("Video", "A digital recording of an image or set of images (such as a movie or animation).",6),
				new listedValue("TIFF", "Tagged Image File Format (TIFF).",7),
				new listedValue("PDF/A Or U/A", "Portable Document Format.",8),
				new listedValue("LUA", "Lua programming language.",9),
				new listedValue("Other", "Being the one or ones distinct from that or those first mentioned or implied.",100),
			];

		public static implicit operator supportFileFormat(int? value) => new supportFileFormat { value = value };
	}

	/// <summary>
	/// The reason for inclusion of the support file.
	/// </summary>
	public class supportFilePurpose : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(supportFilePurpose);
		[JsonIgnore]
		public override string S100FC_name => "Support File Purpose";
		public static listedValue[] listedValues => [
				new listedValue("New", "A file which is new.",1),
				new listedValue("Replacement", "A file which replaces an existing file.",2),
				new listedValue("Deletion", "Deletes an existing file.",3),
			];

		public static implicit operator supportFilePurpose(int? value) => new supportFilePurpose { value = value };
	}

	/// <summary>
	/// The name of a service.
	/// </summary>
	public class serviceName : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(serviceName);
		[JsonIgnore]
		public override string S100FC_name => "Service Name";

		public static implicit operator serviceName(String? value) => new serviceName { value = value };
	}

	/// <summary>
	/// Types of status of services.
	/// </summary>
	public class serviceStatus : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(serviceStatus);
		[JsonIgnore]
		public override string S100FC_name => "Service Status";
		public static listedValue[] listedValues => [
				new listedValue("Provisional", "Indicates a temporary, preliminary, or interim status. A provisional item is not yet finalized or fully approved.",1),
				new listedValue("Released", "Indicates a finalized, officially approved, or publicly available status. A released item is ready for general use or distribution.",2),
				new listedValue("Deprecated", "Indicates that a feature, method, product, or component is no longer recommended for use but is still available.",3),
				new listedValue("Deleted", "Indicates that a feature, method, product, or component is no longer available or has been permanently removed.",4),
			];

		public static implicit operator serviceStatus(int? value) => new serviceStatus { value = value };
	}

	/// <summary>
	/// The publication, document, or reference work from which information comes or is acquired.
	/// </summary>
	public class source : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(source);
		[JsonIgnore]
		public override string S100FC_name => "Source";

		public static implicit operator source(String? value) => new source { value = value };
	}

	/// <summary>
	/// The production date of the source; for example the date of measurement.
	/// </summary>
	public class sourceDate : S100Framework.AttributeModel.DateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sourceDate);
		[JsonIgnore]
		public override string S100FC_name => "Source Date";

		public static implicit operator sourceDate(DateOnly? value) => new sourceDate { value = value };
	}

	/// <summary>
	/// Type of the source.
	/// </summary>
	public class sourceType : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sourceType);
		[JsonIgnore]
		public override string S100FC_name => "Source Type";
		public static listedValue[] listedValues => [
				new listedValue("Law or Regulation", "Treaty, convention, or international agreement; law or regulation issued by a national or other authority.",1),
				new listedValue("Official Publication", "Publication not having the force of law, issued by an international organisation or a national or local administration.",2),
				new listedValue("Mariner Report, Confirmed", "Reported by mariner(s) and confirmed by another source.",7),
				new listedValue("Mariner Report, Not Confirmed", "Reported by mariner(s) but not confirmed.",8),
				new listedValue("Industry Publications and Reports", "Shipping and other industry publications, including graphics, charts and web sites.",9),
				new listedValue("Remotely Sensed Images", "Information obtained from satellite images.",10),
				new listedValue("Photographs", "Information obtained from photographs.",11),
				new listedValue("Products Issued by HO Services", "Information obtained from products issued by Hydrographic Offices.",12),
				new listedValue("News Media", "Information obtained from news media.",13),
				new listedValue("Traffic Data", "Information obtained from the analysis of traffic data.",14),
				new listedValue("Maritime", "A national or regional authority charged with administration of maritime affairs.",15),
			];

		public static implicit operator sourceType(int? value) => new sourceType { value = value };
	}

	/// <summary>
	/// The use for which the dataset is intended.
	/// </summary>
	public class specificUsage : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(specificUsage);
		[JsonIgnore]
		public override string S100FC_name => "Specific Usage";
		public static listedValue[] listedValues => [
				new listedValue("Navigational Purpose Overview", "For use in the study of the characteristics of maritime zones, in the formulation of plans, in the selection of routes, etc., showing only relevant elements of the coastline, harbours, islands, principal navigational marks and obstructions, and submarine landforms.",1),
				new listedValue("Navigational Purpose General", "A nautical chart with universality (i.e., generality) in use, characterized by the requirement that the chart must comprehensively describe various natural elements and socioeconomic elements, and that each element of the subject matter expressed is universal.",2),
				new listedValue("Navigational Purpose Coastal", "Used for marine navigation, mainly displaying submarine landforms, navigational marks, navigational obstacles and other elements related to navigation.",3),
				new listedValue("Navigational Purpose Approach", "Used for near-shore navigation, mainly showing the marine elements close to coastal areas.",4),
				new listedValue("Navigational Purpose Harbour", "Used for entering and leaving harbours, selecting anchorage, studying harbour topography, and carrying out the construction of harbours.",5),
				new listedValue("Navigational Purpose Berthing", "For ships berthing.",6),
			];

		public static implicit operator specificUsage(int? value) => new specificUsage { value = value };
	}

	/// <summary>
	/// An identifier, such as words, numbers, letters, symbols, or any combination of those used to establish a contact to a particular person, organisation or service.
	/// </summary>
	public class telecommunicationIdentifier : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(telecommunicationIdentifier);
		[JsonIgnore]
		public override string S100FC_name => "Telecommunication Identifier";

		public static implicit operator telecommunicationIdentifier(String? value) => new telecommunicationIdentifier { value = value };
	}

	/// <summary>
	/// Classification of methods of communication over a distance by electrical, electronic, or electromagnetic means.
	/// </summary>
	public class telecommunicationService : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(telecommunicationService);
		[JsonIgnore]
		public override string S100FC_name => "Telecommunication Service";
		public static listedValue[] listedValues => [
				new listedValue("Voice", "The transfer or exchange of information by using sounds that are being made by mouth and throat when speaking.",1),
				new listedValue("Facsimile", "A system of transmitting and reproducing graphic matter (as printing or still pictures) by means of signals sent over telephone lines.",2),
				new listedValue("SMS", "Short Message Service is a form of text messaging communication on phones and mobile phones.",3),
				new listedValue("Data", "A representation of facts, concepts or instructions in a formalised manner suitable for communication, interpretation or processing.",4),
				new listedValue("Streamed Data", "Data that is constantly received by and presented to an end-user while being delivered by a provider.",5),
				new listedValue("Telex", "A system of communication in which messages are sent over long distances by using a telephone system and are printed by using a special machine (called a teletypewriter).",6),
				new listedValue("Telegraph", "An apparatus, system or process for communication at a distance by electric transmission over wire.",7),
				new listedValue("Email", "Messages and other data exchanged between individuals using computers in a network.",8),
			];

		public static implicit operator telecommunicationService(int? value) => new telecommunicationService { value = value };
	}

	/// <summary>
	/// A non-formatted digital text string.
	/// </summary>
	public class text : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(text);
		[JsonIgnore]
		public override string S100FC_name => "Text";

		public static implicit operator text(String? value) => new text { value = value };
	}

	/// <summary>
	/// The type of a physical (navigational) product, usually printed on paper.
	/// </summary>
	public class typeOfPhysicalProduct : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(typeOfPhysicalProduct);
		[JsonIgnore]
		public override string S100FC_name => "Type Of Physical Product";

		public static implicit operator typeOfPhysicalProduct(String? value) => new typeOfPhysicalProduct { value = value };
	}

	/// <summary>
	/// The type of product format.
	/// </summary>
	public class typeOfProductFormat : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(typeOfProductFormat);
		[JsonIgnore]
		public override string S100FC_name => "Type Of Product Format";
		public static listedValue[] listedValues => [
				new listedValue("GML", "Geography Markup Language. An XML-based geographic information encoding language developed by the Open GIS Consortium (OGC) to enhance the interoperability of geographic information.",1),
				new listedValue("ISO/IEC 8211", "Specification for a data descriptive file for information interchange.",2),
				new listedValue("PDF", "Portable Document Format. A file format developed by Adobe in 1993 to present documents, including text formatting and images, in a manner independent of application software, hardware, and operating systems.",3),
				new listedValue("HTML", "Hypertext Markup Language.",4),
				new listedValue("ePub", "E-book file format.",5),
				new listedValue("Paper", "For printing hydrographic charts, heavyweight, single layer paper is used. Such paper is generally made wholly or partly from rags and simulates hand-made paper. It is strong, moisture resistant and manufactured to withstand surface erasure.",6),
				new listedValue("HDF-5", "Hierarchical Data Format version 5 is a file format and data model designed for storing and organizing large amounts of numerical data efficiently.",7),
				new listedValue("BSB", "A file format used primarily for storing nautical charts in raster form.",8),
				new listedValue("GeoTiff", "Extension of the TIFF specification to allow the storage of geo- referencing information.",9),
				new listedValue("Application", "Provision of data in a format including operational functionality, such as a software program designed to perform specific tasks or functions for the user.",10),
				new listedValue("XML", "Extensible Markup Language.",11),
				new listedValue("PNG", "Portable Network Graphics format.",12),
			];

		public static implicit operator typeOfProductFormat(int? value) => new typeOfProductFormat { value = value };
	}

	/// <summary>
	/// The unit of a value indicating a time Time Interval.
	/// </summary>
	public class typeOfTimeIntervalUnit : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(typeOfTimeIntervalUnit);
		[JsonIgnore]
		public override string S100FC_name => "Type Of Time Interval Unit";
		public static listedValue[] listedValues => [
				new listedValue("Hour", "A unit of time equal to 60 minutes or 3600 seconds.",1),
				new listedValue("Day", "(1) The duration of one rotation of the earth, or occasionally another celestial body, on its axis. It is measured by successive transits of a reference point on the celestial sphere over the meridian, and each type takes its name from the reference used.  (2) The period of daylight, as distinguished from night.",2),
				new listedValue("Month", "A measure of time based on the motion of the moon in its orbit.",3),
				new listedValue("Year", "A period of one revolution of the earth around the sun.",4),
			];

		public static implicit operator typeOfTimeIntervalUnit(int? value) => new typeOfTimeIntervalUnit { value = value };
	}

	/// <summary>
	/// A date referring to the day a product or service was updated.
	/// </summary>
	public class updateDate : S100Framework.AttributeModel.DateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(updateDate);
		[JsonIgnore]
		public override string S100FC_name => "Update Date";

		public static implicit operator updateDate(DateOnly? value) => new updateDate { value = value };
	}

	/// <summary>
	/// Update number of the ENC being referenced.
	/// </summary>
	public class updateNumber : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(updateNumber);
		[JsonIgnore]
		public override string S100FC_name => "Update Number";

		public static implicit operator updateNumber(int? value) => new updateNumber { value = value };
	}

	/// <summary>
	/// The length or duration of a time interval, referred to a specified time interval unit.
	/// </summary>
	public class valueOfTime : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(valueOfTime);
		[JsonIgnore]
		public override string S100FC_name => "Value Of Time";

		public static implicit operator valueOfTime(int? value) => new valueOfTime { value = value };
	}

	/// <summary>
	/// Identification of a specific form or variation of an entity.
	/// </summary>
	public class version : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(version);
		[JsonIgnore]
		public override string S100FC_name => "Version";

		public static implicit operator version(String? value) => new version { value = value };
	}

	/// <summary>
	/// The length in cm of the shorter side of a paper.
	/// </summary>
	public class paperWidth : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(paperWidth);
		[JsonIgnore]
		public override string S100FC_name => "Paper Width";

		public static implicit operator paperWidth(double? value) => new paperWidth { value = value };
	}

	/// <summary>
	/// The length in cm of the longer side of a paper.
	/// </summary>
	public class paperLength : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(paperLength);
		[JsonIgnore]
		public override string S100FC_name => "Paper Length";

		public static implicit operator paperLength(double? value) => new paperLength { value = value };
	}

	/// <summary>
	/// The official publication date of a notice, product or service.
	/// </summary>
	public class publicationDate : S100Framework.AttributeModel.DateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(publicationDate);
		[JsonIgnore]
		public override string S100FC_name => "Publication Date";

		public static implicit operator publicationDate(DateOnly? value) => new publicationDate { value = value };
	}

	/// <summary>
	/// A consecutive number that specifies a week within a year.
	/// </summary>
	public class weekNumber : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(weekNumber);
		[JsonIgnore]
		public override string S100FC_name => "Week Number";

		public static implicit operator weekNumber(int? value) => new weekNumber { value = value };
	}

	/// <summary>
	/// A number indicating a year.
	/// </summary>
	public class yearNumber : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(yearNumber);
		[JsonIgnore]
		public override string S100FC_name => "Year Number";

		public static implicit operator yearNumber(int? value) => new yearNumber { value = value };
	}

	/// <summary>
	/// Horizontal reference as an EPSG code representing a valid entry in the EPSG Geodetic Parameter Dataset, as maintained by the Geodesy Subcommittee of the IOGP Geomatics Committee, and provided online at epsg.org.
	/// </summary>
	public class horizontalDatumEPSGCode : S100Framework.AttributeModel.CodeListAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(horizontalDatumEPSGCode);
		[JsonIgnore]
		public override string S100FC_name => "Horizontal Datum EPSG Code";
		public static listedValue[] listedValues => [
				new listedValue("EPSG3395 (World Mercator)", "A global Mercator projection commonly used for mapping applications requiring accurate distance measurements near the equator.",3395),
				new listedValue("EPSG3857 (Pseudo-Mercator)", "A popular web mapping projection used by Google Maps, OpenStreetMap, and Bing Maps. Distorts at the poles but is widely used in online maps.",3857),
				new listedValue("EPSG4326 (WGS84)", "World Geodetic System 1984, used globally for GPS and geographic coordinates. Specifies coordinates in latitude and longitude degrees.",4326),
			];
	}

	/// <summary>
	/// The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.
	/// </summary>
	public class verticalDatum : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(verticalDatum);
		[JsonIgnore]
		public override string S100FC_name => "Vertical Datum";
		public static listedValue[] listedValues => [
				new listedValue("Mean Low Water Springs", "The average height of the low waters of spring tides. This level is used as a tidal datum in some areas.",1),
				new listedValue("Mean Lower Low Water Springs", "The average height of lower low water springs at a place.",2),
				new listedValue("Mean Sea Level", "The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.",3),
				new listedValue("Lowest Low Water", "An arbitrary level conforming to the lowest tide observed at a place, or somewhat lower.",4),
				new listedValue("Mean Low Water", "The average height of all low waters at a place over a 19-year period.",5),
				new listedValue("Lowest Low Water Springs", "An arbitrary level conforming to the lowest water level observed at a place at spring tides during a period of time shorter than 19 years.",6),
				new listedValue("Approximate Mean Low Water Springs", "An arbitrary level, usually within 0.3m from that of Mean Low Water Springs (MLWS).",7),
				new listedValue("Indian Spring Low Water", "An arbitrary tidal datum approximating the level of the mean of the lower low water at spring tides. It was first used in waters surrounding India.",8),
				new listedValue("Low Water Springs", "An arbitrary level, approximating that of mean low water springs (MLWS).",9),
				new listedValue("Approximate Lowest Astronomical Tide", "An arbitrary level, usually within 0.3m from that of Lowest Astronomical Tide (LAT).",10),
				new listedValue("Nearly Lowest Low Water", "An arbitrary level approximating the lowest water level observed at a place, usually equivalent to the Indian Spring Low Water (ISLW).",11),
				new listedValue("Mean Lower Low Water", "The average height of the lower low waters at a place over a 19-year period.",12),
				new listedValue("Low Water", "The lowest level reached at a place by the water surface in one oscillation.",13),
				new listedValue("Approximate Mean Low Water", "An arbitrary level, usually within 0.3m from that of Mean Low Water (MLW).",14),
				new listedValue("Approximate Mean Lower Low Water", "An arbitrary level, usually within 0.3m from that of Mean Lower Low Water (MLLW).",15),
				new listedValue("Mean High Water", "The average height of all high waters at a place over a 19-year period.",16),
				new listedValue("Mean High Water Springs", "The average height of the high waters of spring tides.",17),
				new listedValue("High Water", "The highest level reached at a place by the water surface in one oscillation.",18),
				new listedValue("Approximate Mean Sea Level", "An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).",19),
				new listedValue("High Water Springs", "An arbitrary level, approximating that of mean high water springs (MHWS).",20),
				new listedValue("Mean Higher High Water", "The average height of higher high waters at a place over a 19-year period.",21),
				new listedValue("Equinoctial Spring Low Water", "The level of low water springs near the time of an equinox.",22),
				new listedValue("Lowest Astronomical Tide", "The lowest tide level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.",23),
				new listedValue("Local Datum", "An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.",24),
				new listedValue("International Great Lakes Datum 1985", "A vertical reference system with its zero based on the mean water level at Rimouski/Pointe-au-Père, Quebec, over the period 1970 to 1988.",25),
				new listedValue("Mean Water Level", "The average of all hourly water levels over the available period of record.",26),
				new listedValue("Lower Low Water Large Tide", "The average of the lowest low waters, one from each of 19 years of observations.",27),
				new listedValue("Higher High Water Large Tide", "The average of the highest high waters, one from each of 19 years of observations.",28),
				new listedValue("Nearly Highest High Water", "An arbitrary level approximating the highest water level observed at a place, usually equivalent to the high water springs.",29),
				new listedValue("Highest Astronomical Tide", "The highest tidal level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.",30),
				new listedValue("Local Low Water Reference Level", "Low water reference level of the local area.",31),
				new listedValue("Local High Water Reference Level", "High water reference level of the local area.",32),
				new listedValue("Local Mean Water Reference Level", "Mean water reference level of the local area.",33),
				new listedValue("Equivalent Height of Water (German GlW)", "A low water level which is the result of a defined low water discharge - called \"equivalent discharge\".",34),
				new listedValue("Highest Shipping Height of Water (German HSW)", "Upper limit of water levels where navigation is allowed.",35),
				new listedValue("Reference Low Water Level According to Danube Commission", "The water level at a discharge, which is exceeded 94 % of the year within a period of 30 years.",36),
				new listedValue("Highest Shipping Height of Water According to Danube Commission", "The water level at a discharge, which is exceeded 1% of the year within a period of 30 years.",37),
				new listedValue("Dutch River Low Water Reference Level (OLR)", "The water level at a discharge, which is exceeded 95% of the year within a period of 20 years.",38),
				new listedValue("Russian Project Water Level", "Conditional low water level with established probability.",39),
				new listedValue("Russian Normal Backwater Level", "Highest water level derived from the upper backwater stream in watercourse or reservoir under the normal operational conditions.",40),
				new listedValue("Ohio River Datum", "The Ohio River datum.",41),
				new listedValue("Dutch High Water Reference Level", "Dutch High Water Reference Level.",43),
				new listedValue("Baltic Sea Chart Datum 2000", "The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).",44),
				new listedValue("Dutch Estuary Low Water Reference Level (OLW)", "Dutch Estuary Low Water Reference Level (OLW)",45),
				new listedValue("International Great Lakes Datum 2020", "The 2020 update to the International Great Lakes Datum, the official reference system used to measure water level heights in the Great Lakes, connecting channels, and the St. Lawrence River system.",46),
				new listedValue("Sea Floor", "The bottom of the ocean and seas where there is a generally smooth gentle gradient. Also referred to as sea bed (sometimes seabed or sea-bed), and sea bottom.",47),
				new listedValue("Sea Surface", "A two-dimensional (in the horizontal plane) field representing the air-sea interface, with high-frequency fluctuations such as wind waves and swell, but not astronomical tides, filtered out.",48),
				new listedValue("Hydrographic Zero", "A vertical reference near the lowest astronomical tide (LAT), below which the sea level falls only very exceptionally.",49),
			];

		public static implicit operator verticalDatum(int? value) => new verticalDatum { value = value };
	}

}

namespace S100Framework.AttributeModel.S128.ComplexAttributes
{
	using S100Framework.AttributeModel.S128.SimpleAttributes;

	/// <summary>
	/// Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.
	/// </summary>
	public class contactAddress : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(contactAddress);
		[JsonIgnore]
		public override string S100FC_name => "Contact Address";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(administrativeDivision),
					lower = 0,
					upper = 1,
					CreateInstance = () => new administrativeDivision(),
				},
				new AttributeBinding {
					attribute = nameof(cityName),
					lower = 0,
					upper = 1,
					CreateInstance = () => new cityName(),
				},
				new AttributeBinding {
					attribute = nameof(countryName),
					lower = 0,
					upper = 1,
					CreateInstance = () => new countryName(),
				},
				new AttributeBinding {
					attribute = nameof(deliveryPoint),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new deliveryPoint(),
				},
				new AttributeBinding {
					attribute = nameof(postalCode),
					lower = 0,
					upper = 1,
					CreateInstance = () => new postalCode(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? administrativeDivision_optional {
			set { base.AddAttributeValue(new administrativeDivision { value = value }); }
			get { return base.GetAttributeValue<administrativeDivision>(nameof(administrativeDivision))?.value; }
		}
		public String? cityName_optional {
			set { base.AddAttributeValue(new cityName { value = value }); }
			get { return base.GetAttributeValue<cityName>(nameof(cityName))?.value; }
		}
		public String? countryName_optional {
			set { base.AddAttributeValue(new countryName { value = value }); }
			get { return base.GetAttributeValue<countryName>(nameof(countryName))?.value; }
		}
		public String?[] deliveryPoint_optional {
			set { base.AddAttributeValue([.. value.Select(e=> new deliveryPoint { value = e })]); }
			get { return base.GetAttributeValues<deliveryPoint>(nameof(deliveryPoint)).Select(e=>e.value).ToArray(); }
		}
		public String? postalCode_optional {
			set { base.AddAttributeValue(new postalCode { value = value }); }
			get { return base.GetAttributeValue<postalCode>(nameof(postalCode))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// User specified paper size width x, height y
	/// </summary>
	public class customPaperSize : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(customPaperSize);
		[JsonIgnore]
		public override string S100FC_name => "Custom Paper Size";
		public paperWidth paperWidth { get; set; } = new paperWidth();
		public paperLength paperLength { get; set; } = new paperLength();

		[JsonIgnore]
		public override Attribute[] attributes => [
				paperWidth,
				paperLength,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(paperWidth),
					lower = 1,
					upper = 1,
					CreateInstance = () => new paperWidth(),
				},
				new AttributeBinding {
					attribute = nameof(paperLength),
					lower = 1,
					upper = 1,
					CreateInstance = () => new paperLength(),
				},
			];
		#endregion

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// Locale of an option that is selected automatically unless an alternative is specified.
	/// </summary>
	public class defaultLocale : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(defaultLocale);
		[JsonIgnore]
		public override string S100FC_name => "Default Locale";
		public characterEncoding characterEncoding { get; set; } = new characterEncoding();
		public countryName countryName { get; set; } = new countryName();

		[JsonIgnore]
		public override Attribute[] attributes => [
				characterEncoding,
				countryName,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(characterEncoding),
					lower = 1,
					upper = 1,
					CreateInstance = () => new characterEncoding(),
				},
				new AttributeBinding {
					attribute = nameof(countryName),
					lower = 1,
					upper = 1,
					CreateInstance = () => new countryName(),
				},
				new AttributeBinding {
					attribute = nameof(language),
					lower = 0,
					upper = 1,
					CreateInstance = () => new language(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? language_optional {
			set { base.AddAttributeValue(new language { value = value }); }
			get { return base.GetAttributeValue<language>(nameof(language))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
	/// </summary>
	public class featureName : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(featureName);
		[JsonIgnore]
		public override string S100FC_name => "Feature Name";
		public name name { get; set; } = new name();

		[JsonIgnore]
		public override Attribute[] attributes => [
				name,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(language),
					lower = 0,
					upper = 1,
					CreateInstance = () => new language(),
				},
				new AttributeBinding {
					attribute = nameof(name),
					lower = 1,
					upper = 1,
					CreateInstance = () => new name(),
				},
				new AttributeBinding {
					attribute = nameof(nameUsage),
					lower = 0,
					upper = 1,
					CreateInstance = () => new nameUsage(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? language_optional {
			set { base.AddAttributeValue(new language { value = value }); }
			get { return base.GetAttributeValue<language>(nameof(language))?.value; }
		}
		public int? nameUsage_optional {
			set { base.AddAttributeValue(new nameUsage { value = value }); }
			get { return base.GetAttributeValue<nameUsage>(nameof(nameUsage))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.
	/// </summary>
	public class information : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(information);
		[JsonIgnore]
		public override string S100FC_name => "Information";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(fileLocator),
					lower = 0,
					upper = 1,
					CreateInstance = () => new fileLocator(),
				},
				new AttributeBinding {
					attribute = nameof(fileReference),
					lower = 0,
					upper = 1,
					CreateInstance = () => new fileReference(),
				},
				new AttributeBinding {
					attribute = nameof(headline),
					lower = 0,
					upper = 1,
					CreateInstance = () => new headline(),
				},
				new AttributeBinding {
					attribute = nameof(language),
					lower = 0,
					upper = 1,
					CreateInstance = () => new language(),
				},
				new AttributeBinding {
					attribute = nameof(text),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new text(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? fileLocator_optional {
			set { base.AddAttributeValue(new fileLocator { value = value }); }
			get { return base.GetAttributeValue<fileLocator>(nameof(fileLocator))?.value; }
		}
		public String? fileReference_optional {
			set { base.AddAttributeValue(new fileReference { value = value }); }
			get { return base.GetAttributeValue<fileReference>(nameof(fileReference))?.value; }
		}
		public String? headline_optional {
			set { base.AddAttributeValue(new headline { value = value }); }
			get { return base.GetAttributeValue<headline>(nameof(headline))?.value; }
		}
		public String? language_optional {
			set { base.AddAttributeValue(new language { value = value }); }
			get { return base.GetAttributeValue<language>(nameof(language))?.value; }
		}
		public String?[] text_optional {
			set { base.AddAttributeValue([.. value.Select(e=> new text { value = e })]); }
			get { return base.GetAttributeValues<text>(nameof(text)).Select(e=>e.value).ToArray(); }
		}
		#endregion
	}

	/// <summary>
	/// Information about online sources from which a resource or data can be obtained.
	/// </summary>
	public class onlineResource : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(onlineResource);
		[JsonIgnore]
		public override string S100FC_name => "Online Resource";
		public linkage linkage { get; set; } = new linkage();

		[JsonIgnore]
		public override Attribute[] attributes => [
				linkage,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(applicationProfile),
					lower = 0,
					upper = 1,
					CreateInstance = () => new applicationProfile(),
				},
				new AttributeBinding {
					attribute = nameof(linkage),
					lower = 1,
					upper = 1,
					CreateInstance = () => new linkage(),
				},
				new AttributeBinding {
					attribute = nameof(nameOfResource),
					lower = 0,
					upper = 1,
					CreateInstance = () => new nameOfResource(),
				},
				new AttributeBinding {
					attribute = nameof(onlineDescription),
					lower = 0,
					upper = 1,
					CreateInstance = () => new onlineDescription(),
				},
				new AttributeBinding {
					attribute = nameof(protocol),
					lower = 0,
					upper = 1,
					CreateInstance = () => new protocol(),
				},
				new AttributeBinding {
					attribute = nameof(protocolRequest),
					lower = 0,
					upper = 1,
					CreateInstance = () => new protocolRequest(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? applicationProfile_optional {
			set { base.AddAttributeValue(new applicationProfile { value = value }); }
			get { return base.GetAttributeValue<applicationProfile>(nameof(applicationProfile))?.value; }
		}
		public String? nameOfResource_optional {
			set { base.AddAttributeValue(new nameOfResource { value = value }); }
			get { return base.GetAttributeValue<nameOfResource>(nameof(nameOfResource))?.value; }
		}
		public String? onlineDescription_optional {
			set { base.AddAttributeValue(new onlineDescription { value = value }); }
			get { return base.GetAttributeValue<onlineDescription>(nameof(onlineDescription))?.value; }
		}
		public String? protocol_optional {
			set { base.AddAttributeValue(new protocol { value = value }); }
			get { return base.GetAttributeValue<protocol>(nameof(protocol))?.value; }
		}
		public String? protocolRequest_optional {
			set { base.AddAttributeValue(new protocolRequest { value = value }); }
			get { return base.GetAttributeValue<protocolRequest>(nameof(protocolRequest))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// The active period of a recurring event or occurrence.
	/// </summary>
	public class periodicDateRange : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(periodicDateRange);
		[JsonIgnore]
		public override string S100FC_name => "Periodic Date Range";
		public dateEnd dateEnd { get; set; } = new dateEnd();
		public dateStart dateStart { get; set; } = new dateStart();

		[JsonIgnore]
		public override Attribute[] attributes => [
				dateEnd,
				dateStart,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(dateEnd),
					lower = 1,
					upper = 1,
					CreateInstance = () => new dateEnd(),
				},
				new AttributeBinding {
					attribute = nameof(dateStart),
					lower = 1,
					upper = 1,
					CreateInstance = () => new dateStart(),
				},
			];
		#endregion

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// A decision or establishment of a price.
	/// </summary>
	public class pricing : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(pricing);
		[JsonIgnore]
		public override string S100FC_name => "Pricing";
		public currency currency { get; set; } = new currency();
		public price price { get; set; } = new price();

		[JsonIgnore]
		public override Attribute[] attributes => [
				currency,
				price,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(contractPeriod),
					lower = 0,
					upper = 1,
					CreateInstance = () => new contractPeriod(),
				},
				new AttributeBinding {
					attribute = nameof(currency),
					lower = 1,
					upper = 1,
					CreateInstance = () => new currency(),
				},
				new AttributeBinding {
					attribute = nameof(price),
					lower = 1,
					upper = 1,
					CreateInstance = () => new price(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? contractPeriod_optional {
			set { base.AddAttributeValue(new contractPeriod { value = value }); }
			get { return base.GetAttributeValue<contractPeriod>(nameof(contractPeriod))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Size of nautical paper charts.
	/// </summary>
	public class printSize : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(printSize);
		[JsonIgnore]
		public override string S100FC_name => "Print Size";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(iSO216),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4,5,6,7,8],
					CreateInstance = () => new iSO216(),
				},
				new AttributeBinding {
					attribute = nameof(customPaperSize),
					lower = 0,
					upper = 1,
					CreateInstance = () => new customPaperSize(),
				},
			];
		#endregion

		#region Optional Attributes
		public int? iSO216_optional {
			set { base.AddAttributeValue(new iSO216 { value = value }); }
			get { return base.GetAttributeValue<iSO216>(nameof(iSO216))?.value; }
		}
		public customPaperSize? customPaperSize_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<customPaperSize>(nameof(customPaperSize)); }
		}
		#endregion
	}

	/// <summary>
	/// The name of the product specification to which a nautical product adheres.
	/// </summary>
	public class productSpecification : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(productSpecification);
		[JsonIgnore]
		public override string S100FC_name => "Product Specification";
		public editionDate editionDate { get; set; } = new editionDate();
		public name name { get; set; } = new name();
		public version version { get; set; } = new version();

		[JsonIgnore]
		public override Attribute[] attributes => [
				editionDate,
				name,
				version,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(editionDate),
					lower = 1,
					upper = 1,
					CreateInstance = () => new editionDate(),
				},
				new AttributeBinding {
					attribute = nameof(iSSN),
					lower = 0,
					upper = 1,
					CreateInstance = () => new iSSN(),
				},
				new AttributeBinding {
					attribute = nameof(name),
					lower = 1,
					upper = 1,
					CreateInstance = () => new name(),
				},
				new AttributeBinding {
					attribute = nameof(version),
					lower = 1,
					upper = 1,
					CreateInstance = () => new version(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? iSSN_optional {
			set { base.AddAttributeValue(new iSSN { value = value }); }
			get { return base.GetAttributeValue<iSSN>(nameof(iSSN))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// The name of the product specification to which a support file adheres.
	/// </summary>
	public class supportFileSpecification : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(supportFileSpecification);
		[JsonIgnore]
		public override string S100FC_name => "Support File Specification";
		public editionDate editionDate { get; set; } = new editionDate();
		public name name { get; set; } = new name();
		public version version { get; set; } = new version();

		[JsonIgnore]
		public override Attribute[] attributes => [
				editionDate,
				name,
				version,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(editionDate),
					lower = 1,
					upper = 1,
					CreateInstance = () => new editionDate(),
				},
				new AttributeBinding {
					attribute = nameof(name),
					lower = 1,
					upper = 1,
					CreateInstance = () => new name(),
				},
				new AttributeBinding {
					attribute = nameof(version),
					lower = 1,
					upper = 1,
					CreateInstance = () => new version(),
				},
			];
		#endregion

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// The name of the (product) specification to which a nautical service adheres.
	/// </summary>
	public class serviceSpecification : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(serviceSpecification);
		[JsonIgnore]
		public override string S100FC_name => "Service Specification";
		public editionDate editionDate { get; set; } = new editionDate();
		public name name { get; set; } = new name();
		public version version { get; set; } = new version();

		[JsonIgnore]
		public override Attribute[] attributes => [
				editionDate,
				name,
				version,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(editionDate),
					lower = 1,
					upper = 1,
					CreateInstance = () => new editionDate(),
				},
				new AttributeBinding {
					attribute = nameof(name),
					lower = 1,
					upper = 1,
					CreateInstance = () => new name(),
				},
				new AttributeBinding {
					attribute = nameof(version),
					lower = 1,
					upper = 1,
					CreateInstance = () => new version(),
				},
			];
		#endregion

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.
	/// </summary>
	public class sourceIndication : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sourceIndication);
		[JsonIgnore]
		public override string S100FC_name => "Source Indication";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(categoryOfAuthority),
					lower = 0,
					upper = 1,
					permitedValues = [2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19],
					CreateInstance = () => new categoryOfAuthority(),
				},
				new AttributeBinding {
					attribute = nameof(countryName),
					lower = 0,
					upper = 1,
					CreateInstance = () => new countryName(),
				},
				new AttributeBinding {
					attribute = nameof(reportedDate),
					lower = 0,
					upper = 1,
					CreateInstance = () => new reportedDate(),
				},
				new AttributeBinding {
					attribute = nameof(source),
					lower = 0,
					upper = 1,
					CreateInstance = () => new source(),
				},
				new AttributeBinding {
					attribute = nameof(sourceType),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,7,8,9,10,11,12,13,14,15],
					CreateInstance = () => new sourceType(),
				},
				new AttributeBinding {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new featureName(),
				},
			];
		#endregion

		#region Optional Attributes
		public int? categoryOfAuthority_optional {
			set { base.AddAttributeValue(new categoryOfAuthority { value = value }); }
			get { return base.GetAttributeValue<categoryOfAuthority>(nameof(categoryOfAuthority))?.value; }
		}
		public String? countryName_optional {
			set { base.AddAttributeValue(new countryName { value = value }); }
			get { return base.GetAttributeValue<countryName>(nameof(countryName))?.value; }
		}
		public DateOnly? reportedDate_optional {
			set { base.AddAttributeValue(new reportedDate { value = value }); }
			get { return base.GetAttributeValue<reportedDate>(nameof(reportedDate))?.value; }
		}
		public String? source_optional {
			set { base.AddAttributeValue(new source { value = value }); }
			get { return base.GetAttributeValue<source>(nameof(source))?.value; }
		}
		public int? sourceType_optional {
			set { base.AddAttributeValue(new sourceType { value = value }); }
			get { return base.GetAttributeValue<sourceType>(nameof(sourceType))?.value; }
		}
		public featureName?[] featureName_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<featureName>(nameof(featureName)); } 
	}
		#endregion
	}

	/// <summary>
	/// A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.
	/// </summary>
	public class telecommunications : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(telecommunications);
		[JsonIgnore]
		public override string S100FC_name => "Telecommunications";
		public contactInstructions contactInstructions { get; set; } = new contactInstructions();
		public telecommunicationIdentifier telecommunicationIdentifier { get; set; } = new telecommunicationIdentifier();

		[JsonIgnore]
		public override Attribute[] attributes => [
				contactInstructions,
				telecommunicationIdentifier,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(contactInstructions),
					lower = 1,
					upper = 1,
					CreateInstance = () => new contactInstructions(),
				},
				new AttributeBinding {
					attribute = nameof(telecommunicationIdentifier),
					lower = 1,
					upper = 1,
					CreateInstance = () => new telecommunicationIdentifier(),
				},
				new AttributeBinding {
					attribute = nameof(telecommunicationService),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,2,3,4,5,6,7,8],
					CreateInstance = () => new telecommunicationService(),
				},
			];
		#endregion

		#region Optional Attributes
		public int?[] telecommunicationService_optional {
			set { base.AddAttributeValue([.. value.Select(e=> new telecommunicationService { value = e })]); }
			get { return base.GetAttributeValues<telecommunicationService>(nameof(telecommunicationService)).Select(e=>e.value).ToArray(); }
		}
		#endregion
	}

	/// <summary>
	/// The temporal interval of the cycle over which data is produced.
	/// </summary>
	public class timeIntervalOfCycle : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(timeIntervalOfCycle);
		[JsonIgnore]
		public override string S100FC_name => "Time Interval Of Cycle";
		public typeOfTimeIntervalUnit typeOfTimeIntervalUnit { get; set; } = new typeOfTimeIntervalUnit();
		public valueOfTime valueOfTime { get; set; } = new valueOfTime();

		[JsonIgnore]
		public override Attribute[] attributes => [
				typeOfTimeIntervalUnit,
				valueOfTime,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(typeOfTimeIntervalUnit),
					lower = 1,
					upper = 2147483647,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new typeOfTimeIntervalUnit(),
				},
				new AttributeBinding {
					attribute = nameof(valueOfTime),
					lower = 1,
					upper = 1,
					CreateInstance = () => new valueOfTime(),
				},
			];
		#endregion

		#region Optional Attributes
		public int?[] typeOfTimeIntervalUnit_optional {
			set { base.AddAttributeValue([.. value.Select(e=> new typeOfTimeIntervalUnit { value = e })]); }
			get { return base.GetAttributeValues<typeOfTimeIntervalUnit>(nameof(typeOfTimeIntervalUnit)).Select(e=>e.value).ToArray(); }
		}
		#endregion
	}

	/// <summary>
	/// The indication of a specific week within a specific year.
	/// </summary>
	public class weekOfYear : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(weekOfYear);
		[JsonIgnore]
		public override string S100FC_name => "Week Of Year";
		public weekNumber weekNumber { get; set; } = new weekNumber();
		public yearNumber yearNumber { get; set; } = new yearNumber();

		[JsonIgnore]
		public override Attribute[] attributes => [
				weekNumber,
				yearNumber,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(weekNumber),
					lower = 1,
					upper = 1,
					CreateInstance = () => new weekNumber(),
				},
				new AttributeBinding {
					attribute = nameof(yearNumber),
					lower = 1,
					upper = 1,
					CreateInstance = () => new yearNumber(),
				},
			];
		#endregion

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// The cycle of issuing a product or service.
	/// </summary>
	public class issuanceCycle : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(issuanceCycle);
		[JsonIgnore]
		public override string S100FC_name => "Issuance Cycle";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(periodicDateRange),
					lower = 0,
					upper = 1,
					CreateInstance = () => new periodicDateRange(),
				},
				new AttributeBinding {
					attribute = nameof(timeIntervalOfCycle),
					lower = 0,
					upper = 1,
					CreateInstance = () => new timeIntervalOfCycle(),
				},
			];
		#endregion

		#region Optional Attributes
		public periodicDateRange? periodicDateRange_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<periodicDateRange>(nameof(periodicDateRange)); }
		}
		public timeIntervalOfCycle? timeIntervalOfCycle_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<timeIntervalOfCycle>(nameof(timeIntervalOfCycle)); }
		}
		#endregion
	}

	/// <summary>
	/// Information on the printing of nautical paper charts.
	/// </summary>
	public class printInformation : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(printInformation);
		[JsonIgnore]
		public override string S100FC_name => "Print Information";
		public printSize printSize { get; set; } = new printSize();

		[JsonIgnore]
		public override Attribute[] attributes => [
				printSize,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(printAgency),
					lower = 0,
					upper = 1,
					CreateInstance = () => new printAgency(),
				},
				new AttributeBinding {
					attribute = nameof(printNation),
					lower = 0,
					upper = 1,
					CreateInstance = () => new printNation(),
				},
				new AttributeBinding {
					attribute = nameof(reprintEdition),
					lower = 0,
					upper = 1,
					CreateInstance = () => new reprintEdition(),
				},
				new AttributeBinding {
					attribute = nameof(reprintNation),
					lower = 0,
					upper = 1,
					CreateInstance = () => new reprintNation(),
				},
				new AttributeBinding {
					attribute = nameof(printSize),
					lower = 1,
					upper = 1,
					CreateInstance = () => new printSize(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? printAgency_optional {
			set { base.AddAttributeValue(new printAgency { value = value }); }
			get { return base.GetAttributeValue<printAgency>(nameof(printAgency))?.value; }
		}
		public String? printNation_optional {
			set { base.AddAttributeValue(new printNation { value = value }); }
			get { return base.GetAttributeValue<printNation>(nameof(printNation))?.value; }
		}
		public String? reprintEdition_optional {
			set { base.AddAttributeValue(new reprintEdition { value = value }); }
			get { return base.GetAttributeValue<reprintEdition>(nameof(reprintEdition))?.value; }
		}
		public String? reprintNation_optional {
			set { base.AddAttributeValue(new reprintNation { value = value }); }
			get { return base.GetAttributeValue<reprintNation>(nameof(reprintNation))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Information on additional files used in addition to nautical products.
	/// </summary>
	public class supportFile : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(supportFile);
		[JsonIgnore]
		public override string S100FC_name => "Support File";
		public digitalSignatureReference digitalSignatureReference { get; set; } = new digitalSignatureReference();
		public fileLocator fileLocator { get; set; } = new fileLocator();
		public fileName fileName { get; set; } = new fileName();
		public supportFileFormat supportFileFormat { get; set; } = new supportFileFormat();
		public supportFilePurpose supportFilePurpose { get; set; } = new supportFilePurpose();
		public defaultLocale defaultLocale { get; set; } = new defaultLocale();
		public supportFileSpecification supportFileSpecification { get; set; } = new supportFileSpecification();

		[JsonIgnore]
		public override Attribute[] attributes => [
				digitalSignatureReference,
				fileLocator,
				fileName,
				supportFileFormat,
				supportFilePurpose,
				defaultLocale,
				supportFileSpecification,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(comment),
					lower = 0,
					upper = 1,
					CreateInstance = () => new comment(),
				},
				new AttributeBinding {
					attribute = nameof(digitalSignatureReference),
					lower = 1,
					upper = 1,
					permitedValues = [8],
					CreateInstance = () => new digitalSignatureReference(),
				},
				new AttributeBinding {
					attribute = nameof(digitalSignatureValue),
					lower = 0,
					upper = 1,
					permitedValues = [1,2],
					CreateInstance = () => new digitalSignatureValue(),
				},
				new AttributeBinding {
					attribute = nameof(editionNumber),
					lower = 0,
					upper = 1,
					CreateInstance = () => new editionNumber(),
				},
				new AttributeBinding {
					attribute = nameof(fileLocator),
					lower = 1,
					upper = 1,
					CreateInstance = () => new fileLocator(),
				},
				new AttributeBinding {
					attribute = nameof(fileName),
					lower = 1,
					upper = 1,
					CreateInstance = () => new fileName(),
				},
				new AttributeBinding {
					attribute = nameof(issueDate),
					lower = 0,
					upper = 1,
					CreateInstance = () => new issueDate(),
				},
				new AttributeBinding {
					attribute = nameof(otherDataTypeDescription),
					lower = 0,
					upper = 1,
					CreateInstance = () => new otherDataTypeDescription(),
				},
				new AttributeBinding {
					attribute = nameof(supportFileFormat),
					lower = 1,
					upper = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,100],
					CreateInstance = () => new supportFileFormat(),
				},
				new AttributeBinding {
					attribute = nameof(supportFilePurpose),
					lower = 1,
					upper = 1,
					permitedValues = [1,2,3],
					CreateInstance = () => new supportFilePurpose(),
				},
				new AttributeBinding {
					attribute = nameof(defaultLocale),
					lower = 1,
					upper = 1,
					CreateInstance = () => new defaultLocale(),
				},
				new AttributeBinding {
					attribute = nameof(supportFileSpecification),
					lower = 1,
					upper = 1,
					CreateInstance = () => new supportFileSpecification(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? comment_optional {
			set { base.AddAttributeValue(new comment { value = value }); }
			get { return base.GetAttributeValue<comment>(nameof(comment))?.value; }
		}
		public int? digitalSignatureValue_optional {
			set { base.AddAttributeValue(new digitalSignatureValue { value = value }); }
			get { return base.GetAttributeValue<digitalSignatureValue>(nameof(digitalSignatureValue))?.value; }
		}
		public int? editionNumber_optional {
			set { base.AddAttributeValue(new editionNumber { value = value }); }
			get { return base.GetAttributeValue<editionNumber>(nameof(editionNumber))?.value; }
		}
		public DateOnly? issueDate_optional {
			set { base.AddAttributeValue(new issueDate { value = value }); }
			get { return base.GetAttributeValue<issueDate>(nameof(issueDate))?.value; }
		}
		public String? otherDataTypeDescription_optional {
			set { base.AddAttributeValue(new otherDataTypeDescription { value = value }); }
			get { return base.GetAttributeValue<otherDataTypeDescription>(nameof(otherDataTypeDescription))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// The temporal interval over which the product is updated or renewed.
	/// </summary>
	public class timeIntervalOfProduct : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(timeIntervalOfProduct);
		[JsonIgnore]
		public override string S100FC_name => "Time Interval Of Product";
		public issueDate issueDate { get; set; } = new issueDate();

		[JsonIgnore]
		public override Attribute[] attributes => [
				issueDate,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(expirationDate),
					lower = 0,
					upper = 1,
					CreateInstance = () => new expirationDate(),
				},
				new AttributeBinding {
					attribute = nameof(issueDate),
					lower = 1,
					upper = 1,
					CreateInstance = () => new issueDate(),
				},
				new AttributeBinding {
					attribute = nameof(issuanceCycle),
					lower = 0,
					upper = 1,
					CreateInstance = () => new issuanceCycle(),
				},
			];
		#endregion

		#region Optional Attributes
		public DateOnly? expirationDate_optional {
			set { base.AddAttributeValue(new expirationDate { value = value }); }
			get { return base.GetAttributeValue<expirationDate>(nameof(expirationDate))?.value; }
		}
		public issuanceCycle? issuanceCycle_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<issuanceCycle>(nameof(issuanceCycle)); }
		}
		#endregion
	}

	/// <summary>
	/// A reference to a of specific Notice to Mariners.
	/// </summary>
	public class referenceToNM : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(referenceToNM);
		[JsonIgnore]
		public override string S100FC_name => "Reference To NM";
		public publicationDate publicationDate { get; set; } = new publicationDate();

		[JsonIgnore]
		public override Attribute[] attributes => [
				publicationDate,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(publicationDate),
					lower = 1,
					upper = 1,
					CreateInstance = () => new publicationDate(),
				},
				new AttributeBinding {
					attribute = nameof(weekOfYear),
					lower = 0,
					upper = 1,
					CreateInstance = () => new weekOfYear(),
				},
			];
		#endregion

		#region Optional Attributes
		public weekOfYear? weekOfYear_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<weekOfYear>(nameof(weekOfYear)); }
		}
		#endregion
	}

}

namespace S100Framework.AttributeModel.S128.InformationTypes
{
	using S100Framework.AttributeModel.S128.SimpleAttributes;
	using S100Framework.AttributeModel.S128.ComplexAttributes;

	/// <summary>
	/// A header identifying a section within a catalogue.
	/// </summary>
	public class CatalogueSectionHeader : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(CatalogueSectionHeader);
		[JsonIgnore]
		public override string S100FC_name => "Catalogue Section Header";
		public catalogueSectionNumber catalogueSectionNumber { get; set; } = new catalogueSectionNumber();

		[JsonIgnore]
		public override Attribute[] attributes => [
				catalogueSectionNumber,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(catalogueSectionNumber),
					lower = 1,
					upper = 1,
					CreateInstance = () => new catalogueSectionNumber(),
				},
				new AttributeBinding {
					attribute = nameof(catalogueSectionTitle),
					lower = 0,
					upper = 1,
					CreateInstance = () => new catalogueSectionTitle(),
				},
				new AttributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 1,
					CreateInstance = () => new information(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? catalogueSectionTitle_optional {
			set { base.AddAttributeValue(new catalogueSectionTitle { value = value }); }
			get { return base.GetAttributeValue<catalogueSectionTitle>(nameof(catalogueSectionTitle))?.value; }
		}
		public information? information_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<information>(nameof(information)); }
		}
		#endregion
	}

	/// <summary>
	/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
	/// </summary>
	public class ContactDetails : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ContactDetails);
		[JsonIgnore]
		public override string S100FC_name => "Contact Details";
		public contactInstructions contactInstructions { get; set; } = new contactInstructions();

		[JsonIgnore]
		public override Attribute[] attributes => [
				contactInstructions,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(contactInstructions),
					lower = 1,
					upper = 1,
					CreateInstance = () => new contactInstructions(),
				},
				new AttributeBinding {
					attribute = nameof(contactAddress),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new contactAddress(),
				},
				new AttributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
				new AttributeBinding {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new onlineResource(),
				},
				new AttributeBinding {
					attribute = nameof(telecommunications),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new telecommunications(),
				},
				new AttributeBinding {
					attribute = nameof(sourceIndication),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new sourceIndication(),
				},
			];
		#endregion

		#region Optional Attributes
		public contactAddress?[] contactAddress_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<contactAddress>(nameof(contactAddress)); } 
	}
		public information?[] information_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<information>(nameof(information)); } 
	}
		public onlineResource?[] onlineResource_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<onlineResource>(nameof(onlineResource)); } 
	}
		public telecommunications?[] telecommunications_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<telecommunications>(nameof(telecommunications)); } 
	}
		public sourceIndication?[] sourceIndication_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<sourceIndication>(nameof(sourceIndication)); } 
	}
		#endregion
	}

	/// <summary>
	/// An indication of the type or justification of a carriage requirement.
	/// </summary>
	public class IndicationOfCarriageRequirement : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(IndicationOfCarriageRequirement);
		[JsonIgnore]
		public override string S100FC_name => "Indication of Carriage Requirement";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(domesticCarriageRequirements),
					lower = 0,
					upper = 1,
					CreateInstance = () => new domesticCarriageRequirements(),
				},
				new AttributeBinding {
					attribute = nameof(internationalCarriageRequirements),
					lower = 0,
					upper = 1,
					CreateInstance = () => new internationalCarriageRequirements(),
				},
				new AttributeBinding {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new featureName(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? domesticCarriageRequirements_optional {
			set { base.AddAttributeValue(new domesticCarriageRequirements { value = value }); }
			get { return base.GetAttributeValue<domesticCarriageRequirements>(nameof(domesticCarriageRequirements))?.value; }
		}
		public String? internationalCarriageRequirements_optional {
			set { base.AddAttributeValue(new internationalCarriageRequirements { value = value }); }
			get { return base.GetAttributeValue<internationalCarriageRequirements>(nameof(internationalCarriageRequirements))?.value; }
		}
		public featureName?[] featureName_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<featureName>(nameof(featureName)); } 
	}
		#endregion
	}

	/// <summary>
	/// Pricing information of nautical products.
	/// </summary>
	public class PriceInformation : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(PriceInformation);
		[JsonIgnore]
		public override string S100FC_name => "Price Information";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
				new AttributeBinding {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new onlineResource(),
				},
				new AttributeBinding {
					attribute = nameof(pricing),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new pricing(),
				},
				new AttributeBinding {
					attribute = nameof(sourceIndication),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new sourceIndication(),
				},
			];
		#endregion

		#region Optional Attributes
		public information?[] information_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<information>(nameof(information)); } 
	}
		public onlineResource?[] onlineResource_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<onlineResource>(nameof(onlineResource)); } 
	}
		public pricing?[] pricing_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<pricing>(nameof(pricing)); } 
	}
		public sourceIndication?[] sourceIndication_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<sourceIndication>(nameof(sourceIndication)); } 
	}
		#endregion
	}

	/// <summary>
	/// Information about the authority responsible for production.
	/// </summary>
	public class ProducerInformation : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ProducerInformation);
		[JsonIgnore]
		public override string S100FC_name => "Producer Information";
		public agencyResponsibleForProduction agencyResponsibleForProduction { get; set; } = new agencyResponsibleForProduction();

		[JsonIgnore]
		public override Attribute[] attributes => [
				agencyResponsibleForProduction,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(agencyResponsibleForProduction),
					lower = 1,
					upper = 1,
					CreateInstance = () => new agencyResponsibleForProduction(),
				},
				new AttributeBinding {
					attribute = nameof(agencyName),
					lower = 0,
					upper = 1,
					CreateInstance = () => new agencyName(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? agencyName_optional {
			set { base.AddAttributeValue(new agencyName { value = value }); }
			get { return base.GetAttributeValue<agencyName>(nameof(agencyName))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Information related to a distributor.
	/// </summary>
	public class DistributorInformation : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(DistributorInformation);
		[JsonIgnore]
		public override string S100FC_name => "Distributor Information";
		public distributorName distributorName { get; set; } = new distributorName();

		[JsonIgnore]
		public override Attribute[] attributes => [
				distributorName,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(distributorName),
					lower = 1,
					upper = 1,
					CreateInstance = () => new distributorName(),
				},
			];
		#endregion

		#region Optional Attributes
		#endregion
	}

}

namespace S100Framework.AttributeModel.S128.FeatureTypes
{
	using S100Framework.AttributeModel.S128.SimpleAttributes;
	using S100Framework.AttributeModel.S128.ComplexAttributes;

	/// <summary>
	/// An element within a catalogue of elements.
	/// </summary>
	public class CatalogueElement : S100Framework.AttributeModel.FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(CatalogueElement);
		[JsonIgnore]
		public override string S100FC_name => "Catalogue Element";
		public catalogueElementClassification catalogueElementClassification { get; set; } = new catalogueElementClassification();
		public notForNavigation notForNavigation { get; set; } = new notForNavigation();

		[JsonIgnore]
		public override Attribute[] attributes => [
				catalogueElementClassification,
				notForNavigation,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(agencyResponsibleForProduction),
					lower = 0,
					upper = 1,
					CreateInstance = () => new agencyResponsibleForProduction(),
				},
				new AttributeBinding {
					attribute = nameof(catalogueElementClassification),
					lower = 1,
					upper = 2147483647,
					CreateInstance = () => new catalogueElementClassification(),
				},
				new AttributeBinding {
					attribute = nameof(catalogueElementIdentifier),
					lower = 0,
					upper = 1,
					CreateInstance = () => new catalogueElementIdentifier(),
				},
				new AttributeBinding {
					attribute = nameof(classification),
					lower = 0,
					upper = 1,
					CreateInstance = () => new classification(),
				},
				new AttributeBinding {
					attribute = nameof(iMOMaritimeService),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new iMOMaritimeService(),
				},
				new AttributeBinding {
					attribute = nameof(notForNavigation),
					lower = 1,
					upper = 1,
					CreateInstance = () => new notForNavigation(),
				},
				new AttributeBinding {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new featureName(),
				},
				new AttributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
				new AttributeBinding {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 1,
					CreateInstance = () => new onlineResource(),
				},
				new AttributeBinding {
					attribute = nameof(sourceIndication),
					lower = 0,
					upper = 1,
					CreateInstance = () => new sourceIndication(),
				},
				new AttributeBinding {
					attribute = nameof(supportFile),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new supportFile(),
				},
				new AttributeBinding {
					attribute = nameof(timeIntervalOfProduct),
					lower = 0,
					upper = 1,
					CreateInstance = () => new timeIntervalOfProduct(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? agencyResponsibleForProduction_optional {
			set { base.AddAttributeValue(new agencyResponsibleForProduction { value = value }); }
			get { return base.GetAttributeValue<agencyResponsibleForProduction>(nameof(agencyResponsibleForProduction))?.value; }
		}
		public int?[] catalogueElementClassification_optional {
			set { base.AddAttributeValue([.. value.Select(e=> new catalogueElementClassification { value = e })]); }
			get { return base.GetAttributeValues<catalogueElementClassification>(nameof(catalogueElementClassification)).Select(e=>e.value).ToArray(); }
		}
		public String? catalogueElementIdentifier_optional {
			set { base.AddAttributeValue(new catalogueElementIdentifier { value = value }); }
			get { return base.GetAttributeValue<catalogueElementIdentifier>(nameof(catalogueElementIdentifier))?.value; }
		}
		public String? classification_optional {
			set { base.AddAttributeValue(new classification { value = value }); }
			get { return base.GetAttributeValue<classification>(nameof(classification))?.value; }
		}
		public int?[] iMOMaritimeService_optional {
			set { base.AddAttributeValue([.. value.Select(e=> new iMOMaritimeService { value = e })]); }
			get { return base.GetAttributeValues<iMOMaritimeService>(nameof(iMOMaritimeService)).Select(e=>e.value).ToArray(); }
		}
		public featureName?[] featureName_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<featureName>(nameof(featureName)); } 
	}
		public information?[] information_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<information>(nameof(information)); } 
	}
		public onlineResource? onlineResource_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<onlineResource>(nameof(onlineResource)); }
		}
		public sourceIndication? sourceIndication_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<sourceIndication>(nameof(sourceIndication)); }
		}
		public supportFile?[] supportFile_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValues<supportFile>(nameof(supportFile)); } 
	}
		public timeIntervalOfProduct? timeIntervalOfProduct_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<timeIntervalOfProduct>(nameof(timeIntervalOfProduct)); }
		}
		#endregion
	}

	/// <summary>
	/// A physical or electronic product, that is primarily intended for navigation.
	/// </summary>
	public class NavigationalProduct : CatalogueElement
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(NavigationalProduct);
		[JsonIgnore]
		public override string S100FC_name => "Navigational Product";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(approximateGridResolution),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new approximateGridResolution(),
				},
				new AttributeBinding {
					attribute = nameof(compilationScale),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new compilationScale(),
				},
				new AttributeBinding {
					attribute = nameof(distributionStatus),
					lower = 0,
					upper = 1,
					permitedValues = [1,2],
					CreateInstance = () => new distributionStatus(),
				},
				new AttributeBinding {
					attribute = nameof(editionNumber),
					lower = 0,
					upper = 1,
					CreateInstance = () => new editionNumber(),
				},
				new AttributeBinding {
					attribute = nameof(maximumDisplayScale),
					lower = 0,
					upper = 1,
					CreateInstance = () => new maximumDisplayScale(),
				},
				new AttributeBinding {
					attribute = nameof(minimumDisplayScale),
					lower = 0,
					upper = 1,
					CreateInstance = () => new minimumDisplayScale(),
				},
				new AttributeBinding {
					attribute = nameof(navigationPurpose),
					lower = 0,
					upper = 3,
					permitedValues = [1,2,3],
					CreateInstance = () => new navigationPurpose(),
				},
				new AttributeBinding {
					attribute = nameof(optimumDisplayScale),
					lower = 0,
					upper = 1,
					CreateInstance = () => new optimumDisplayScale(),
				},
				new AttributeBinding {
					attribute = nameof(originalProductNumber),
					lower = 0,
					upper = 1,
					CreateInstance = () => new originalProductNumber(),
				},
				new AttributeBinding {
					attribute = nameof(producerNation),
					lower = 0,
					upper = 1,
					CreateInstance = () => new producerNation(),
				},
				new AttributeBinding {
					attribute = nameof(productNumber),
					lower = 0,
					upper = 1,
					CreateInstance = () => new productNumber(),
				},
				new AttributeBinding {
					attribute = nameof(specificUsage),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4,5,6],
					CreateInstance = () => new specificUsage(),
				},
				new AttributeBinding {
					attribute = nameof(updateDate),
					lower = 0,
					upper = 1,
					CreateInstance = () => new updateDate(),
				},
				new AttributeBinding {
					attribute = nameof(updateNumber),
					lower = 0,
					upper = 1,
					CreateInstance = () => new updateNumber(),
				},
				new AttributeBinding {
					attribute = nameof(horizontalDatumEPSGCode),
					lower = 0,
					upper = 1,
					CreateInstance = () => new horizontalDatumEPSGCode(),
				},
				new AttributeBinding {
					attribute = nameof(verticalDatum),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45],
					CreateInstance = () => new verticalDatum(),
				},
			];
		#endregion

		#region Optional Attributes
		public double?[] approximateGridResolution_optional {
			set { base.AddAttributeValue([.. value.Select(e=> new approximateGridResolution { value = e })]); }
			get { return base.GetAttributeValues<approximateGridResolution>(nameof(approximateGridResolution)).Select(e=>e.value).ToArray(); }
		}
		public int?[] compilationScale_optional {
			set { base.AddAttributeValue([.. value.Select(e=> new compilationScale { value = e })]); }
			get { return base.GetAttributeValues<compilationScale>(nameof(compilationScale)).Select(e=>e.value).ToArray(); }
		}
		public int? distributionStatus_optional {
			set { base.AddAttributeValue(new distributionStatus { value = value }); }
			get { return base.GetAttributeValue<distributionStatus>(nameof(distributionStatus))?.value; }
		}
		public int? editionNumber_optional {
			set { base.AddAttributeValue(new editionNumber { value = value }); }
			get { return base.GetAttributeValue<editionNumber>(nameof(editionNumber))?.value; }
		}
		public int? maximumDisplayScale_optional {
			set { base.AddAttributeValue(new maximumDisplayScale { value = value }); }
			get { return base.GetAttributeValue<maximumDisplayScale>(nameof(maximumDisplayScale))?.value; }
		}
		public int? minimumDisplayScale_optional {
			set { base.AddAttributeValue(new minimumDisplayScale { value = value }); }
			get { return base.GetAttributeValue<minimumDisplayScale>(nameof(minimumDisplayScale))?.value; }
		}
		public int?[] navigationPurpose_optional {
			set { base.AddAttributeValue([.. value.Select(e=> new navigationPurpose { value = e })]); }
			get { return base.GetAttributeValues<navigationPurpose>(nameof(navigationPurpose)).Select(e=>e.value).ToArray(); }
		}
		public int? optimumDisplayScale_optional {
			set { base.AddAttributeValue(new optimumDisplayScale { value = value }); }
			get { return base.GetAttributeValue<optimumDisplayScale>(nameof(optimumDisplayScale))?.value; }
		}
		public String? originalProductNumber_optional {
			set { base.AddAttributeValue(new originalProductNumber { value = value }); }
			get { return base.GetAttributeValue<originalProductNumber>(nameof(originalProductNumber))?.value; }
		}
		public String? producerNation_optional {
			set { base.AddAttributeValue(new producerNation { value = value }); }
			get { return base.GetAttributeValue<producerNation>(nameof(producerNation))?.value; }
		}
		public String? productNumber_optional {
			set { base.AddAttributeValue(new productNumber { value = value }); }
			get { return base.GetAttributeValue<productNumber>(nameof(productNumber))?.value; }
		}
		public int? specificUsage_optional {
			set { base.AddAttributeValue(new specificUsage { value = value }); }
			get { return base.GetAttributeValue<specificUsage>(nameof(specificUsage))?.value; }
		}
		public DateOnly? updateDate_optional {
			set { base.AddAttributeValue(new updateDate { value = value }); }
			get { return base.GetAttributeValue<updateDate>(nameof(updateDate))?.value; }
		}
		public int? updateNumber_optional {
			set { base.AddAttributeValue(new updateNumber { value = value }); }
			get { return base.GetAttributeValue<updateNumber>(nameof(updateNumber))?.value; }
		}
		public int? horizontalDatumEPSGCode_optional {
			set { base.AddAttributeValue(new horizontalDatumEPSGCode { value = value }); }
			get { return base.GetAttributeValue<horizontalDatumEPSGCode>(nameof(horizontalDatumEPSGCode))?.value; }
		}
		public int? verticalDatum_optional {
			set { base.AddAttributeValue(new verticalDatum { value = value }); }
			get { return base.GetAttributeValue<verticalDatum>(nameof(verticalDatum))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Electronic navigation product.
	/// </summary>
	public class ElectronicProduct : NavigationalProduct
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ElectronicProduct);
		[JsonIgnore]
		public override string S100FC_name => "Electronic Product";
		public issueDate issueDate { get; set; } = new issueDate();
		public typeOfProductFormat typeOfProductFormat { get; set; } = new typeOfProductFormat();

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				issueDate,
				typeOfProductFormat,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(compressionFlag),
					lower = 0,
					upper = 1,
					CreateInstance = () => new compressionFlag(),
				},
				new AttributeBinding {
					attribute = nameof(datasetName),
					lower = 0,
					upper = 1,
					CreateInstance = () => new datasetName(),
				},
				new AttributeBinding {
					attribute = nameof(issueDate),
					lower = 1,
					upper = 1,
					CreateInstance = () => new issueDate(),
				},
				new AttributeBinding {
					attribute = nameof(issueTime),
					lower = 0,
					upper = 1,
					CreateInstance = () => new issueTime(),
				},
				new AttributeBinding {
					attribute = nameof(typeOfProductFormat),
					lower = 1,
					upper = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12],
					CreateInstance = () => new typeOfProductFormat(),
				},
				new AttributeBinding {
					attribute = nameof(productSpecification),
					lower = 0,
					upper = 1,
					CreateInstance = () => new productSpecification(),
				},
			];
		#endregion

		#region Optional Attributes
		public Boolean? compressionFlag_optional {
			set { base.AddAttributeValue(new compressionFlag { value = value }); }
			get { return base.GetAttributeValue<compressionFlag>(nameof(compressionFlag))?.value; }
		}
		public String? datasetName_optional {
			set { base.AddAttributeValue(new datasetName { value = value }); }
			get { return base.GetAttributeValue<datasetName>(nameof(datasetName))?.value; }
		}
		public S100Framework.DomainModel.S100.Time? issueTime_optional {
			set { base.AddAttributeValue(new issueTime { value = value }); }
			get { return base.GetAttributeValue<issueTime>(nameof(issueTime))?.value; }
		}
		public productSpecification? productSpecification_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<productSpecification>(nameof(productSpecification)); }
		}
		#endregion
	}

	/// <summary>
	/// A product printed on paper.
	/// </summary>
	public class PhysicalProduct : NavigationalProduct
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(PhysicalProduct);
		[JsonIgnore]
		public override string S100FC_name => "Physical Product";
		public editionDate editionDate { get; set; } = new editionDate();

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				editionDate,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(editionDate),
					lower = 1,
					upper = 1,
					CreateInstance = () => new editionDate(),
				},
				new AttributeBinding {
					attribute = nameof(iSBN),
					lower = 0,
					upper = 1,
					CreateInstance = () => new iSBN(),
				},
				new AttributeBinding {
					attribute = nameof(publicationNumber),
					lower = 0,
					upper = 1,
					CreateInstance = () => new publicationNumber(),
				},
				new AttributeBinding {
					attribute = nameof(typeOfPhysicalProduct),
					lower = 0,
					upper = 1,
					CreateInstance = () => new typeOfPhysicalProduct(),
				},
				new AttributeBinding {
					attribute = nameof(printInformation),
					lower = 0,
					upper = 1,
					CreateInstance = () => new printInformation(),
				},
				new AttributeBinding {
					attribute = nameof(referenceToNM),
					lower = 0,
					upper = 1,
					CreateInstance = () => new referenceToNM(),
				},
			];
		#endregion

		#region Optional Attributes
		public String? iSBN_optional {
			set { base.AddAttributeValue(new iSBN { value = value }); }
			get { return base.GetAttributeValue<iSBN>(nameof(iSBN))?.value; }
		}
		public String? publicationNumber_optional {
			set { base.AddAttributeValue(new publicationNumber { value = value }); }
			get { return base.GetAttributeValue<publicationNumber>(nameof(publicationNumber))?.value; }
		}
		public String? typeOfPhysicalProduct_optional {
			set { base.AddAttributeValue(new typeOfPhysicalProduct { value = value }); }
			get { return base.GetAttributeValue<typeOfPhysicalProduct>(nameof(typeOfPhysicalProduct))?.value; }
		}
		public printInformation? printInformation_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<printInformation>(nameof(printInformation)); }
		}
		public referenceToNM? referenceToNM_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<referenceToNM>(nameof(referenceToNM)); }
		}
		#endregion
	}

	/// <summary>
	/// A service that makes use of S-100 based product specifications to support data transfer.
	/// </summary>
	public class S100Service : CatalogueElement
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(S100Service);
		[JsonIgnore]
		public override string S100FC_name => "S100 Service";
		public typeOfProductFormat typeOfProductFormat { get; set; } = new typeOfProductFormat();

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				typeOfProductFormat,
				.. base.attributesOptional,
			];

		#region Attribute Bindingss
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(compressionFlag),
					lower = 0,
					upper = 1,
					CreateInstance = () => new compressionFlag(),
				},
				new AttributeBinding {
					attribute = nameof(serviceName),
					lower = 0,
					upper = 1,
					CreateInstance = () => new serviceName(),
				},
				new AttributeBinding {
					attribute = nameof(serviceStatus),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new serviceStatus(),
				},
				new AttributeBinding {
					attribute = nameof(typeOfProductFormat),
					lower = 1,
					upper = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12],
					CreateInstance = () => new typeOfProductFormat(),
				},
				new AttributeBinding {
					attribute = nameof(serviceSpecification),
					lower = 0,
					upper = 1,
					CreateInstance = () => new serviceSpecification(),
				},
				new AttributeBinding {
					attribute = nameof(productSpecification),
					lower = 0,
					upper = 1,
					CreateInstance = () => new productSpecification(),
				},
			];
		#endregion

		#region Optional Attributes
		public Boolean? compressionFlag_optional {
			set { base.AddAttributeValue(new compressionFlag { value = value }); }
			get { return base.GetAttributeValue<compressionFlag>(nameof(compressionFlag))?.value; }
		}
		public String? serviceName_optional {
			set { base.AddAttributeValue(new serviceName { value = value }); }
			get { return base.GetAttributeValue<serviceName>(nameof(serviceName))?.value; }
		}
		public int? serviceStatus_optional {
			set { base.AddAttributeValue(new serviceStatus { value = value }); }
			get { return base.GetAttributeValue<serviceStatus>(nameof(serviceStatus))?.value; }
		}
		public serviceSpecification? serviceSpecification_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<serviceSpecification>(nameof(serviceSpecification)); }
		}
		public productSpecification? productSpecification_optional {
			set { base.AddAttributeValue(value); }
			get { return base.GetAttributeValue<productSpecification>(nameof(productSpecification)); }
		}
		#endregion
	}

}

namespace S100Framework.AttributeModel.S128
{
	using System.Text.Json;
	using S100Framework.AttributeModel.S128.SimpleAttributes;
	using S100Framework.AttributeModel.S128.ComplexAttributes;
	using S100Framework.AttributeModel.S128.FeatureTypes;

	public class Summary : ISummary
	{
		public static string Name => "S-128 Catalogue of Nautical Products";
		public static string Scope => "Catalogue of Nautical Products";
		public static string ProductId => "S-128";
		public static Version Version => new Version("2.0.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2025-04-30", "yyyy-MM-dd");
	}

	public static class Extensions {
		public static JsonSerializerOptions AppendTypeInfoResolver(this JsonSerializerOptions jsonSerializerOptions) {
			var resolver = new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver();
			resolver.Modifiers.Add(typeInfo => {
				if (typeInfo.Type == typeof(S100Framework.AttributeModel.Attribute)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "code",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(administrativeDivision), typeDiscriminator: "administrativeDivision"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(agencyName), typeDiscriminator: "agencyName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(agencyResponsibleForProduction), typeDiscriminator: "agencyResponsibleForProduction"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(applicationProfile), typeDiscriminator: "applicationProfile"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(approximateGridResolution), typeDiscriminator: "approximateGridResolution"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(catalogueElementClassification), typeDiscriminator: "catalogueElementClassification"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(catalogueElementIdentifier), typeDiscriminator: "catalogueElementIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(catalogueSectionNumber), typeDiscriminator: "catalogueSectionNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(catalogueSectionTitle), typeDiscriminator: "catalogueSectionTitle"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfAuthority), typeDiscriminator: "categoryOfAuthority"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(characterEncoding), typeDiscriminator: "characterEncoding"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(cityName), typeDiscriminator: "cityName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(classification), typeDiscriminator: "classification"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(comment), typeDiscriminator: "comment"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(compilationScale), typeDiscriminator: "compilationScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(compressionFlag), typeDiscriminator: "compressionFlag"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(contactInstructions), typeDiscriminator: "contactInstructions"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(contractPeriod), typeDiscriminator: "contractPeriod"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(countryName), typeDiscriminator: "countryName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(currency), typeDiscriminator: "currency"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(datasetName), typeDiscriminator: "datasetName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateEnd), typeDiscriminator: "dateEnd"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateStart), typeDiscriminator: "dateStart"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(deliveryPoint), typeDiscriminator: "deliveryPoint"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(digitalSignatureValue), typeDiscriminator: "digitalSignatureValue"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nameUsage), typeDiscriminator: "nameUsage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(distributionStatus), typeDiscriminator: "distributionStatus"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(distributorName), typeDiscriminator: "distributorName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(domesticCarriageRequirements), typeDiscriminator: "domesticCarriageRequirements"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(editionDate), typeDiscriminator: "editionDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(editionNumber), typeDiscriminator: "editionNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(expirationDate), typeDiscriminator: "expirationDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileLocator), typeDiscriminator: "fileLocator"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileName), typeDiscriminator: "fileName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileReference), typeDiscriminator: "fileReference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(headline), typeDiscriminator: "headline"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(iMOMaritimeService), typeDiscriminator: "iMOMaritimeService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(internationalCarriageRequirements), typeDiscriminator: "internationalCarriageRequirements"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(iSBN), typeDiscriminator: "iSBN"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(iSO216), typeDiscriminator: "iSO216"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(iSSN), typeDiscriminator: "iSSN"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(issueDate), typeDiscriminator: "issueDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(issueTime), typeDiscriminator: "issueTime"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(language), typeDiscriminator: "language"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(linkage), typeDiscriminator: "linkage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfProductMapping), typeDiscriminator: "categoryOfProductMapping"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(maximumDisplayScale), typeDiscriminator: "maximumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(minimumDisplayScale), typeDiscriminator: "minimumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(name), typeDiscriminator: "name"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nameOfResource), typeDiscriminator: "nameOfResource"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(notForNavigation), typeDiscriminator: "notForNavigation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(onlineDescription), typeDiscriminator: "onlineDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(optimumDisplayScale), typeDiscriminator: "optimumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(originalProductNumber), typeDiscriminator: "originalProductNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(otherDataTypeDescription), typeDiscriminator: "otherDataTypeDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(postalCode), typeDiscriminator: "postalCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(price), typeDiscriminator: "price"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(printAgency), typeDiscriminator: "printAgency"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(printNation), typeDiscriminator: "printNation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(producerNation), typeDiscriminator: "producerNation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(productNumber), typeDiscriminator: "productNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(productReference), typeDiscriminator: "productReference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(protocol), typeDiscriminator: "protocol"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(protocolRequest), typeDiscriminator: "protocolRequest"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(publicationNumber), typeDiscriminator: "publicationNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(reprintEdition), typeDiscriminator: "reprintEdition"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(reprintNation), typeDiscriminator: "reprintNation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(reportedDate), typeDiscriminator: "reportedDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(digitalSignatureReference), typeDiscriminator: "digitalSignatureReference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(navigationPurpose), typeDiscriminator: "navigationPurpose"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(supportFileFormat), typeDiscriminator: "supportFileFormat"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(supportFilePurpose), typeDiscriminator: "supportFilePurpose"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(serviceName), typeDiscriminator: "serviceName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(serviceStatus), typeDiscriminator: "serviceStatus"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(source), typeDiscriminator: "source"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sourceDate), typeDiscriminator: "sourceDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sourceType), typeDiscriminator: "sourceType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(specificUsage), typeDiscriminator: "specificUsage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunicationIdentifier), typeDiscriminator: "telecommunicationIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunicationService), typeDiscriminator: "telecommunicationService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(text), typeDiscriminator: "text"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(typeOfPhysicalProduct), typeDiscriminator: "typeOfPhysicalProduct"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(typeOfProductFormat), typeDiscriminator: "typeOfProductFormat"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(typeOfTimeIntervalUnit), typeDiscriminator: "typeOfTimeIntervalUnit"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(updateDate), typeDiscriminator: "updateDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(updateNumber), typeDiscriminator: "updateNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(valueOfTime), typeDiscriminator: "valueOfTime"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(version), typeDiscriminator: "version"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(paperWidth), typeDiscriminator: "paperWidth"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(paperLength), typeDiscriminator: "paperLength"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(publicationDate), typeDiscriminator: "publicationDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(weekNumber), typeDiscriminator: "weekNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(yearNumber), typeDiscriminator: "yearNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(horizontalDatumEPSGCode), typeDiscriminator: "horizontalDatumEPSGCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(verticalDatum), typeDiscriminator: "verticalDatum"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(contactAddress), typeDiscriminator: "contactAddress"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(customPaperSize), typeDiscriminator: "customPaperSize"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(defaultLocale), typeDiscriminator: "defaultLocale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureName), typeDiscriminator: "featureName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(information), typeDiscriminator: "information"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(onlineResource), typeDiscriminator: "onlineResource"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(periodicDateRange), typeDiscriminator: "periodicDateRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pricing), typeDiscriminator: "pricing"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(printSize), typeDiscriminator: "printSize"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(productSpecification), typeDiscriminator: "productSpecification"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(supportFileSpecification), typeDiscriminator: "supportFileSpecification"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(serviceSpecification), typeDiscriminator: "serviceSpecification"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sourceIndication), typeDiscriminator: "sourceIndication"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunications), typeDiscriminator: "telecommunications"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeIntervalOfCycle), typeDiscriminator: "timeIntervalOfCycle"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(weekOfYear), typeDiscriminator: "weekOfYear"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(issuanceCycle), typeDiscriminator: "issuanceCycle"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(printInformation), typeDiscriminator: "printInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(supportFile), typeDiscriminator: "supportFile"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeIntervalOfProduct), typeDiscriminator: "timeIntervalOfProduct"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(referenceToNM), typeDiscriminator: "referenceToNM"));
				}
			});
			jsonSerializerOptions.TypeInfoResolver = resolver;
			return jsonSerializerOptions;
		}
	}
}
