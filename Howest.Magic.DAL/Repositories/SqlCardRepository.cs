using Howest.MagicCards.DAL.Models.sql;
using Microsoft.EntityFrameworkCore;

namespace Howest.MagicCards.DAL.Repositories;

public class SqlCardRepository : ICardRepository
{
    private readonly MyDbContext _db;

    public SqlCardRepository(MyDbContext myDbContext)
    {
        _db = myDbContext;
    }

    public async Task<IQueryable<card>> GetAllCards()
    {
        var allCards = _db.cards
            .Include(c => c.artist)
            .Include(c => c.rarity_codeNavigation)
            .Include(c => c.set_codeNavigation)
            .OrderBy(c => c.id)
            .Select(c => c);
        return await Task.FromResult(allCards);
    }

    public Task<card> GetCardById(long id)
    {
        return _db.cards
            .SingleOrDefaultAsync(c => c.id == id);
    }
}