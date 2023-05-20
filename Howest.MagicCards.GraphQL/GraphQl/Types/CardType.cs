using GraphQL.Types;
using Howest.MagicCards.DAL.Models.sql;

namespace Howest.MagicCards.GraphQL.Types;

public class CardType : ObjectGraphType<card>
{
    public CardType()
    {
        Field(c => c.id, type: typeof(IdGraphType)).Description("id of the card").Name("id");

        Field(c => c.name, type: typeof(StringGraphType)).Description("name of the card").Name("name");
        Field(c => c.mana_cost, type: typeof(StringGraphType)).Description("mana cost of the card").Name("mana_cost");
        Field(c => c.converted_mana_cost, type: typeof(StringGraphType)).Description("converted mana cost of the card")
            .Name("converted_mana_cost");
        Field(c => c.power, type: typeof(StringGraphType)).Description("power of the card").Name("power");
        Field(c => c.toughness, type: typeof(StringGraphType)).Description("toughness of the card").Name("toughness");
        Field(c => c.card_colors, type: typeof(StringGraphType)).Description("card colors of the card")
            .Name("card_colors");
        Field(c => c.set_code, type: typeof(StringGraphType)).Description("set code of the card").Name("set_code");
        Field(c => c.rarity_code, type: typeof(StringGraphType)).Description("rarity code of the card")
            .Name("rarity_code");
        Field<ArtistType>("artist");
        Field(c => c.image, type: typeof(StringGraphType)).Description("image of the card").Name("image");
        Field(c => c.original_image_url, type: typeof(StringGraphType)).Description("original image url of the card")
            .Name("original_image_url");
    }
}