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
    public class QuejasReclamoRepository : CRUDRepository<QuejasReclamo>, IQuejasReclamoRepository
    {
        public GenericFilterResponse<QuejasReclamo> GetByFilter(GenericFilterRequest request)
        {
            var query = dbSet.Where(x => x.IdQuejaReclamo == x.IdQuejaReclamo);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "IdQuejaReclamo":
                            query = query.Where(x => x.IdQuejaReclamo == short.Parse(j.Value));
                            break;
                        case "IdContrato":
                            query = query.Where(x => x.IdContrato == short.Parse(j.Value));
                            break;
                        case "FechaQuejaReclamo":
                            query = query.Where(x => x.FechaQuejaReclamo.ToLongDateString()
                            .Contains(j.Value));
                            break;
                        case "Descripcion":
                            query = query.Where(x => x.Descripcion.ToLower().Contains(j.Value.ToLower()));
                            break;
                    }
                }
            });

            GenericFilterResponse<QuejasReclamo> res = new GenericFilterResponse<QuejasReclamo>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.FechaQuejaReclamo)
                .ToList();

            return res;
        }
    }
}
