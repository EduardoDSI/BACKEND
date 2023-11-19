using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class ProductoClienteResponse
    {
        public int IdProducClien { get; set; }

        public string Descripcion { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public string? Observacion { get; set; }

        public int? IdContrato { get; set; }

        //public virtual Contrato? IdContratoNavigation { get; set; }
    }
}
