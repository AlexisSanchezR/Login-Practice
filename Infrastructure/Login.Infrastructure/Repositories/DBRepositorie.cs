using Login.Domain.models;
using Login.Infrastructure.Interfaces;
using Npgsql;

namespace Login.Infrastructure.Repositories
{
    public class DBRepositorie : IDataBaseRepositorie
    {
        private readonly IDBClient _client;
        public DBRepositorie(IDBClient DBClient)
        {
            _client = DBClient;
        }
        public async Task CreateUser(UserModel createUserModel)
        {

            var conn = await _client.GetConnection();

            var sql = $"INSERT INTO Login (Id,Email,Password,Username,UserLastName,Phone) VALUES (@Id,@Email,@Password,@Username,@UserLastName,@Phone)";

            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                // Usa parámetros para prevenir inyección SQL
                cmd.Parameters.AddWithValue("@Id", createUserModel.Id);
                cmd.Parameters.AddWithValue("@Email", createUserModel.Email);
                cmd.Parameters.AddWithValue("@Password", createUserModel.Password);
                cmd.Parameters.AddWithValue("@Username", createUserModel.Username);
                cmd.Parameters.AddWithValue("@UserLastName", createUserModel.UserLastName);
                cmd.Parameters.AddWithValue("@Phone", createUserModel.Phone);
                await cmd.ExecuteNonQueryAsync(); // Ejecuta la consulta INSERT
            }
        }

        public async Task deleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task getAll()
        {
            throw new NotImplementedException();
        }

        public async Task getById(string getById)
        {
            throw new NotImplementedException();
        }

        public async Task updateUser(UserModel upteUserModel)
        {
            throw new NotImplementedException();
        }
    }
}
