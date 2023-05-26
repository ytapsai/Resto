using Microsoft.EntityFrameworkCore;
using Swagger_Resto_pub_Domain.Repo;

namespace Swagger_Resto_pub_Domain.UnitofWork
{
    public interface IUnitOfWork
    {
        public IClientRepo ClientRepo { get; }



    }
}
