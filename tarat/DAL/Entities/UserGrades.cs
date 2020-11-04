using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserGrades
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}
