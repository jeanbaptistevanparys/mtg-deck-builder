using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.Web.Pages;

public partial class DeckBuilder
{
    private string CardArtistFilter = string.Empty;

    private string CardNameFilter = string.Empty;
    private string CardOrderFilter = string.Empty;
    private string CardRarityFilter = string.Empty;
    private readonly IEnumerable<CardReadDTO> Cards = null;
    private string CardSetFilter = string.Empty;
    private string CardTextFilter = string.Empty;
    private string CardTypeFilter = string.Empty;

    private readonly IEnumerable<CardReadDTO> Deck = null;

    private async Task ShowPreviousPage()
    {
        //todo: implement
    }

    private async Task ShowNextPage()
    {
        //todo: implement
    }

    private async Task LoadCards()
    {
        //todo: implement
    }

    private async Task ClearDeck()
    {
        //todo: implement
    }

    private async Task AddCardToDeck(CardReadDTO card)
    {
        //todo: implement
    }

    private async Task RemoveCardFromDeck(long Id)
    {
        //todo: implement
    }
}