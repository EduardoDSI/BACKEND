using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class ContratoUsuarioRequest
    {
        public int IdContrUsuario { get; set; }

        public int? IdUsuario { get; set; }

        public int? IdContrato { get; set; }

        //public virtual Contrato? IdContratoNavigation { get; set; }

        //public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
