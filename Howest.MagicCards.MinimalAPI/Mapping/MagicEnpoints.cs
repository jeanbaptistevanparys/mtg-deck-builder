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
            return await deckRepo.GetDeckAsync() is IEnumerable<Card> cards
                ? Results.Ok(cards)
                : Results.NotFound("No cards found");
        }).WithTags("Deck");

        app.MapPost($"{urlPrefix}/deck", async (MongoDeckRepository deckRepo, [FromBody] Card newcard) =>
            {
                newcard.Mongo_id = ObjectId.GenerateNewId().ToString();
                await deckRepo.AddToDeck(newcard);
                return Results.Created($"{urlPrefix}/deck/{newcard?.Mongo_id ?? ObjectId.GenerateNewId().ToString()}",
                    newcard);
            }
        ).WithTags("Deck");

        app.MapDelete($"{urlPrefix}/deck", async (MongoDeckRepository deckRepo) =>
            {
                await deckRepo.DeleteAll();
                return Results.Ok("the deck is deleted!");
            }
        ).WithTags("Deck");

        app.MapPut($"{urlPrefix}/deck/" + "{id}",
            async (long id, MongoDeckRepository deckRepo, [FromBody] Amount amount) =>
            {
                var dbcard = await deckRepo.GetCard(id);
                if (dbcard is null)
                {
                    return Results.NotFound($"Card with id {id} is not found!");
                }

                dbcard.Amount += amount.amount;
                if (dbcard.Amount <= 0)
                {
                    await deckRepo.DeleteFromDeckAsync(id);
                    return Results.Ok($"Card with id {id} is deleted!");
                }

                await deckRepo.UpdateCardAsync(dbcard);
                return Results.Ok($"Card with id {id} is updated!");
            }
        ).WithTags("Deck");
    }

    public static void AddMagicServices(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<MongoDBSettings>(config);
        services.AddSingleton<MongoDeckRepository>();
    }
}