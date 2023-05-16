using AutoMapper;
using AutoMapper.QueryableExtensions;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Howest.MagicCards.WebAPI.Controllers;

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


    [HttpGet()]
    public ActionResult<IEnumerable<CardReadDTO>> GetCards()
    {
        return Ok(_cardRepo.getAllCards().ProjectTo<CardReadDTO>(_mapper.ConfigurationProvider));
    }
}