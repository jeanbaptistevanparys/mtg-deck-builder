using Howest.MagicCards.DAL.Models.sql;

namespace Howest.MagicCards.DAL.Repositories;

public interface IArtistRepository
{
    Task<IQueryable<artist>> GetAllArtists();
    Task<artist> GetArtistById(long id);
}