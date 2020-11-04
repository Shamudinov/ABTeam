using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Seeds
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            RoleSeed.Seed(modelBuilder);
            UserSeed.Seed(modelBuilder);
            LanguageSeed.Seed(modelBuilder);
        }
    }
}
