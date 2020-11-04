using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Subject { get; set;  }
        [StringLength(10000)]
        public string Text { get; set; }
        public string UserToId { get; set; }
        public User UserTo { get; set; }
        public string UserFromId { get; set; }
        public User UserFrom { get; set; }
        public DateTime Time { get; set; }
        public int Urgency { get; set; } 
    }
}