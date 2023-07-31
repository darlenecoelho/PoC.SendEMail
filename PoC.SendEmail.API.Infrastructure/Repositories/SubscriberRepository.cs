using Dapper;
using PoC.SendEmail.API.Domain.Interfaces;
using PoC.SendEmail.API.Domain.Models;
using System.Data;

namespace PoC.SendEmail.API.Infrastructure.Repositories;
public class SubscriberRepository : ISubscriberRepository
{
    private readonly IDbConnection _connection;

    public SubscriberRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<int> Add(Subscriber subscriber)
    {
        subscriber.DateCreated = DateTime.Now;
        string query = "INSERT INTO Subscribers (Email, DateCreated) VALUES (@Email, @DateCreated); SELECT LAST_INSERT_ID();";
        return await _connection.ExecuteScalarAsync<int>(query, subscriber);
    }

    public async Task<bool> GetByEmail(string email)
    {
        string existsQuery = "SELECT 1 FROM Subscribers WHERE Email = @Email LIMIT 1;";
        return await _connection.ExecuteScalarAsync<bool>(existsQuery, new { Email = email });
    }

    public async Task<IEnumerable<Subscriber>> GetAllSubscribers()
    {
        string query = "SELECT * FROM Subscribers;";
        return await _connection.QueryAsync<Subscriber>(query);
    }
}

