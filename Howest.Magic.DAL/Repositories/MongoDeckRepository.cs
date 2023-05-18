using Howest.MagicCards.DAL.Models.mongo;
using Microsoft.Extensions.Options;

using Microsoft.Extensions.Options;
using Howest.MagicCards.DAL.Models.mongo;
using MongoDB.Driver;

namespace Howest.MagicCards.DAL.Repositories;

public class MongoDeckRepository : IDeckRepository
{
    private readonly IMongoCollection<Card> _deckCollection;

    public MongoDeckRepository(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _deckCollection = database.GetCollection<Card>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Card>> GetDeckAsync()
    {
        return await _deckCollection.Find(card => true).ToListAsync();
    }

    public async Task AddToDeck(Card card)
    {
        await _deckCollection.InsertOneAsync(card);
    }

    public async Task DeleteFromDeckAsync(long id)
    {
        await _deckCollection.DeleteOneAsync(card => card.Id == id);
    }
    
}