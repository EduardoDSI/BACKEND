using System;
using System.Collections.Generic;

namespace BDModel.DBWifihome;

public partial class DetalleContrato
{
    public int IdDetalleContrato { get; set; }

    public int? IdProductoServicio { get; set; }

    public int? IdContrato { get; set; }

    public virtual Contrato? IdContratoNavigation { get; set; }

    public virtual ProductoServicio? IdProductoServicioNavigation { get; set; }
}
