// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsersList.cs" company="">
//   
// </copyright>
// <summary>
//   The users list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The users list.
    /// </summary>
    public class UsersList
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the users view list.
        /// </summary>
        public List<UserForModel> UsersViewList { get; set; }

        #endregion
    }

    /// <summary>
    /// The user for model.
    /// </summary>
    public class UserForModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the ad username.
        /// </summary>
        public string ADUsername { get; set; }

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
}