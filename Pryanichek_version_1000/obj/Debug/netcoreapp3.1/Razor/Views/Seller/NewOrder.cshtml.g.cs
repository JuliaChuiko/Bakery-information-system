#pragma checksum "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\NewOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8adc773ae55c116b6e0b61d7b0ba9ead2fef6a5e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Seller_NewOrder), @"mvc.1.0.view", @"/Views/Seller/NewOrder.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8adc773ae55c116b6e0b61d7b0ba9ead2fef6a5e", @"/Views/Seller/NewOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40756e5d2c077713db41ccd668cb5ef57b1800e5", @"/Views/_ViewImports.cshtml")]
    public class Views_Seller_NewOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ClassClient>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Seller/CreateOrder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\NewOrder.cshtml"
  
    ViewData["Title"] = "Страничка продавца";
    Layout = "~/Views/Shared/_New_Layout2.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8adc773ae55c116b6e0b61d7b0ba9ead2fef6a5e4598", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8adc773ae55c116b6e0b61d7b0ba9ead2fef6a5e5671", async() => {
                WriteLiteral(@"

    <aside>
        <div class=""widget"">
            <h3 class=""widget-title"">Быстрый поиск</h3>
            <ul class=""widget-list"">
                <li><a href=""/Seller/Price"">Стоимость изделия</a></li>
                <li><a href=""/Seller/ProductList"">Ассортимент</a></li>
                <li><a href=""/Seller/NewOrder"">Изделие под заказ</a></li>
                <li><a href=""/Seller/Allergic"">Определить аллегренные компоненты в изделии</a></li>
                <li><a href=""/Seller/CreateCheck"">Добавить чек</a></li>
                <li><a href=""/Seller/Receipts""> Просмотреть список чеков за определенную дату</a></li>
                <li><a href=""/Seller/ReceiptPeriod""> Просмотреть список чеков за период</a></li>
            </ul>
        </div>
    </aside>
    <section>

        <div width=""800"" style=""background-color:white"">
            <table>
                <thead>
                    <tr>

                        <td>Имя и фамилия</td>
                        <td>Номер телефон");
                WriteLiteral("а</td>\r\n                        <td>Кол-во визитов сети</td>\r\n                        <td></td>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n\r\n");
#nullable restore
#line 44 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\NewOrder.cshtml"
                     foreach (var i in Model)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 47 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\NewOrder.cshtml"
                           Write(i.ClientName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 48 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\NewOrder.cshtml"
                           Write(i.TelNo);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 49 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\NewOrder.cshtml"
                           Write(i.VisitsNumbers);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8adc773ae55c116b6e0b61d7b0ba9ead2fef6a5e8542", async() => {
                    WriteLiteral("\r\n                                    <input type=\"hidden\" name=\"Identifyier\"");
                    BeginWriteAttribute("value", " value=\"", 1918, "\"", 1940, 1);
#nullable restore
#line 52 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\NewOrder.cshtml"
WriteAttributeValue("", 1926, i.Identifyier, 1926, 14, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                                    <button type=\"submit\" class=\"btn btn-secondary\">Добавить заказ </button>\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 57 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\NewOrder.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                   \r\n                </tbody>\r\n\r\n\r\n            </table>\r\n        </div>\r\n       \r\n\r\n    </section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ClassClient>> Html { get; private set; }
    }
}
#pragma warning restore 1591
