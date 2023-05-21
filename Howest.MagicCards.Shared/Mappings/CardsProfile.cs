using AutoMapper;
using Howest.MagicCards.DAL.Models.sql;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.Shared.Mappings;

public class CardsProfile : Profile
{
    public CardsProfile()
    {
        CreateMap<card, CardReadDTO>()
            .ForMember(dto => dto.Fullname,
                opt => opt.MapFrom(c => c.artist.full_name))
            .ForMember(dto => dto.Color, opt => opt.MapFrom( c => c.card_colors.Select(cc => cc.color.name).FirstOrDefault()));
        
        CreateMap<card, CardReadDetailDTO>().ForMember(dto => dto.Fullname,
                opt => opt.MapFrom(c => c.artist.full_name))
            .ForMember(dto => dto.Color, opt => opt.MapFrom( c => c.card_colors.Select(cc => cc.color.name).FirstOrDefault()));
    }
}