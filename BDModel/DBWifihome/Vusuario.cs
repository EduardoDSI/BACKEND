using System;
using System.Collections.Generic;

namespace BDModel.DBWifihome;

public partial class Vusuario
{
    public int Id { get; set; }

    public string Usuario { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public int? IdPersona { get; set; }

    public string Nombres { get; set; } = null!;

    public string NumeroCelular { get; set; } = null!;

    public string NroIdentificacion { get; set; } = null!;

    public int IdRol { get; set; }

    public string RolFuncion { get; set; } = null!;
}
