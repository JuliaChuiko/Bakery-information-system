#pragma checksum "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Baker\ShowOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0215cb6883575b5a21bf9e7449d8aacf6a1e75e0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Baker_ShowOrders), @"mvc.1.0.view", @"/Views/Baker/ShowOrders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0215cb6883575b5a21bf9e7449d8aacf6a1e75e0", @"/Views/Baker/ShowOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40756e5d2c077713db41ccd668cb5ef57b1800e5", @"/Views/_ViewImports.cshtml")]
    public class Views_Baker_ShowOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pryanichek_version_1000.Models.NewOrder>
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
#line 3 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Baker\ShowOrders.cshtml"
  
    ViewData["Title"] = "Страничка пекаря";
    Layout = "~/Views/Shared/_Baker_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<html>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0215cb6883575b5a21bf9e7449d8aacf6a1e75e03720", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        window.PopStateEvent = history.go(1);\r\n    </script>\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0215cb6883575b5a21bf9e7449d8aacf6a1e75e04793", async() => {
                WriteLiteral(@"

    <div>
    </div>

    <aside>
        <div class=""widget"">
            <h3 class=""widget-title"">Быстрый поиск</h3>
            <ul class=""widget-list"">
                <li><a href=""/Baker/Products"">Список изделий</a></li>
                <li><a href=""/Baker/CurrentList"">Текущие заказы</a></li>
                <li><a href=""/Baker/Orders"">Выполненные заказы</a></li>
                <li><a href=""/Baker/AddProducts"">Что нужно допечь?</a></li>
</div>
    </aside>

    <section>
        <div style=""background-color:white"">
            <table>
                <tr>
                    <td>Номер чека</td>
                    <td>Продавец</td>
                    <td>Получатель</td>
                    <td>Дата приема и сдачи заказа</td>
                    <td>Состояние заказа</td>
                    <td>Продукт, кол-во (шт.)</td>
                    <td>Заказ выполнил</td>
                    <td>Сумма (грн)</td>

                </tr>


");
#nullable restore
#line 47 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Baker\ShowOrders.cshtml"
                 foreach (var i in TempData["Orders"] as List<NewOrder>)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 50 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Baker\ShowOrders.cshtml"
                       Write(i.OrderNo);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 51 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Baker\ShowOrders.cshtml"
                       Write(i.Cashier);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 52 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Baker\ShowOrders.cshtml"
                       Write(i.ToPerson);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 53 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Baker\ShowOrders.cshtml"
                       Write(i.StartDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("   ");
#nullable restore
#line 53 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Baker\ShowOrders.cshtml"
                                      Write(i.EndDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 54 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Baker\ShowOrders.cshtml"
                       Write(i.Status);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 55 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Baker\ShowOrders.cshtml"
                       Write(i.ProductNameWithCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 56 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Baker\ShowOrders.cshtml"
                       Write(i.FromPerson);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 57 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Baker\ShowOrders.cshtml"
                       Write(i.Sum);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 60 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Baker\ShowOrders.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </table>\r\n        </div>\r\n        </section>\r\n");
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
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pryanichek_version_1000.Models.NewOrder> Html { get; private set; }
    }
}
#pragma warning restore 1591