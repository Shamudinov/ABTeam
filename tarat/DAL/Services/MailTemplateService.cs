using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Services
{
    public class MailTemplateService : BaseService
    {
        public MailTemplateService() : base() { }

        public IQueryable<MailTemplate> List()
        {
            return context.mailTemplates;
        }
        public void Add(MailTemplate model)
        {
            context.mailTemplates.Add(model);
            context.SaveChanges();
        }

        public void Remove(MailTemplate model)
        {
            context.mailTemplates.Remove(model);
            context.SaveChanges();
        }

        public void Edit(MailTemplate model)
        {
            context.mailTemplates.Update(model);
            context.SaveChanges();
        }
    }
}
