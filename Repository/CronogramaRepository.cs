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
    public class CronogramaRepository : CRUDRepository<Cronograma>, ICronogramaRepository
    {
        public GenericFilterResponse<Cronograma> GetByFilter(GenericFilterRequest request)
        {
            var query = dbSet.Where(x => x.IdCronograma == x.IdCronograma);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "idCronograma":
                            query = query.Where(x => x.IdCronograma == short.Parse(j.Value));
                            break;
                        case "idContrato":
                            query = query.Where(x => x.IdContrato == short.Parse(j.Value));
                            break;
                        case "nroCuota":
                            query = query.Where(x => x.NroCuota == short.Parse(j.Value));
                            break;
                        case "fechaVenc":
                            query = query.Where(x => x.FechaVenc.ToLongDateString()
                            .Contains(j.Value));
                            break;
                        case "mes":
                            byte? jValue = byte.TryParse(j.Value.ToString(), out byte parsedValue) ? (byte?)parsedValue : null;
                            query = query.Where(x => x.Mes.HasValue && x.Mes.Value == jValue);
                            break;
                        case "mesLetra":
                            query = query.Where(x => x.MesLetra.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "anio":
                            query = query.Where(x => x.Anio == short.Parse(j.Value));
                            break;
                        case "penalidadMes":
                            query = query.Where(x => x.PenalidadMes == short.Parse(j.Value));
                            break;
                        case "aniadido":
                            query = query.Where(x => x.Aniadido == short.Parse(j.Value));
                            break;
                        case "deudaAnt":
                            query = query.Where(x => x.DeudaAnt == short.Parse(j.Value));
                            break;
                        case "totalPago":
                            query = query.Where(x => x.TotalPago == short.Parse(j.Value));
                            break;
                        case "fechaPago":
                            query = query.Where(x => x.FechaPago.ToLongDateString()
                            .Contains(j.Value));
                            break;
                        case "estadoPago":
                            query = query.Where(x => x.EstadoPago.ToLower().Contains(j.Value.ToLower()));
                            break;
                    }
                }
            });

            GenericFilterResponse<Cronograma> res = new GenericFilterResponse<Cronograma>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.NroCuota)
                .ToList();

            return res;
        }
    }
}
