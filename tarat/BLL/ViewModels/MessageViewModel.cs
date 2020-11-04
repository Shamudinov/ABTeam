using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string UserToId { get; set; }
        public string UserToName { get; set; }
        public string UserFromId { get; set; }
        public string UserFromName { get; set; }
        public DateTime Time { get; set; }
        public int Urgency { get; set; }
    }
}
