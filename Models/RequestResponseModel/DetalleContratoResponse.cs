using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class DetalleContratoResponse
    {
        public int IdDetalleContrato { get; set; }

        public int? IdProductoServicio { get; set; }

        public int? IdContrato { get; set; }

        //public virtual Contrato? IdContratoNavigation { get; set; }

        //public virtual ProductoServicio? IdProductoServicioNavigation { get; set; }
    }
}
