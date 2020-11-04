using AutoMapper;
using BLL.AutoMapper;
using BLL.Models;
using Common.Builder;
using DAL.Entities;
using DAL.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logics
{
    public class EmailLogic
    {
        static MailTemplateService mailTemplateService;
        static IMapper mapper;

        static EmailLogic()
        {
            mailTemplateService = ObjectBuilder<MailTemplateService>.Build();
            mapper = MapBuilder.Build();
        }

        public async static Task Send(MailModel _mail)
        {
            if (_mail.From == null)
            {
                _mail.From = "skoool.sender@gmail.com";
            }

            var mail = new MailMessage();
            mail.To.Add(_mail.To);
            mail.From = new MailAddress(_mail.From);
            mail.Subject = _mail.Subject;
            string Body = _mail.Body;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("skoool.sender@gmail.com", "PFqW^4+=66yk");  
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

        public static object GetTemplates()
        {
            return mailTemplateService.List().OrderBy(x => x.LanguageId).ToList();
        }

        public static IEnumerable<MailTemplate> GetTemplatesByLang(string lang)
        {
            return mailTemplateService.List().Include(x => x.Language).Where(x => x.Language.Name == lang).ToList();
        }

        public static void AddMailTemplate(MailTemplate mail)
        {
            mailTemplateService.Add(mail);
        }

        public static IEnumerable<MailTemplate> MailTemplateList()
        {
            return mailTemplateService.List().Include(x => x.Language).ToList();
        }

        public static void EditMailTemplate(MailTemplate _model)
        {
            var model = mailTemplateService.List().First(x => x.Id == _model.Id);
            model.Body = _model.Body;
            model.Subject = _model.Subject;
            model.LanguageId = _model.LanguageId;

            mailTemplateService.Edit(model);
        }

        public static void DeleteMailTemplate(int id)
        {
            var model = mailTemplateService.List().First(x => x.Id == id);
            mailTemplateService.Remove(model);
        }
    }
}
