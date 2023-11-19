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
    public class UbigeoRepository : CRUDRepository<Ubigeo>, IUbigeoRepository
    {
        public GenericFilterResponse<Ubigeo> GetByFilter(GenericFilterRequest request)
        {
            var query = dbSet.Where(x => x.IdUbigeo == x.IdUbigeo);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "idUbigeo":
                            query = query.Where(x => x.IdUbigeo == short.Parse(j.Value));
                            break;
                        case "departamento":
                            query = query.Where(x => x.Departamento.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "provincia":
                            query = query.Where(x => x.Provincia.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "distrito":
                            query = query.Where(x => x.Distrito.ToLower().Contains(j.Value.ToLower()));
                            break;
                    }
                }
            });

            GenericFilterResponse<Ubigeo> res = new GenericFilterResponse<Ubigeo>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.Distrito)
                .ToList();

            return res;
        }
    }
}
