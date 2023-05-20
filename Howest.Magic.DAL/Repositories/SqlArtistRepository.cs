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
        IQueryable<artist> allArtists = _db.artists
            .Include(a => a.cards)
            .OrderBy( a => a.id)
            .Select(a => a);
        return await Task.FromResult(allArtists) ;
    }
    public Task<artist> GetArtistById(long id)
    {
        return _db.artists
            .SingleOrDefaultAsync(a => a.id == id);
    }
}