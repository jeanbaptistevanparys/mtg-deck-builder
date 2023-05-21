using Howest.MagicCards.DAL.Models.sql;

namespace Howest.MagicCards.Shared.DTO;

public class CardReadDTO
{
    public long Id { get; init; }
    public string Name { get; init; }
    public string Fullname { get; init; }
    public string Mana_Cost { get; init; }
    public string Converted_Mana_Cost { get; init; }
    public string rarity_code { get; init; }
    public string Text { get; init; }
    public string Artist { get; init; }
    public string Original_Image_Url { get; init; }
    public string Color { get; init; }
    
}