using System;
using System.Configuration;
using System.IO;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Swagger_Resto_pub_DBSetup;
using Swagger_Resto_pub_Domain.Repo;
using Swagger_Resto_pub_Domain.UnitofWork;

namespace Swagger_Test_Wpf_Admin
{
    public partial class App : Application
    {
        private readonly IConfiguration _configuration;
        private AppDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public App()
        {
            _unitOfWork = new UnitOfWork(_dbContext);
            // Build the configuration
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            // Create an instance of AppDbContext with the connection string
            string connectionString = _configuration.GetConnectionString("DatabaseString");
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            _dbContext = new AppDbContext(options);

            // Create an instance of ClientRepo with the AppDbContext instance
            var clientRepo = new ClientRepo(_dbContext);

            // Create an instance of DomainController with the ClientRepo instance
            var domainController = new DomainController(_unitOfWork);

            MainWindow mainWindow = new MainWindow(_dbContext);
            mainWindow.Show();
        }

        
    }
}
