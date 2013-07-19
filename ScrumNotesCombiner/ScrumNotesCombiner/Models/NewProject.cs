using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ScrumNotesCombiner.Models;

namespace ScrumNotesCombiner.Models
{
    public class NewProject
    {
        //Properties for new project (HTTPPOST)
        [Required(ErrorMessage = "Title not specified")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Project administrator not specified !")]
        public int Admin { get; set; }
        [Required(ErrorMessage = "Start date not specified")]
        public string StartDate { get; set; }
        public DateTime ParsedStartDate { get; set;}
        [Required(ErrorMessage = "Estimated finish date not specified")]
        public string EstFinishDate { get; set; }
        public DateTime ParsedEstFinishDate { get; set; }
        public string Comments { get; set;}
        public bool ProjectMembers { get; set; }
        //Properties for list view selection
        public List<user> ListForProjectAdmin { set; get;} //Users list for "project admin" dropdownbox
        public SchedulingStatusList SchedulingStatusList { set; get; } //Sched.statuses list for Sched.statuses table
        public string action { get; set;} //Possible values: "View", "Create", "Edit" (for form submit configuration)
        public UsersListForProject UsersListForProject { get; set;} //Users list for role table
        //Controls enable/disable
        public bool AllowEdit { get; set; }
        public string ProjectAction { get; set; } //"Create", "Edit", "View"

        public NewProject()
        {
            
        }

        public NewProject(bool create, List<user> userlist, string currentaction, SchedulingStatusList ssl, UsersListForProject ulfp)
        {
            if (create==false){ListForProjectAdmin = userlist;}
            SchedulingStatusList = ssl;
            action = currentaction;
            UsersListForProject = ulfp;
        }
    }
}