using GraphQL;
using GraphQL.Types;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.GraphQL.Types;

namespace Howest.MagicCards.GraphQL.Query;

public class RootQuery : ObjectGraphType
{
    public RootQuery(ICardRepository cardRepository, IArtistRepository artistRepository)
    {
        Name = "Query";

        FieldAsync<ListGraphType<CardType>>(
            "Cards",
            Description = "Get all cards",
            new QueryArguments
            {
                new QueryArgument<StringGraphType> { Name = "power" },
                new QueryArgument<StringGraphType> { Name = "toughness" },
                new QueryArgument<IntGraphType> { Name = "limit" }
            },
            async context =>
            {
                var limit = context.GetArgument<int>("limit");
                var power = context.GetArgument<string>("power");
                var toughness = context.GetArgument<string>("toughness");
                
                var cards = await cardRepository.GetAllCards();
                return cards
                    .Where(c =>
                        (string.IsNullOrEmpty(power) || c.power == power) &&
                        (string.IsNullOrEmpty(toughness) || c.toughness == toughness)
                    )
                    .Take(limit == default ? int.MaxValue : limit)
                    .ToList();
            }
        );

        FieldAsync<ListGraphType<ArtistType>>(
            Name = "Artists",
            Description = "Get all artists",
            new QueryArguments
            {
                new QueryArgument<StringGraphType> { Name = "id" },
                new QueryArgument<IntGraphType> { Name = "limit" }
            },
            resolve: async context =>
            {
                var limit = context.GetArgument<int>("limit");
                var id = context.GetArgument<string>("id");
                var artists = await artistRepository.GetAllArtists();
                return artists
                    .Where(a =>
                        (string.IsNullOrEmpty(id) || a.id.ToString() == id)
                    )
                    .Take(limit == default ? int.MaxValue : limit)
                    .ToList();
            }
        );
    }
}