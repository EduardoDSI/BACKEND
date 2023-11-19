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
    public class TipoDocumentoRepository : CRUDRepository<TipoDocumento>, ITipoDocumentoRepository
    {
        public GenericFilterResponse<TipoDocumento> GetByFilter(GenericFilterRequest request)
        {
            var query = dbSet.Where(x => x.IdTipoDocumento == x.IdTipoDocumento);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "idTipoDocumento":
                            query = query.Where(x => x.IdTipoDocumento == short.Parse(j.Value));
                            break;
                        case "Nombre":
                            query = query.Where(x => x.Nombre.ToLower().Contains(j.Value.ToLower()));
                            break;
                    }
                }
            });

            GenericFilterResponse<TipoDocumento> res = new GenericFilterResponse<TipoDocumento>();

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
