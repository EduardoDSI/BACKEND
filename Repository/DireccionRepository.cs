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
    public class DireccionRepository : CRUDRepository<Direccion>, IDireccionRepository
    {
        public GenericFilterResponse<Direccion> GetByFilter(GenericFilterRequest request)
        {
            var query = dbSet.Where(x => x.IdDireccion == x.IdDireccion);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "idDireccion":
                            query = query.Where(x => x.IdDireccion == short.Parse(j.Value));
                            break;
                        case "calle":
                            query = query.Where(x => x.Calle.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "referencia":
                            query = query.Where(x => x.Referencia.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "idPersona":
                            query = query.Where(x => x.IdPersona == short.Parse(j.Value));
                            break;
                    }
                }
            });

            GenericFilterResponse<Direccion> res = new GenericFilterResponse<Direccion>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.Calle)
                .ToList();

            return res;
        }
    }
}
