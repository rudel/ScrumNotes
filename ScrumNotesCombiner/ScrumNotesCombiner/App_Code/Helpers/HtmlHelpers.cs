// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlHelpers.cs" company="">
//   
// </copyright>
// <summary>
//   The html helpers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.App_Code.Helpers
{
    using System.Web.Mvc;

    /// <summary>
    /// The html helpers.
    /// </summary>
    public static class HtmlHelpers
    {
        #region Public Methods and Operators

        /// <summary>
        /// The action image.
        /// </summary>
        /// <param name="html">
        /// The html.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="controller">
        /// The controller.
        /// </param>
        /// <param name="routeValues">
        /// The route values.
        /// </param>
        /// <param name="imagePath">
        /// The image path.
        /// </param>
        /// <param name="alt">
        /// The alt.
        /// </param>
        /// <param name="confirmation">
        /// The confirmation.
        /// </param>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        public static MvcHtmlString ActionImage(
            this HtmlHelper html, 
            string action, 
            string controller, 
            object routeValues, 
            string imagePath, 
            string alt, 
            bool confirmation)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);

            // build the <img> tag
            string onclick = "return confirm('Are you sure that you want to perform delete operaion ?')";
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alt);
            if (confirmation)
            {
                imgBuilder.MergeAttribute("onclick", onclick);
            }

            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, controller, routeValues));
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(anchorHtml);
        }

        #endregion
    }
}