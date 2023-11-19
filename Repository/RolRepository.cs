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
    public class RolRepository : CRUDRepository<Rol>, IRolRepository
    {
        public GenericFilterResponse<Rol> GetByFilter(GenericFilterRequest request)
        {
            var query = dbSet.Where(x => x.IdRol == x.IdRol);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "idRol":
                            query = query.Where(x => x.IdRol == short.Parse(j.Value));
                            break;
                        case "funcion":
                            query = query.Where(x => x.Funcion.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "idUsuario":
                            query = query.Where(x => x.IdUsuario == short.Parse(j.Value));
                            break;
                    }
                }
            });

            GenericFilterResponse<Rol> res = new GenericFilterResponse<Rol>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.Funcion)
                .ToList();

            return res;
        }
    }
}
