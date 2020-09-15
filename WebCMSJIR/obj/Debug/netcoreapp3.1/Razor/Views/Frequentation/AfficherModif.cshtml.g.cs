#pragma checksum "D:\CMS\WebCMSJIR\WebCMSJIR\Views\Frequentation\AfficherModif.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ecda5f421c684fd0f81c7341ba1121f2624c020"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Frequentation_AfficherModif), @"mvc.1.0.view", @"/Views/Frequentation/AfficherModif.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\CMS\WebCMSJIR\WebCMSJIR\Views\_ViewImports.cshtml"
using WebCMSJIR;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\CMS\WebCMSJIR\WebCMSJIR\Views\_ViewImports.cshtml"
using WebCMSJIR.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\CMS\WebCMSJIR\WebCMSJIR\Views\Frequentation\AfficherModif.cshtml"
using WebCMSJIR.Views.Frequentation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\CMS\WebCMSJIR\WebCMSJIR\Views\Frequentation\AfficherModif.cshtml"
using Oracle.ManagedDataAccess.Client;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ecda5f421c684fd0f81c7341ba1121f2624c020", @"/Views/Frequentation/AfficherModif.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff12f2f1c28b66ce037e3e0bcf76c921bdbbd6b8", @"/Views/_ViewImports.cshtml")]
    public class Views_Frequentation_AfficherModif : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\CMS\WebCMSJIR\WebCMSJIR\Views\Frequentation\AfficherModif.cshtml"
  
    var matricule = ViewBag.Message;
    var medecin = ViewBag.Medecin;
    var typePat = ViewBag.Type;

    FonctionFreq fFreq = new FonctionFreq();
    OracleDataReader drU = fFreq.displayUpdateA(matricule, typePat, medecin);
    drU.Read();


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""row"">
        <div class=""col-md-3"">
            <div class=""form-group"">
                <label for=""field-1"" class=""control-label"">A. Matricule</label>
                <input type=""text"" name=""Amat"" class=""form-control"" id=""field-1""");
            BeginWriteAttribute("value", " value=\"", 595, "\"", 625, 1);
#nullable restore
#line 18 "D:\CMS\WebCMSJIR\WebCMSJIR\Views\Frequentation\AfficherModif.cshtml"
WriteAttributeValue("", 603, drU.GetOracleValue(4), 603, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
            </div>
        </div>
        <div class=""col-md-3"">
            <div class=""form-group"">
                <label for=""field-1"" class=""control-label"">N. Matricule</label>
                <input type=""text"" name=""Nmat"" class=""form-control"" id=""field-1""");
            BeginWriteAttribute("value", " value=\"", 898, "\"", 928, 1);
#nullable restore
#line 24 "D:\CMS\WebCMSJIR\WebCMSJIR\Views\Frequentation\AfficherModif.cshtml"
WriteAttributeValue("", 906, drU.GetOracleValue(3), 906, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
            </div>
        </div>

    </div>
    <div class=""row"">
        <div class=""col-md-6"">
            <div class=""form-group"">
                <label for=""field-3"" class=""control-label"">Nom</label>
                <input type=""text"" name=""nomP"" class=""form-control"" id=""field-3""");
            BeginWriteAttribute("value", " value=\"", 1229, "\"", 1259, 1);
#nullable restore
#line 33 "D:\CMS\WebCMSJIR\WebCMSJIR\Views\Frequentation\AfficherModif.cshtml"
WriteAttributeValue("", 1237, drU.GetOracleValue(2), 1237, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
            </div>
        </div>
        <div class=""col-md-4"">
            <div class=""form-group"">
                <label for=""field-3"" class=""control-label"">Type Patient</label>
                <input type=""text"" name=""typeP"" class=""form-control"" id=""field-3""");
            BeginWriteAttribute("value", "value=\"", 1531, "\"", 1560, 1);
#nullable restore
#line 39 "D:\CMS\WebCMSJIR\WebCMSJIR\Views\Frequentation\AfficherModif.cshtml"
WriteAttributeValue("", 1538, drU.GetOracleValue(5), 1538, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-8"">
            <div class=""form-group"" id=""modifMed"">
                <label for=""field-4"" class=""control-label"">Medecin</label>
                <input class=""form-control"" name=""medP"" type=""text""");
            BeginWriteAttribute("value", " value=\"", 1862, "\"", 1892, 1);
#nullable restore
#line 47 "D:\CMS\WebCMSJIR\WebCMSJIR\Views\Frequentation\AfficherModif.cshtml"
WriteAttributeValue("", 1870, drU.GetOracleValue(0), 1870, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                <i class=""fa fa-remove"" onclick=""ModifMed()""></i>
            </div>
        </div>
    
    </div>
    <div class=""row"">
        <div class=""col-md-3"">
            <div class=""form-group no-margin"">
                <label for=""field-7"" class=""control-label"">Numero</label>
                <input type=""text"" name=""numP"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 2264, "\"", 2294, 1);
#nullable restore
#line 57 "D:\CMS\WebCMSJIR\WebCMSJIR\Views\Frequentation\AfficherModif.cshtml"
WriteAttributeValue("", 2272, drU.GetOracleValue(1), 2272, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly/>                             \r\n            </div>\r\n        </div>\r\n    </div>\r\n                                                   \r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591