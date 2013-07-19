// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="">
//   
// </copyright>
// <summary>
//   The home controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ScrumNotesCombiner.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using ScrumNotesCombiner.Models;

    /// <summary>
    ///     The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        // Homepage
        #region Public Methods and Operators

        /// <summary>
        /// The action with project.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="ProjectAction">
        /// The Project Action.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult ActionWithProject(int id, string ProjectAction)
        {
            var ScrumNotesDatabase = new Database();
            List<user> userlist = ScrumNotesDatabase.GetUsers();
            SchedulingStatusList ssl = ScrumNotesDatabase.GetSchedulingStatuses(id);
            UsersListForProject ulfp = ScrumNotesDatabase.GetUsersForProjectRoles(id);
            var nproject = new NewProject(false, userlist, ProjectAction, ssl, ulfp);
            switch (ProjectAction)
            {
                case "Create":
                    nproject.AllowEdit = true;
                    nproject.ProjectAction = ProjectAction;
                    return View(nproject);
                    break;
                case "View":
                    nproject.AllowEdit = false;
                    return View(nproject);
                    break;
                case "Edit":
                    nproject.AllowEdit = true;
                    return View(nproject);
                    break;
                case "Delete":
                    ScrumNotesDatabase.DeleteProject(id);
                    return RedirectToAction("Index");
                    break;
            }
            return this.View();
        }

        /// <summary>
        /// The action with project.
        /// </summary>
        /// <param name="newproject">
        /// The newproject.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult ActionWithProject(NewProject newproject)
        {
            var ScrumNotesDatabase = new Database();
            switch (newproject.ProjectAction)
            {
                case "Create":
                    ScrumNotesDatabase.CreateProject(newproject);
                    this.RedirectToAction("Index");
                    return this.View(newproject);
                    break;
                case "Edit":
                    return this.View(newproject);
            }
            return RedirectToAction("Index");
        }

        // <summary>
                /// The action with scheduled status.
                /// </summary>
                /// <param name="id">
                /// The id.
                /// </param>
                /// <param name="action">
                /// The action.
                /// </param>
                /// <returns>
                /// The <see cref="ActionResult"/>.
                /// </returns>
            public
            ActionResult ActionWithScheduledStatus 
            (string id, string action)
            {
                return this.View();
            }

            // <summary>
            ///     The index.
            /// </summary>
            /// <returns>
            ///     The <see cref="ActionResult" />.
            /// </returns>
        public
            ActionResult Index 
            ()
            {
                var ScrumNotesDatabase = new Database();
                ProjectsList projects = ScrumNotesDatabase.GetProjectsList();
                return this.View(projects);
            }

            #endregion
        }


    }