using FacturasAPP.DAC.Models;
using FacturasAPP.DTO.Dto;
using FacturasAPP.DTO.Models.Respository;
using Microsoft.EntityFrameworkCore;

namespace FacturasAPP.REP.Respository
{
    public class FacturaDetalleRepository : IFacturaDetalleRepository
    {
        private readonly FctContext _fctContext;
        public FacturaDetalleRepository(FctContext fctContext)
        {
            _fctContext = fctContext;
        }

        public async Task<List<FacturaDetalle>> Get()
        {
            var invoiceDetailes = await _fctContext.FacturaDetalles
                .Include(f => f.FacturaId)
                .Include(f => f.ProductoId)
                .ToListAsync();

            return invoiceDetailes;
        }
        public async Task<FacturaDetalle?> GetById(int id)
        {
            var invoiceDetail = await _fctContext.FacturaDetalles
                .Include(f => f.FacturaId)
                .Include(f => f.ProductoId)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id && f.Dltt == false);

            return invoiceDetail;
        }
        public async Task<bool> Add(FacturaDetalleDto product)
        {


            return true;
        }

    }
}
