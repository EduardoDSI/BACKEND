using BDModel.DBWifihome;
using Models.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBussnies
{
    public interface IUsuarioBussnies : ICRUDBussnies<UsuarioRequest, UsuarioResponse>
    {
        UsuarioResponse GetByUserName(string username);
        Vusuario GetByVistaUsername(string username);
    }
}