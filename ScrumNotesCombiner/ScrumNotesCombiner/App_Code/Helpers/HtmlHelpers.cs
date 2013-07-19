using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumNotesCombiner.App_Code.Helpers
{
    using System.Web.Mvc;

    public static class HtmlHelpers
    {
        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, string controller, object routeValues, string imagePath, string alt, bool confirmation)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);
            // build the <img> tag
            string onclick = "return confirm('Are you sure that you want to perform delete operaion ?')";
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alt);
            if (confirmation==true){imgBuilder.MergeAttribute("onclick", onclick);}
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);
            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, controller, routeValues));
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(anchorHtml);
        }
    }
}