#pragma checksum "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Owner\MonthSales.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9c41510a611a73ee8690a84969e22e8d006940a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Owner_MonthSales), @"mvc.1.0.view", @"/Views/Owner/MonthSales.cshtml")]
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
#line 1 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\_ViewImports.cshtml"
using Pryanichek_version_1000;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\_ViewImports.cshtml"
using Pryanichek_version_1000.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9c41510a611a73ee8690a84969e22e8d006940a", @"/Views/Owner/MonthSales.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40756e5d2c077713db41ccd668cb5ef57b1800e5", @"/Views/_ViewImports.cshtml")]
    public class Views_Owner_MonthSales : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pryanichek_version_1000.Models.MonthSale>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Owner\MonthSales.cshtml"
  
    ViewData["Title"] = "Страничка владельца";
    Layout = "~/Views/Shared/_New_Layout2.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9c41510a611a73ee8690a84969e22e8d006940a3715", async() => {
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9c41510a611a73ee8690a84969e22e8d006940a4681", async() => {
                WriteLiteral(@"
    <div>
    </div>
    <aside>
        <div class=""widget"">
            <h3 class=""widget-title"">Быстрый поиск</h3>
            <ul class=""widget-list"">
                <li><a href=""/Owner/Prodazi"">Сумма продаж во всех пекарнях</a></li>
                <li><a href=""/Owner/Information"">Информация о пекарне</a></li>
            </ul>
        </div>
    </aside>
    <section>
        <div style=""background-color:white"">
            <table>
                <tr>
                    <td colspan=""5"" style=""font-weight:bold; color:crimson; text-align:center; font-size:16px"">Сумма продаж за текущий месяц</td>
                </tr>
                <tr>
                    <td>Номер пекарни</td>
                    <td>Название пекарни</td>
                    <td>Месяц</td>
                    <td>Год</td>
                    <td>Сумма продаж</td>
                </tr>

");
#nullable restore
#line 39 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Owner\MonthSales.cshtml"
                 foreach (var i in TempData["MonthSales"] as List<MonthSale>)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 42 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Owner\MonthSales.cshtml"
                   Write(i.BakeryNo);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 43 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Owner\MonthSales.cshtml"
                   Write(i.BakeryName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 44 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Owner\MonthSales.cshtml"
                   Write(i.Month);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 45 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Owner\MonthSales.cshtml"
                   Write(i.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 46 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Owner\MonthSales.cshtml"
                   Write(i.Sum);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                   \r\n                </tr>\r\n");
#nullable restore
#line 49 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Owner\MonthSales.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </table>\r\n        </div>\r\n    </section>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pryanichek_version_1000.Models.MonthSale> Html { get; private set; }
    }
}
#pragma warning restore 1591
