// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SchedulingStatusList.cs" company="">
//   
// </copyright>
// <summary>
//   The scheduling status view list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The scheduling status view list.
    /// </summary>
    public class SchedulingStatusViewList
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the allias.
        /// </summary>
        public string Allias { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the day of month.
        /// </summary>
        public string DayOfMonth { get; set; }

        /// <summary>
        /// Gets or sets the day of week.
        /// </summary>
        public string DayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the emails.
        /// </summary>
        public string Emails { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the scheduled time.
        /// </summary>
        public string ScheduledTime { get; set; }

        /// <summary>
        /// Gets or sets the scrum template id.
        /// </summary>
        public int ScrumTemplateID { get; set; }

        /// <summary>
        /// Gets or sets the scrum template name.
        /// </summary>
        public string ScrumTemplateName { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        #endregion
    }

    /// <summary>
    /// The scheduling status list.
    /// </summary>
    public class SchedulingStatusList
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SchedulingStatusList"/> class.
        /// </summary>
        /// <param name="lst">
        /// The lst.
        /// </param>
        public SchedulingStatusList(List<SchedulingStatusViewList> lst)
        {
            this.SchedulingStatusDbList = lst;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the scheduling status db list.
        /// </summary>
        public List<SchedulingStatusViewList> SchedulingStatusDbList { get; set; }

        #endregion
    }
}