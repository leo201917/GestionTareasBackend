using System.Data;
using Microsoft.Data.SqlClient;

namespace GestionTareas.Infraestructura.Persistencia.Conexion
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString)
        {
            Console.WriteLine("CTOR DbConnectionFactory CS = " + connectionString);

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("ConnectionString vacía", nameof(connectionString));

            _connectionString = connectionString;
        }

        public IDbConnection Create()
        {
            Console.WriteLine("Create() CS len = " + (_connectionString?.Length ?? -1));
            return new Microsoft.Data.SqlClient.SqlConnection(_connectionString);
        }

    }
}
