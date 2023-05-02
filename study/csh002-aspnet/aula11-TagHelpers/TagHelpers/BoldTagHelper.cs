
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace App.TagHelpers;

[HtmlTargetElement("bold")]
[HtmlTargetElement(Attributes = "bold")]
public class BoldTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
       output.Attributes.RemoveAll("bold");
       output.PreContent.SetHtmlContent("<strong>");
       output.PostContent.SetHtmlContent("</strong>");

       if(output.TagName == "bold")
       {
        output.TagName = "";
       }
    }
}