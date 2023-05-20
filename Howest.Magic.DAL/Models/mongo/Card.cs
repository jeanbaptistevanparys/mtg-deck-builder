using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Howest.MagicCards.DAL.Models.mongo;

public class Card
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Mongo_id { get; set; }

    [BsonElement("id")]
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [BsonElement("artist")]
    [JsonPropertyName("artist")]
    public string Artist { get; set; } = null!;

    [BsonElement("color")]
    [JsonPropertyName("color")]
    public string Color { get; set; } = null!;

    [BsonElement("type")]
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [BsonElement("rarity")]
    [JsonPropertyName("rarity")]
    public string Rarity { get; set; } = null!;

    [BsonElement("set")]
    [JsonPropertyName("set")]
    public string Set { get; set; } = null!;

    [BsonElement("text")]
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;

    [BsonElement("flavor")]
    [JsonPropertyName("flavor")]
    public string Flavor { get; set; } = null!;

    [BsonElement("number")]
    [JsonPropertyName("number")]
    public string Number { get; set; } = null!;

    [BsonElement("power")]
    [JsonPropertyName("power")]
    public string Power { get; set; } = null!;

    [BsonElement("toughness")]
    [JsonPropertyName("toughness")]
    public string Toughness { get; set; } = null!;

    [BsonElement("layout")]
    [JsonPropertyName("layout")]
    public string Layout { get; set; } = null!;

    [BsonElement("multiverse_id")]
    [JsonPropertyName("multiverse_id")]
    public string Multiverse_Id { get; set; } = null!;

    [BsonElement("original_image_url")]
    [JsonPropertyName("original_image_url")]
    public string Original_Image_Url { get; set; } = null!;

    [BsonElement("image")]
    [JsonPropertyName("image")]
    public string Image { get; set; } = null!;

    [BsonElement("original_text")]
    [JsonPropertyName("original_text")]
    public string Original_Text { get; set; } = null!;

    [BsonElement("original_type")]
    [JsonPropertyName("original_type")]
    public string Original_Type { get; set; } = null!;

    [BsonElement("mtg_id")]
    [JsonPropertyName("mtg_id")]
    public string Mtg_Id { get; set; } = null!;

    [BsonElement("variations")]
    [JsonPropertyName("variations")]
    public string Variations { get; set; } = null!;
}