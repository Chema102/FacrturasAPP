using FacturasAPP.DAC.Models;
using FacturasAPP.DTO.Dto;

namespace FacturasAPP.DTO.Models.Respository
{
    public interface IFacturaDetalleRepository
    {
        Task<List<FacturaDetalle>> Get();
        Task<FacturaDetalle?> GetById(int id);
        Task<bool> Add(FacturaDetalleDto product);
        Task<bool> Delete(string id);
        Task<bool> Update(FacturaDetalleDto id);
    }
}
