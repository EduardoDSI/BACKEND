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
    public class ContratoUsuarioRepository : CRUDRepository<ContratoUsuario>, IContratoUsuarioRepository
    {
        public GenericFilterResponse<ContratoUsuario> GetByFilter(GenericFilterRequest request)
        {
            var query = dbSet.Where(x => x.IdContrUsuario == x.IdContrUsuario);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "idContrUsuario":
                            query = query.Where(x => x.IdContrUsuario == short.Parse(j.Value));
                            break;
                        case "idUsuario":
                            query = query.Where(x => x.IdUsuario == short.Parse(j.Value));
                            break;
                        case "idContrato":
                            query = query.Where(x => x.IdContrato == short.Parse(j.Value));
                            break;                      
                    }
                }
            });

            GenericFilterResponse<ContratoUsuario> res = new GenericFilterResponse<ContratoUsuario>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.IdContrUsuario)
                .ToList();

            return res;
        }
    }
}
