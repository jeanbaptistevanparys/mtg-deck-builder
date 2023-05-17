
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
            .Select(b => b);
        return allCards;
    }
}