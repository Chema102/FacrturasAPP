using FacturasAPP.DAC.Models;

namespace FacturasAPP.DTO.Dto
{
    public class SelectRepositoryDto
    {
        public List<Product> Product { get; set; }
        public List<Factura> Factura { get; set; }
    }
}
