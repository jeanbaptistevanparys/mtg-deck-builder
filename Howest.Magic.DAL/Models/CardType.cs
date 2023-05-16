namespace Howest.MagicCards.DAL.Models;

public class CardType
{
    public int CardId { get; set; }
    public int TypeId { get; set; }

    public Card Card { get; set; }
    public Type Type { get; set; }
}