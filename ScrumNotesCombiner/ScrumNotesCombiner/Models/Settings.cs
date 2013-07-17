using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumNotesCombiner.Models
{
    public class Settings
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public bool CreateNewDatabase { get; set;}
        public string ScrumAdministratorName { get; set; }
        public string ScrumAdministratorPassword { get; set;}
    }
}