using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GalejSnack.DataAccess.Models;

public class ChatMessage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement]
    public string Sender { get; set; }

    [BsonElement]
    public string Message { get; set; }

    [BsonElement]
    public DateTime Timestamp { get; set; }
}