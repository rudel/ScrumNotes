using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumNotesCombiner.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        public ActionResult ShowUsers() //List of users here
        {
            return View();
        }

        public ActionResult ActionWithUser(string id, string action) //Performes actions with users
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
