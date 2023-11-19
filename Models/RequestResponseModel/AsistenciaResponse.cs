using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class AsistenciaResponse
    {
        public int IdAsistencia { get; set; }

        public DateTime FechaAsistencia { get; set; }

        public DateTime FechaReali { get; set; }

        public string TipoServicio { get; set; } = null!;

        public string? Observaciones { get; set; }

        public int? IdContrato { get; set; }
    }
}
