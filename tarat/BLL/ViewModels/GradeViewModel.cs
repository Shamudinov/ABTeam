using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class GradeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Tuple<string, string>> Users { get; set; }
    }
}
