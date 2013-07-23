// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsersListForProject.cs" company="">
//   
// </copyright>
// <summary>
//   The users view list for project.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The users view list for project.
    /// </summary>
    public class UsersViewListForProject
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the a dusername.
        /// </summary>
        public string ADusername { get; set; }

        /// <summary>
        /// Gets or sets the allias.
        /// </summary>
        public string Allias { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public string Role { get; set; }

        #endregion
    }

    /// <summary>
    /// The users list for project.
    /// </summary>
    public class UsersListForProject
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersListForProject"/> class.
        /// </summary>
        /// <param name="userlist">
        /// The userlist.
        /// </param>
        public UsersListForProject(List<UsersViewListForProject> userlist)
        {
            this.UsersDbListForProject = userlist;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the users db list for project.
        /// </summary>
        public List<UsersViewListForProject> UsersDbListForProject { get; set; }

        #endregion
    }
}