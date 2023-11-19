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
    public class AsistenciaBussnies : IAsistenciaBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IAsistenciaRepository _AsistenciaRepository;
        private readonly IMapper _mapper;
        public AsistenciaBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _AsistenciaRepository = new AsistenciaRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
        public List<AsistenciaResponse> GetAll()
        {
            List<Asistencium> Asistencias = _AsistenciaRepository.GetAll();
            List<AsistenciaResponse> lstResponse = _mapper.Map<List<AsistenciaResponse>>(Asistencias);
            return lstResponse;
        }

        public AsistenciaResponse GetById(int id)
        {
            Asistencium Asistencia = _AsistenciaRepository.GetById(id);
            AsistenciaResponse resul = _mapper.Map<AsistenciaResponse>(Asistencia);
            return resul;
        }

        public AsistenciaResponse Create(AsistenciaRequest entity)
        {
            Asistencium Asistencia = _mapper.Map<Asistencium>(entity);
            Asistencia = _AsistenciaRepository.Create(Asistencia);
            AsistenciaResponse result = _mapper.Map<AsistenciaResponse>(Asistencia);
            return result;
        }
        public List<AsistenciaResponse> CreateMultiple(List<AsistenciaRequest> lista)
        {
            List<Asistencium> Asistencias = _mapper.Map<List<Asistencium>>(lista);
            Asistencias = _AsistenciaRepository.CreateMultiple(Asistencias);
            List<AsistenciaResponse> result = _mapper.Map<List<AsistenciaResponse>>(Asistencias);
            return result;
        }

        public AsistenciaResponse Update(AsistenciaRequest entity)
        {
            Asistencium Asistencia = _mapper.Map<Asistencium>(entity);
            Asistencia = _AsistenciaRepository.Update(Asistencia);
            AsistenciaResponse result = _mapper.Map<AsistenciaResponse>(Asistencia);
            return result;
        }

        public List<AsistenciaResponse> UpdateMultiple(List<AsistenciaRequest> lista)
        {
            List<Asistencium> Asistencias = _mapper.Map<List<Asistencium>>(lista);
            Asistencias = _AsistenciaRepository.UpdateMultiple(Asistencias);
            List<AsistenciaResponse> result = _mapper.Map<List<AsistenciaResponse>>(Asistencias);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _AsistenciaRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<AsistenciaRequest> lista)
        {
            List<Asistencium> Asistencias = _mapper.Map<List<Asistencium>>(lista);
            int cantidad = _AsistenciaRepository.DeleteMultipleItems(Asistencias);
            return cantidad;
        }

        public GenericFilterResponse<AsistenciaResponse> GetByFilter(GenericFilterRequest request)
        {

            GenericFilterResponse<AsistenciaResponse> result = _mapper.Map<GenericFilterResponse<AsistenciaResponse>>(_AsistenciaRepository.GetByFilter(request));

            return result;
        }


        #endregion END CRUD METHODS
    }
}