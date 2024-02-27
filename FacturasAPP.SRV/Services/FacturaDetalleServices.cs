using AutoMapper;
using FacturasAPP.DTO.Dto;
using FacturasAPP.DTO.Models.Respository;
using FacturasAPP.DTO.Models.Services;

namespace FacturasAPP.SRV.Services
{
    public class FacturaDetalleServices: IFacturaDetalleServices
    {
        private readonly IFacturaDetalleRepository _facturaDetalleRepository;
        private readonly IMapper _mapper;
        public FacturaDetalleServices(IFacturaDetalleRepository facturaDetalleRepository, IMapper mapper)
        {
            _facturaDetalleRepository = facturaDetalleRepository;
            _mapper = mapper;
        }

        public async Task<List<FacturaDetalleDto>> Get()
        {
            var invoiceDetails = await _facturaDetalleRepository.Get();

            var invoiceDetailsDto = _mapper.Map<List<FacturaDetalleDto>>(invoiceDetails);

            return invoiceDetailsDto;
        }
        public async Task<FacturaDetalleDto> GetById(int id)
        {
            var invoiceDetail = await _facturaDetalleRepository.GetById(id);
            var invoiceDetailDto = _mapper.Map<FacturaDetalleDto>(invoiceDetail);
            return invoiceDetailDto;
        }

        public async Task<bool> Delete(int id)
        {
            var isInvoiceDetail =await GetById(id);

            if (isInvoiceDetail == null)
                return false;

            var isDelete =await _facturaDetalleRepository.Delete(id);

            return isDelete;
        }
        public async Task<bool> Add(FacturaDetalleDto invoiceDto)
        {
            return await _facturaDetalleRepository.Add(invoiceDto);
        }
        public async Task<bool> Update(FacturaDetalleDto invoiceDto)
        { 
            return await _facturaDetalleRepository.Update(invoiceDto);
        }

    }
}
