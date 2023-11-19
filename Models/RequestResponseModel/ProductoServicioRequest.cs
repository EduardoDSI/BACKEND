using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class ProductoServicioRequest
    {
        public int IdProdServ { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public byte? Puntuacion { get; set; }

        public int StockMin { get; set; }

        public int? StockActual { get; set; }

        public decimal Precio { get; set; }

        public string Estado { get; set; } = null!;

        //public virtual ICollection<DetalleContrato> DetalleContratos { get; set; } = new List<DetalleContrato>();

        //public virtual ICollection<Imagen> Imagens { get; set; } = new List<Imagen>();
    }
}
