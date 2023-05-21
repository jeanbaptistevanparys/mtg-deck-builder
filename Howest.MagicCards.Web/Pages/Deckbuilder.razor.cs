using Howest.MagicCards.DAL.Models.mongo;
using Howest.MagicCards.Shared.DTO;
using Howest.MagicCards.WebAPI.Wrappers;
using Microsoft.AspNetCore.Components;

namespace Howest.MagicCards.Web.Pages;

public partial class DeckBuilder
{
    private HttpClient _httpClient;
    private HttpClient _httpClientDecks;
    private string CardArtistFilter = string.Empty;

    private string CardNameFilter = string.Empty;
    private string CardOrderFilter = string.Empty;
    private string CardRarityFilter = string.Empty;
    private IEnumerable<CardReadDTO> Cards;

    private string CardSetFilter = string.Empty;
    private string CardTextFilter = string.Empty;
    private string CardTypeFilter = string.Empty;

    private int CurrentPage = 1;

    private IEnumerable<Card> Deck;

    [Inject] public IHttpClientFactory HttpClientFactory { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _httpClient = HttpClientFactory.CreateClient("mtgWebAPI");
        _httpClientDecks = HttpClientFactory.CreateClient("mtgMinimalAPI");
        await LoadCards();
        await LoadDeck();
    }

    private async Task ShowPreviousPage()
    {
        if (CurrentPage > 1)
        {
            CurrentPage--;
            await LoadCards();
        }
    }

    private async Task ShowNextPage()
    {
        CurrentPage++;
        await LoadCards();
    }

    private async Task LoadCards()
    {
        var response = await _httpClient.GetAsync(Filter());
        Console.WriteLine(Filter());
        if (response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadFromJsonAsync<PagedResponse<IEnumerable<CardReadDTO>>>();
            Cards = res.Data;
            Console.WriteLine(res.Data.Count());
        }
    }

    private async Task LoadDeck()
    {
        var response = await _httpClientDecks.GetAsync("deck");
        if (response.IsSuccessStatusCode) Deck = await response.Content.ReadFromJsonAsync<IEnumerable<Card>>();
    }

    private async Task ClearDeck()
    {
        var response = await _httpClientDecks.DeleteAsync("deck");
        if (response.IsSuccessStatusCode) await LoadDeck();
    }

    private async Task AddCardToDeck(CardReadDTO card)
    {
        if (Deck.Count(c => c.Id == card.Id) > 0)
        {
            var amount = new Amount();
            amount.amount = 1;
            Console.WriteLine(JsonContent.Create(amount));
            var response = await _httpClientDecks.PutAsync($"deck/{card.Id}", JsonContent.Create(amount));
        }
        else
        {
            var newCard = new Card();
            newCard.Mongo_id = "";
            newCard.Amount = 1;
            newCard.Id = card.Id;
            newCard.Name = card.Name;
            newCard.Mana_Cost = card.Mana_Cost;
            newCard.Converted_Mana_Cost = card.Converted_Mana_Cost;
            newCard.Artist = card.Fullname;
            newCard.Color = card.Color;
            newCard.Text = card.Text;
            var response = await _httpClientDecks.PostAsync("deck", JsonContent.Create(newCard));
        }

        Console.WriteLine(Deck.Count(c => c.Id == card.Id) > 0);
        await LoadDeck();
    }

    private async Task RemoveCardFromDeck(long Id)
    {
        var amount = new Amount();
        amount.amount = -1;
        Console.WriteLine(JsonContent.Create(amount).ToString());
        var response = await _httpClientDecks.PutAsync($"deck/{Id}", JsonContent.Create(amount));
        if (response.IsSuccessStatusCode) await LoadDeck();
    }

    private string Filter()
    {
        var filter = "cards";

        var filterlist = new List<string>();
        var orderlist = new List<string>();

        if (CardSetFilter != string.Empty) filterlist.Add($"Set={CardSetFilter}");
        if (CardArtistFilter != string.Empty) filterlist.Add($"Artist={CardArtistFilter}");
        if (CardRarityFilter != string.Empty) filterlist.Add($"Rarity={CardRarityFilter}");
        if (CardTypeFilter != string.Empty) filterlist.Add($"CardType={CardTypeFilter}");
        if (CardNameFilter != string.Empty) filterlist.Add($"CardName={CardNameFilter}");
        if (CardTextFilter != string.Empty) filterlist.Add($"CardText={CardTextFilter}");
        if (CurrentPage != 1) filterlist.Add($"PageNumber={CurrentPage}");

        filter += filterlist.Count == 0 ? "" : "?";
        if (filterlist.Count > 0) filter += string.Join("&", filterlist);


        if (CardSetFilter != string.Empty) orderlist.Add("Set");
        if (CardArtistFilter != string.Empty) orderlist.Add("artist");
        if (CardRarityFilter != string.Empty) orderlist.Add("rarity");
        if (CardTypeFilter != string.Empty) orderlist.Add("card_type");
        if (CardNameFilter != string.Empty) orderlist.Add("name");
        if (CardTextFilter != string.Empty) orderlist.Add("text");

        filter += orderlist.Count == 0 || CardOrderFilter == string.Empty
            ? ""
            : $"orderByQueryString={string.Join(",", orderlist) + ',' + CardOrderFilter}";

        return filter;
    }
}