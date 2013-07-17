using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ScrumNotesCombiner.Models
{
    public class NewStatus
    {
        [Required(ErrorMessage = "Type not specified")]
        public string StatusCommonType { set; get; } 
        //Dayly (args: today/tomorrow - today, yesterday)
        //Weekly (args: this week/next week - this week, last week
        //Monthly (args: this month/next month - this month/last month
        [Required(ErrorMessage = "Argument not specified")]
        public string FirstArg { set; get;}
        [Required(ErrorMessage = "Argument not specified")]
        public string SecondArg { set; get; }
        public string Blocker { set; get; }
        [Required(ErrorMessage = "Detailed today not specified")]
        public string DT { set; get; }
    }
}