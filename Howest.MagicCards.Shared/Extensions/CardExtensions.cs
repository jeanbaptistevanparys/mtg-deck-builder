using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.Shared.Extensions;

public static class CardExtensions
{
    public static IQueryable<card> ToFilteredList(this IQueryable<card> entities, string set, string artist,
        string rarity, string cardType, string cardName, string cardText)
    {
        return entities
            .Where(
                c => c.set_codeNavigation.name.Contains(set) &&
                     c.artist.full_name.Contains(artist) &&
                     c.rarity_code.Contains(rarity) &&
                     c.card_types.Any(ct => ct.type.name.Contains(cardType)) &&
                     c.name.Contains(cardName) &&
                     c.text.Contains(cardText)
            );
    }
    
    public static IQueryable<card> ToSortedList(this IQueryable<card> entities, bool? ascending)
    {
        return ascending == true
            ? entities.OrderBy(c => c.name)
            : entities.OrderByDescending(c => c.name);
    }
}