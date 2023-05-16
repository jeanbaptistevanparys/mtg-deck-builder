namespace Howest.MagicCards.DAL.Models;

public partial class Artist
{
    public Artist()
    {
        Cards = new HashSet<Card>();
    }
    public int Id { get; set; }
    public string Fullname { get; set; }
    
    public virtual ICollection<Card> Cards { get; set; }
}