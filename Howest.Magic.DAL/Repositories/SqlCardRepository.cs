
using Howest.MagicCards.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Howest.MagicCards.DAL.Repositories;

public class SqlCardRepository : ICardRepository
{
    private readonly MyDbContext _db;
    
    public SqlCardRepository(MyDbContext myDbContext)
    {
        _db = myDbContext;
    }
    
    public IQueryable<card> getAllCards()
    {
        IQueryable<card> allCards = _db.cards
            .OrderBy( c => c.id)
            .Select(b => b);
        return allCards;
    }
    
    public card? getCardById(long id)
    {
        card? singleCard = _db.cards
            .SingleOrDefault(c => c.id == id);

        return singleCard;
    }
}