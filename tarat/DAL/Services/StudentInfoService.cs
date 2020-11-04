using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Services
{
    public class StudentInfoService : BaseService
    {
        public StudentInfoService() : base() { }

        public IQueryable<StudentInfo> List()
        {
            return context.studentInfos;
        }
        public void Add(StudentInfo model)
        {
            context.studentInfos.Add(model);
            context.SaveChanges();
        }

        public void AddRange(List<StudentInfo> list)
        {
            context.AddRange(list);
            context.SaveChanges();
        }

        public void Remove(StudentInfo model)
        {
            context.studentInfos.Remove(model);
            context.SaveChanges();
        }

        public void Edit(StudentInfo model)
        {
            context.studentInfos.Update(model);
            context.SaveChanges();
        }
    }
}
