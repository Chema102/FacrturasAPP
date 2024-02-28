namespace FacturasAPP.DAC.Models;

public partial class Product
{
    public string Id { get; set; } = null!;

    public string Descripccion { get; set; } = null!;

    public DateTime? Crt { get; set; }

    public DateTime? Uppdt { get; set; }

    public bool? Dltt { get; set; }

}
