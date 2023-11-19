using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class CronogramaRequest
    {
        public int IdCronograma { get; set; }

        public int? IdContrato { get; set; }

        public decimal NroCuota { get; set; }

        public DateTime FechaVenc { get; set; }

        public byte? Mes { get; set; }

        public string? MesLetra { get; set; }

        public int? Anio { get; set; }

        public decimal? PenalidadMes { get; set; }

        public decimal? Aniadido { get; set; }

        public decimal? DeudaAnt { get; set; }

        public decimal TotalPago { get; set; }

        public DateTime FechaPago { get; set; }

        public string EstadoPago { get; set; } = null!;

        //public virtual Contrato? IdContratoNavigation { get; set; }
    }
}
