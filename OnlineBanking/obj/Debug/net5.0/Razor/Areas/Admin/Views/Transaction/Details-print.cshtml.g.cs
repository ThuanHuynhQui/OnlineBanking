#pragma checksum "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33a9a60dedf42536ca23efa5eaffe3c3c04947b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Transaction_Details_print), @"mvc.1.0.view", @"/Areas/Admin/Views/Transaction/Details-print.cshtml")]
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
#line 1 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\_ViewImports.cshtml"
using OnlineBanking;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\_ViewImports.cshtml"
using OnlineBanking.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33a9a60dedf42536ca23efa5eaffe3c3c04947b0", @"/Areas/Admin/Views/Transaction/Details-print.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5167f54ba00eb82f3f13d8e393f5193874279dce", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Transaction_Details_print : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlineBanking.Models.Transaction>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
  
    ViewData["Title"] = "Transaction";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-12"">
        <!-- Main content -->
        <div class=""invoice p-3 mb-3"">
            <!-- title row -->
            <div class=""row"">
                <div class=""col-12"">
                    <h4>
                        <i class=""fas fa-globe""></i> Online Banking
                        <small class=""float-right"">Date: ");
#nullable restore
#line 14 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                                                    Write(ViewBag.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</small>
                    </h4>
                </div>
                <!-- /.col -->
            </div>
            <!-- info row -->
            <div class=""row invoice-info"">
                <div class=""col-sm-4 invoice-col"">
                    From
                    <address>
                        <strong>");
#nullable restore
#line 24 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                           Write(ViewBag.Sender.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong><br>\r\n                        ");
#nullable restore
#line 25 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                   Write(ViewBag.Sender.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                        Phone: ");
#nullable restore
#line 26 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                          Write(ViewBag.Sender.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                        Email: ");
#nullable restore
#line 27 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                          Write(ViewBag.Sender.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </address>\r\n                </div>\r\n                <!-- /.col -->\r\n                <div class=\"col-sm-4 invoice-col\">\r\n                    To\r\n                    <address>\r\n                        <strong>");
#nullable restore
#line 34 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                           Write(ViewBag.Receiver.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong><br>\r\n                        ");
#nullable restore
#line 35 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                   Write(ViewBag.Receiver.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                        Phone: ");
#nullable restore
#line 36 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                          Write(ViewBag.Receiver.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                        Email: ");
#nullable restore
#line 37 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                          Write(ViewBag.Receiver.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </address>
                </div>
            </div>
            <!-- /.row -->
            <!-- Table row -->
            <div class=""row"">
                <div class=""table-responsive"">
                    <table class=""table"">
                        <tr>
                            <th style=""width:50%"">TransactionId:</th>
                            <td>");
#nullable restore
#line 48 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                           Write(Model.TransactionId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <th>Sender Card Id:</th>\r\n                            <td>");
#nullable restore
#line 52 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                           Write(Model.SenderCardId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <th>Receiver Card Id:</th>\r\n                            <td>");
#nullable restore
#line 56 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                           Write(Model.ReceiverCardId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <th>Amount:</th>\r\n                            <td>");
#nullable restore
#line 60 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                           Write(Model.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <th>Fee:</th>\r\n                            <td>");
#nullable restore
#line 64 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                           Write(Model.Fee);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <th>Content:</th>\r\n                            <td>");
#nullable restore
#line 68 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                           Write(Model.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <th>Time:</th>\r\n                            <td>");
#nullable restore
#line 72 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                           Write(Model.Time);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <th>Status:</th>\r\n");
#nullable restore
#line 76 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                             if (Model.Status)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>Success</td>\r\n");
#nullable restore
#line 79 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>Fail</td>\r\n");
#nullable restore
#line 83 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 85 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                         if (!Model.Status)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>Reason:</th>\r\n                                <td>");
#nullable restore
#line 89 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                               Write(Model.Reason);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 91 "D:\FPT_Aptech\semeter_03\eProject\Source_Code\OnlineBanking\OnlineBanking\Areas\Admin\Views\Transaction\Details-print.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </table>
                </div>
                <!-- /.col -->
            </div>
            <!-- this row will not appear when printing -->
            <div class=""row no-print"">
                <div class=""col-12"">
                    <a href=""invoice-print.html"" rel=""noopener"" target=""_blank"" class=""btn btn-default float-right""><i class=""fas fa-print""></i> Print</a>
                </div>
            </div>
        </div>
        <!-- /.invoice -->
    </div><!-- /.col -->
</div><!-- /.row -->

");
            DefineSection("script", async() => {
                WriteLiteral(" \r\n    <script>window.addEventListener(\"load\", window.print());</script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineBanking.Models.Transaction> Html { get; private set; }
    }
}
#pragma warning restore 1591
