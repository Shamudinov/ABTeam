using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Services
{
    public class UserService : BaseService
    {
        public UserService() : base() { }

        public IQueryable<User> GetUsers()
        {
            return context.Users;
        }

        public IQueryable<IdentityRole> GetRoles()
        {
            return context.Roles;
        }

        public IQueryable<IdentityUserRole<string>> GetUserRoles()
        {
            return context.UserRoles;
        }

        public void RemoveUserRoles(List<IdentityUserRole<string>> roles)
        {
            context.UserRoles.RemoveRange(roles);
            context.SaveChanges();
        }

        public void AddUserRoles(List<IdentityUserRole<string>> roles)
        {
            context.AddRange(roles);
            context.SaveChanges();
        }

        public void Edit(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}
