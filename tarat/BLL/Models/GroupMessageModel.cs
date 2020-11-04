using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class GroupMessageModel
    {
        public List<string> Grades { get; set; }
        public List<string> Users { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Time { get; set; }
        public int Urgency { get; set; }
    }
}
