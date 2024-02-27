using FacturasAPP.DAC.Models;
using FacturasAPP.DTO.Dto;
using FacturasAPP.DTO.Models.Respository;
using Microsoft.EntityFrameworkCore;


namespace FacturasAPP.REP.Respository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly FctContext _fctContext;
        public ProductsRepository(FctContext fctContext)
        {
            _fctContext = fctContext;
        }

        public async Task<List<Product>> Get()
        {
            return await _fctContext.Productos.AsNoTracking().Where(m => m.Dltt == false).ToListAsync();
        }

        public async Task<Product> GetById(string id)
        {
            var producto = await _fctContext.Productos
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id && m.Dltt == false);

            return producto;
        }

        public async Task<bool> Add(ProducDto productDto)
        {
            var product = new Product
            {
                Id = productDto.Id,
                Descripccion = productDto.Description,
                Crt = DateTime.Now,
                Uppdt = DateTime.Now,
                Dltt = false
            };

            _fctContext.Productos.Add(product);
            var isProduct =await _fctContext.SaveChangesAsync();

            return isProduct > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var product = await GetById(id);

            product.Dltt = true;
            product.Uppdt = DateTime.Now;
            _fctContext.Productos.Update(product);
            var isSave = await _fctContext.SaveChangesAsync();

            return isSave > 0;
        }

        public async Task<bool> Update(ProducDto producDto)
        {
            var product = await GetById(producDto.Id);

            if(product == null)
                return false;

            try
            {
                product.Id = producDto.Id;
                product.Descripccion = producDto.Description;
                product.Uppdt = DateTime.Now;

                _fctContext.Productos.Update(product);

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
