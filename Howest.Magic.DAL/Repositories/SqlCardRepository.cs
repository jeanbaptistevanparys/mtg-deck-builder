
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Models.sql;
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
    
    public IQueryable<card> GetAllCards()
    {
        IQueryable<card> allCards = _db.cards
            .OrderBy( c => c.id)
            .Select(b => b);
        return allCards;
    }
    
    public card? GetCardById(long id)
    {
        card? singleCard = _db.cards
            .SingleOrDefault(c => c.id == id);

        return singleCard;
    }
    
    public Task<card> GetCardByIdAsync(long id)
    {
        return _db.cards
            .SingleOrDefaultAsync(c => c.id == id);
    }
}