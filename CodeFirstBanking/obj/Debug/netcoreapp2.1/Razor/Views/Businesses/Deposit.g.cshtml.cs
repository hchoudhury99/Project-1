#pragma checksum "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Deposit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59b4ba4ef9a95738aa1cd44d316e21247c4c1768"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Businesses_Deposit), @"mvc.1.0.view", @"/Views/Businesses/Deposit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Businesses/Deposit.cshtml", typeof(AspNetCore.Views_Businesses_Deposit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59b4ba4ef9a95738aa1cd44d316e21247c4c1768", @"/Views/Businesses/Deposit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb43ca6fe8834b20346ca5adf1c003e6986866ec", @"/Views/_ViewImports.cshtml")]
    public class Views_Businesses_Deposit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CodeFirstBanking.Models.Business>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Deposit.cshtml"
  
    ViewData["Title"] = "Deposit";

#line default
#line hidden
            BeginContext(86, 22, true);
            WriteLiteral("\r\n<h2>Deposit</h2>\r\n\r\n");
            EndContext();
#line 9 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Deposit.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(143, 23, false);
#line 11 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Deposit.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(170, 140, true);
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <hr />\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(311, 56, false);
#line 18 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Deposit.cshtml"
           Write(Html.LabelFor(model => model.BusinessId, "Business Id:"));

#line default
#line hidden
            EndContext();
            BeginContext(367, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(386, 41, false);
#line 19 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Deposit.cshtml"
           Write(Html.EditorFor(Model => Model.BusinessId));

#line default
#line hidden
            EndContext();
            BeginContext(427, 129, true);
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(557, 63, false);
#line 26 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Deposit.cshtml"
           Write(Html.LabelFor(Model => Model.AccountBalance, "Deposit Amount:"));

#line default
#line hidden
            EndContext();
            BeginContext(620, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(639, 45, false);
#line 27 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Deposit.cshtml"
           Write(Html.EditorFor(Model => Model.AccountBalance));

#line default
#line hidden
            EndContext();
            BeginContext(684, 200, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <input type=\"submit\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 37 "C:\Users\hamma\source\repos\CodeFirstBanking\CodeFirstBanking\Views\Businesses\Deposit.cshtml"
}

#line default
#line hidden
            BeginContext(887, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
