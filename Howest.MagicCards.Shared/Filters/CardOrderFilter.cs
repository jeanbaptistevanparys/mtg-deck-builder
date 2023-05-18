namespace Howest.MagicCards.Shared.Filters;

public class CardOrderFilter : CardFilter
{
    public string orderByQueryString { get; set; } = string.Empty;
}