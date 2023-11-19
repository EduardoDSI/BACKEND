using System;
using System.Collections.Generic;

namespace BDModel.DBWifihome;

public partial class Direccion
{
    public int IdDireccion { get; set; }

    public string Calle { get; set; } = null!;

    public string? Referencia { get; set; }

    public int? IdPersona { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }
}
