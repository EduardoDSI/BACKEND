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
    public class DireccionBussnies : IDireccionBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IDireccionRepository _DireccionRepository;
        private readonly IMapper _mapper;
        public DireccionBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _DireccionRepository = new DireccionRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
        public List<DireccionResponse> GetAll()
        {
            List<Direccion> Direccions = _DireccionRepository.GetAll();
            List<DireccionResponse> lstResponse = _mapper.Map<List<DireccionResponse>>(Direccions);
            return lstResponse;
        }

        public DireccionResponse GetById(int id)
        {
            Direccion Direccion = _DireccionRepository.GetById(id);
            DireccionResponse resul = _mapper.Map<DireccionResponse>(Direccion);
            return resul;
        }

        public DireccionResponse Create(DireccionRequest entity)
        {
            Direccion Direccion = _mapper.Map<Direccion>(entity);
            Direccion = _DireccionRepository.Create(Direccion);
            DireccionResponse result = _mapper.Map<DireccionResponse>(Direccion);
            return result;
        }
        public List<DireccionResponse> CreateMultiple(List<DireccionRequest> lista)
        {
            List<Direccion> Direccions = _mapper.Map<List<Direccion>>(lista);
            Direccions = _DireccionRepository.CreateMultiple(Direccions);
            List<DireccionResponse> result = _mapper.Map<List<DireccionResponse>>(Direccions);
            return result;
        }

        public DireccionResponse Update(DireccionRequest entity)
        {
            Direccion Direccion = _mapper.Map<Direccion>(entity);
            Direccion = _DireccionRepository.Update(Direccion);
            DireccionResponse result = _mapper.Map<DireccionResponse>(Direccion);
            return result;
        }

        public List<DireccionResponse> UpdateMultiple(List<DireccionRequest> lista)
        {
            List<Direccion> Direccions = _mapper.Map<List<Direccion>>(lista);
            Direccions = _DireccionRepository.UpdateMultiple(Direccions);
            List<DireccionResponse> result = _mapper.Map<List<DireccionResponse>>(Direccions);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _DireccionRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<DireccionRequest> lista)
        {
            List<Direccion> Direccions = _mapper.Map<List<Direccion>>(lista);
            int cantidad = _DireccionRepository.DeleteMultipleItems(Direccions);
            return cantidad;
        }

        public GenericFilterResponse<DireccionResponse> GetByFilter(GenericFilterRequest request)
        {

            GenericFilterResponse<DireccionResponse> result = _mapper.Map<GenericFilterResponse<DireccionResponse>>(_DireccionRepository.GetByFilter(request));

            return result;
        }


        #endregion END CRUD METHODS
    }
}