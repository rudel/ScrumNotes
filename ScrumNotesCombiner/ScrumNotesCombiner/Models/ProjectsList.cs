// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectsList.cs" company="">
//   
// </copyright>
// <summary>
//   The projects list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The projects list.
    /// </summary>
    public class ProjectsList
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsList"/> class.
        /// </summary>
        /// <param name="lst">
        /// The lst.
        /// </param>
        public ProjectsList(List<ProjectsViewList> lst)
        {
            this.ProjectDatabaseList = lst;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the project database list.
        /// </summary>
        public List<ProjectsViewList> ProjectDatabaseList { get; set; }

        #endregion
    }

    /// <summary>
    /// The projects view list.
    /// </summary>
    public class ProjectsViewList
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the admin.
        /// </summary>
        public string Admin { get; set; }

        /// <summary>
        /// Gets or sets the allias.
        /// </summary>
        public string Allias { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the est finish date.
        /// </summary>
        public string EstFinishDate { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public string StartDate { get; set; }

        #endregion
    }
}