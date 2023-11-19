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
    public class ContratoRepository : CRUDRepository<Contrato>, IContratoRepository
    {
        public GenericFilterResponse<Contrato> GetByFilter(GenericFilterRequest request)
        {
            var query = dbSet.Where(x => x.IdContrato == x.IdContrato);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "idContrato":
                            query = query.Where(x => x.IdContrato == short.Parse(j.Value));
                            break;
                        case "duracionContratoMes":
                            query = query.Where(x => x.DuracionContratoMes == short.Parse(j.Value));
                            break;
                        case "fechaContrato":
                            query = query.Where(x => x.FechaContrato.ToLongDateString()
                            .Contains(j.Value));
                            break;
                        case "fechaVenContrato":
                            query = query.Where(x => x.FechaVenContrato.ToLongDateString()
                            .Contains(j.Value));
                            break;
                        case "tipoComprobante":
                            query = query.Where(x => x.TipoComprobante.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "modoPago":
                            query = query.Where(x => x.ModoPago.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "MontoTarifaPlana":
                            query = query.Where(x => x.MontoTarifaPlana == short.Parse(j.Value));
                            break;
                        case "MontoPagado":
                            query = query.Where(x => x.MontoPagado == short.Parse(j.Value));
                            break;
                        case "estado":
                            query = query.Where(x => x.Estado.ToLower().Contains(j.Value.ToLower()));
                            break;
                    }
                }
            });

            GenericFilterResponse<Contrato> res = new GenericFilterResponse<Contrato>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.FechaContrato)
                .ToList();

            return res;
        }
    }
}
