using FacturasAPP.DTO.Dto;

namespace FacturasAPP.DTO.Models.Services
{
    public interface IFacturaDetalleServices
    {
        Task<List<FacturaDetalleDto>> Get();
        Task<FacturaDetalleDto> GetById(int id);
        Task<bool> Delete(int id);
        Task<bool> Add(FacturaDetalleDto invoiceDto);
        Task<bool> Update(FacturaDetalleDto invoiceDto);
    }
}
