using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumNotesCombiner.Controllers
{
    public class ScrumTemplatesController : Controller
    {
        //
        // GET: /ScrumTemplates/

        public ActionResult ScrumTemplates()
        {
            return View();
        }

        public ActionResult ActionWithScrumTemplate(string id, string action)
        {
            switch (action)
            {
                case "create":
                    break;
                case "view":
                    break;
                case "edit":
                    break;
                case "remove":
                    break;
            }
            return View();
        }

    }
}
