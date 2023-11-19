using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class ContratoRequest
    {
        public int IdContrato { get; set; }

        public int DuracionContratoMes { get; set; }

        public DateTime FechaContrato { get; set; }

        public DateTime FechaVenContrato { get; set; }

        public string TipoComprobante { get; set; } = null!;

        public string ModoPago { get; set; } = null!;

        public decimal MontoTarifaPlana { get; set; }

        public decimal MontoPagado { get; set; }

        public string Estado { get; set; } = null!;

        //public virtual ICollection<Asistencium> Asistencia { get; set; } = new List<Asistencium>();

        //public virtual ICollection<ContratoUsuario> ContratoUsuarios { get; set; } = new List<ContratoUsuario>();

        //public virtual ICollection<Cronograma> Cronogramas { get; set; } = new List<Cronograma>();

        //public virtual ICollection<DetalleContrato> DetalleContratos { get; set; } = new List<DetalleContrato>();

        //public virtual ICollection<ProductoCliente> ProductoClientes { get; set; } = new List<ProductoCliente>();

        //public virtual ICollection<QuejasReclamo> QuejasReclamos { get; set; } = new List<QuejasReclamo>();
    }
}
