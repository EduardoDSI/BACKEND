using System;
using System.Collections.Generic;

namespace BDModel.DBWifihome;

public partial class Asistencium
{
    public int IdAsistencia { get; set; }

    public DateTime FechaAsistencia { get; set; }

    public DateTime FechaReali { get; set; }

    public string TipoServicio { get; set; } = null!;

    public string? Observaciones { get; set; }

    public int? IdContrato { get; set; }

    public virtual Contrato? IdContratoNavigation { get; set; }
}
