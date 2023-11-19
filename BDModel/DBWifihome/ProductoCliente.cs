using System;
using System.Collections.Generic;

namespace BDModel.DBWifihome;

public partial class ProductoCliente
{
    public int IdProducClien { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string? Observacion { get; set; }

    public int? IdContrato { get; set; }

    public virtual Contrato? IdContratoNavigation { get; set; }
}
