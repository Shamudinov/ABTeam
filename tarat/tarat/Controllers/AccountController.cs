using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BLL.Logics;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("Login")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (returnUrl == null)
                returnUrl = "/";

            if (User.Identity.IsAuthenticated)
            {
                return Redirect(returnUrl);
            }

            ViewData["returnUrl"] = returnUrl;
            return View();  
        }

        [Route("Registry")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registry()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View();
        }

        [Route("Logout")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Logout()
        {
            var task = _signInManager.SignOutAsync();

            task.Wait();

            return Redirect("/Login");
        }

        [Route("Distribution")]
        [Authorize(Roles = "Manager")]
        public IActionResult Distribution()
        {
            return View();
        }
        
        [Route("EditGrade")]
        [Authorize(Roles = "Manager")]
        public IActionResult EditGrade(string id)
        {
            var grades = AccountLogic.GetTeacherGradesWithUsers(id);
            var user = _userManager.Users.First(x => x.Id == id);

            if (grades == null)
            {
                grades = new List<Grade>();
            }

            var list = _userManager.Users.Include(x => x.School.Grades)
                .First(x => x.Id == id).School.Grades
                .Select(x => new Tuple<Grade, bool> (x, grades.Any(y => x.Id == y.Id)))
                .ToList();

            return View(new Tuple<List<Tuple<Grade, bool>>, string, string>(list, id, user.Name + " " + user.Surname));
        }

        [Authorize(Roles = "Manager")]
        public IActionResult SaveTeacherGrades(string userId, int[] grade)
        {
            AccountLogic.TeacherGradeSave(userId, grade);
            return Redirect("/Distribution");
        }

        [Route("UserList")]
        [Authorize]
        public IActionResult UserList()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var userRoles = _userManager.GetRolesAsync(user).Result;

            var list = AccountLogic.GetAccessUser(user, userRoles.ToList())
                .Select(x => new Tuple<User, bool>(x, _userManager.GetRolesAsync(x).Result.Contains("Student")))
                .OrderBy(x => x.Item2)
                .ToList();

            return View(list);
        }
    }
}
