namespace Howest.MagicCards.DAL.Models;

public partial class Type
{
    public Type()
    {
        CardType = new HashSet<CardType>();
    }
    
    public string Id { get; set; }
    
    public string Name { get; set; }
    public string type { get; set; }
    
    public virtual ICollection<CardType> CardType { get; set; }
    
}