using GalejSnack.DataAccess.Models;
using GalejSnack.DataAccess.Services.Interfaces;
using MongoDB.Driver;

namespace GalejSnack.DataAccess.Services;
public class ChatRepository : IChatRepository
{
    private readonly IMongoCollection<ChatMessage> _chatCollection;

    public ChatRepository()
    {
        var connectionString = "mongodb://localhost:27017";
        var databaseName = "TestChat";
        var collectionName = "Bös";

        var mongoClient = new MongoClient(connectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseName);
        _chatCollection = mongoDatabase.GetCollection<ChatMessage>(collectionName);
    }

    public async Task<ChatMessage> GetByIdAsync(string id)
    {
        var filter = Builders<ChatMessage>.Filter.Eq(message => message.Id, id);
        return await _chatCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<ChatMessage>> GetAllAsync()
    {
        var filter = Builders<ChatMessage>.Filter.Empty;
        return await _chatCollection.Find(filter).ToListAsync();
    }

    public async Task AddAsync(ChatMessage entity)
    {
        await _chatCollection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(ChatMessage entity)
    {
        await _chatCollection.ReplaceOneAsync(message => message.Id == entity.Id, entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _chatCollection.DeleteOneAsync(message => message.Id == id);
    }
}