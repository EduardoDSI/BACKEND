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
    public class DetalleContratoRepository : CRUDRepository<DetalleContrato>, IDetalleContratoRepository
    {
        public GenericFilterResponse<DetalleContrato> GetByFilter(GenericFilterRequest request)
        {
            var query = dbSet.Where(x => x.IdDetalleContrato == x.IdDetalleContrato);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "idDetalleContrato":
                            query = query.Where(x => x.IdDetalleContrato == short.Parse(j.Value));
                            break;
                        case "idProductoServicio":
                            query = query.Where(x => x.IdProductoServicio == short.Parse(j.Value));
                            break;
                        case "idContrato":
                            query = query.Where(x => x.IdContrato == short.Parse(j.Value));
                            break;
                    }
                }
            });

            GenericFilterResponse<DetalleContrato> res = new GenericFilterResponse<DetalleContrato>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.IdDetalleContrato)
                .ToList();

            return res;
        }
    }
}
