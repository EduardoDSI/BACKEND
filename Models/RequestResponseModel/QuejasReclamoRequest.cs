using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class QuejasReclamoRequest
    {
        public int IdQuejaReclamo { get; set; }

        public int? IdContrato { get; set; }

        public DateTime FechaQuejaReclamo { get; set; }

        public string Descripcion { get; set; } = null!;

        //public virtual Contrato? IdContratoNavigation { get; set; }
    }
}
