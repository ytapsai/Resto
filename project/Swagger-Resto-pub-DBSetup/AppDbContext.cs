using Microsoft.EntityFrameworkCore;

using Swagger_Resto_pub_DBSetup.Model;
using System;
using System.Linq;

namespace Swagger_Resto_pub_DBSetup
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClientEf> Clients { get; set; }
        public DbSet<DishEf> Dishes { get; set; }
        public DbSet<OrderEf> Orders { get; set; }
        public DbSet<OrderDishEf> OrderDishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configureer de SQL Server verbinding
            string connectionString = @"Server=.\SQLEXPRESS;Database=Restopub;Trusted_Connection=True;TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definieer de primaire sleutel voor OrderDishEf als samengestelde sleutel van OrderId en DishId
            modelBuilder.Entity<OrderDishEf>()
                .HasKey(od => new { od.OrderId, od.DishId });

            // Configureer de relatie tussen OrderDishEf en OrderEf
            modelBuilder.Entity<OrderDishEf>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDishes)
                .HasForeignKey(od => od.OrderId);

            // Configureer de relatie tussen OrderDishEf en DishEf
            modelBuilder.Entity<OrderDishEf>()
                .HasOne(od => od.Dish)
                .WithMany(d => d.OrderDishes)
                .HasForeignKey(od => od.DishId);

            base.OnModelCreating(modelBuilder);
        }

        public void DeleteAndCreateDatabase()
        {
            bool databaseExists = Database.CanConnect();

            if (databaseExists)
            {
                Database.EnsureDeleted(); // Verwijder alle tabellen
                Console.WriteLine("Database tabellen verwijderd");
            }

            Database.EnsureCreated(); // Maak nieuwe tabellen aan
            Console.WriteLine("Database succesvol aangemaakt.");

           
        }

    }
}
