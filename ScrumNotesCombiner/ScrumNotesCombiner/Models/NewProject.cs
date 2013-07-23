// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewProject.cs" company="">
//   
// </copyright>
// <summary>
//   The new project.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The new project.
    /// </summary>
    public class NewProject
    {
        // Properties for new project (HTTPPOST)
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NewProject"/> class.
        /// </summary>
        public NewProject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewProject"/> class.
        /// </summary>
        /// <param name="create">
        /// The create.
        /// </param>
        /// <param name="userlist">
        /// The userlist.
        /// </param>
        /// <param name="currentaction">
        /// The currentaction.
        /// </param>
        /// <param name="ssl">
        /// The ssl.
        /// </param>
        /// <param name="ulfp">
        /// The ulfp.
        /// </param>
        public NewProject(
            bool create, UsersList userlist, string currentaction, SchedulingStatusList ssl, UsersListForProject ulfp)
        {
            if (create == false)
            {
                this.ListForProjectAdmin = userlist;
            }

            this.SchedulingStatusList = ssl;
            this.action = currentaction;
            this.UsersListForProject = ulfp;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the admin.
        /// </summary>
        [Required(ErrorMessage = "Project administrator not specified !")]
        public int Admin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether allow edit.
        /// </summary>
        public bool AllowEdit { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the est finish date.
        /// </summary>
        [Required(ErrorMessage = "Estimated finish date not specified")]
        public string EstFinishDate { get; set; }

        /// <summary>
        /// Gets or sets the list for project admin.
        /// </summary>
        public UsersList ListForProjectAdmin { get; set; }

        /// <summary>
        /// Gets or sets the parsed est finish date.
        /// </summary>
        public DateTime ParsedEstFinishDate { get; set; }

        /// <summary>
        /// Gets or sets the parsed start date.
        /// </summary>
        public DateTime ParsedStartDate { get; set; }

        /// <summary>
        /// Gets or sets the project action.
        /// </summary>
        public string ProjectAction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether project members.
        /// </summary>
        public bool ProjectMembers { get; set; }

        /// <summary>
        /// Gets or sets the roles in project list.
        /// </summary>
        public List<RolesInProject> RolesInProjectList { get; set; }

        // Properties for list view selection

        // Users list for "project admin" dropdownbox
        /// <summary>
        /// Gets or sets the scheduling status list.
        /// </summary>
        public SchedulingStatusList SchedulingStatusList { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        [Required(ErrorMessage = "Start date not specified")]
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [Required(ErrorMessage = "Title not specified")]
        public string Title { get; set; }

        // Sched.statuses list for Sched.statuses table

        // Possible values: "View", "Create", "Edit" (for form submit configuration)
        /// <summary>
        /// Gets or sets the users list for project.
        /// </summary>
        public UsersListForProject UsersListForProject { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        public string action { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int id { get; set; }

        #endregion

        // Users list for role table
        // Controls enable/disable
        #region Public Methods and Operators

        /// <summary>
        /// The set extra params.
        /// </summary>
        /// <param name="create">
        /// The create.
        /// </param>
        /// <param name="userlist">
        /// The userlist.
        /// </param>
        /// <param name="currentaction">
        /// The currentaction.
        /// </param>
        /// <param name="ssl">
        /// The ssl.
        /// </param>
        /// <param name="ulfp">
        /// The ulfp.
        /// </param>
        public void SetExtraParams(
            bool create, UsersList userlist, string currentaction, SchedulingStatusList ssl, UsersListForProject ulfp)
        {
            if (create == false)
            {
                this.ListForProjectAdmin = userlist;
            }

            this.SchedulingStatusList = ssl;
            this.action = currentaction;
            this.UsersListForProject = ulfp;
        }

        #endregion
    }

    /// <summary>
    /// The roles in project.
    /// </summary>
    public class RolesInProject
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        #endregion
    }
}