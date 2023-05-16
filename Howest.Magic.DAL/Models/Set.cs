namespace Howest.MagicCards.DAL.Models;

public class Set
{
    
    public Set()
    {
        Cards = new HashSet<Card>();
    }
    public string Code { get; set; }
    public string Name { get; set; }
    
    public virtual ICollection<Card> Cards { get; set; }
}