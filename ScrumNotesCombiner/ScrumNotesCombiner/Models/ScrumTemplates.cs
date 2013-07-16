using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumNotesCombiner.Models
{
    public class ScrumTemplates
    {
        public int ProjectId {get; set;}
        public string TemplateName {get; set;}
        [AllowHtml]
        public string TemplateContent { get; set;}
    }
}