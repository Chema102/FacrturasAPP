using AutoMapper;
using FacturasAPP.DAC.Models;
using FacturasAPP.DTO.Dto;

namespace FacturasAPP.SRV.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProducDto>();
        }
    }
}
