#pragma checksum "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d32a60981deaa0b361c288550f7aa713c9dd3594"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vehicle_Details), @"mvc.1.0.view", @"/Views/Vehicle/Details.cshtml")]
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
#line 1 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\_ViewImports.cshtml"
using CarTradeCenter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\_ViewImports.cshtml"
using CarTradeCenter.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d32a60981deaa0b361c288550f7aa713c9dd3594", @"/Views/Vehicle/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97a37713f15942f3ab9417c390ccb34df53da26f", @"/Views/_ViewImports.cshtml")]
    public class Views_Vehicle_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarTradeCenter.Data.Models.Vehicle>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
            WriteLiteral("<div>\r\n    <center><h5>");
#nullable restore
#line 11 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
           Write(Model.CompanyProvider);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5></center>\r\n\r\n\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            Link do aukcji\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 399, "\"", 442, 1);
#nullable restore
#line 20 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
WriteAttributeValue("", 406, Html.DisplayFor(model => model.Url), 406, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Link</a>\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Koniec Aukcji (");
#nullable restore
#line 23 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
                      Write(Html.DisplayNameFor(model => model.DateAuctionEnd));

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 26 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateAuctionEnd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Początek Aukcji (");
#nullable restore
#line 29 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
                        Write(Html.DisplayNameFor(model => model.DateAuctionStart));

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 32 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateAuctionStart));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Numer Auckji (");
#nullable restore
#line 35 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
                     Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 38 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Stan\r\n        </dt>\r\n");
#nullable restore
#line 43 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
         if (Model.IsDamaged)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-10\">\r\n                Uszkodzony\r\n            </dd>\r\n");
#nullable restore
#line 48 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-10\">\r\n                Nieuszkodzony\r\n            </dd>\r\n");
#nullable restore
#line 54 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dl>\r\n    <hr />\r\n</div>\r\n\r\n<div>\r\n");
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    Zdjęcia\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 70 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
             foreach (var img in Model.Images)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 1862, "\"", 1876, 1);
#nullable restore
#line 74 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
WriteAttributeValue("", 1868, img.Url, 1868, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-thumbnail\" style=\"width: 100%\">\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 77 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n<div>\r\n");
            WriteLiteral("    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            Wyposarzenie Standardowe (");
#nullable restore
#line 87 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
                                 Write(Html.DisplayNameFor(model => model.InfoBasic));

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 90 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
       Write(Html.DisplayFor(model => model.InfoBasic));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <hr />\r\n        </dd>\r\n        \r\n        <dt class=\"col-sm-2\">\r\n            Wyposarzenie Opcjonalne (");
#nullable restore
#line 95 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
                                Write(Html.DisplayNameFor(model => model.InfoExtra));

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 98 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
       Write(Html.DisplayFor(model => model.InfoExtra));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <hr />\r\n        </dd>\r\n");
#nullable restore
#line 101 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
         if (Model.IsDamaged)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt class=\"col-sm-2\">\r\n                Uszkodzenia (");
#nullable restore
#line 104 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
                        Write(Html.DisplayNameFor(model => model.InfoDamage));

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 107 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
           Write(Html.DisplayFor(model => model.InfoDamage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <hr />\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                Części nieuszkodzone (");
#nullable restore
#line 111 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
                                 Write(Html.DisplayNameFor(model => model.InfoUsableParts));

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 114 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
           Write(Html.DisplayFor(model => model.InfoUsableParts));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <hr />\r\n            </dd>\r\n");
#nullable restore
#line 117 "C:\Users\ZZ01M5820\Box Sync\.Net Projects\repos\CarTradeCenter\Views\Vehicle\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dl>\r\n    <hr />\r\n</div>\r\n\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d32a60981deaa0b361c288550f7aa713c9dd359412942", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarTradeCenter.Data.Models.Vehicle> Html { get; private set; }
    }
}
#pragma warning restore 1591
