// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScrumTemplates.cs" company="">
//   
// </copyright>
// <summary>
//   The scrum templates.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Models
{
    using System.Web.Mvc;

    /// <summary>
    /// The scrum templates.
    /// </summary>
    public class ScrumTemplates
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the template content.
        /// </summary>
        [AllowHtml]
        public string TemplateContent { get; set; }

        /// <summary>
        /// Gets or sets the template name.
        /// </summary>
        public string TemplateName { get; set; }

        #endregion
    }
}