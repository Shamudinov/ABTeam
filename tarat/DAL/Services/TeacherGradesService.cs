using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Services
{
    public class UserGradesService : BaseService
    {
        public UserGradesService() : base() { }

        public IQueryable<UserGrades> List()
        {
            return context.userGrades;
        }

        public void Add(UserGrades model)
        {
            context.userGrades.Add(model);
            context.SaveChanges();
        }
        public void Edit(UserGrades model)
        {
            context.userGrades.Update(model);
            context.SaveChanges();
        }
        public void Remove(UserGrades model)
        {
            context.userGrades.Remove(model);
            context.SaveChanges();
        }
    }
}
