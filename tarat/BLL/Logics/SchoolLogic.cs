using AutoMapper;
using BLL.AutoMapper;
using BLL.ViewModels;
using Common.Builder;
using DAL.Entities;
using DAL.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Logics
{
    public class SchoolLogic
    {
        static SchoolService _schoolService;
        static GradeService _gradeService;
        static IMapper _mapper;
        static SchoolLogic()
        {
            _schoolService = ObjectBuilder<SchoolService>.Build();
            _gradeService = ObjectBuilder<GradeService>.Build();
            _mapper = MapBuilder.Build();
        }

        public static IEnumerable<SchoolViewModel> List()
        {
            var list = _schoolService.List().Include(x => x.Grades).ToList();
            
            return _mapper.Map<List<School>, List<SchoolViewModel>>(list);
        }

        public static School GetByName(string name)
        {
            return _schoolService.List().Include(x => x.Grades).First(x => x.Name == name);
        }

        public static School GetById(int id)
        {
            return _schoolService.List().Include(x => x.Grades).First(x => x.Id == id);
        }

        public static void EditName(int id, string name)
        {
            var model = _schoolService.List().First(x => x.Id == id);
            model.Name = name;

            _schoolService.Edit(model);
        }

        public static void AddGrade(int schoolId, string name)
        {
            var model = new Grade { Name = name, schoolId = schoolId };
            _gradeService.Add(model);
        }
        public static void DeleteGrade(int id)
        {
            var model = _gradeService.List().First(x => x.Id == id);
            _gradeService.Remove(model);
        }

        public static void EditGrade(int id, string name)
        {
            var model = _gradeService.List().First(x => x.Id == id);
            model.Name = name;

            _gradeService.Edit(model);
        }

        public static void Add(string name)
        {
            var model = new School { Name = name };
            _schoolService.Add(model);
        }
    }
}
