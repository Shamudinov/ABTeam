using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int schoolId { get; set; }
        public School school { get; set; }
        public ICollection<UserGrades> TeacherGrades { get; set; }
    }
}
