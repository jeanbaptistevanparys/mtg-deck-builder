using GraphQL.Types;
using Howest.MagicCards.DAL.Models.sql;

namespace Howest.MagicCards.GraphQL.Types;

public class ArtistType : ObjectGraphType<artist>
{
    public ArtistType()
    {
        Field(a => a.id, type: typeof(IdGraphType)).Description("id of the artist").Name("id");

        Field(a => a.full_name, type: typeof(StringGraphType)).Description("name of the artist").Name("full_name");
        Field(a => a.cards, type: typeof(ListGraphType<CardType>));
    }
}