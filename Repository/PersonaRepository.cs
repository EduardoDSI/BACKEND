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
    public class PersonaRepository : CRUDRepository<Persona>, IPersonaRepository
    {
        public GenericFilterResponse<Persona> GetByFilter(GenericFilterRequest request)
        {
            var query = dbSet.Where(x => x.IdPersona == x.IdPersona);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "idPersona":
                            query = query.Where(x => x.IdPersona == short.Parse(j.Value));
                            break;
                        case "Nombres":
                            query = query.Where(x => x.Nombres.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "ApellidoPaterno":
                            query = query.Where(x => x.ApellidoPaterno.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "ApellidoMaterno":
                            query = query.Where(x => x.ApellidoMaterno.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "FechaNacimiento":
                            query = query.Where(x => x.FechaNacimiento.ToLongDateString()
                            .Contains(j.Value));
                            break;
                        case "CorreoElectronico":
                            query = query.Where(x => x.CorreoElectronico.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "NumeroCelular":
                            query = query.Where(x => x.NumeroCelular.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "TipoPersona":
                            query = query.Where(x => x.TipoPersona.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "NroIdentificacion":
                            query = query.Where(x => x.NroIdentificacion.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "IdTipoDocumento":
                            query = query.Where(x => x.IdTipoDocumento == short.Parse(j.Value));
                            break;
                    }
                }
            });

            GenericFilterResponse<Persona> res = new GenericFilterResponse<Persona>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.Nombres)
                .ToList();

            return res;
        }
    }
}
