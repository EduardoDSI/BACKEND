using System;
using System.Collections.Generic;

namespace BDModel.DBWifihome;

public partial class Ubigeo
{
    public int IdUbigeo { get; set; }

    public string Departamento { get; set; } = null!;

    public string? Provincia { get; set; }

    public string? Distrito { get; set; }
}
