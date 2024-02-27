using FacturasAPP.DAC.Models;
using FacturasAPP.DTO.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasAPP.DTO.Models.Respository
{
    public interface IFacturaRepository
    {
        Task<List<Factura>> Get();
        Task<Factura> GetById(int id);
        Task<bool> Delete(int id);
        Task<bool> Add(FacturaDto invoiceDto);
        Task<bool> Update(FacturaDto invoiceDto);
    }
}
