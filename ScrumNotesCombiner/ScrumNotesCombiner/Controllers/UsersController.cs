// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsersController.cs" company="">
//   
// </copyright>
// <summary>
//   The users controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Controllers
{
    using System.Web.Mvc;

    using ScrumNotesCombiner.Models;

    /// <summary>
    /// The users controller.
    /// </summary>
    public class UsersController : Controller
    {

        #region Public Methods and Operators

        /// <summary>
        /// The action with user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="UserAction">
        /// The user action.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult ActionWithUser(int id, string UserAction)
        {
            // Performes actions with users
            var nuser = new NewUser();
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
                    ScrumNotesDatabase.DeleteUser(id);
                    return this.RedirectToAction("ShowUsers");
            }

            return this.View();
        }

        /// <summary>
        /// The action with user.
        /// </summary>
        /// <param name="newUser">
        /// The new user.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult ActionWithUser(NewUser newUser)
        {
            var ScrumNotesDatabase = new Database();
            switch (newUser.UserAction)
            {
                case "Create":
                    ScrumNotesDatabase.CreateUser(newUser);
                    return this.RedirectToAction("ShowUsers");
                case "Edit":
                    ScrumNotesDatabase.ModifyUser(newUser);
                    return this.RedirectToAction("ShowUsers");
            }

            return this.View(newUser);
        }

        /// <summary>
        /// The show users.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult ShowUsers()
        {
            // List of users here
            var ScrumNotesDatabase = new Database();
            UsersList userslist = ScrumNotesDatabase.GetUsersList();
            return View(userslist);
        }

        #endregion
    }
}