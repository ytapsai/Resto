using System.Collections.Generic;
using Swagger_Resto_pub_DBSetup.Model;
using Swagger_Resto_pub_Domain.UnitofWork;

namespace Swagger_Resto_pub_Domain.Repo
{
    public class DomainController
    {
        private readonly IUnitOfWork _unitOfWork;

        public DomainController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ClientEf GetById(int id)
        {
            return _unitOfWork.ClientRepo.GetById(id);
        }

        public IEnumerable<ClientEf> GetAll()
        {
            return _unitOfWork.ClientRepo.GetAll();
        }

        public void Add(ClientEf client)
        {
            _unitOfWork.ClientRepo.Add(client);
              
        }

        public void Update(ClientEf client)
        {
            _unitOfWork.ClientRepo.Update(client);
                                
        }

        public void Delete(ClientEf client)
        {
            _unitOfWork.ClientRepo.Delete(client);
        
        }

        public ClientEf GetByName(string name)
        {
            return _unitOfWork.ClientRepo.GetByName(name);
        }

        public Dictionary<int, ClientEf> GetAllWithIds()
        {
            return _unitOfWork.ClientRepo.GetAllWithIds();
        }

      
    }
}
