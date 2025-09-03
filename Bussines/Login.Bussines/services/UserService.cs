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
    public class UserService : IUserService
    {
        private readonly IDataBaseRepositorie _dataBaseRepositorie;
        public UserService(IDataBaseRepositorie dataBaseRepositorie) {
            _dataBaseRepositorie = dataBaseRepositorie;
        }

        public async Task CreateUser(UserModel createUserModel)
        {
            await _dataBaseRepositorie.CreateUser(createUserModel);
        }

        public async Task<UserModel> GetUserById(string userId)
        {
            var user = await _dataBaseRepositorie.getById(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("Usuario no encontrado.");
            }
            return user;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dataBaseRepositorie.GetAllUsers();
        }

        public async Task<bool> UpdateUser(string userId, UserModel updateUserModel)
        {
            var user = await _dataBaseRepositorie.getById(userId);
            if (user == null) return false; // No existe


            // Mapeo los cambios
            user.Username = updateUserModel.Username;
            user.UserLastName = updateUserModel.UserLastName;
            user.Email = updateUserModel.Email;
            user.Password = updateUserModel.Password;
            

            await _dataBaseRepositorie.UpdateUser(user);
            return true;

        }
    }
}
