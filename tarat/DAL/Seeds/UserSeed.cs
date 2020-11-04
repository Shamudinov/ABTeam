using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Seeds
{
    public static class UserSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = "1", UserName = "admin@gmail.com", NormalizedUserName ="ADMIN@GMAIL.COM", Email = "admin@gmail.com", PasswordHash = "AQAAAAEAACcQAAAAEAOdA7GmNJmKoW8wqllczD1w4HqU/dVP2db/RI7XKHoF9R+Pczges5nA+KBLIYAgJQ==", ConcurrencyStamp = "c6ce248d-0026-41ae-b41c-b7684f0baba8", SecurityStamp = "68c210af-b666-41f3-9cc7-4cc40efa5f9e" }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { UserId = "1", RoleId = "50209db0-e4a4-4d6e-92cb-2777a86e5f37" },
                new IdentityUserRole<string>() { UserId = "1", RoleId = "d8ab412f-b321-4b26-8172-a5d075603dd3" },
                new IdentityUserRole<string>() { UserId = "1", RoleId = "edb57926-50f6-4493-aad2-e1e657d05495" },
                new IdentityUserRole<string>() { UserId = "1", RoleId = "edb57926-50f6-4493-aad2-e1e657d05490" }
            );
        }
    }
}
