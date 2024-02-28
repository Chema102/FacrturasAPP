using AutoMapper;
using FacturasAPP.DAC.Models;
using FacturasAPP.DTO.Dto;
using FacturasAPP.DTO.Models.Respository;
using FacturasAPP.DTO.Models.Services;

namespace FacturasAPP.SRV.Services
{
    public class ProductsServices : IProductosServices
    {
        private readonly IProductsRepository _productsRepository;
        private IMapper _mapper;
        public ProductsServices(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<List<ProducDto>> Get()
        {
            var products = await _productsRepository.Get();
            var productsDto = new List<ProducDto>();

            if (products == null) 
                return new List<ProducDto>();

            foreach (var item in products)
            {
                productsDto.Add(new ProducDto
                {
                    Id = item.Id,
                    Description = item.Descripccion,
                    CreatedDate = (DateTime)item.Crt,
                });
            }
            //var result = _mapper.Map<List<ProducDto>>(products);
            return productsDto;
        } 

        public async Task<ProducDto> GetById(string id)
        {
            var product = await _productsRepository.GetById(id);

            if (product == null)
                return null;

            var productsDto = new ProducDto
            {
                Id = product.Id,
                Description= product.Descripccion, 
                CreatedDate = (DateTime)product.Crt

            };

            return  productsDto;
        }

        public async Task<bool> Add(ProducDto product)
        {
            return await _productsRepository.Add(product);
        }

        public async Task<bool> Delete(string id)
        {
            var isProduc = await GetById(id);

            if (isProduc == null)
                return false;

            var isResult = await _productsRepository.Delete(id);

            return isResult;
        }

        public async Task<bool> Update(ProducDto productDto)
        {
            var isUpdate = await _productsRepository.Update(productDto);

            return isUpdate;
        }
    }
}
