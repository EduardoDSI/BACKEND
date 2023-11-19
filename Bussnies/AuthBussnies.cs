using AutoMapper;
using BDModel.DBWifihome;
using IBussnies;
using Models.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilSecurity;

namespace Bussnies
{
    public class AuthBussnies : IAuthBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IUsuarioBussnies _usuarioBussnies;
        private readonly IMapper _mapper;
        //private readonly IRolBussnies _rolBussnies;
        private readonly UtilEncriptarDesencriptar _cripto;
        public AuthBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioBussnies = new UsuarioBussnies(mapper);
            //_rolBussnies = new RolBussnies(mapper);
            _cripto = new UtilEncriptarDesencriptar();
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        public LoginResponse Login(LoginRequest request)
        {
            LoginResponse result = new LoginResponse();

            //01 VALIDAMOS QUE EL USUARIO EXISTA
            Vusuario usuario = _usuarioBussnies.GetByVistaUsername(request.Usuario);
            if (usuario == null)
            {
                return result;
            }


            //02 VALIDAMOS QUE EL USUARIO EXISTA
            //02.01 ==> proceso de encriptar un texto
            string newPassword = request.Contraseña;

            if (newPassword != usuario.Contrasenia)
            {
                return result;
            }

            result.Success = true;
            result.Mensaje = "LOGIN CORRECTO";

            result.Usuario = new UsuarioLoginResponse();
            result.Usuario.Id = usuario.Id;
            result.Usuario.Usuario = usuario.Usuario;
            result.Usuario.Contrasenia = usuario.Contrasenia;
            result.Usuario.IdPersona = usuario.Id;
            result.Usuario.IdRol = usuario.IdRol;
            result.Rol = new RolResponse();
            result.Rol.IdRol = usuario.Id;
            result.Rol.Funcion = usuario.RolFuncion;
            result.Persona = new PersonaResponse();
            result.Persona.Nombres = usuario.Nombres;
            result.Persona.NroIdentificacion = usuario.NroIdentificacion;


            /*ESTE TIPO DE IMPLEMENTACIÓN NO ES LA MAS OPTIMA*/
            /*
             * VAMOS A REALIZAR CONSULTAS INDEPENDIENTES
             * _rolBussnies
             * _personaBussnies
             */

            //result.Usuario = new UsuarioLoginResponse();
            //result.Rol = new RolResponse();
            //busqueda del usuario
            //busqueda del rol
            return result;
        }
    }
}
