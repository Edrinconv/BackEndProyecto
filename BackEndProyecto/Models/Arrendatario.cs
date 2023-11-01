using System;
using System.Collections.Generic;

namespace BackEndProyecto.Models;

public partial class Arrendatario
{
    public int CedulaArrendatario { get; set; }

    public string? NombreArrendatario { get; set; }

    public string? ApellidoArrendatario { get; set; }

    public int? TelefonoArrendatario { get; set; }

    public string? CorreoArrendatario { get; set; }
}
