#pragma checksum "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a48b34472264554fddd8c59e601590378995632d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Quiz_Quizzes), @"mvc.1.0.view", @"/Views/Quiz/Quizzes.cshtml")]
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
#line 1 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\_ViewImports.cshtml"
using WickedQuiz.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\_ViewImports.cshtml"
using WickedQuiz.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\_ViewImports.cshtml"
using WickedQuiz.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\_ViewImports.cshtml"
using WickedQuiz.Models.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a48b34472264554fddd8c59e601590378995632d", @"/Views/Quiz/Quizzes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe0008138c2ad169847f087b848da0c3b99c816e", @"/Views/_ViewImports.cshtml")]
    public class Views_Quiz_Quizzes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Quiz>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
  
    ViewData["Title"] = "Quizzes";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Quizzes</h1>\r\n");
#nullable restore
#line 8 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
 if (!Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <p>Er zijn nog geen quizzes aangemaakt.</p>\r\n        <p>De eerste quiz moet nog worden aangemaakt.</p>\r\n    </div>\r\n");
#nullable restore
#line 14 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 21 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
               Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 24 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
               Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 27 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
               Write(Html.DisplayNameFor(model => model.Difficulty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 33 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 43 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Difficulty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 46 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
                   Write(Html.ActionLink("Play", "Play", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 47 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
                   Write(Html.ActionLink("Score tabel", "IndexScoresForQuiz", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 50 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 53 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\Quizzes.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Quiz>> Html { get; private set; }
    }
}
#pragma warning restore 1591