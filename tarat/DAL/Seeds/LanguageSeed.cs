using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Seeds
{
    public class LanguageSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, Name = "kg"},
                new Language { Id = 2, Name = "ru" },
                new Language { Id = 3, Name = "en" }
            );
        }
    }
}
