using Login.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Bussines.Interfaces
{
    public interface ICreateUserService
    {
        public Task CreateUser(UserModel createUserModel);
    }
}
