using System;
using System.Collections.Generic;

namespace FacrturasAPP.Models;

public partial class Producto
{
    public string Id { get; set; } = null!;

    public string Descripccion { get; set; } = null!;

    public DateTime? Crt { get; set; }

    public DateTime? Uppdt { get; set; }

    public bool? Dltt { get; set; }

    public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; } = new List<FacturaDetalle>();
}
