using GalejSnack.DataAccess.Models;
using GalejSnack.DataAccess.Services.Interfaces;
using MongoDB.Driver;

namespace GalejSnack.DataAccess.Services;
public class ChatRepository : IChatRepository
{
    private readonly IMongoCollection<ChatMessage> _chatCollection;

    public ChatRepository()
    {
        var connectionString = "";
        var databaseName = "";
        var collectionName = "";

        var mongoClient = new MongoClient(connectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseName);
        _chatCollection = mongoDatabase.GetCollection<ChatMessage>(collectionName);
    }

    public async Task<ChatMessage> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ChatMessage>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(ChatMessage entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(ChatMessage entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}