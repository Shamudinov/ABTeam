using AutoMapper;
using BLL.AutoMapper;
using BLL.ViewModels;
using Common.Builder;
using DAL.Entities;
using DAL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BLL.Logics
{
    public class AccountLogic
    {
        static UserService userService;
        static UserGradesService userGradesService;
        static GradeService gradeService;
        static StudentInfoService studentInfoService;
        
        static IMapper mapper;

        static AccountLogic()
        {
            userService = ObjectBuilder<UserService>.Build();
            userGradesService = ObjectBuilder<UserGradesService>.Build();
            gradeService = ObjectBuilder<GradeService>.Build();
            studentInfoService = ObjectBuilder<StudentInfoService>.Build();
            mapper = MapBuilder.Build();
        }

        public static IEnumerable<User> GetUsers()
        {
            return userService.GetUsers().ToList();
        }

        public static void EditUserRole(string userId, List<string> roles)
        {
            var listRoles = userService.GetUserRoles().Where(x => x.UserId == userId);

            var deleteRoles = listRoles.Where(x => !roles.Contains(x.RoleId)).ToList();
            userService.RemoveUserRoles(deleteRoles);

            var addRoles = new List<IdentityUserRole<string>>();
            foreach (var roleId in roles.Where(x => !listRoles.Any(y => y.RoleId == x)))
            {
                addRoles.Add(new IdentityUserRole<string> { RoleId = roleId, UserId = userId });
            }
            userService.AddUserRoles(addRoles);
        }

        public static User GetUser(string userName)
        {
            return userService.GetUsers().FirstOrDefault(x => x.UserName == userName);
        }

        public static IEnumerable<IdentityRole> GetRoles()
        {
            return userService.GetRoles().ToList();
        }

        public static IEnumerable<IdentityRole> GetUserRoles(string userId)
        {
            var list = userService.GetUserRoles().Where(x => x.UserId == userId).Select(x => x.RoleId).ToList();

            return userService.GetRoles().Where(x => list.Contains(x.Id));
        }
        
        public static List<Grade> GetTeacherGradesWithUsers(string userId)
        {
            var list = gradeService.List()
                .Include(x => x.TeacherGrades)
                .ThenInclude(x => x.User)
                .Where(x => x.TeacherGrades.Any(x => x.UserId == userId))
                .ToList();

            return list;
        }

        public static void TeacherGradeSave(string userId, int[] grade)
        {
            var userGrades = userGradesService.List().Where(x => x.UserId == userId).ToList();
            var removeList = userGrades.Where(x => !grade.Contains(x.GradeId)).ToList();
            var addList = grade.Where(x => !userGrades.Any(y => y.GradeId == x)).ToList();

            foreach(var item in removeList)
            {
                userGradesService.Remove(item);
            }
            foreach (var item in addList)
            {
                userGradesService.Add(new UserGrades { UserId = userId, GradeId = item });
            }
        }

        public static IEnumerable<User> GetAccessUser(User user, List<string> roles)
        {
            var list = userService.GetUsers().Include(x => x.Grades).ThenInclude(x => x.Grade).ThenInclude(x => x.school).ToList();

            if (roles.Contains("Admin"))
                return list;

            if (roles.Contains("Manager"))
                return list.Where(x => x.SchoolId == user.SchoolId).ToList();

            var gradeList = GetTeacherGradesWithUsers(user.Id);
            return list.Where(x => x.Grades.Any(y => gradeList.Any(z => z.Id == y.GradeId))).ToList();
        }
        
        public static void AddStudentsInfo(List<StudentInfo> list)
        {
            studentInfoService.AddRange(list);
        }
    }
}
