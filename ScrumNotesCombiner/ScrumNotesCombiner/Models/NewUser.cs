// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewUser.cs" company="">
//   
// </copyright>
// <summary>
//   The new user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The new user.
    /// </summary>
    public class NewUser
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the a dname.
        /// </summary>
        [Required(ErrorMessage = "Active Directory user name not specified")]
        public string ADname { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether allow edit.
        /// </summary>
        public bool AllowEdit { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required(ErrorMessage = "Email not specified")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "email is incorrect")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the is scru madmin.
        /// </summary>
        [Required(ErrorMessage = "Не указано намерение относительно мероприятия")]
        public bool? IsSCRUMadmin { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required(ErrorMessage = "Name not specified")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the project role.
        /// </summary>
        public bool? ProjectRole { get; set; }

        /// <summary>
        /// Gets or sets the user action.
        /// </summary>
        public string UserAction { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int id { get; set; }

        #endregion
    }
}