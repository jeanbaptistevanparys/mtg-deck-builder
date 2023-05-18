using Howest.MagicCards.DAL.Models.mongo;
using Howest.MagicCards.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Howest.MagicCards.MinimalAPI.Mapping;

public static class MagicEnpoints
{
    public static void MapMagicEndpoints(this WebApplication app, string urlPrefix)
    {
        app.MapGet($"{urlPrefix}/deck", async (MongoDeckRepository deckRepo) =>
        {
            return (await deckRepo.GetDeckAsync() is IEnumerable<Card> cards)
                ? Results.Ok(cards)
                : Results.NotFound("No cards found");

        }).WithTags("Deck");

        app.MapPost($"{urlPrefix}/deck", async (MongoDeckRepository deckRepo, [FromBodyAttribute] Card newcard) =>
            {
                await deckRepo.AddToDeck(newcard ?? new Card { Mongo_id = ObjectId.GenerateNewId().ToString() });
                return Results.Created($"{urlPrefix}/deck/{newcard?.Mongo_id ?? ObjectId.GenerateNewId().ToString()}", newcard);
            }
        ).WithTags("Deck");

        app.MapDelete($"{urlPrefix}/deck/{{id}}", async (MongoDeckRepository deckRepo, long id) =>
            {
                await deckRepo.DeleteFromDeckAsync(id);
                return Results.Ok($"Card with id {id} is deleted!");
            }
        ).WithTags("Deck");
    }
    
    public static void AddMagicServices(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<MongoDBSettings>(config);
        services.AddSingleton<MongoDeckRepository>();
    }
}