using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumNotesCombiner.Models
{
    public class SchedulingStatusViewList
    {
        public int Id { get; set; }
        public string Allias { get; set; }
        public string Type { get; set;}
        public string DayOfWeek { get; set;}
        public string DayOfMonth { get; set; }
        public string Comments { get; set; }
        public string ScheduledTime { get; set;}
        public string Emails { get; set; }
        public int ScrumTemplateID { get; set;}
        public string ScrumTemplateName { get; set;}
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }

    public class SchedulingStatusList
    {
        public List<SchedulingStatusViewList> SchedulingStatusDbList { get; set;}
        
        public SchedulingStatusList(List<SchedulingStatusViewList> lst)
        {
            SchedulingStatusDbList = lst;
        }
    }
}