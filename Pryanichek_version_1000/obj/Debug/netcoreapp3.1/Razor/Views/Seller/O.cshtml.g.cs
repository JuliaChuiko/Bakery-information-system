#pragma checksum "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91847053d536052de5a911175ce503d7741e1ff1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Seller_O), @"mvc.1.0.view", @"/Views/Seller/O.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91847053d536052de5a911175ce503d7741e1ff1", @"/Views/Seller/O.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40756e5d2c077713db41ccd668cb5ef57b1800e5", @"/Views/_ViewImports.cshtml")]
    public class Views_Seller_O : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Seller/RemoveFromOrderCard"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Seller/SaveOrder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("600"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Seller/AddToOrderCard"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Seller/ComeBackOrder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
  
    ViewData["Title"] = "Страничка продавца";
    Layout = "~/Views/Shared/_New_Layout2.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "91847053d536052de5a911175ce503d7741e1ff16315", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "91847053d536052de5a911175ce503d7741e1ff17388", async() => {
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
        <div width=""400"" style=""background-color:white"">

            <table style=""text-align:center"">
                <thead>
                    <tr>
                        <td colspan=""5"" style=""font-weight:bold; co");
                WriteLiteral(@"lor:crimson; text-align:center; font-size:16px"">Новый заказ</td>
                    </tr>
                    
                    <tr>

                        <td>Изделие</td>
                        <td>Количество</td>
                        <td>Стоимость</td>
                        <td></td>
                    </tr>

                </thead>
                <tbody>
");
#nullable restore
#line 48 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
                     foreach (var v in TempData["ListInOrder"] as List<Item>)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 51 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
                           Write(v.ProductName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <label style=\"color:crimson\">");
#nullable restore
#line 51 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
                                                                       Write(v.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label></td>\r\n                            <td>");
#nullable restore
#line 52 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
                           Write(v.count);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 53 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
                           Write(v.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\r\n                            <td>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "91847053d536052de5a911175ce503d7741e1ff110812", async() => {
                    WriteLiteral("\r\n                                    <input type=\"hidden\" name=\"ProductNo\"");
                    BeginWriteAttribute("value", " value=\"", 2209, "\"", 2229, 1);
#nullable restore
#line 56 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
WriteAttributeValue("", 2217, v.ProductNo, 2217, 12, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                                    <button type=\"submit\" class=\"btn btn-danger\">Отменить изделие</button>\r\n                                ");
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
#line 61 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td colspan=\"5\" style=\"font-weight:normal; color:crimson; text-align:center; font-size:14px\">\r\n                            ");
#nullable restore
#line 64 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
                       Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "91847053d536052de5a911175ce503d7741e1ff113923", async() => {
                    WriteLiteral(@"
                            <td colspan=""4"" style=""text-align:center"">
                                <input type=""hidden"" name=""ProductNo"" />
                                <button type=""submit"" class=""btn btn-success"">Сохранить заказ</button><label style=""color:crimson"">");
#nullable restore
#line 71 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
                                                                                                                              Write(ViewBag.Err);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</label>\r\n                            </td>\r\n                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </tr>

                </tbody>

            </table>

        </div>


        <div>

        </div>

        <div width=""600"" style=""background-color:white"">

            <table align=""center"">
                <thead>
                    <tr>
                        <td>Изделие</td>
                        <td>Цена</td>
                        <td></td>
                    </tr>
                </thead>
                <tbody>
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "91847053d536052de5a911175ce503d7741e1ff116836", async() => {
                    WriteLiteral("\r\n");
#nullable restore
#line 99 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
                         foreach (var i in Model)
                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 102 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
                               Write(i.ProductName);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 103 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
                               Write(i.Price.ToString("c"));

#line default
#line hidden
#nullable disable
                    WriteLiteral("</td>\r\n                                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "91847053d536052de5a911175ce503d7741e1ff118126", async() => {
                        WriteLiteral("\r\n                                    <td>\r\n                                        <input type=\"hidden\" name=\"ProductNo\"");
                        BeginWriteAttribute("value", " value=\"", 4200, "\"", 4220, 1);
#nullable restore
#line 106 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"
WriteAttributeValue("", 4208, i.ProductNo, 4208, 12, false);

#line default
#line hidden
#nullable disable
                        EndWriteAttribute();
                        WriteLiteral(" />\r\n                                        <button type=\"submit\" class=\"btn btn-secondary\">Добавить в заказ</button>\r\n                                    </td>\r\n                                ");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                            </tr>\r\n");
#nullable restore
#line 111 "C:\Users\Юлия Чуйко\source\repos\Pryanichek_version_1000\Pryanichek_version_1000\Views\Seller\O.cshtml"

                        }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "91847053d536052de5a911175ce503d7741e1ff122394", async() => {
                    WriteLiteral("\r\n                                <button type=\"submit\" class=\"btn btn-danger\">Отменить действие</button>\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                        </td>\r\n\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n\r\n\r\n        </div>\r\n    </section>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
