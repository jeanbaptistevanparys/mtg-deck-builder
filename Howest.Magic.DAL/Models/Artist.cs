namespace Howest.MagicCards.DAL.Models;

public partial class Artist
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public Card Cards { get; set; }
}