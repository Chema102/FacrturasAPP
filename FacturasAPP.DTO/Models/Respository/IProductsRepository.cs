using FacturasAPP.DAC.Models;
using FacturasAPP.DTO.Dto;

namespace FacturasAPP.DTO.Models.Respository
{
    public interface IProductsRepository
    {
        Task<List<Product>> Get();
        Task<Product> GetById(string id);
        Task<bool> Add(ProducDto product);
        Task<bool> Delete(string id);
        Task<bool> Update(ProducDto id);
    }
}
