using System;
using System.Collections.Generic;

namespace BDModel.DBWifihome;

public partial class TipoDocumento
{
    public int IdTipoDocumento { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
