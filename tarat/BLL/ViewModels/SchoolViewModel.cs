﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class SchoolViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Grades { get; set; }
    }
}
