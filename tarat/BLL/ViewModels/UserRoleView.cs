using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class UserRoleView
    {
        public string UserId { get; set; }
        public IEnumerable<IdentityRole> AllRoles { get; set; }
        public IEnumerable<IdentityRole> UserRoles { get; set; }
    }
}
