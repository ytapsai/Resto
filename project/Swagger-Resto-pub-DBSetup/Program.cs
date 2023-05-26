using System;
using Microsoft.EntityFrameworkCore;
using Swagger_Resto_pub_DBSetup;

namespace Swagger_Resto_pub_DBSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure the SQL Server connection
            string connectionString = @"Server=.\SQLEXPRESS;Database=Restopub;Trusted_Connection=True;TrustServerCertificate=true;";

            // Create DbContext options with the connection string
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Create an instance of AppDbContext
            using (var dbContext = new AppDbContext(optionsBuilder.Options))
            {
                dbContext.DeleteAndCreateDatabase();
            }


        }
    }
}
