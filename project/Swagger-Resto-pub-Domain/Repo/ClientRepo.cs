using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Swagger_Resto_pub_DBSetup;
using Swagger_Resto_pub_DBSetup.Model;

namespace Swagger_Resto_pub_Domain.Repo
{
    public class ClientRepo : IClientRepo
    {
        private readonly AppDbContext _dbContext;

        public ClientRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ClientEf GetById(int id)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<ClientEf> GetAll()
        {
            return _dbContext.Clients.ToList();
        }

        public void Add(ClientEf client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }

        public void Update(ClientEf client)
        {
            _dbContext.Clients.Update(client);
            _dbContext.SaveChanges();
        }

        public void Delete(ClientEf client)
        {
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
        }

        public ClientEf GetByName(string name)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.FirstName == name);
        }

        public Dictionary<int, ClientEf> GetAllWithIds()
        {
            return _dbContext.Clients.ToDictionary(c => c.Id, c => c);
        }
    }
}
