using Microsoft.EntityFrameworkCore;
using Swagger_Resto_pub_DBSetup;
using Swagger_Resto_pub_Domain.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swagger_Resto_pub_Domain.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public IClientRepo ClientRepo { get; set; }

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            ClientRepo = new ClientRepo(_dbContext);

        }
    }
}
