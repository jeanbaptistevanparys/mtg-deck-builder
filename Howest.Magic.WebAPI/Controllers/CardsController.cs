using AutoMapper;
using AutoMapper.QueryableExtensions;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.DTO;
using Howest.MagicCards.Shared.Extensions;
using Howest.MagicCards.Shared.Filters;
using Howest.MagicCards.WebAPI.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Howest.MagicCards.WebAPI.Controllers;

[ApiVersion("1.1")]
[ApiVersion("1.5")]
[ApiController]
[Route("api/[controller]")]
public class CardsController : ControllerBase 
{
    private readonly ICardRepository _cardRepo;
    private readonly IMapper _mapper;


    public CardsController(ICardRepository cardRepository, IMapper mapper)
    {
        _cardRepo = cardRepository;
        _mapper = mapper;
    }


    [HttpGet(), MapToApiVersion("1.1")]
    public async Task<ActionResult<IEnumerable<CardReadDTO>>> GetCards([FromQuery] CardFilter filter)
    {
        
        return (await _cardRepo.GetAllCards() is { } allCards)
            ? Ok(new PagedResponse<IEnumerable<CardReadDTO>>(
                allCards
                    .ToPagedList(filter.PageNumber, filter.PageSize)
                    .ProjectTo<CardReadDTO>(_mapper.ConfigurationProvider)
                    .ToList(),
                filter.PageNumber, filter.PageSize, allCards.Count()))
            : NotFound(new Response<CardReadDTO>()
            {
                Errors = new string[] { "404" },
                Message = "No cards found "
            });

    }
    
    [HttpGet(), MapToApiVersion("1.5")]
    public async Task<ActionResult<CardReadDTO>> GetCards([FromQuery] CardOrderFilter filter, [FromServices] IConfiguration config)
    {
        filter.MaxPageSize = int.Parse(config["maxPageSize"]);
        
        return (await _cardRepo.GetAllCards() is { } allCards)
            ? Ok(new PagedResponse<IEnumerable<CardReadDTO>>(
                allCards
                    .ToFilteredList(filter.Set, filter.Artist, filter.Rarity, filter.CardType, filter.CardName, filter.CardText)
                    .Sort(filter.orderByQueryString)
                    .ToPagedList(filter.PageNumber, filter.PageSize)
                    .ProjectTo<CardReadDTO>(_mapper.ConfigurationProvider)
                    .ToList(),
                filter.PageNumber, filter.PageSize, allCards.Count()))
            : NotFound(new Response<CardReadDTO>()
            {
                Errors = new string[] { "404" },
                Message = "No cards found "
            });
    }
    
    
    
    [HttpGet("{id:long}", Name = "GetCardById"), MapToApiVersion("1.1")]
    public async Task<ActionResult<CardReadDTO>>  GetCardbyId(long id)
    {
        return (await _cardRepo.GetCardByIdAsync(id) is { } card)
            ? Ok(_mapper.Map<CardReadDTO>(card))
            : NotFound(new Response<CardReadDTO>()
            {
                Errors = new string[] { "404" },
                Message = "No card found with id " + id
            });
    }
    
    [HttpGet("{id:long}", Name = "GetCardById"), MapToApiVersion("1.5")]
    public async Task<ActionResult<CardReadDTO>> GetCardById(long id)
    {
        return (await _cardRepo.GetCardByIdAsync(id) is { } card)
            ? Ok(_mapper.Map<CardReadDetailDTO>(card))
            : NotFound(new Response<CardReadDetailDTO>()
            {
                Errors = new string[] { "404" },
                Message = "No card found with id " + id
            });
    }
} 
