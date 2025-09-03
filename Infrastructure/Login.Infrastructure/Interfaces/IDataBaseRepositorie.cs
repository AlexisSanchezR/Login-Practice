using Login.Domain.models;

namespace Login.Infrastructure.Interfaces
{
    public interface IDataBaseRepositorie
    {
        public Task CreateUser(UserModel createUserModel);
        public Task deleteUser(string id);
        public Task<bool> UpdateUser(UserModel updateUserModel);
        public Task<UserModel> getById(string getById);
        public Task<List<UserModel>> GetAllUsers();
    }
}
