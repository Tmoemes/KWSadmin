#pragma checksum "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff467692896ea28bc5369d65ad7dc683a19f8a90"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Data_OrderView), @"mvc.1.0.view", @"/Views/Data/OrderView.cshtml")]
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
#line 1 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\_ViewImports.cshtml"
using AspView;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\_ViewImports.cshtml"
using AspView.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff467692896ea28bc5369d65ad7dc683a19f8a90", @"/Views/Data/OrderView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8200eefa344782677945bd46d1abcb4a3746170c", @"/Views/_ViewImports.cshtml")]
    public class Views_Data_OrderView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KWSAdmin.Application.Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div>\r\n    <h4>Order</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 8 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 11 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Info));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Info));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Creator.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Creator.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <h5>Client</h5>\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 35 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Client.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 38 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Client.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 41 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Client.FName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 44 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Client.FName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 47 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Client.LName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 50 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Client.LName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 53 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Client.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 56 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Client.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 59 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Client.EMail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 62 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Client.EMail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 65 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Client.Adres));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 68 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Client.Adres));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <h5>Accu</h5>\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 74 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Accu.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 77 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Accu.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 80 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Accu.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 83 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Accu.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 86 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Accu.Specs));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 89 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Accu.Specs));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 92 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayNameFor(model => model.Accu.Creator.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 95 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
       Write(Html.DisplayFor(model => model.Accu.Creator.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 101 "C:\Users\meesv\source\repos\Tmoemes\KWSadmin\AspView\Views\Data\OrderView.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff467692896ea28bc5369d65ad7dc683a19f8a9013250", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KWSAdmin.Application.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
