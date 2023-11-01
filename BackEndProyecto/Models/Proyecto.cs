using System;
using System.Collections.Generic;

namespace BackEndProyecto.Models;

public partial class Proyecto
{
    public int MatriculaInmobiliariaProyecto { get; set; }

    public string? NombreProyecto { get; set; }

    public string? DireccionProyecto { get; set; }

    public int? EstratoProyecto { get; set; }

    public string? EscrituraReglamentoProyecto { get; set; }

    public string? AdministradorProyecto { get; set; }

    public string? TelefonoAdministradorProyecto { get; set; }

    public string? CorreoAdministradorProyecto { get; set; }
}
