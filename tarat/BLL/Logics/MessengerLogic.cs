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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Logics
{

    public class MessengerLogic
    {

        static MessengerService messengerService;

        static IMapper mapper;


        static MessengerLogic()
        {

            messengerService = ObjectBuilder<MessengerService>.Build();

            mapper = MapBuilder.Build();

        }


        public UserViewModel Search(string name)
        {
            string searchingName = "";

            foreach (var v in name)

            {

                if (v != ' ')

                {

                    searchingName += v;

                }

            }

            var serviceUser = messengerService.Search(searchingName);

            var resultUser = mapper.Map<User, UserViewModel>(serviceUser);

            return resultUser;
        }

        public bool AccessMail(int id, string userId)
        {
            return messengerService.List().Any(x => x.Id == id && (x.UserFromId == userId || x.UserToId == userId));
        }

        public MessageViewModel GetMessageById(int id)
        {
            var model = messengerService.List().Include(x => x.UserFrom).Include(x => x.UserTo).First(x => x.Id == id);

            return mapper.Map<Message, MessageViewModel>(model);
        }

        public async Task<MessageViewModel> GetMessageByTime(string time) 
        {
            var model = await messengerService.GetMessageByTime(Convert.ToDateTime(time));

            return mapper.Map<Message, MessageViewModel>(model);
        }

        public void Save(MessageViewModel message)
        {
            var model = mapper.Map<MessageViewModel, Message>(message);

            messengerService.Save(model);
        }


        public IEnumerable<MessageViewModel> GetMessage(string userNameFrom, string userToId)
        {
            var result = messengerService.GetMessage(userNameFrom, userToId).ToList();

            var mapResult = mapper.Map<List<Message>, List<MessageViewModel>>(result);

            return mapResult;

        }


        public IEnumerable<UserViewModel> GetUsers(string userName)
        {
            var result = messengerService.GetUsers(userName).Distinct().ToList();

            var mapResult = mapper.Map<List<User>, List<UserViewModel>>(result);

            return mapResult;

        }

        public List<MessageViewModel> GetMessagesFrom(string userId)
        {
            var list = messengerService.List()
                .Where(x => x.UserFromId == userId)
                .Include(x => x.UserFrom)
                .Include(x => x.UserTo)
                .OrderByDescending(x => x.Time).ToList();
            
            return mapper.Map<List<Message>, List<MessageViewModel>>(list);
        }

        public List<MessageViewModel> GetMessagesTo(string userId)
        {
            var list = messengerService.List()
                .Where(x => x.UserToId == userId)
                .Include(x => x.UserFrom)
                .Include(x => x.UserTo)
                .OrderByDescending(x => x.Time).ToList();

            return mapper.Map<List<Message>, List<MessageViewModel>>(list);
        }

        public IEnumerable<MessageViewModel> GetMessages(string userId1, string userId2)
        {
            var list = messengerService.List()
                .Where(x => (x.UserFromId == userId1 && x.UserToId == userId2) || (x.UserFromId == userId2 && x.UserToId == userId1))
                .ToList();

            return mapper.Map<List<Message>, List<MessageViewModel>>(list);
        }

        public async Task<IEnumerable<string>> UsersInGroup(List<string> groups)
        {
            var result = await messengerService.UsersInGroup(groups);

            var model = result.ToList();

            return model;

        }
    }
}