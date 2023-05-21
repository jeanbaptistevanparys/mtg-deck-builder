using Howest.MagicCards.DAL.Models.sql;
using Howest.MagicCards.Shared.DTO;
using Howest.MagicCards.WebAPI.Wrappers;
using Microsoft.AspNetCore.Components;

namespace Howest.MagicCards.Web.Pages;

public partial class DeckBuilder
{
    
    private int CurrentPage = 1;
    private string CardArtistFilter = string.Empty;

    private string CardNameFilter = string.Empty;
    private string CardOrderFilter = string.Empty;
    private string CardRarityFilter = string.Empty;

    private string CardSetFilter = string.Empty;
    private string CardTextFilter = string.Empty;
    private string CardTypeFilter = string.Empty;

    private IEnumerable<CardReadDTO> Deck;
    private IEnumerable<CardReadDTO> Cards;
    
    private HttpClient _httpClient;
    private HttpClient _httpClientDecks;

    [Inject]
    public IHttpClientFactory HttpClientFactory { get; set; }
    protected override async Task OnInitializedAsync()
    {
        _httpClient = HttpClientFactory.CreateClient("mtgWebAPI");
        _httpClientDecks = HttpClientFactory.CreateClient("mtgMinimalAPI");
        await LoadCards();
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
        HttpResponseMessage response = await _httpClient.GetAsync(Filter());
       Console.WriteLine(Filter());
         if (response.IsSuccessStatusCode)
         {
             PagedResponse<IEnumerable<CardReadDTO>> res = await response.Content.ReadFromJsonAsync<PagedResponse<IEnumerable<CardReadDTO>>>();
             Cards = res.Data;
             Console.WriteLine(res.Data.Count());
         }
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

    private string Filter()
    {
        string filter = "cards?";
        List<string> orderfilter = new List<string>();
        filter += CardSetFilter == String.Empty ? "" : $"Set={CardSetFilter}&";
        filter += CardArtistFilter == String.Empty ? "" : $"Artist={CardArtistFilter}&";
        filter += CardRarityFilter == String.Empty ? "" : $"Rarity={CardRarityFilter}&";
        filter += CardTypeFilter == String.Empty ? "" : $"CardType={CardTypeFilter}&";
        filter += CardNameFilter == String.Empty ? "" : $"CardName={CardNameFilter}&";
        filter += CardTextFilter == String.Empty ? "" : $"CardText={CardTextFilter}&";

        if (CardSetFilter != string.Empty) orderfilter.Add("Set");
        if (CardArtistFilter != string.Empty) orderfilter.Add("artist");
        if (CardRarityFilter != string.Empty) orderfilter.Add("rarity");
        if (CardTypeFilter != string.Empty) orderfilter.Add("card_type");
        if (CardNameFilter != string.Empty) orderfilter.Add("name");
        if (CardTextFilter != string.Empty) orderfilter.Add("text");
        
        filter += orderfilter.Count == 0 || CardOrderFilter == string.Empty ? "" : $"orderByQueryString={string.Join(",", orderfilter) +','+ CardOrderFilter}";
        
        return filter;
    }
}