using System;
using System.Collections.Generic;

namespace BDModel.DBWifihome;

public partial class Imagen
{
    public int IdImagen { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdProductoServicio { get; set; }

    public virtual ProductoServicio? IdProductoServicioNavigation { get; set; }
}
