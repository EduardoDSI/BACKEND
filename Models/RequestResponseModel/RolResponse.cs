using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class RolResponse
    {
        public int IdRol { get; set; }

        public string Funcion { get; set; } = null!;

        public int? IdUsuario { get; set; }

        //public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
