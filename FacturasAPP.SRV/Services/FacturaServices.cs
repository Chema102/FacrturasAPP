using FacturasAPP.DTO.Dto;
using FacturasAPP.DTO.Models.Respository;
using FacturasAPP.DTO.Models.Services;

namespace FacturasAPP.SRV.Services
{
    public class FacturaServices : IFacturaServices
    {
        private readonly IFacturaRepository _facturaRepository;
        public FacturaServices(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public async Task<List<FacturaDto>> Get()
        {
            var invoices = await _facturaRepository.Get();
            var invoicesDto = new List<FacturaDto>();

            if (invoices == null)
                return new List<FacturaDto>();

            foreach (var item in invoices)
            {
                invoicesDto.Add(new FacturaDto
                {
                    Id = item.Id,
                    Fecha = (DateOnly)item.Fecha,
                    Total = (decimal)item.Total,
                    Create = (DateTime)item.Crt,
                });
            }
            //var result = _mapper.Map<List<ProducDto>>(invoices);
            return invoicesDto;
        }

        public async Task<FacturaDto> GetById(int id)
        {
            var invoice = await _facturaRepository.GetById(id);

            if (invoice == null)
                return null;

            var invoicesDto = new FacturaDto
            {
                Id = invoice.Id,
                Fecha = (DateOnly)invoice.Fecha,
                Total = (decimal)invoice.Total, 
                Create = (DateTime)invoice.Crt

            };

            return invoicesDto;
        }

        public async Task<bool> Add(FacturaDto product)
        {
            return await _facturaRepository.Add(product);
        }

        public async Task<bool> Delete(int id)
        {
            var isInvoice = await GetById(id);
            if (isInvoice == null)
                return false;

            var isResult = await _facturaRepository.Delete(id);

            return isResult;
        }

        public async Task<bool> Update(FacturaDto productDto)
        {
            return await _facturaRepository.Update(productDto); ;
        }

    }
}
