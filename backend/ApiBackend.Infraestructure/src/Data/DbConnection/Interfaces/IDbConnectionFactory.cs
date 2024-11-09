using System.Data;

namespace ApiBackend.Infraestructure.src.Data.DbConnection.Interfaces;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
}
