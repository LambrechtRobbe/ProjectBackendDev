#pragma checksum "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\ResultQuiz.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6555b3d86ae3724e16bae3bb0a781dda4eb8eff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Quiz_ResultQuiz), @"mvc.1.0.view", @"/Views/Quiz/ResultQuiz.cshtml")]
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
using WickedQuiz.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6555b3d86ae3724e16bae3bb0a781dda4eb8eff", @"/Views/Quiz/ResultQuiz.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8fefb75708fae51d4fcca661ea344b0b3cc25e14", @"/Views/_ViewImports.cshtml")]
    public class Views_Quiz_ResultQuiz : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WickedQuiz.Models.Models.Score>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Quizzes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\ResultQuiz.cshtml"
  
    ViewData["Title"] = "Result Quiz";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6555b3d86ae3724e16bae3bb0a781dda4eb8eff4835", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>ResultQuiz</title>\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6555b3d86ae3724e16bae3bb0a781dda4eb8eff5899", async() => {
                WriteLiteral("\r\n\r\n<div>\r\n    <h4>Score</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 22 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\ResultQuiz.cshtml"
       Write(Html.DisplayNameFor(model => model.FinalScore));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 25 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\ResultQuiz.cshtml"
       Write(Html.DisplayFor(model => model.FinalScore));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 28 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\ResultQuiz.cshtml"
       Write(Html.DisplayNameFor(model => model.MaxScore));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 31 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\ResultQuiz.cshtml"
       Write(Html.DisplayFor(model => model.MaxScore));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 34 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\ResultQuiz.cshtml"
       Write(Html.DisplayNameFor(model => model.DateFinished));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 37 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\ResultQuiz.cshtml"
       Write(Html.DisplayFor(model => model.DateFinished));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 40 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\ResultQuiz.cshtml"
       Write(Html.DisplayNameFor(model => model.ApplicationUserId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 43 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\ResultQuiz.cshtml"
       Write(Html.DisplayFor(model => model.ApplicationUserId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 46 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\ResultQuiz.cshtml"
       Write(Html.DisplayNameFor(model => model.QuizId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 49 "D:\GithubRepos\ProjectBackendDev\WickedQuiz\WickedQuiz.Web\Views\Quiz\ResultQuiz.cshtml"
       Write(Html.DisplayFor(model => model.QuizId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6555b3d86ae3724e16bae3bb0a781dda4eb8eff9629", async() => {
                    WriteLiteral("Back to quizzes");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n</div>\r\n");
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
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WickedQuiz.Models.Models.Score> Html { get; private set; }
    }
}
#pragma warning restore 1591
