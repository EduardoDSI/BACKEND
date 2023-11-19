using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class UsuarioResponse
    {
        public int IdUsuario { get; set; }

        public string Usuario1 { get; set; } = null!;

        public string Contrasenia { get; set; } = null!;

        public int? IdPersona { get; set; }
    }
}
