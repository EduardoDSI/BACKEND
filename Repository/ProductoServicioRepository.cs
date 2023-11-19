using BDModel.DBWifihome;
using IRepository;
using Models.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductoServicioRepository : CRUDRepository<ProductoServicio>, IProductoServicioRepository
    {
        public GenericFilterResponse<ProductoServicio> GetByFilter(GenericFilterRequest request)
        {
            var query = dbSet.Where(x => x.IdProdServ == x.IdProdServ);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "idProductoServicio":
                            query = query.Where(x => x.IdProdServ == short.Parse(j.Value));
                            break;
                        case "mombre":
                            query = query.Where(x => x.Nombre.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "descripcion":
                            query = query.Where(x => x.Descripcion.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "puntuacion":
                            byte? jValue = byte.TryParse(j.Value.ToString(), out byte parsedValue) ? (byte?)parsedValue : null;
                            query = query.Where(x => x.Puntuacion.HasValue && x.Puntuacion.Value == jValue);
                            break;
                        case "stockMin":
                            query = query.Where(x => x.StockMin == short.Parse(j.Value));
                            break;
                        case "stockActual":
                            query = query.Where(x => x.StockActual == short.Parse(j.Value));
                            break;
                        case "precio":
                            query = query.Where(x => x.Precio == short.Parse(j.Value));
                            break;
                        case "estado":
                            query = query.Where(x => x.Estado.ToLower().Contains(j.Value.ToLower()));
                            break;
                    }
                }
            });

            GenericFilterResponse<ProductoServicio> res = new GenericFilterResponse<ProductoServicio>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.Nombre)
                .ToList();

            return res;
        }
    }
}
