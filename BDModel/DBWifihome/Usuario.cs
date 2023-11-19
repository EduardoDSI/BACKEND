using System;
using System.Collections.Generic;

namespace BDModel.DBWifihome;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public int? IdPersona { get; set; }

    public virtual ICollection<ContratoUsuario> ContratoUsuarios { get; set; } = new List<ContratoUsuario>();

    public virtual ICollection<Error> ErrorUsuarioActualizaNavigations { get; set; } = new List<Error>();

    public virtual ICollection<Error> ErrorUsuarioCreaNavigations { get; set; } = new List<Error>();

    public virtual Persona? IdPersonaNavigation { get; set; }

    public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();
}
