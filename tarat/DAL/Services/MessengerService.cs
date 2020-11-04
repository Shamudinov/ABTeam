using DAL.DataContext;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class MessengerService : BaseService
    {
        public MessengerService() : base() { }

        public User Search(string name)
        {
            var user = context.Users.FirstOrDefault(x => (x.Name + x.Surname)
            .Contains(name) && (x.Surname + x.Name).Contains(name));
            return user;
        }

        public IQueryable<Message> List()
        {
            return context.messages;
        }

        public void Save(Message message)
        {
            message.UserFromId = message.UserFromId;
            context.Add(message);
            context.SaveChanges();
        }

        public IQueryable<Message> GetMessage(string userNameFrom, string userToId)
        {
            var model = context.messages
                .Where(x => (x.UserFrom.UserName == userNameFrom && x.UserToId == userToId) || (x.UserTo.UserName == userNameFrom && x.UserFromId == userToId));

            return model;
        }

        public async Task<Message> GetMessageByTime(DateTime time)
        {
            var model = await context.messages.FirstOrDefaultAsync(x => x.Time == time);
            return model;
        }

        public IEnumerable<User> GetUsers(string userName)
        {
            var result = context.messages.Where(x => x.UserFrom.UserName == userName).Select(x => x.UserTo).Distinct().ToList();
            result.AddRange(context.messages.Where(x => x.UserTo.UserName == userName).Select(x => x.UserFrom).Distinct().ToList());
            return result;
        }


        public async Task<IQueryable<string>> UsersInGroup(List<string> groups)
        {
            var result = context.userGrades.Where(x => groups.Contains(x.Grade.Name)).Select(x => x.User.Id);
            return result;
        }
    }
}