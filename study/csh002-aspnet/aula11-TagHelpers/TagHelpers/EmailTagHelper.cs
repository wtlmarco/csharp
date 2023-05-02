
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace App.TagHelpers;

//Aplicado as tags <email>
public class EmailTagHelper : TagHelper
{
    private const string mailToAttributeName = "mailTo";
    
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        string emailTo = context.AllAttributes[mailToAttributeName].Value.ToString();
        
        output.TagName = "a";
        output.Attributes.SetAttribute("href", $"mailto:{emailTo}");
        output.Content.SetContent("Envie-nos um email");

        output.Attributes.Remove(context.AllAttributes[mailToAttributeName]);
    }
}