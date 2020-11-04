using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DAL.Entities;
using DAL.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public class OptionBuild
        {
            public OptionBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> opsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }
        }

        public DatabaseContext() : base()
        {

        }

        public static OptionBuild ops = new OptionBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<School> schools { get; set; }
        public DbSet<Grade> grades { get; set; }
        public DbSet<UserGrades> userGrades { get; set; }
        public DbSet<Language> languages { get; set; }
        public DbSet<MailTemplate> mailTemplates { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<StudentInfo> studentInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }
    }
}
