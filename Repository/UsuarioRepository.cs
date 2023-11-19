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
    public class UsuarioRepository : CRUDRepository<Usuario>, IUsuarioRepository
    {
        public GenericFilterResponse<Usuario> GetByFilter(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        public Usuario GetByUserName(string username)
        {
            Usuario usuario = dbSet
                .Where(x => x.Usuario1.ToLower() == username.ToLower())
                //ES MEDIANAMENTE OPTIMO
                //.Include(x => x.IdRolNavigation)
                //.Include(x => x.IdPersonaNavigation)

                .FirstOrDefault();

            return usuario;
        }

        public Vusuario GetByVistaUsername(string username)
        {
            Vusuario vUsuario = db.Vusuarios.Where(x => x.Usuario.ToLower() == username.ToLower()).FirstOrDefault();
            return vUsuario;
        }
    }
}
