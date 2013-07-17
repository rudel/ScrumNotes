using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumNotesCombiner.Models
{
    public class NewScheduleStatus
    {
        public int id { set; get; }
        public string Allias { set; get; }
        public string Type { set; get; } //Dayly/Weekly/Monthly
        public string DayOfWeek { set; get; } //Day of week for weekly and monthly sched.statuses
        public string DayOfMonth { set; get; } //Day of month for monthly sched.statuses (if DayofMonth is not working day - the task will be scheduled to the nearest working day)
        public List<string> emails { set; get; } //Emails list
        public string scheduled_time { set; get;} //Exact time for scheduling task
    }
}