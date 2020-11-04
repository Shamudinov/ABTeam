using AutoMapper;
using BLL.ViewModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region School
            CreateMap<School, SchoolViewModel>()
                .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
                .ForMember(x => x.Grades, x => x.MapFrom(m => m.Grades.Select(x => x.Name).ToList()));
            #endregion

            #region User

            CreateMap<User, UserViewModel>()

                .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))

                .ForMember(x => x.Name, x => x.MapFrom(m => m.Name))

                .ForMember(x => x.Surname, x => x.MapFrom(m => m.Surname))

                .ForMember(x => x.Email, x => x.MapFrom(m => m.Email))

                .ForMember(x => x.Grades, x => x.MapFrom(m => m.Grades.Select(z => z.Grade.Name).ToList()))

                .ForMember(x => x.School, x => x.MapFrom(m => m.School))

                .ForMember(x => x.Password, x => x.MapFrom(m => m.PasswordHash));

            #endregion

            #region Message

            CreateMap<Message, MessageViewModel>()

                .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))

                .ForMember(x => x.UserFromId, x => x.MapFrom(m => m.UserFromId))

                .ForMember(x => x.Subject, x => x.MapFrom(m => m.Subject))

                .ForMember(x => x.UserToId, x => x.MapFrom(m => m.UserToId))

                .ForMember(x => x.Text, x => x.MapFrom(m => m.Text))

                .ForMember(x => x.Time, x => x.MapFrom(m => m.Time))

                .ForMember(x => x.UserFromName, x => x.MapFrom(m => m.UserFrom.Name + " " + m.UserFrom.Surname))

                .ForMember(x => x.UserToName, x => x.MapFrom(m => m.UserTo.Name + " " + m.UserTo.Surname))

                .ForMember(x => x.Subject, x => x.MapFrom(m => m.Subject))

                .ForMember(x => x.Urgency, x => x.MapFrom(m => m.Urgency));

            CreateMap<MessageViewModel, Message>()

                .ForMember(x => x.UserFromId, x => x.MapFrom(m => m.UserFromId))

                .ForMember(x => x.UserToId, x => x.MapFrom(m => m.UserToId))

                .ForMember(x => x.Subject, x => x.MapFrom(m => m.Subject))

                .ForMember(x => x.Text, x => x.MapFrom(m => m.Text))

                .ForMember(x => x.Time, x => x.MapFrom(m => m.Time))

                .ForMember(x => x.Urgency, x => x.MapFrom(m => m.Urgency));

            #endregion
        }
    }
}
