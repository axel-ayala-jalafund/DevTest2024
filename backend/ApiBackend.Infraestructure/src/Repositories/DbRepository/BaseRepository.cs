using ApiBackend.Core.src.Domain.Entity;
using ApiBackend.Core.src.Domain.Interfaces.Repositories;
using ApiBackend.Infraestructure.src.Data.DbConnection.Interfaces;
using Dapper;

namespace ApiBackend.Infraestructure.src.Repositories.DbRepository;

public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
{
    protected readonly IDbConnectionFactory _dbConnection;
    protected abstract string TableName { get; }

    public BaseRepository(IDbConnectionFactory connectionFactory)
    {
        _dbConnection = connectionFactory;
    }

    public async Task<bool> CreateAsync(T item)
    {
        using var connection = await _dbConnection.CreateConnectionAsync();
        var properties = typeof(T).GetProperties()
            .Where(p => p.Name != "Id")
            .Select(p => p.Name);


        var columns = string.Join(", ", properties);
        var values = string.Join(", ", properties.Select(p => $"@{p}"));

        var query = $"INSERT INTO {TableName} ({columns}) VALUES ({values})";
        var result = await connection.ExecuteAsync(query, item);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var connection = await _dbConnection.CreateConnectionAsync();
        var query = $"DELETE FROM {TableName} WHERE id = @Id";
        var result = await connection.ExecuteAsync(query, new { Id = id });
        return result > 0;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using var connection = await _dbConnection.CreateConnectionAsync();
        var query = $"SELECT * FROM {TableName}";
        return await connection.QueryAsync<T>(query);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        using var connection = await _dbConnection.CreateConnectionAsync();
        var query = $"SELECT * FROM {TableName} WHERE id = @Id";
        return await connection.QuerySingleOrDefaultAsync<T>(query, new { Id = id });
    }
}
