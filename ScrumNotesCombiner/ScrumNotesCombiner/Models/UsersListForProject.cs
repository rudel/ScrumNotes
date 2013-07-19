using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumNotesCombiner.Models
{
    public class UsersViewListForProject
    {
        public int Id { get; set; }
        public string Allias { get; set; }
        public string ADusername { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
    
    public class UsersListForProject
    {
        public List<UsersViewListForProject> UsersDbListForProject { set; get;}
        public UsersListForProject(List<UsersViewListForProject> userlist)
        {
            UsersDbListForProject = userlist;
        }
    }
}