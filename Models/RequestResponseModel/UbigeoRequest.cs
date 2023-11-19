using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class UbigeoRequest
    {
        public int IdUbigeo { get; set; }

        public string Departamento { get; set; } = null!;

        public string? Provincia { get; set; }

        public string? Distrito { get; set; }
    }
}
