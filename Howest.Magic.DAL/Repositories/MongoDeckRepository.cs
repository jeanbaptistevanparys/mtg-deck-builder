using Howest.MagicCards.DAL.Models.mongo;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Howest.MagicCards.DAL.Repositories;

public class MongoDeckRepository : IDeckRepository
{
    private readonly IMongoCollection<Card> _deckCollection;

    public MongoDeckRepository(IOptions<MongoDBSettings> mongoDBSettings)
    {
        var client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _deckCollection = database.GetCollection<Card>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Card>> GetDeckAsync()
    {
        return await _deckCollection.Find(card => true).ToListAsync();
    }

    public async Task<Card> GetCard(long id)
    {
        return await _deckCollection.Find(card => card.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddToDeck(Card card)
    {
        await _deckCollection.InsertOneAsync(card);
    }

    public async Task DeleteFromDeckAsync(long id)
    {
        await _deckCollection.DeleteOneAsync(card => card.Id == id);
    }

    public async Task UpdateCardAsync(Card card)
    {
        await _deckCollection.UpdateOneAsync(c => c.Id == card.Id,
            Builders<Card>.Update.Set("amount", card.Amount));
    }

    public async Task DeleteAll()
    {
        await _deckCollection.DeleteManyAsync(card => true);
    }
}