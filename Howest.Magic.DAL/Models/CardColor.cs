namespace Howest.MagicCards.DAL.Models;

public partial class CardColor
{
    public int CardId { get; set; }
    public int ColorId { get; set; }

    public Card Card { get; set; }
    public Color Color { get; set; }
}