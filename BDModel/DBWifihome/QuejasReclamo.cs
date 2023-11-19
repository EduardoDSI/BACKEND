using System;
using System.Collections.Generic;

namespace BDModel.DBWifihome;

public partial class QuejasReclamo
{
    public int IdQuejaReclamo { get; set; }

    public int? IdContrato { get; set; }

    public DateTime FechaQuejaReclamo { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual Contrato? IdContratoNavigation { get; set; }
}
