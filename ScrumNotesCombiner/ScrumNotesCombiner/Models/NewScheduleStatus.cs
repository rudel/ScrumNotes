// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewScheduleStatus.cs" company="">
//   
// </copyright>
// <summary>
//   The new schedule status.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The new schedule status.
    /// </summary>
    public class NewScheduleStatus
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the allias.
        /// </summary>
        public string Allias { get; set; }

        // Day of week for weekly and monthly sched.statuses
        /// <summary>
        /// Gets or sets the day of month.
        /// </summary>
        public string DayOfMonth { get; set; }

        /// <summary>
        /// Gets or sets the day of week.
        /// </summary>
        public string DayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        // Day of month for monthly sched.statuses (if DayofMonth is not working day - the task will be scheduled to the nearest working day)
        /// <summary>
        /// Gets or sets the emails.
        /// </summary>
        public List<string> emails { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int id { get; set; }

        // Emails list
        /// <summary>
        /// Gets or sets the scheduled_time.
        /// </summary>
        public string scheduled_time { get; set; }

        #endregion

        // Exact time for scheduling task
    }
}