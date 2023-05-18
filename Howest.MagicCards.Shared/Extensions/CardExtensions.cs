using System.Reflection;
using System.Text;
using Howest.MagicCards.DAL.Models.sql;
using System.Linq.Dynamic.Core;

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
    
    public static IQueryable<card> Sort(this IQueryable<card> cards, string orderByQueryString)
    {
        if (string.IsNullOrEmpty(orderByQueryString))
        {
            return cards.OrderBy(c => c.name);
        }

        string[] orderParameters = orderByQueryString.Trim().Split(',');
        PropertyInfo[] propertyInfos = typeof(card).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        StringBuilder orderQueryBuilder = new StringBuilder();

        foreach (string param in orderParameters)
        {
            if (!string.IsNullOrEmpty(param))
            {
                string propertyFromQueryName = param.Split(" ")[0];
                PropertyInfo objectProperty = propertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty is not null)
                {
                    string direction = param.EndsWith(" desc") ? "descending" : "ascending";
                    orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
                }
            }
        }

        string orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
        if (string.IsNullOrWhiteSpace(orderQuery))
        {
            return cards.OrderBy(b => b.name);
        }

        return cards.OrderBy(orderQuery);
    }
}