using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Services
{
    public class SchoolService : BaseService
    {
        public SchoolService() : base() { }

        public IQueryable<School> List()
        {
            return context.schools;
        }

        public void Edit(School model)
        {
            context.schools.Update(model);
            context.SaveChanges();
        }
        public void Add(School model)
        {
            context.schools.Add(model);
            context.SaveChanges();
        }
    }
}
