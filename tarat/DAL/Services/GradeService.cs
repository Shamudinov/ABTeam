using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Services
{
    public class GradeService : BaseService
    {
        public GradeService() : base() { }

        public IQueryable<Grade> List()
        {
            return context.grades;
        }
        public void Add(Grade model)
        {
            context.grades.Add(model);
            context.SaveChanges();
        }

        public void Remove(Grade model)
        {
            context.grades.Remove(model);
            context.SaveChanges();
        }

        public void Edit(Grade model)
        {
            context.grades.Update(model);
            context.SaveChanges();
        }
    }
}
