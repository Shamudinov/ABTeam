using DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services
{
    public class BaseService
    {
        protected DatabaseContext context { get; private set; }
        public BaseService()
        {
            context = DatabaseContextBuilder.Build();
        }
    }
}
