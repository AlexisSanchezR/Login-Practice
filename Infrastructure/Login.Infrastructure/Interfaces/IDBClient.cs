using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Infrastructure.Interfaces
{
    public interface IDBClient
    {
        public Task<NpgsqlConnection> GetConnection();
    }
}
