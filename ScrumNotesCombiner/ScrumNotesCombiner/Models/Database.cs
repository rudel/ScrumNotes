// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Database.cs" company="">
//   
// </copyright>
// <summary>
//   The database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScrumNotesCombiner.Models
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    /// <summary>
    /// The database.
    /// </summary>
    public class Database
    {
        // Project-Related
        #region Public Methods and Operators

        /// <summary>
        /// The create project.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int CreateProject(NewProject project)
        {
            // returns null if ok, 1 if fails, 2 if the project with similar name already exists
            try
            {
                project.ParsedStartDate = DateTime.Parse(project.StartDate);
                project.ParsedEstFinishDate = DateTime.Parse(project.EstFinishDate);
                var createcontext =
                    new ScrumNotesDbClassDataContext(
                        ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ToString());
                int? id = createcontext.Projects.Count() + 1;
                IQueryable<Project> projects = from p in createcontext.Projects
                                               where p.Allias.Equals(project.Title)
                                               select p;
                if (projects.Count() != 0)
                {
                    createcontext.Dispose();
                    return 2;
                }

                int newid = createcontext.Projects.Count() + 1;
                var record = new Project
                                 {
                                     Allias = project.Title, 
                                     Comments = project.Comments, 
                                     EstFinishDate = project.ParsedEstFinishDate, 
                                     Id = newid, 
                                     ProjectAdminId = project.Admin, 
                                     StartDate = project.ParsedStartDate
                                 };
                createcontext.Projects.InsertOnSubmit(record);
                createcontext.Projects.Context.SubmitChanges();
                createcontext.Dispose();
                return 0;
            }
            catch (Exception e)
            {
                return 1;
            }
        }

        /// <summary>
        /// The create user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int CreateUser(NewUser user)
        {
            var createcontext =
                new ScrumNotesDbClassDataContext(
                    ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ToString());
            int users = (from u in createcontext.Users where u.ADUserName.Equals(user.ADname) select u).Count();
            try
            {
                if (users != 0)
                {
                    return 2;
                }

                int newid = createcontext.Users.Count() + 1;
                var record = new User
                                 {
                                     Id = newid, 
                                     ADUserName = user.ADname, 
                                     Allias = user.Name, 
                                     Email = user.Email, 
                                     Comments = user.Comments
                                 };
                createcontext.Users.InsertOnSubmit(record);
                createcontext.Users.Context.SubmitChanges();
                createcontext.Dispose();
                return 0;
            }
            catch (Exception e)
            {
                return 1;
            }
        }

        /// <summary>
        /// The delete project.
        /// </summary>
        /// <param name="projectId">
        /// The project id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool DeleteProject(int projectId)
        {
            try
            {
                var deletecontext =
                    new ScrumNotesDbClassDataContext(
                        ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ToString());
                Project project =
                    (from p in deletecontext.Projects where p.Id.Equals(projectId) select p).FirstOrDefault();
                deletecontext.Projects.DeleteOnSubmit(project);
                deletecontext.SubmitChanges();
                deletecontext.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// The delete user.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool DeleteUser(int userId)
        {
            try
            {
                var deletecontext =
                    new ScrumNotesDbClassDataContext(
                        ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ToString());
                User user = (from u in deletecontext.Users where u.Id.Equals(userId) select u).FirstOrDefault();
                deletecontext.Users.DeleteOnSubmit(user);
                deletecontext.SubmitChanges();
                deletecontext.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// The get project info.
        /// </summary>
        /// <param name="projectId">
        /// The project id.
        /// </param>
        /// <returns>
        /// The <see cref="NewProject"/>.
        /// </returns>
        public NewProject GetProjectInfo(int projectId)
        {
            var selectioncontext =
                new ScrumNotesDbClassDataContext(
                    ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ToString());
            var project = new NewProject();
            IQueryable<Project> selectproject = from p in selectioncontext.Projects select p;
            project.Title = selectproject.FirstOrDefault().Allias;
            project.StartDate = selectproject.FirstOrDefault().StartDate.ToString();
            project.EstFinishDate = selectproject.FirstOrDefault().EstFinishDate.ToString();
            project.Comments = selectproject.FirstOrDefault().Comments;
            selectioncontext.Dispose();
            return project;
        }

        /// <summary>
        /// The get projects list.
        /// </summary>
        /// <returns>
        /// The <see cref="ProjectsList"/>.
        /// </returns>
        public ProjectsList GetProjectsList()
        {
            var selectioncontext =
                new ScrumNotesDbClassDataContext(
                    ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ToString());
            List<ProjectsViewList> p2 = (from p in selectioncontext.Projects
                                         from u in selectioncontext.Users
                                         where u.Id.Equals(p.ProjectAdminId)
                                         select
                                             new ProjectsViewList
                                                 {
                                                     Id = p.Id, 
                                                     Admin = u.Allias, 
                                                     Comments = p.Comments, 
                                                     Allias = p.Allias, 
                                                     EstFinishDate = p.EstFinishDate.ToString(), 
                                                     StartDate = p.StartDate.ToString()
                                                 }).ToList();
            var p1 = new ProjectsList(p2);
            selectioncontext.Dispose();
            return p1;
        }

        /// <summary>
        /// The get scheduling statuses.
        /// </summary>
        /// <param name="projectId">
        /// The project id.
        /// </param>
        /// <returns>
        /// The <see cref="SchedulingStatusList"/>.
        /// </returns>
        public SchedulingStatusList GetSchedulingStatuses(int projectId)
        {
            var selectioncontext =
                new ScrumNotesDbClassDataContext(
                    ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ToString());
            List<SchedulingStatusViewList> ssl1 = (from s in selectioncontext.ScheduleStatus
                                                   from p in selectioncontext.Projects
                                                   where p.Id.Equals(projectId)
                                                   select
                                                       new SchedulingStatusViewList
                                                           {
                                                               Id = s.Id, 
                                                               Allias = s.Allias, 
                                                               DayOfWeek = s.DayOfWeek.ToString(), 
                                                               DayOfMonth =
                                                                   s.DayOfMonth.ToString(), 
                                                               ScheduledTime =
                                                                   s.ScheduledTime.ToString(), 
                                                               ProjectName = p.Allias
                                                           }).ToList();
            var ssl2 = new SchedulingStatusList(ssl1);
            selectioncontext.Dispose();
            return ssl2;
        }

        /// <summary>
        /// The get user info.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="NewUser"/>.
        /// </returns>
        public NewUser GetUserInfo(int userId)
        {
            var selectioncontext =
                new ScrumNotesDbClassDataContext(
                    ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ToString());
            var user = new NewUser();
            IQueryable<User> selectuser = from u in selectioncontext.Users where u.Id.Equals(userId) select u;
            user.Name = selectuser.FirstOrDefault().Allias;
            user.ADname = selectuser.FirstOrDefault().ADUserName;
            user.IsSCRUMadmin = selectuser.FirstOrDefault().ScrumAdmin;
            user.Email = selectuser.FirstOrDefault().Email;
            user.Comments = selectuser.FirstOrDefault().Comments;
            selectioncontext.Dispose();
            return user;
        }

        /// <summary>
        /// The get users for project roles.
        /// </summary>
        /// <param name="projectId">
        /// The project id.
        /// </param>
        /// <returns>
        /// The <see cref="UsersListForProject"/>.
        /// </returns>
        public UsersListForProject GetUsersForProjectRoles(int projectId)
        {
            var selectioncontext =
                new ScrumNotesDbClassDataContext(
                    ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ToString());
            List<UsersViewListForProject> ulfp1;
            ulfp1 = (from u in selectioncontext.Users
                     from r in selectioncontext.Roles
                     where r.ProjectId.Equals(projectId)
                     select
                         new UsersViewListForProject
                             {
                                 Id = u.Id, 
                                 Allias = u.Allias, 
                                 ADusername = u.ADUserName, 
                                 Email = u.Email, 
                                 Role = r.Name
                             }).ToList();
            var ulfp2 = new UsersListForProject(ulfp1);
            selectioncontext.Dispose();
            return ulfp2;
        }

        /// <summary>
        /// The get users in project.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="UsersList"/>.
        /// </returns>
        public UsersList GetUsersInProject(int id)
        {
            var selectioncontext =
                new ScrumNotesDbClassDataContext(
                    ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ToString());
            List<UserForModel> p1 = (from u in selectioncontext.Users
                                     from r in selectioncontext.Roles
                                     where r.ProjectId.Equals(id)
                                     select new UserForModel { Allias = u.Allias }).ToList();
            var userlist = new UsersList();
            userlist.UsersViewList = p1;
            selectioncontext.Dispose();
            return userlist;
        }

        /// <summary>
        /// The get users list.
        /// </summary>
        /// <returns>
        /// The <see cref="UsersList"/>.
        /// </returns>
        public UsersList GetUsersList()
        {
            // Fetching users for Project Administrator listbox
            var selectioncontext =
                new ScrumNotesDbClassDataContext(
                    ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ToString());
            var userslist = new UsersList();
            List<UserForModel> p2 = (from p in selectioncontext.Users
                                     select
                                         new UserForModel
                                             {
                                                 ADUsername = p.ADUserName, 
                                                 Allias = p.Allias, 
                                                 Email = p.Email, 
                                                 Id = p.Id
                                             }).ToList();
                
                // ADUserName = p.ADUserName, Allias = p.Allias, Email = p.Email, Id = p.Id}).ToList();
            var p1 = new UsersList();
            p1.UsersViewList = p2;
            selectioncontext.Dispose();
            return p1;
        }

        /// <summary>
        /// The modify project.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ModifyProject(NewProject project)
        {
            try
            {
                int id = project.id;
                var updatecontext =
                    new ScrumNotesDbClassDataContext(
                        ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ToString());
                Project projectrecord = (from p in updatecontext.Projects where p.Id.Equals(id) select p).Single();
                project.ParsedStartDate = DateTime.Parse(project.StartDate);
                project.ParsedEstFinishDate = DateTime.Parse(project.EstFinishDate);
                projectrecord.Allias = project.Title;
                projectrecord.Comments = project.Comments;
                projectrecord.EstFinishDate = project.ParsedEstFinishDate;
                projectrecord.ProjectAdminId = project.Admin;
                projectrecord.StartDate = project.ParsedStartDate;
                updatecontext.SubmitChanges();
                updatecontext.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// The modify user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ModifyUser(NewUser user)
        {
            try
            {
                var modifycontext =
                    new ScrumNotesDbClassDataContext(
                        ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ToString());
                User userrecord = (from u in modifycontext.Users where u.Id.Equals(user.id) select u).Single();
                userrecord.Allias = user.Name;
                userrecord.ADUserName = user.ADname;
                userrecord.Comments = user.Comments;
                userrecord.Email = user.Email;
                userrecord.ScrumAdmin = user.IsSCRUMadmin ?? false;
                modifycontext.SubmitChanges();
                modifycontext.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion
    }
}