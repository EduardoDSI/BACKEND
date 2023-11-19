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
    public class RolBussnies : IRolBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IRolRepository _RolRepository;
        private readonly IMapper _mapper;
        public RolBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _RolRepository = new RolRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
        public List<RolResponse> GetAll()
        {
            List<Rol> Rols = _RolRepository.GetAll();
            List<RolResponse> lstResponse = _mapper.Map<List<RolResponse>>(Rols);
            return lstResponse;
        }

        public RolResponse GetById(int id)
        {
            Rol Rol = _RolRepository.GetById(id);
            RolResponse resul = _mapper.Map<RolResponse>(Rol);
            return resul;
        }

        public RolResponse Create(RolRequest entity)
        {
            Rol Rol = _mapper.Map<Rol>(entity);
            Rol = _RolRepository.Create(Rol);
            RolResponse result = _mapper.Map<RolResponse>(Rol);
            return result;
        }
        public List<RolResponse> CreateMultiple(List<RolRequest> lista)
        {
            List<Rol> Rols = _mapper.Map<List<Rol>>(lista);
            Rols = _RolRepository.CreateMultiple(Rols);
            List<RolResponse> result = _mapper.Map<List<RolResponse>>(Rols);
            return result;
        }

        public RolResponse Update(RolRequest entity)
        {
            Rol Rol = _mapper.Map<Rol>(entity);
            Rol = _RolRepository.Update(Rol);
            RolResponse result = _mapper.Map<RolResponse>(Rol);
            return result;
        }

        public List<RolResponse> UpdateMultiple(List<RolRequest> lista)
        {
            List<Rol> Rols = _mapper.Map<List<Rol>>(lista);
            Rols = _RolRepository.UpdateMultiple(Rols);
            List<RolResponse> result = _mapper.Map<List<RolResponse>>(Rols);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _RolRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<RolRequest> lista)
        {
            List<Rol> Rols = _mapper.Map<List<Rol>>(lista);
            int cantidad = _RolRepository.DeleteMultipleItems(Rols);
            return cantidad;
        }

        public GenericFilterResponse<RolResponse> GetByFilter(GenericFilterRequest request)
        {

            GenericFilterResponse<RolResponse> result = _mapper.Map<GenericFilterResponse<RolResponse>>(_RolRepository.GetByFilter(request));

            return result;
        }


        #endregion END CRUD METHODS
    }
}