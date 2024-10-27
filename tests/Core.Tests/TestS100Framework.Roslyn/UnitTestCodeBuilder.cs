#define prop
//#define propfull

using S100Framework.DomainModel;

using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using Xunit.Abstractions;


namespace TestS100Framework
{
    public static class Information
    {
        public static Version Version => new Version("");
    }

    namespace Test
    {
        public class NullableTest
        {
            public int? Value { get; set; }
        }
    }
}

//namespace TestS100Framework.Bindings
//{
//    using S100Framework.DomainModel.S131;
//    using S100Framework.DomainModel.S131.Bindings.InformationAssociations;
//    using S100Framework.DomainModel.S131.Bindings.Roles;
//    using S100Framework.DomainModel.S131.ComplexAttributes;
//    using S100Framework.DomainModel.S131.InformationTypes;

     
//    public class AbstractRxNInformationAssociations {
//        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
//        public List<InclusionType<isApplicableTo>> isApplicableTo { get; set; } = [];

//        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
//        public List<RelatedOrganisation<theOrganisation>> theOrganisation { get; set; } = [];
//    }

//    public abstract class AbstractRxN : InformationType
//    {
//        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
//        public categoryOfAuthority? categoryOfAuthority { get; set; } = default;

//        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
//        public List<rxNCode> rxNCode { get; set; } = [];

//        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
//        public List<textContent> textContent { get; set; } = [];

//        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
//        public List<InclusionType<isApplicableTo>> isApplicableTo { get; set; } = [];

//        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
//        public List<RelatedOrganisation<theOrganisation>> theOrganisation { get; set; } = [];

//        public AbstractRxNInformationAssociations InformationAssociations { get; set; } = new();

//        public AbstractRxN() {
//        }
//    }
//}

namespace TestS100Framework
{
    public class UnitTestCodeBuilder
    {
        private readonly ITestOutputHelper _output;

        public UnitTestCodeBuilder(ITestOutputHelper output) {
            this._output = output;
        }

        [Fact]
        public void Test_CreateClass() {
            var type1 = typeof(Test.NullableTest);
            var type2 = typeof(bool?);

            var s100 = XDocument.Load(@"..\..\..\..\..\..\artifacts\S-101 Electronic Navigational Chart (ENC)\S-101_FC_1.2.3.xml");

            var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

            File.WriteAllText(@"c:\temp\content.cs", content.fc, Encoding.UTF8);
        }

        [Fact]
        public void Test_Bindings() { 
        }

        [Fact]
        public void Build_KnownFeatureCataloguesLocal() {
            Build_S101();

            Build_S122();

            Build_S124();

            Build_S128();

            Build_S131();

            //Build_S201();
        }

        [Fact]
        public void Build_KnownFeatureCatalogues() {
            Build_S101();
            File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-101_FC.g.cs", File.ReadAllText(@".\..\..\..\S-101_FC.cs"));
            File.WriteAllText(@"..\..\..\..\..\..\src\UI\S100Framework.WPF\S-101_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\S-101_ViewModel.cs"));

            Build_S122();
            File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-122_FC.g.cs", File.ReadAllText(@".\..\..\..\S-122_FC.cs"));
            File.WriteAllText(@"..\..\..\..\..\..\src\UI\S100Framework.WPF\S-122_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\S-122_ViewModel.cs"));

