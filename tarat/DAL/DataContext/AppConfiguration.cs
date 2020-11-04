using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DAL.DataContext
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var connection = root.GetSection("ConnectionStrings:DefaultConnection");
            sqlConnectionString = connection.Value;


        }

        public string sqlConnectionString { get; private set; }
    }
}
