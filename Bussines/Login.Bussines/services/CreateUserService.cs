using Login.Bussines.Interfaces;
using Login.Domain.models;
using Login.Infrastructure.Cliente;
using Login.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Bussines.services
{
    public class CreateUserService : ICreateUserService
    {
        private readonly IDataBaseRepositorie _dataBaseRepositorie;
        public CreateUserService(IDataBaseRepositorie dataBaseRepositorie) {
            _dataBaseRepositorie = dataBaseRepositorie;
        }
        public async Task CreateUser(UserModel createUserModel)
        {
            await _dataBaseRepositorie.CreateUser(createUserModel);
        }
    }
}
