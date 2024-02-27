namespace FacturasAPP.DTO.Dto
{
    public class FacturaDto
    {
        public int Id { get; set; }
        public required DateOnly Fecha { get; set; }

        public required decimal Total { get; set; }

        public DateTime? Crt { get; set; }
    }
}
