namespace FacturasAPP.DTO.Dto
{
    public class FacturaDetalleDto
    {
        public int Id { get; set; }

        public required int FacturaId { get; set; }

        public required string ProductoId { get; set; }

        public decimal Precio { get; set; }

        public DateTime? Crt { get; set; }
    }
}
