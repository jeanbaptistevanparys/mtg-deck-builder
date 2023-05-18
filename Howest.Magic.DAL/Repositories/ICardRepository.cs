using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Models.sql;

namespace Howest.MagicCards.DAL.Repositories;

public interface ICardRepository
{
    IQueryable<card> GetAllCards();
    card GetCardById(long id);
    Task<card> GetCardByIdAsync(long id);
}