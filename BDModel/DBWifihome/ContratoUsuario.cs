using System;
using System.Collections.Generic;

namespace BDModel.DBWifihome;

public partial class ContratoUsuario
{
    public int IdContrUsuario { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdContrato { get; set; }

    public virtual Contrato? IdContratoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
