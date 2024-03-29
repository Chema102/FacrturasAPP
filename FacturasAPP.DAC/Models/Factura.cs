﻿using System;
using System.Collections.Generic;

namespace FacturasAPP.DAC.Models;

public partial class Factura
{
    public int Id { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Total { get; set; }

    public DateTime? Crt { get; set; }

    public DateTime? Uppdt { get; set; }

    public bool? Dltt { get; set; }

}
