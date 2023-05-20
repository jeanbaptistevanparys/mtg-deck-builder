using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Howest.MagicCards.DAL.Models.mongo;

public class Card
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Mongo_id { get; set; }
    
    [BsonElement("amount")]
    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [BsonElement("id")]
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    
    [BsonElement("mana_cost")]
    [JsonPropertyName("mana_cost")]
    public string Mana_Cost { get; set; } = null!;
    
    [BsonElement("converted_mana_cost")]
    [JsonPropertyName("converted_mana_cost")]
    public string Converted_Mana_Cost { get; set; } = null!;

    [BsonElement("artist")]
    [JsonPropertyName("artist")]
    public string Artist { get; set; } = null!;

    [BsonElement("color")]
    [JsonPropertyName("color")]
    public string Color { get; set; } = null!;

    [BsonElement("text")]
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;
}