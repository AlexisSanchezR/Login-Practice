using Login.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Infrastructure.Interfaces
{
    public interface IDataBaseRepositorie
    {
        public Task CreateUser(UserModel createUserModel);
        public Task deleteUser(string id);
        public Task updateUser(UserModel upteUserModel);
        public Task getById(string getById);
        public Task getAll();


    }
}
