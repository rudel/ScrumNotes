using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumNotesCombiner.Controllers
{
    public class HomeController : Controller //Homepage
    {
        public ActionResult Index() //List of projects here
        {
            return View();
        }

        public ActionResult ActionWithProject(string id, string action) //Performes actions with project
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
        public ActionResult ActionWithScheduledStatus(string id, string action)
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
