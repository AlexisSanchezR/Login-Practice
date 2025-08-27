using Login.Infrastructure.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Infrastructure.Cliente
{
    public class DBClient : IDBClient
    {
        private readonly string _dbConnectionString;
        public DBClient(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }
        public async Task<NpgsqlConnection> GetConnection()
        {
            var connection = new NpgsqlConnection(_dbConnectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
