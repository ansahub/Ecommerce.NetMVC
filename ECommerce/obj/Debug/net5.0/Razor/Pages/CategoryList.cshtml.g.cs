#pragma checksum "C:\Users\anschete\source\repos\Associate Training PS\Ansari\FinalAssignment\ECommerce\Pages\CategoryList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac9b965baf5c521ad320f0b659ccc85303203cdf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ECommerce.Web.Pages.Pages_CategoryList), @"mvc.1.0.razor-page", @"/Pages/CategoryList.cshtml")]
namespace ECommerce.Web.Pages
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
#line 1 "C:\Users\anschete\source\repos\Associate Training PS\Ansari\FinalAssignment\ECommerce\Pages\_ViewImports.cshtml"
using ECommerce;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac9b965baf5c521ad320f0b659ccc85303203cdf", @"/Pages/CategoryList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ddb0343438289f80a6ccbc2278232e1db938a87", @"/Pages/_ViewImports.cshtml")]
    public class Pages_CategoryList : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"


<a class=""btn btn-primary"" aria-current=""page"" href=""/AddCategory"">Add Category</a>
<a class=""btn btn-primary"" aria-current=""page"" href=""/ItemList"">See all items</a>


<table class=""table"">
    <thead>
        <tr>
            <th>
                Category ID
            </th>
            <th>
                Category name
            </th>

            <th></th>
        </tr>
    </thead>
    <tbody>

");
#nullable restore
#line 27 "C:\Users\anschete\source\repos\Associate Training PS\Ansari\FinalAssignment\ECommerce\Pages\CategoryList.cshtml"
         foreach (var item in Model.Categories)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 31 "C:\Users\anschete\source\repos\Associate Training PS\Ansari\FinalAssignment\ECommerce\Pages\CategoryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 34 "C:\Users\anschete\source\repos\Associate Training PS\Ansari\FinalAssignment\ECommerce\Pages\CategoryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 38 "C:\Users\anschete\source\repos\Associate Training PS\Ansari\FinalAssignment\ECommerce\Pages\CategoryList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ECommerce.Web.Pages.CategoryListModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ECommerce.Web.Pages.CategoryListModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ECommerce.Web.Pages.CategoryListModel>)PageContext?.ViewData;
        public ECommerce.Web.Pages.CategoryListModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591