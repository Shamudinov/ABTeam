using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class UserMessageViewModel
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }
        public int Urgency { get; set; }
    }
}
