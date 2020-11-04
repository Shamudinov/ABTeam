using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Logics;
using Common.Builder;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BLL.ViewModels;

namespace Web.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly MessengerLogic _messengerLogic;

        public MessageController(UserManager<User> userManager)
        {
            _userManager = userManager;
            _messengerLogic = ObjectBuilder<MessengerLogic>.Build();
        }

        [Route("messages")]
        [Authorize]
        public IActionResult Index(string id)
        {
            if (id != null)
            {
                var userId = _userManager.GetUserId(HttpContext.User);

                return Redirect("/message/send?userFromId=" + userId + "&userToId=" + id);
            }

            return View();
        }

        [Route("mail")]
        [Authorize]
        public IActionResult Mail(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (!_messengerLogic.AccessMail(id, userId))
            {
                return Redirect("/messages");
            }

            var model = _messengerLogic.GetMessageById(id);

            ViewData["id"] = id;
            return View(model);
        }

        [Authorize]
        public IActionResult Send(string userFromId, string userToId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (userId == userFromId)
                ViewData["id"] = userToId;
            else
                ViewData["id"] = userFromId;

            return View();
        }
    }
}
