using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL.Logics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tarat.Models;
using BLL.Models;
using Microsoft.AspNetCore.Identity;
using DAL.Entities;

namespace tarat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var userRoles = _userManager.GetRolesAsync(user).Result;

            if (userRoles.Count() == 1 && userRoles.Contains("Student"))
                return Redirect("/messages");

            ViewData["SchoolId"] = user.SchoolId;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
