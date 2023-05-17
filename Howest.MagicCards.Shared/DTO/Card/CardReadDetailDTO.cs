namespace Howest.MagicCards.Shared.DTO;

public class CardReadDetailDTO
{
    public long Id { get; init; }
    public string Name { get; init; }
    public string mana_cost { get; init; }
    public string Converted_Mana_Cost { get; init; }
    public string Type { get; init; }
    public string rarity_code { get; init; }
    public string Set_Code { get; init; }
    public string Text { get; init; }
    public string Flavor { get; init; }
    public string ArtistId { get; init; }
    public string Number { get; init; }
    public string Power { get; init; }
    public string Toughness { get; init; }
    public string Layout { get; init; }
    public string Multiverse_Id { get; init; }
    public string Original_Image_Url { get; init; }
    public string Image { get; init; }
    public string Original_Text { get; init; }
    public string Original_Type { get; init; }
    public string Mtg_Id { get; init; }
    public string Variations { get; init; }
}