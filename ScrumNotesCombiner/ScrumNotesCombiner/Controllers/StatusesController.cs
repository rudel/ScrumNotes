// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusesController.cs" company="">
//   
// </copyright>
// <summary>
//   The statuses controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The statuses controller.
    /// </summary>
    public class StatusesController : Controller
    {
        // GET: /Statuses/
        #region Public Methods and Operators

        /// <summary>
        /// The action with status.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult ActionWithStatus()
        {
            return this.View();
        }

        /// <summary>
        /// The statuses.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Statuses()
        {
            return this.View();
        }

        #endregion
    }
}