namespace FacturasAPP.DAC.Models;
public partial class FacturaDetalle
{
    public int Id { get; set; }

    public int FacturaId { get; set; }

    public string ProductoId { get; set; } = null!;

    public decimal? Precio { get; set; }

    public DateTime? Crt { get; set; }

    public DateTime? Uppdt { get; set; }

    public bool? Dltt { get; set; }
    public virtual Factura Factura { get; set; } = null!;

    public virtual Product Producto { get; set; } = null!;
}

