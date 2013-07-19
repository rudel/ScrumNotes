using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScrumNotesCombiner.Models;

namespace ScrumNotesCombiner.Models
{
    public class ProjectsList
    {
        public List<ProjectsViewList> ProjectDatabaseList { get; set; }
        public ProjectsList(List<ProjectsViewList> lst)
        {
            ProjectDatabaseList = lst;
        }
    }
    
    public class ProjectsViewList
    {
        public string Id { set; get;}
        public string Allias { set; get; }
        public string Admin { set; get; }
        public string StartDate { set; get;}
        public string EstFinishDate { set; get;}
        public string Comments { set; get; }
    }

}