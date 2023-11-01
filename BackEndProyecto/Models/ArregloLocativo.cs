using System;
using System.Collections.Generic;

namespace BackEndProyecto.Models;

public partial class ArregloLocativo
{
    public int IdLocativaArreglo { get; set; }

    public DateTime? FechaInicioArreglo { get; set; }

    public DateTime? FechaFinalizacionArreglo { get; set; }

    public string? EstadoArreglo { get; set; }

    public string? ObservacionesArreglo { get; set; }
}
