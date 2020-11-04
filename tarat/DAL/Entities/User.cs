using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string INN { get; set; }
        public int? SchoolId { get; set; }
        public School School { get; set; }
        public ICollection<UserGrades> Grades { get; set; }
    }
}
