using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class MailTemplate
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
