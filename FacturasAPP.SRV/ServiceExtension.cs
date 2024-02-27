using FacturasAPP.DTO.Models.Services;
using FacturasAPP.REP;
using FacturasAPP.SRV.Mapper;
using FacturasAPP.SRV.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FacturasAPP.SRV
{
    public static class ServiceExtension 
    {
        public static void AddProductsServicesConfigure(IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IProductosServices, ProductsServices>();
            services.AddScoped<IFacturaServices, FacturaServices>();
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
        }

    }
}
