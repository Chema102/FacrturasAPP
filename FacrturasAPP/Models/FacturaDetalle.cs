using System;
using System.Collections.Generic;

namespace FacrturasAPP.Models;

public partial class FacturaDetalle
{
    public int Id { get; set; }

    public int FacturaId { get; set; }

    public required string ProductoId { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? Crt { get; set; }

    public DateTime? Uppdt { get; set; }

    public bool? Dltt { get; set; }

    public required Factura Factura { get; set; }

    public required Producto Producto { get; set; }
}
