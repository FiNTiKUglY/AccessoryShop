using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WEB_053505_Pronin.TagHelpers
{
    [HtmlTargetElement(tag: "img", Attributes = "img-action, img-controller")]
    public class ImageTagHelper : TagHelper
    {
        private LinkGenerator _linkGenerator;
        public string ImgController { get; set; }
        public string ImgAction { get; set; }

        public ImageTagHelper(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("src", _linkGenerator.GetPathByAction(ImgAction, ImgController));
        }
    }
}
