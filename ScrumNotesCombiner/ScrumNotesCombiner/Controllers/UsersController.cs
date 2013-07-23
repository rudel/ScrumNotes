using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumNotesCombiner.Models;

namespace ScrumNotesCombiner.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        public ActionResult ShowUsers() //List of users here
        {
            var ScrumNotesDatabase = new Database();
            UsersList userslist = ScrumNotesDatabase.GetUsersList();
            return View(userslist);
        }

        [HttpGet]
        public ActionResult ActionWithUser(int id, string UserAction) //Performes actions with users
        {
            NewUser nuser = new NewUser();
            var ScrumNotesDatabase = new Database();
            nuser.UserAction = UserAction;
            switch (UserAction)
            {
                case "Create":
                    nuser.AllowEdit = true;
                    return View(nuser);
                case "View":
                    nuser.AllowEdit = false;
                    nuser = ScrumNotesDatabase.GetUserInfo(id);
                    return this.View(nuser);
                case "Edit":
                    nuser = ScrumNotesDatabase.GetUserInfo(id);
                    nuser.id = id;
                    nuser.AllowEdit = true;
                    return this.View(nuser);
                case "Delete":
                    ScrumNotesDatabase.delete_user(id);
                    return RedirectToAction("ShowUsers");
            }
            return View();
        }
        
        [HttpPost]
        public ActionResult ActionWithUser(NewUser newUser)
        {
            var ScrumNotesDatabase = new Database();
            switch (newUser.UserAction)
            {
                case "Create":
                    ScrumNotesDatabase.CreateUser(newUser);
                    return RedirectToAction("ShowUsers");
                case "Edit":
                    ScrumNotesDatabase.ModifyUser(newUser);
                    return RedirectToAction("ShowUsers");
            }
            return this.View(newUser);
        }
    }
}
