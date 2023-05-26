using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Swagger_Resto_pub_DBSetup;

namespace Swagger_Resto_pub_DBAdd
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Get the base directory of the application
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Construct the relative path to the Data.sql file
                string dataFilePath = Path.Combine(baseDirectory, "Data", "Data.sql");

                // Read the SQL script from the file
                string sqlScript = File.ReadAllText(dataFilePath);

                // Configure the SQL Server connection
                string connectionString = @"Server=.\SQLEXPRESS;Database=Restopub;Trusted_Connection=True;TrustServerCertificate=true;";

                // Create DbContext options with the connection string
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer(connectionString);

                // Create an instance of AppDbContext
                using var dbContext = new AppDbContext(optionsBuilder.Options);
                
                    // Execute the SQL script
                    dbContext.Database.ExecuteSqlRaw(sqlScript);

                    Console.WriteLine("Data succesvol Toegevoegd.");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error tijdens toevoegen data: " + ex.Message);
            }
        }
    }
}
