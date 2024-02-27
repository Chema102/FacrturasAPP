using FacturasAPP.DAC.Models;
using FacturasAPP.DTO.Dto;

namespace FacturasAPP.DTO.Models.Services
{
    public interface IFacturaServices
    {
        Task<List<FacturaDto>> Get();
        Task<FacturaDto> GetById(int id);
        Task<bool> Delete(int id);
        Task<bool> Add(FacturaDto invoiceDto);
        Task<bool> Update(FacturaDto invoiceDto);
    }
}
