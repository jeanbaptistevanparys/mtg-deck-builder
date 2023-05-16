namespace Howest.MagicCards.DAL.Models;

public partial class Rarity
{
    public Rarity()
    {
        Cards = new HashSet<Card>();
    }
    public int Code { get; set; }
    public string Name { get; set; }
    
    public virtual ICollection<Card> Cards { get; set; }
}