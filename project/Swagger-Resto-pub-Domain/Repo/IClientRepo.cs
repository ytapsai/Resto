using System.Collections.Generic;
using Swagger_Resto_pub_DBSetup.Model;

namespace Swagger_Resto_pub_Domain.Repo
{
    public interface IClientRepo
    {
        ClientEf GetById(int id);
        IEnumerable<ClientEf> GetAll();
        void Add(ClientEf client);
        void Update(ClientEf client);
        void Delete(ClientEf client);
        ClientEf GetByName(string name);
        Dictionary<int, ClientEf> GetAllWithIds();
    }
}
