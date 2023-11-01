using System;
using System.Collections.Generic;

namespace BackEndProyecto.Models;

public partial class Inmueble
{
    public string MatriculaInmobiliariaInmueble { get; set; } = null!;

    public string? ChipInmueble { get; set; }

    public string? TipoInmueble { get; set; }

    public string? NomenclaturaInmueble { get; set; }

    public decimal? AreaPrivadaInmueble { get; set; }

    public decimal? AreaConstruidaInmueble { get; set; }

    public string? NumeroEscrituraInmueble { get; set; }

    public int? AlcobasInmueble { get; set; }

    public int? BanosInmueble { get; set; }

    public int? VehiculoInmueble { get; set; }

    public int? IdLocativaInmueble { get; set; }

    public int? CedulaPropietarioInmueble { get; set; }

    public int? MatriculaInmobiliariaProyectoInmueble { get; set; }
}
