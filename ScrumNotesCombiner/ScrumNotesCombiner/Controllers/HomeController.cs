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
    using System.Reflection;
    using System.Web.Mvc;

    using log4net;

    using ScrumNotesCombiner.Models;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        #region Static Fields

        /// <summary>
        /// The _logger.
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        // Homepage
        #region Public Methods and Operators

        /// <summary>
        /// The action with project.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="ProjectAction">
        /// The project action.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult ActionWithProject(int id, string ProjectAction)
        {
            var ScrumNotesDatabase = new Database();
            UsersList userlist = ScrumNotesDatabase.GetUsersInProject(id);
            SchedulingStatusList ssl = ScrumNotesDatabase.GetSchedulingStatuses(id);
            UsersListForProject ulfp = ScrumNotesDatabase.GetUsersForProjectRoles(id);
            _logger.Debug("Performing actions with project");
            var nproject = new NewProject(false, userlist, ProjectAction, ssl, ulfp);
            switch (ProjectAction)
            {
                case "Create":
                    nproject.AllowEdit = true;
                    nproject.ProjectAction = ProjectAction;
                    return View(nproject);
                    break;
                case "View":
                    nproject = ScrumNotesDatabase.GetProjectInfo(id);
                    nproject.SetExtraParams(false, userlist, ProjectAction, ssl, ulfp);
                    nproject.AllowEdit = false;
                    return View(nproject);
                    break;
                case "Edit":
                    nproject = ScrumNotesDatabase.GetProjectInfo(id);
                    nproject.SetExtraParams(false, userlist, ProjectAction, ssl, ulfp);
                    nproject.AllowEdit = true;
                    nproject.id = id;
                    return View(nproject);
                    break;
                case "Delete":
                    ScrumNotesDatabase.DeleteProject(id);
                    return this.RedirectToAction("Index");
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
                    ScrumNotesDatabase.ModifyProject(newproject);
                    return this.RedirectToAction("Index");
            }

            return this.RedirectToAction("Index");
        }

        /// <summary>
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
        public ActionResult ActionWithScheduledStatus(string id, string action)
        {
            return this.View();
        }

        // <summary>
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            var ScrumNotesDatabase = new Database();
            ProjectsList projects = ScrumNotesDatabase.GetProjectsList();
            return this.View(projects);
        }

        #endregion
    }
}