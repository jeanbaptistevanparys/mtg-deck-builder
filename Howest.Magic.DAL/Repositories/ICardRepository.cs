using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories;

public interface ICardRepository
{
    IQueryable<card> GetAllCards();
    card GetCardById(long id);
    Task<card> GetCardByIdAsync(long id);
}