using FacturasAPP.DTO.Dto;

namespace FacturasAPP.DTO.Models.Services
{
    public interface IProductosServices
    {
        Task<List<ProducDto>> Get();
        Task<ProducDto> GetById(string id);
        Task<bool> Add(ProducDto product);
        Task<bool> Delete(string id);
        Task<bool> Update(ProducDto product);
    }
}
