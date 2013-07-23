// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsController.cs" company="">
//   
// </copyright>
// <summary>
//   The settings controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The settings controller.
    /// </summary>
    public class SettingsController : Controller
    {
        #region Public Methods and Operators

        /// <summary>
        /// The settings.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Settings()
        {
            return this.View();
        }

        #endregion
    }
}