using System;
using System.Collections.Generic;

namespace BackEndProyecto.Models;

public partial class ContratoArriendo
{
    public int IdContrato { get; set; }

    public DateTime? FechaInicioContrato { get; set; }

    public decimal? ValorCanonContrato { get; set; }

    public decimal? ValorAdministracionContrato { get; set; }

    public int? RcPagosContrato { get; set; }

    public int? CedulaArrendatarioContrato { get; set; }
}
