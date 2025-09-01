using Login.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Bussines.Interfaces
{
    public interface IUserService
    {
        public Task CreateUser(UserModel createUserModel);
        public Task<UserModel> GetUserById(string getById);
        public Task<IEnumerable<UserModel>> GetAllUsers();
    }
}
