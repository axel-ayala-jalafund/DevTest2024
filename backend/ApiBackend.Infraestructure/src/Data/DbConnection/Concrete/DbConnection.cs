using System.Data;
using ApiBackend.Infraestructure.src.Data.DbConnection.Interfaces;
using Microsoft.Extensions.Options;
using Npgsql;

namespace ApiBackend.Infraestructure.src.Data.DbConnection.Concrete;

public class DbConnection : IDbConnectionFactory
{
    private readonly DataBaseOptions _options;

    public DbConnection(IOptions<DataBaseOptions> options)
    {
        _options = options.Value;
    }

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new NpgsqlConnection(_options.DefaultConnection);
        await connection.OpenAsync();
        return connection;
    }
}
