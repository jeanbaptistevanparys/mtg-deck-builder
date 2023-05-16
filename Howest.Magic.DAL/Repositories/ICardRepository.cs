using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories;

public interface ICardRepository
{
    IQueryable<card> getAllCards();
}