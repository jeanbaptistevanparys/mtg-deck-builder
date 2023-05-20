using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Models.sql;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Howest.MagicCards.DAL.Repositories;

public class SqlArtistRepository : IArtistRepository
{
    private readonly MyDbContext _db;
    
    public SqlArtistRepository(MyDbContext myDbContext)
    {
        _db = myDbContext;
    }
    
    public async Task<IQueryable<artist>> GetAllArtists()
    {
        IQueryable<artist> allCards = _db.artists
            .OrderBy( c => c.id)
            .Select(b => b);
        return await Task.FromResult(allCards) ;
    }
    public Task<artist> GetArtistById(long id)
    {
        return _db.artists
            .SingleOrDefaultAsync(c => c.id == id);
    }
}