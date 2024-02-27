using FacturasAPP.DAC.Models;
using FacturasAPP.DTO.Dto;
using FacturasAPP.DTO.Models.Respository;
using Microsoft.EntityFrameworkCore;

namespace FacturasAPP.REP.Respository
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly FctContext _fctContext;
        public FacturaRepository(FctContext fctContext)
        {
            _fctContext = fctContext;
        }
        public async Task<List<Factura>> Get()
        {
            var invoices = await _fctContext.Facturas
                .AsNoTracking()
                .Where(m => m.Dltt == false)
                .ToListAsync();

            return invoices;
        }

        public async Task<Factura> GetById(int id)
        {
            var producto = await _fctContext.Facturas
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id && m.Dltt == false);

            return producto;
        }
        public async Task<bool> Add(FacturaDto invoiceDto)
        {
            var invoice = new Factura
            {
                Id = invoiceDto.Id,
                Total = invoiceDto.Total,
                Fecha = invoiceDto.Fecha,
                Crt = DateTime.Now,
                Uppdt = DateTime.Now,
                Dltt = false
            };
            try
            {
                _fctContext.Facturas.Add(invoice);
                var isProduct = await _fctContext.SaveChangesAsync();
                return isProduct > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                //crear una tabla para almacenar errrores
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var invoice = await GetById(id);

                invoice.Dltt = true;
                invoice.Uppdt = DateTime.Now;
                _fctContext.Facturas.Update(invoice);
                var isSave = await _fctContext.SaveChangesAsync();

                return isSave > 0;

            }
            catch (DbUpdateConcurrencyException)
            {
                //crear una tabla para almacenar errrores
                return false;
            }
        }
        public async Task<bool> Update(FacturaDto invoiceDto)
        {
            var invoice = await GetById(invoiceDto.Id);

            if (invoice == null)
                return false;
            try
            {
                invoice.Total = invoiceDto.Total;
                invoice.Fecha = invoiceDto.Fecha;
                invoice.Uppdt = DateTime.Now;

                _fctContext.Facturas.Update(invoice);

                var isSave = await _fctContext.SaveChangesAsync();
                return isSave > 0;

            }
            catch (DbUpdateConcurrencyException)
            {
                //crear una tabla para almacenar errrores
                return false;
            }

        }

    }
}
