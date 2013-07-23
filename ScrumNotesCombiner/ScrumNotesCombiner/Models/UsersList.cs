using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumNotesCombiner.Models
{
    public class UsersList
    {
        public List<User> UsersViewList { get; set;}
    }
    public class User
    {
        public int Id { get; set; }
        public string Allias { get; set; }
        public string ADusername { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }

}