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
        #region Public Methods and Operators

        /// <summary>
        /// The get users.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<user> GetUsers()
        {
            // Fetching users for Project Administrator listbox
            var SelectionContext =
                new DataClasses1DataContext(
                    ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ConnectionString);

            List<user> userlist = SelectionContext.users.ToList();
            return userlist;
        }

        public SchedulingStatusList GetSchedulingStatuses(int project_id)
        {
            var SelectionContext =
                new DataClasses1DataContext(
                    ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ConnectionString);
            List<SchedulingStatusViewList> ssl1 = (from sl in SelectionContext.ScheduleStatus
                                                   join p in SelectionContext.projects on sl.ProjectID equals p.id into
                                                       ids
                                                   from x in ids.DefaultIfEmpty()
                                                   where sl.ProjectID.Equals(project_id)
                                                   select
                                                       new SchedulingStatusViewList
                                                           {
                                                               Id = sl.id,
                                                               Allias = sl.Allias,
                                                               DayOfWeek =
                                                                   sl.DayOfWeek.ToString(),
                                                               DayOfMonth =
                                                                   sl.DayOfMonth.ToString(),
                                                               ScheduledTime =
                                                                   sl.ScheduledTime.ToString(),
                                                               ProjectName = x.Allias,
                                                               Type = sl.Type
                                                           }).ToList();
            var ssl2 = new SchedulingStatusList(ssl1);
            return ssl2;
        }

        public UsersListForProject GetUsersForProjectRoles(int project_id)
        {
            var SelectionContext =
                new DataClasses1DataContext(
                    ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ConnectionString);
            List<UsersViewListForProject> ulfp1;
            if (project_id != 0)
            {
                ulfp1 = (from u in SelectionContext.users
                         join r in SelectionContext.roles on u.id equals r.UserId into ids
                         from x in ids.DefaultIfEmpty()
                         select
                             new UsersViewListForProject
                                 {
                                     Allias = u.Allias,
                                     ADusername = u.ADusername,
                                     Email = u.email,
                                     Role = x.Name
                                 }).ToList();
            }
            else
            {
                ulfp1 = (from u in SelectionContext.users
                         join r in SelectionContext.roles on u.id equals r.UserId into ids
                         from x in ids.DefaultIfEmpty()
                         select
                             new UsersViewListForProject
                                 {
                                     Allias = u.Allias,
                                     ADusername = u.ADusername,
                                     Email = u.email,
                                     Role = x.Name
                                 }).ToList();
            }

            UsersListForProject ulfp2 = new UsersListForProject(ulfp1);
            return ulfp2;
        }

        public ProjectsList GetProjectsList()
        {
            var SelectionContext =
               new DataClasses1DataContext(
                   ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ConnectionString);
            List<ProjectsViewList> p2 = (from p in SelectionContext.projects
                                         join u in SelectionContext.users on p.ProjectAdminId equals u.id into ids
                                         from x in ids.DefaultIfEmpty()
                                         select
                                             new ProjectsViewList
                                             {
                                                 Id = p.id.ToString(),
                                                 Admin = x.Allias,
                                                 Comments = p.Comments,
                                                 Allias = p.Allias,
                                                 EstFinishDate = p.EstFinishDate.ToString(),
                                                 StartDate = p.StartDate.ToString()
                                             }).ToList();

            var p1 = new ProjectsList(p2);
            return p1;
        }
        
        public NewProject GetProjectInfo(int projectId)
        {
            var SelectionContext = 
               new DataClasses1DataContext(
                   ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ConnectionString);
            NewProject project = new NewProject();
            var selectproject = from p in SelectionContext.projects select p;
            project.Title = selectproject.FirstOrDefault().Allias;
            project.StartDate = selectproject.FirstOrDefault().StartDate.ToString();
            project.EstFinishDate = selectproject.FirstOrDefault().EstFinishDate.ToString();
            project.Comments = selectproject.FirstOrDefault().Comments;
            return project;
        }

        public bool DeleteProject(int project_id)
        {
            try
            {
                var ProjectDeleteContext = new DataClasses1DataContext(
                   ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ConnectionString);
                ProjectDeleteContext.delete_project(project_id); //Project deletion stored procedure execution
                return true;
            }
            catch(Exception e)
            {

                return false;
            }
        }

        public int CreateProject(NewProject project) //returns null if ok, 1 if fails, 2 if the project with similar name already exists
        {
            try
            {
                project.ParsedStartDate = DateTime.Parse(project.StartDate);
                project.ParsedEstFinishDate = DateTime.Parse(project.EstFinishDate);
                var ProjectCreateContext = new DataClasses1DataContext(
                   ConfigurationManager.ConnectionStrings["ScrumNotesCombinerConnectionString"].ConnectionString);
                int? count = 0;
                ProjectCreateContext.check_project_existance(project.Title,ref count);
                if (count != 0)
                {
                    return 2;
                }
                int newid = ProjectCreateContext.projects.Count() + 1;
                var record = new project
                                 {
                                     Allias = project.Title,
                                     Comments = project.Comments,
                                     EstFinishDate = project.ParsedEstFinishDate,
                                     id = newid,
                                     ProjectAdminId = project.Admin,
                                     StartDate = project.ParsedStartDate
                                 };
                ProjectCreateContext.projects.InsertOnSubmit(record);
                ProjectCreateContext.projects.Context.SubmitChanges();
                return 0;
            }
            catch (Exception)
            {
                
                return 1;
            }
        }
        #endregion
    }
}