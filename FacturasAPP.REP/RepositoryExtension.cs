using FacturasAPP.DAC.Models;
using FacturasAPP.DTO.Models.Respository;
using FacturasAPP.REP.Respository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FacturasAPP.REP
{
    public class RepositoryExtension
    {
        public static void AddProductsRepositoryConfigure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddDbContext<FctContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DBContext"));
            });

        }
    }
}
