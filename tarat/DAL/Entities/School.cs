using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
