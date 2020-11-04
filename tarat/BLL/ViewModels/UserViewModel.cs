using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string School { get; set; }
        public string INN { get; set; }
        public IEnumerable<string> Grades { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
