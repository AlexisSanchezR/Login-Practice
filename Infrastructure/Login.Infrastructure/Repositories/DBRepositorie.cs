using Login.Domain.models;
using Login.Infrastructure.Interfaces;
using Npgsql;
using Serilog;

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

            var sql = $"INSERT INTO \"Login\" (\"Id\", \"Username\", \"UserLastName\", \"Email\", \"Password\", \"Phone\") VALUES (@Id,@Username,@UserLastName,@Email,@Password,@Phone)";

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

        public async Task<UserModel> getById(string userId)
        {
            var conn = await _client.GetConnection();
            string sql = "SELECT \"Id\", \"Username\", \"UserLastName\", \"Email\", \"Phone\" FROM \"Login\" WHERE \"Id\" = @id";

            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", userId);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync()) // Si hay fila
                    {
                        string id = reader.GetString(0);
                        string Username = reader.GetString(1);
                        string UserLastName = reader.GetString(2);
                        string Email = reader.GetString(3);
                        string Phone = reader.GetString(4);

                        // Crear y retornar el modelo
                        return new UserModel
                        {
                            Id = id,
                            Username = Username,
                            UserLastName = UserLastName,
                            Email = Email,
                            Phone = Phone
                        };
                    }
                    else
                    {
                        Log.Error("Usuario no encontrado.");
                        return null; // Retorna null si no hay usuario
                    }
                }
            }
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var usuarios = new List<UserModel>();
            var conn = await _client.GetConnection();

            string sql = "SELECT \"Id\", \"Username\", \"UserLastName\", \"Email\", \"Phone\" FROM \"Login\"";

            using (var command = new NpgsqlCommand(sql, conn))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    usuarios.Add(new UserModel
                    {
                        Id = reader.GetString(0),
                        Username = reader.GetString(1),
                        UserLastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        Phone = reader.GetString(4),
                    });
                }
            }

            return usuarios;
        }

        public async Task<bool> UpdateUser(UserModel updateUserModel)
        {

            var conn = await _client.GetConnection();


            var sql = @"UPDATE ""Login"" 
                SET ""Username"" = @Username, 
                    ""UserLastName"" = @UserLastName, 
                    ""Email"" = @Email, 
                    ""Password"" = @Password, 
                    ""Phone"" = @Phone
                WHERE ""Id"" = @Id";
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", updateUserModel.Id);
                cmd.Parameters.AddWithValue("@Username", updateUserModel.Username);
                cmd.Parameters.AddWithValue("@UserLastName", updateUserModel.UserLastName);
                cmd.Parameters.AddWithValue("@Password", updateUserModel.Password);
                cmd.Parameters.AddWithValue("@Email", updateUserModel.Email);
                cmd.Parameters.AddWithValue("@Phone", updateUserModel.Phone);
                
                var rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }


        public async Task deleteUser(string id)
        {
            throw new NotImplementedException();
        }

    }
}
