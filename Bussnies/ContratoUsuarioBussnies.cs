using AutoMapper;
using BDModel.DBWifihome;
using IBussnies;
using IRepository;
using Models.RequestResponseModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussnies
{
    public class ContratoUsuarioBussnies : IContratoUsuarioBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IContratoUsuarioRepository _ContratoUsuarioRepository;
        private readonly IMapper _mapper;
        public ContratoUsuarioBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _ContratoUsuarioRepository = new ContratoUsuarioRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
        public List<ContratoUsuarioResponse> GetAll()
        {
            List<ContratoUsuario> ContratoUsuarios = _ContratoUsuarioRepository.GetAll();
            List<ContratoUsuarioResponse> lstResponse = _mapper.Map<List<ContratoUsuarioResponse>>(ContratoUsuarios);
            return lstResponse;
        }

        public ContratoUsuarioResponse GetById(int id)
        {
            ContratoUsuario ContratoUsuario = _ContratoUsuarioRepository.GetById(id);
            ContratoUsuarioResponse resul = _mapper.Map<ContratoUsuarioResponse>(ContratoUsuario);
            return resul;
        }

        public ContratoUsuarioResponse Create(ContratoUsuarioRequest entity)
        {
            ContratoUsuario ContratoUsuario = _mapper.Map<ContratoUsuario>(entity);
            ContratoUsuario = _ContratoUsuarioRepository.Create(ContratoUsuario);
            ContratoUsuarioResponse result = _mapper.Map<ContratoUsuarioResponse>(ContratoUsuario);
            return result;
        }
        public List<ContratoUsuarioResponse> CreateMultiple(List<ContratoUsuarioRequest> lista)
        {
            List<ContratoUsuario> ContratoUsuarios = _mapper.Map<List<ContratoUsuario>>(lista);
            ContratoUsuarios = _ContratoUsuarioRepository.CreateMultiple(ContratoUsuarios);
            List<ContratoUsuarioResponse> result = _mapper.Map<List<ContratoUsuarioResponse>>(ContratoUsuarios);
            return result;
        }

        public ContratoUsuarioResponse Update(ContratoUsuarioRequest entity)
        {
            ContratoUsuario ContratoUsuario = _mapper.Map<ContratoUsuario>(entity);
            ContratoUsuario = _ContratoUsuarioRepository.Update(ContratoUsuario);
            ContratoUsuarioResponse result = _mapper.Map<ContratoUsuarioResponse>(ContratoUsuario);
            return result;
        }

        public List<ContratoUsuarioResponse> UpdateMultiple(List<ContratoUsuarioRequest> lista)
        {
            List<ContratoUsuario> ContratoUsuarios = _mapper.Map<List<ContratoUsuario>>(lista);
            ContratoUsuarios = _ContratoUsuarioRepository.UpdateMultiple(ContratoUsuarios);
            List<ContratoUsuarioResponse> result = _mapper.Map<List<ContratoUsuarioResponse>>(ContratoUsuarios);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _ContratoUsuarioRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<ContratoUsuarioRequest> lista)
        {
            List<ContratoUsuario> ContratoUsuarios = _mapper.Map<List<ContratoUsuario>>(lista);
            int cantidad = _ContratoUsuarioRepository.DeleteMultipleItems(ContratoUsuarios);
            return cantidad;
        }

        public GenericFilterResponse<ContratoUsuarioResponse> GetByFilter(GenericFilterRequest request)
        {

            GenericFilterResponse<ContratoUsuarioResponse> result = _mapper.Map<GenericFilterResponse<ContratoUsuarioResponse>>(_ContratoUsuarioRepository.GetByFilter(request));

            return result;
        }


        #endregion END CRUD METHODS
    }
}