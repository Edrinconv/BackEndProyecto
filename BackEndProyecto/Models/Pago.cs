using System;
using System.Collections.Generic;

namespace BackEndProyecto.Models;

public partial class Pago
{
    public int RcPagos { get; set; }

    public int? FacturaPagos { get; set; }

    public DateTime? FechaPagos { get; set; }

    public DateTime? FechaAbonoCanonPagos { get; set; }

    public decimal? AbonoAdministracionPagos { get; set; }

    public decimal? InteresPagos { get; set; }

    public decimal? TasaInteresPagos { get; set; }
}
