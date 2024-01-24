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
        return await _chatCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<ChatMessage>> GetAllAsync()
    {
        return await _chatCollection.Find(x => true).ToListAsync();
    }

    public async Task AddAsync(ChatMessage entity)
    {
        await _chatCollection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(ChatMessage entity)
    {
        await _chatCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _chatCollection.DeleteOneAsync(x => x.Id == id);
    }
}