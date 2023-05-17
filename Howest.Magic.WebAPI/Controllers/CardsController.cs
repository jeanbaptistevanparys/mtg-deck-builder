using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Howest.MagicCards.DAL.Models;
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


    [ApiVersion("1.5")]
    [HttpGet()]
    public ActionResult<IEnumerable<CardReadDTO>> GetCards([FromQuery] CardFilter filter, [FromServices] IConfiguration config)
    {
        filter.MaxPageSize = int.Parse(config["maxPageSize"]);
        
        return (_cardRepo.getAllCards() is { } allCards)
            ? Ok(new PagedResponse<IEnumerable<CardReadDTO>>(
                allCards
                    .ToFilteredList(filter.Set, filter.Artist, filter.Rarity, filter.CardType, filter.CardName, filter.CardText)
                    .ToPagedList(filter.PageNumber, filter.PageSize)
                    .ProjectTo<CardReadDTO>(_mapper.ConfigurationProvider)
                    .ToList(),
                filter.PageNumber, filter.PageSize))
        : NotFound(new Response<CardReadDTO>()
        {
            Errors = new string[] { "404" },
            Message = "No cards found "
        });
    }
    
    [ApiVersion("1.1")]
    [HttpGet("{id:long}", Name = "GetCardById")]
    
    public ActionResult<CardReadDTO> GetCardById(long id)
    {
        return (_cardRepo.getCardById(id) is { } card)
            ? Ok(_mapper.Map<CardReadDTO>(card))
            : NotFound(new Response<CardReadDTO>()
            {
                Errors = new string[] { "404" },
                Message = "No card found with id " + id
            });
    }
} 