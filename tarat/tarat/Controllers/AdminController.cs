using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Logics;
using BLL.ViewModels;
using DAL.Entities;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            var list = _userManager.Users.Include(x => x.School).Include(x => x.Grades).ThenInclude(x => x.Grade).ToList();

            return View(list);
        }
        public IActionResult UserEdit(string id)
        {
            var model = new UserRoleView();
            model.AllRoles = AccountLogic.GetRoles();
            model.UserRoles = AccountLogic.GetUserRoles(id);
            model.UserId = id;

            return View(model);
        }
        public IActionResult UserSaveRole(List<string> roles, string userId)
        {
            AccountLogic.EditUserRole(userId, roles);

            return Redirect("/Admin");
        }
        public IActionResult Create()
        {
            var list = SchoolLogic.List();
            return View(list);
        }
        public IActionResult Add(UserViewModel model)
        {
            var school = SchoolLogic.GetByName(model.School);

            var user = new User();
            user.UserName = model.Email;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.SchoolId = school.Id;
            
            var result = _userManager.CreateAsync(user, model.Password);
            result.Wait();
            var tAddRole = _userManager.AddToRoleAsync(user, model.Role);
            tAddRole.Wait();

            return Redirect("/Admin");
        }
        public IActionResult Schools()
        {
            var list = SchoolLogic.List();
            return View(list);
        }
        public IActionResult SchoolEdit(int id)
        {
            var school = SchoolLogic.GetById(id);

            return View(school);
        }
        public IActionResult SchoolCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SchoolAdd(string name)
        {
            SchoolLogic.Add(name);
            return Redirect("/Admin/Schools");
        }
        [HttpPost]
        public IActionResult SchoolSave(int id, string name)
        {
            SchoolLogic.EditName(id, name);
            return Redirect("/Admin/SchoolEdit?id=" + id.ToString());
        }
        [HttpPost]
        public IActionResult GradeAdd(int schoolId, string name)
        {
            SchoolLogic.AddGrade(schoolId, name);
            return Redirect("/Admin/SchoolEdit?id=" + schoolId.ToString());
        }
        public IActionResult GradeSave(int schoolId, int id, string name)
        {
            SchoolLogic.EditGrade(id, name);
            return Redirect("/Admin/SchoolEdit?id=" + schoolId.ToString());
        }

        public IActionResult MessageTemplates()
        {
            var list = EmailLogic.MailTemplateList();
            return View(list);
        }
        public IActionResult CreateMessageTemplate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMessageTemplate(MailTemplate model)
        {
            EmailLogic.AddMailTemplate(model);
            return Redirect("/Admin/MessageTemplates");
        }
        public IActionResult EditMessageTemplate(int id)
        {
            var model = EmailLogic.MailTemplateList().First(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditMessageTemplate(MailTemplate model)
        {
            EmailLogic.EditMailTemplate(model);
            return Redirect("/Admin/MessageTemplates");
        }
        public IActionResult DeleteMessageTemplate(int id)
        {
            EmailLogic.DeleteMailTemplate(id);
            return Redirect("/Admin/MessageTemplates");
        }
        public IActionResult StudentAddExcel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExcel(IFormFile file)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = file.OpenReadStream())
            {
                var list = new List<StudentInfo>();

                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    bool isFirst = true;

                    while (reader.Read())
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                            continue;
                        }

                        if (reader.GetValue(0) == null)
                            break;

                        var model = new StudentInfo();

                        model.INN = reader.GetValue(0).ToString();
                        model.Surname = reader.GetValue(1).ToString();
                        model.Name = reader.GetValue(2).ToString();
                        model.School = reader.GetValue(3).ToString();
                        model.Grade = reader.GetValue(4).ToString();

                        list.Add(model);
                    }

                    AccountLogic.AddStudentsInfo(list);
                }
            }
            return Redirect("/Admin");
        }
    }
}
