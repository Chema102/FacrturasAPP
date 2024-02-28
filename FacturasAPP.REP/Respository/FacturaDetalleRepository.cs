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
                .Include(f => f.Factura)
                .Include(f => f.Producto)
                .Where(m => m.Dltt == false)
                .AsNoTracking()
                .ToListAsync();

            return invoiceDetailes;
        }
        public async Task<FacturaDetalle?> GetById(int id)
        {
            var invoiceDetail = await _fctContext.FacturaDetalles
                .Include(f => f.Factura)
                .Include(f => f.Producto)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id && f.Dltt == false);

            return invoiceDetail;
        }
        public async Task<bool> Add(FacturaDetalleDto facturaDetalleDto)
        {
            var invoiceDetail = new FacturaDetalle();
            invoiceDetail.ProductoId = facturaDetalleDto.ProductoId;
            invoiceDetail.FacturaId = facturaDetalleDto.FacturaId;
            invoiceDetail.Precio = facturaDetalleDto.Precio;
            invoiceDetail.Crt = DateTime.Now;
            invoiceDetail.Uppdt = DateTime.Now;
            invoiceDetail.Dltt = false;

            try
            {
                _fctContext.FacturaDetalles.Add(invoiceDetail);
                var isSave = await _fctContext.SaveChangesAsync();

                return isSave > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                //crear una tabla para almacenar errrores
                return false;
            }

        }

        public async Task<bool> Delete(int id)
        {
            var invoiceDetail = await GetById(id);

            invoiceDetail.Dltt = true;
            invoiceDetail.Uppdt = DateTime.Now;

            try
            {
                _fctContext.FacturaDetalles.Update(invoiceDetail);
                var isSave = await _fctContext.SaveChangesAsync();

                return isSave > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                //crear una tabla para almacenar errrores
                return false;
            }
        }
        public async Task<bool> Update(FacturaDetalleDto facturaDetalleDto)
        {
            var invoiceDetail = await GetById(facturaDetalleDto.Id);

            if (invoiceDetail == null)
                return false;

            invoiceDetail.Precio = facturaDetalleDto.Precio;
            invoiceDetail.FacturaId = facturaDetalleDto.FacturaId;
            invoiceDetail.ProductoId = facturaDetalleDto.ProductoId;
            invoiceDetail.Uppdt = DateTime.Now;

            try
            {
                _fctContext.FacturaDetalles.Update(invoiceDetail);
                var isSave = await _fctContext.SaveChangesAsync();

                return isSave > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                //crear una tabla para almacenar errrores
                return false;
            }
        }

        public SelectRepositoryDto GetDataSelect()
        {
            var factura = _fctContext.Facturas.AsNoTracking().Where(m => m.Dltt == false).ToList();

            var producto = _fctContext.Productos.AsNoTracking().Where(m => m.Dltt == false).ToList();

            return new SelectRepositoryDto { Factura= factura, Product = producto };
        }


    }
}
