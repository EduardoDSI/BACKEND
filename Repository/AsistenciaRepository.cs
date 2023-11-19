using BDModel.DBWifihome;
using IRepository;
using Microsoft.EntityFrameworkCore;
using Models.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AsistenciaRepository : CRUDRepository<Asistencium>, IAsistenciaRepository
    {
        public GenericFilterResponse<Asistencium> GetByFilter(GenericFilterRequest request)
        {
            var query = dbSet.Where(x => x.IdAsistencia == x.IdAsistencia);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "idAsistencia":
                            query = query.Where(x => x.IdAsistencia == short.Parse(j.Value));
                            break;
                        case "fechaAsistencia":
                            query = query.Where(x => x.FechaAsistencia.ToLongDateString()
                            .Contains(j.Value));
                            break;
                        case "fechaReali":
                            query = query.Where(x => x.FechaReali.ToLongDateString()
                            .Contains(j.Value));
                            break;
                        case "tipoServicio":
                            query = query.Where(x => x.TipoServicio.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "observaciones":
                            query = query.Where(x => x.Observaciones.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "idContrato":
                            query = query.Where(x => x.IdContrato == short.Parse(j.Value));
                            break;
                        
                    }
                }
            });

            GenericFilterResponse<Asistencium> res = new GenericFilterResponse<Asistencium>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.FechaAsistencia)
                .ToList();

            return res;
        }
    }
}
