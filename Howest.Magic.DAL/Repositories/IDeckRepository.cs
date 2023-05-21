using Howest.MagicCards.DAL.Models.mongo;

namespace Howest.MagicCards.DAL.Repositories;

public interface IDeckRepository
{
    public Task<List<Card>> GetDeckAsync();
    public Task AddToDeck(Card card);

    public Task<Card> GetCard(long id);
    public Task DeleteFromDeckAsync(long id);

    public Task DeleteAll();

    public Task UpdateCardAsync(Card card);
}