using Howest.MagicCards.DAL.Models.sql;

namespace Howest.MagicCards.DAL.Repositories;

public interface ICardRepository
{
    Task<IQueryable<card>> GetAllCards();
    Task<card> GetCardById(long id);
}