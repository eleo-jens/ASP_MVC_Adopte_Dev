using BLL.Entities;
using DO = DAL.Entities;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mapper;

namespace BLL.Services
{
    public class ClientService : IClientRepository<Client, int>
    {
        private readonly IClientRepository<DO.Client, int> _repository;

        public ClientService(IClientRepository<DO.Client, int> repository)
        {
            _repository = repository;
        }

        public Client Get(int id)
        {
            return _repository.Get(id).ToBLL(); 
        }

        public int Insert(Client entity)
        {
            return _repository.Insert(entity.ToDAL()); 
        }

        int? IAuthRepository.CheckPassword(string login, string password)
        {
            return _repository.CheckPassword(login, password); 
        }
    }
}
