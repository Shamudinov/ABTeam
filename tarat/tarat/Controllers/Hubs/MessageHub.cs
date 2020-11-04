using BLL.Logics;
using BLL.ViewModels;
using Common.Builder;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers.Hubs
{
    public class MessageHub : Hub
    {
        private readonly MessengerLogic messengerLogic;

        public MessageHub()
        {
            messengerLogic = ObjectBuilder<MessengerLogic>.Build();
        }

        /*public async Task Send(string text, string to)
        {
            var message = new MessageViewModel() { Text = text, UserToId = to, UserFromId = Context.User.Identity.Name, Time = DateTime.Now };
            await messengerLogic.Save(message);
            if (Context.UserIdentifier != message.UserToId) // если получатель и текущий пользователь не совпадают
                await Clients.User(Context.UserIdentifier).SendAsync("Receive", message);
            await Clients.User(message.UserToId).SendAsync("Receive", message);
        }*/

        public async Task SendGroups(List<string> students, string time)
        {
            var model = await messengerLogic.GetMessageByTime(time);
            await Clients.Users(students).SendAsync("Receive", model);
        }
    }
}