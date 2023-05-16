namespace Howest.MagicCards.DAL.Models;

public partial class Type
{
    public Type()
    {
        CardTypes = new HashSet<CardType>();
    }
    
    public string Name { get; set; }
    public string type { get; set; }
    
    public virtual ICollection<CardType> CardTypes { get; set; }
    
}