namespace Howest.MagicCards.DAL.Models;

public partial class Color
{
    public Color()
    {
        CardColor = new HashSet<CardColor>();
    }
    
    public string Code { get; set; }
    public string Name { get; set; }
    
    public virtual ICollection<CardColor> CardColor { get; set; }
}