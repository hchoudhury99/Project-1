#pragma checksum "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Transfer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d8cb27c5621b5c8ef0bf61027e3e679a77314cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Businesses_Transfer), @"mvc.1.0.view", @"/Views/Businesses/Transfer.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Businesses/Transfer.cshtml", typeof(AspNetCore.Views_Businesses_Transfer))]
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
#line 1 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\_ViewImports.cshtml"
using CodeFirstBanking;

#line default
#line hidden
#line 2 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\_ViewImports.cshtml"
using CodeFirstBanking.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d8cb27c5621b5c8ef0bf61027e3e679a77314cf", @"/Views/Businesses/Transfer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb43ca6fe8834b20346ca5adf1c003e6986866ec", @"/Views/_ViewImports.cshtml")]
    public class Views_Businesses_Transfer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CodeFirstBanking.Models.Business>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Transfer.cshtml"
  
    ViewData["Title"] = "Transfer";

#line default
#line hidden
            BeginContext(87, 23, true);
            WriteLiteral("\r\n<h2>Transfer</h2>\r\n\r\n");
            EndContext();
#line 9 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Transfer.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(145, 23, false);
#line 11 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Transfer.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(172, 140, true);
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <hr />\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(313, 56, false);
#line 18 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Transfer.cshtml"
           Write(Html.LabelFor(model => model.BusinessId, "Business Id:"));

#line default
#line hidden
            EndContext();
            BeginContext(369, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(388, 41, false);
#line 19 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Transfer.cshtml"
           Write(Html.EditorFor(Model => Model.BusinessId));

#line default
#line hidden
            EndContext();
            BeginContext(429, 129, true);
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(559, 56, false);
#line 26 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Transfer.cshtml"
           Write(Html.LabelFor(model => model.checkingId, "Checking Id:"));

#line default
#line hidden
            EndContext();
            BeginContext(615, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(634, 41, false);
#line 27 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Transfer.cshtml"
           Write(Html.EditorFor(Model => Model.checkingId));

#line default
#line hidden
            EndContext();
            BeginContext(675, 129, true);
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(805, 64, false);
#line 34 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Transfer.cshtml"
           Write(Html.LabelFor(Model => Model.AccountBalance, "Transfer Amount:"));

#line default
#line hidden
            EndContext();
            BeginContext(869, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(888, 111, false);
#line 35 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Transfer.cshtml"
           Write(Html.EditorFor(Model => Model.AccountBalance, new { htmlAttributes = new { @class = "form-group", @min="0" } }));

#line default
#line hidden
            EndContext();
            BeginContext(999, 200, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <input type=\"submit\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 45 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Transfer.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CodeFirstBanking.Models.Business> Html { get; private set; }
    }
}
#pragma warning restore 1591
