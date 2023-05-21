using System.Text.Json.Serialization;

namespace Howest.MagicCards.DAL.Models.mongo;

public class Amount
{
    [JsonPropertyName("amount")] public int amount { get; set; }
}