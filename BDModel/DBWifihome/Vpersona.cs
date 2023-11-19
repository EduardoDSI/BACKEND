using System;
using System.Collections.Generic;

namespace BDModel.DBWifihome;

public partial class Vpersona
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public string TipoPersona { get; set; } = null!;

    public string NumeroCelular { get; set; } = null!;

    public string NroIdentificacion { get; set; } = null!;

    public string TipoDocumento { get; set; } = null!;
}
