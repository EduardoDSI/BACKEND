using System;
using System.Collections.Generic;

namespace BDModel.DBWifihome;

public partial class Rol
{
    public int IdRol { get; set; }

    public string Funcion { get; set; } = null!;

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
