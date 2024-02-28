using AutoMapper;
using FacturasAPP.DAC.Models;
using FacturasAPP.DTO.Dto;

namespace FacturasAPP.SRV.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<FacturaDetalle, FacturaDetalleDto>();
            CreateMap<Factura, SelectDto>()
                .ForMember(dest => dest.Select,
                  opt => opt.MapFrom(src => src.Total.ToString() + "$ - " + src.Fecha));
            CreateMap<Product, SelectDto>()
                .ForMember(dest => dest.Select,
                opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
