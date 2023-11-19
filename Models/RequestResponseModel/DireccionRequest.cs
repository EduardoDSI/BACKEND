using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class DireccionRequest
    {
        public int IdDireccion { get; set; }

        public string Calle { get; set; } = null!;

        public string? Referencia { get; set; }

        public int? IdPersona { get; set; }

        //public virtual Persona? IdPersonaNavigation { get; set; }
    }
}
