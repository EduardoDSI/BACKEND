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
    public class ProductoClienteRepository : CRUDRepository<ProductoCliente>, IProductoClienteRepository
    {
        public GenericFilterResponse<ProductoCliente> GetByFilter(GenericFilterRequest request)
        {
            var query = dbSet.Where(x => x.IdProducClien == x.IdProducClien);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "idProducClien":
                            query = query.Where(x => x.IdProducClien == short.Parse(j.Value));
                            break;
                        case "descripcion":
                            query = query.Where(x => x.Descripcion.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "estado":
                            query = query.Where(x => x.Estado.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "observacion":
                            query = query.Where(x => x.Observacion.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "idContrato":
                            query = query.Where(x => x.IdContrato == short.Parse(j.Value));
                            break;
                    }
                }
            });

            GenericFilterResponse<ProductoCliente> res = new GenericFilterResponse<ProductoCliente>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.Estado)
                .ToList();

            return res;
        }
    }
}
