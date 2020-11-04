using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContext
{
    public class DatabaseContextBuilder
    {
        static DatabaseContext context;

        public static DatabaseContext Build()
        {
            if (context == null)
            {
                context = new DatabaseContext(DatabaseContext.ops.dbOptions);
            }

            return context;
        }
    }
}
