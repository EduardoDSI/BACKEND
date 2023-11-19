using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class UsuarioLoginResponse
    {
        public int Id { get; set; }

        public string Usuario { get; set; } = null!;

        public string Contrasenia { get; set; } = null!;

        public int IdPersona { get; set; }
        public int IdRol { get; set; }
    }
}
