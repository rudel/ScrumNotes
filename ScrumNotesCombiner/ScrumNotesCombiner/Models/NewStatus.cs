// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewStatus.cs" company="">
//   
// </copyright>
// <summary>
//   The new status.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The new status.
    /// </summary>
    public class NewStatus
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the blocker.
        /// </summary>
        public string Blocker { get; set; }

        /// <summary>
        /// Gets or sets the dt.
        /// </summary>
        [Required(ErrorMessage = "Detailed today not specified")]
        public string DT { get; set; }

        /// <summary>
        /// Gets or sets the first arg.
        /// </summary>
        [Required(ErrorMessage = "Argument not specified")]
        public string FirstArg { get; set; }

        /// <summary>
        /// Gets or sets the second arg.
        /// </summary>
        [Required(ErrorMessage = "Argument not specified")]
        public string SecondArg { get; set; }

        /// <summary>
        /// Gets or sets the status common type.
        /// </summary>
        [Required(ErrorMessage = "Type not specified")]
        public string StatusCommonType { get; set; }

        #endregion
    }
}