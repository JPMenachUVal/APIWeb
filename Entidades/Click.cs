using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Click
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("number")]
    [BsonRepresentation(BsonType.Int32)]
    public int Number { get; set; }
}
