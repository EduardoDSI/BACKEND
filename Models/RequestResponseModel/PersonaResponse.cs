using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class PersonaResponse
    {
        public int IdPersona { get; set; }

        public string Nombres { get; set; } = null!;

        public string? ApellidoPaterno { get; set; }

        public string? ApellidoMaterno { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string CorreoElectronico { get; set; } = null!;

        public string NumeroCelular { get; set; } = null!;

        public string TipoPersona { get; set; } = null!;

        public string NroIdentificacion { get; set; } = null!;

        public int? IdTipoDocumento { get; set; }

        //public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

        //public virtual ICollection<Error> Errors { get; set; } = new List<Error>();

        //public virtual TipoDocumento? IdTipoDocumentoNavigation { get; set; }

        //public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
