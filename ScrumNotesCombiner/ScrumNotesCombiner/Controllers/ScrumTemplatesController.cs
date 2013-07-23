// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScrumTemplatesController.cs" company="">
//   
// </copyright>
// <summary>
//   The scrum templates controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The scrum templates controller.
    /// </summary>
    public class ScrumTemplatesController : Controller
    {
        #region Public Methods and Operators

        /// <summary>
        /// The action with scrum template.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult ActionWithScrumTemplate(string id, string action)
        {
            switch (action)
            {
                case "create":
                    break;
                case "view":
                    break;
                case "edit":
                    break;
                case "remove":
                    break;
            }

            return this.View();
        }

        /// <summary>
        /// The scrum templates.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult ScrumTemplates()
        {
            return this.View();
        }

        #endregion
    }
}