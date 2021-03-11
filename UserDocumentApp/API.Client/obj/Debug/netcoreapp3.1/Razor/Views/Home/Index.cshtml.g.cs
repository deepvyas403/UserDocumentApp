#pragma checksum "I:\ProjectCode\PracticalTest\UserDocumentApp\UserDocumentApp\UserDocumentApp\API.Client\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "266e8277ef6bd0124cec82e63d30ae4803130ca0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"266e8277ef6bd0124cec82e63d30ae4803130ca0", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<API.Core.Models.UserDocumentViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "I:\ProjectCode\PracticalTest\UserDocumentApp\UserDocumentApp\UserDocumentApp\API.Client\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "User Documents";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>");
#nullable restore
#line 7 "I:\ProjectCode\PracticalTest\UserDocumentApp\UserDocumentApp\UserDocumentApp\API.Client\Views\Home\Index.cshtml"
Write(ViewBag.StatusCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
<br/>
<h2>Add Document</h2>
<form asp-action=""Add"" method=""post"">
    <div class=""form-group"">
        <label for=""Document"">Select Document:</label>
        <input type=""file"" name=""DocumentName"" accept=""application/pdf"" />
    </div>
    <div class=""form-group"">
        <label for=""Username"">User name:</label>
        <input class=""form-control"" name=""UserName"" />
    </div>
    <div class=""text-center panel-body"">
        <button type=""submit"" class=""btn btn-sm btn-primary"">Upload</button>
    </div>
</form>

<br/>
<br />
<div class=""container"">
    <table class=""table table-striped"">
        <thead>
            <tr>
                <th>Name of User</th>
                <th>Name of Document</th>
                <th>Uploaded At</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 37 "I:\ProjectCode\PracticalTest\UserDocumentApp\UserDocumentApp\UserDocumentApp\API.Client\Views\Home\Index.cshtml"
             if (Model != null && Model.Any())
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "I:\ProjectCode\PracticalTest\UserDocumentApp\UserDocumentApp\UserDocumentApp\API.Client\Views\Home\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 42 "I:\ProjectCode\PracticalTest\UserDocumentApp\UserDocumentApp\UserDocumentApp\API.Client\Views\Home\Index.cshtml"
                       Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</td>\r\n                        <td>");
#nullable restore
#line 43 "I:\ProjectCode\PracticalTest\UserDocumentApp\UserDocumentApp\UserDocumentApp\API.Client\Views\Home\Index.cshtml"
                       Write(item.DocumentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 44 "I:\ProjectCode\PracticalTest\UserDocumentApp\UserDocumentApp\UserDocumentApp\API.Client\Views\Home\Index.cshtml"
                       Write(item.DocumentUploadedDateTime.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 1459, "\"", 1484, 1);
#nullable restore
#line 46 "I:\ProjectCode\PracticalTest\UserDocumentApp\UserDocumentApp\UserDocumentApp\API.Client\Views\Home\Index.cshtml"
WriteAttributeValue("", 1466, item.DocumentPath, 1466, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"No Document found\" target=\"_blank\">View</a>\r\n                            <a class=\"btn btn-danger\" asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-documentId", " asp-route-documentId=\"", 1609, "\"", 1648, 1);
#nullable restore
#line 47 "I:\ProjectCode\PracticalTest\UserDocumentApp\UserDocumentApp\UserDocumentApp\API.Client\Views\Home\Index.cshtml"
WriteAttributeValue("", 1632, item.DocumentID, 1632, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" method=\"delete\">Delete</a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 50 "I:\ProjectCode\PracticalTest\UserDocumentApp\UserDocumentApp\UserDocumentApp\API.Client\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "I:\ProjectCode\PracticalTest\UserDocumentApp\UserDocumentApp\UserDocumentApp\API.Client\Views\Home\Index.cshtml"
                 
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"4\">No Records found.</td>\r\n                </tr>\r\n");
#nullable restore
#line 57 "I:\ProjectCode\PracticalTest\UserDocumentApp\UserDocumentApp\UserDocumentApp\API.Client\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<API.Core.Models.UserDocumentViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
