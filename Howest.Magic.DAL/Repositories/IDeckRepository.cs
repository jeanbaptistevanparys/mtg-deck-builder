using Howest.MagicCards.DAL.Models.mongo;

namespace Howest.MagicCards.DAL.Repositories;

public interface IDeckRepository
{
    public  Task<List<Card>> GetDeckAsync();
    public  Task AddToDeck(Card card);
    public  Task DeleteFromDeckAsync(long id);
    
    public Task UpdateCardAsync(Card card);
    
    
}