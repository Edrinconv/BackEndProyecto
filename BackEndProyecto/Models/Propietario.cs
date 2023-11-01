using System;
using System.Collections.Generic;

namespace BackEndProyecto.Models;

public partial class Propietario
{
    public int CedulaPropietario { get; set; }

    public string? NombrePropietario { get; set; }

    public string? ApellidoPropietario { get; set; }

    public int? TelefonoPropietario { get; set; }

    public string? CorreoPropietario { get; set; }

    public int? CuentaBancariaPropietario { get; set; }

    public string? TipoCuentaPropietario { get; set; }

    public string? NombreBancoPropietario { get; set; }
}
