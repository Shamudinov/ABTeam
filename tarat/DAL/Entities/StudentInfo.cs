using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class StudentInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [StringLength(14, MinimumLength = 14)]
        public string INN { get; set; }
        public string School { get; set; }
        public string Grade { get; set; }
    }
}
