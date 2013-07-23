// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="">
//   
// </copyright>
// <summary>
//   The settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Models
{
    /// <summary>
    /// The settings.
    /// </summary>
    public class Settings
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether create new database.
        /// </summary>
        public bool CreateNewDatabase { get; set; }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the scrum administrator name.
        /// </summary>
        public string ScrumAdministratorName { get; set; }

        /// <summary>
        /// Gets or sets the scrum administrator password.
        /// </summary>
        public string ScrumAdministratorPassword { get; set; }

        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
        public string ServerName { get; set; }

        #endregion
    }
}