            Build_S124();
            File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-124_FC.g.cs", File.ReadAllText(@".\..\..\..\S-124_FC.cs"));
            File.WriteAllText(@"..\..\..\..\..\..\src\UI\S100Framework.WPF\S-124_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\S-124_ViewModel.cs"));

            Build_S128();
            File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-128_FC.g.cs", File.ReadAllText(@".\..\..\..\S-128_FC.cs"));
            File.WriteAllText(@"..\..\..\..\..\..\src\UI\S100Framework.WPF\S-128_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\S-128_ViewModel.cs"));

            Build_S131();
            File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-131_FC.g.cs", File.ReadAllText(@".\..\..\..\S-131_FC.cs"));
            File.WriteAllText(@"..\..\..\..\..\..\src\UI\S100Framework.WPF\S-131_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\S-131_ViewModel.cs"));

            //Build_S201();
            //File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-201_FC.g.cs", File.ReadAllText(@".\..\..\..\S-201_FC.cs"));
            //File.WriteAllText(@"..\..\..\..\..\..\src\UI\S100Framework.WPF\S-201_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\S-201_ViewModel.cs"));

            File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\DomainModelBase.cs", File.ReadAllText(@".\..\..\..\DomainModelBase.cs"));
        }

        [Fact]
        public void Build_S101() {
            var type1 = typeof(Test.NullableTest);
            var type2 = typeof(bool?);

            var s100 = XDocument.Load(@".\Artifacts\S-101_FC_1.5.0.xml");

            var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

            File.WriteAllText(@".\..\..\..\S-101_FC.cs", content.fc, Encoding.UTF8);
            File.WriteAllText(@".\..\..\..\S-101_ViewModel.cs", content.view, Encoding.UTF8);

            File.WriteAllText(@".\..\..\..\DomainModelBase.cs", content.common, Encoding.UTF8);
        }

        [Fact]
        public void Build_S122() {

            var s100 = XDocument.Load(@".\Artifacts\jpS-122_FC_1.2.1.xml");

            var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

            File.WriteAllText(@".\..\..\..\S-122_FC.cs", content.fc, Encoding.UTF8);
            File.WriteAllText(@".\..\..\..\S-122_ViewModel.cs", content.view, Encoding.UTF8);

            File.WriteAllText(@".\..\..\..\DomainModelBase.cs", content.common, Encoding.UTF8);
        }

        [Fact]
        public void Build_S124() {
            var type1 = typeof(Test.NullableTest);
            var type2 = typeof(bool?);

            var v = RuntimeHelpers.GetUninitializedObject(typeof(DateTime));

            var s100 = XDocument.Load(@".\Artifacts\S-124FC_1.5_20240330.xml");

            var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

            File.WriteAllText(@".\..\..\..\S-124_FC.cs", content.fc, Encoding.UTF8);
            File.WriteAllText(@".\..\..\..\S-124_ViewModel.cs", content.view, Encoding.UTF8);

            File.WriteAllText(@".\..\..\..\DomainModelBase.cs", content.common, Encoding.UTF8);
        }

        [Fact]
        public void Build_S128() {
            var type1 = typeof(Test.NullableTest);
            var type2 = typeof(bool?);

            var s100 = XDocument.Load(@".\Artifacts\S-128_FC_Ed2.0.0.xml");

            var content = S100Framework.ClassBuilder.CatalogueBuilder(s100, "http://www.iho.int/S128/2.0");

            File.WriteAllText(@".\..\..\..\S-128_FC.cs", content.fc, Encoding.UTF8);
            File.WriteAllText(@".\..\..\..\S-128_ViewModel.cs", content.view, Encoding.UTF8);

            File.WriteAllText(@".\..\..\..\DomainModelBase.cs", content.common, Encoding.UTF8);
        }

        [Fact]
        public void Build_S131() {
            var s100 = XDocument.Load(@".\Artifacts\131_1_0_0_20230315_FC.xml");

            var content = S100Framework.ClassBuilder.CatalogueBuilder(s100, "http://www.iho.int/S131/1.0");

            File.WriteAllText(@".\..\..\..\S-131_FC.cs", content.fc, Encoding.UTF8);
            File.WriteAllText(@".\..\..\..\S-131_ViewModel.cs", content.view, Encoding.UTF8);

            File.WriteAllText(@".\..\..\..\DomainModelBase.cs", content.common, Encoding.UTF8);
        }

        [Fact]
        public void Build_S201() {
            var s100 = XDocument.Load(@".\Artifacts\8. S-201 Ed 1.1.0_Annex D2_Feature Catalogue.xml");

            var content = S100Framework.ClassBuilder.CatalogueBuilder(s100, "http://www.iho.int/S201/1.0");

            File.WriteAllText(@".\..\..\..\S-201_FC.cs", content.fc, Encoding.UTF8);
            File.WriteAllText(@".\..\..\..\S-201_ViewModel.cs", content.view, Encoding.UTF8);

            File.WriteAllText(@".\..\..\..\DomainModelBase.cs", content.common, Encoding.UTF8);
        }
    }
}


/*
    public enum S100_FC_RoleType {
        [System.Xml.Serialization.XmlEnum("association")]
        association,

        [System.Xml.Serialization.XmlEnum("aggregation")]
        aggregation,

        [System.Xml.Serialization.XmlEnum("composition")]
        composition
    }

    public class informationBinding {
        public S100_FC_RoleType roleType { get; set; }

    }
*/