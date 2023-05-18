namespace Howest.MagicCards.Shared.Filters;

public class CardFilter : PaginationFilter
{
    public string Set { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public string Rarity { get; set; } = string.Empty;
    public string CardType { get; set; } = string.Empty;
    public string CardName { get; set; } = string.Empty;
    public string CardText { get; set; } = string.Empty;
    
}