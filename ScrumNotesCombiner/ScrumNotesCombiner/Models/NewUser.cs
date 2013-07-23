using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ScrumNotesCombiner.Models
{
    public class NewUser
    {
            public int id { get; set;}
            [Required(ErrorMessage = "Name not specified")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Active Directory user name not specified")]
            public string ADname { get; set; }
            [Required(ErrorMessage = "Email not specified")]
            [RegularExpression(".+\\@.+\\..+", ErrorMessage = "email is incorrect")]
            public string Email { get; set; }
            public string Comments { get; set; }
            [Required(ErrorMessage = "Не указано намерение относительно мероприятия")]
            public bool? IsSCRUMadmin { get; set; }
            public bool? ProjectRole { get; set; }

            //
            public string UserAction { get; set;}
            public bool AllowEdit { get; set; }
    }
}