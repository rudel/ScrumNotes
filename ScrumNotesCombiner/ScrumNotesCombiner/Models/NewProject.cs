using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ScrumNotesCombiner.Models
{
    public class NewProject
    {
        [Required(ErrorMessage = "Title not specified")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Project administrator not specified !")]
        public int Admin { get; set; }
        [Required(ErrorMessage = "Start date not specified")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Estimated finish date not specified")]
        public DateTime EstFinishDate { get; set; }

        public string Comments { get; set;}
        public bool ProjectMembers { get; set; }
    }
}