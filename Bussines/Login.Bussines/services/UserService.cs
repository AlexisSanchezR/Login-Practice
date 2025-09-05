using Login.Bussines.Interfaces;
using Login.Domain.models;
using Login.Infrastructure.Interfaces;
using Newtonsoft.Json;
using Serilog;

namespace Login.Bussines.services
{
    public class UserService : IUserService
    {
        private readonly IDataBaseRepositorie _dataBaseRepositorie;
        public UserService(IDataBaseRepositorie dataBaseRepositorie)
        {
            _dataBaseRepositorie = dataBaseRepositorie;
        }

        public async Task CreateUser(UserModel createUserModel)
        {
            try
            {
                await _dataBaseRepositorie.CreateUser(createUserModel);
            }
            catch (Exception e)
            {
                Log.Error($"Error: {JsonConvert.SerializeObject(createUserModel)}");
                throw new Exception($"{e.Message}");
            }

        }

        public async Task<UserModel> GetUserById(string userId)
        {
            var user = await _dataBaseRepositorie.getById(userId);
            try
            {
                if (user == null)
                {
                    throw new KeyNotFoundException($"Usuario no encontrado. {userId}");
                }  
            }
            catch (KeyNotFoundException)
            {
                Log.Error("There was an error finding the user by id");
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
            try
            {
                if (user == null)
                {
                    throw new KeyNotFoundException($"Usuario no encontrado. {userId}");
                }

            }
            catch (KeyNotFoundException)
            {

                Log.Error("There was an error finding the user");
            }

            // Mapeo los cambios
            user.Username = updateUserModel.Username;
            user.UserLastName = updateUserModel.UserLastName;
            user.Email = updateUserModel.Email;
            user.Password = updateUserModel.Password;


            await _dataBaseRepositorie.UpdateUser(user);
            return true;

        }
        public async Task<bool> DeleteUser(string userId)
        {
            try
            {
                var user = await _dataBaseRepositorie.getById(userId);
                if (user == null)
                {
                    throw new KeyNotFoundException($"Usuario no encontrado. {userId}");
                }
                return true;
            }
            catch (KeyNotFoundException)
            {
                Log.Error("there was an error when trying to delete user");
            }
            catch (Exception)
            {
                throw;
            }

            return false;
        }
    }
}
