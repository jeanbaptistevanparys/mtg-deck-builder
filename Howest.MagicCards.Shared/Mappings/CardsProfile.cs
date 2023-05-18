using AutoMapper;
using Howest.MagicCards.DAL.Models.sql;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.Shared.Mappings;

public class CardsProfile : Profile
{
    public CardsProfile()
    {
        CreateMap<card, CardReadDTO>();
        CreateMap<card, CardReadDetailDTO>();
    }
}