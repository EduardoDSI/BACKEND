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
    public class CronogramaBussnies : ICronogramaBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly ICronogramaRepository _CronogramaRepository;
        private readonly IMapper _mapper;
        public CronogramaBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _CronogramaRepository = new CronogramaRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
        public List<CronogramaResponse> GetAll()
        {
            List<Cronograma> Cronogramas = _CronogramaRepository.GetAll();
            List<CronogramaResponse> lstResponse = _mapper.Map<List<CronogramaResponse>>(Cronogramas);
            return lstResponse;
        }

        public CronogramaResponse GetById(int id)
        {
            Cronograma Cronograma = _CronogramaRepository.GetById(id);
            CronogramaResponse resul = _mapper.Map<CronogramaResponse>(Cronograma);
            return resul;
        }

        public CronogramaResponse Create(CronogramaRequest entity)
        {
            Cronograma Cronograma = _mapper.Map<Cronograma>(entity);
            Cronograma = _CronogramaRepository.Create(Cronograma);
            CronogramaResponse result = _mapper.Map<CronogramaResponse>(Cronograma);
            return result;
        }
        public List<CronogramaResponse> CreateMultiple(List<CronogramaRequest> lista)
        {
            List<Cronograma> Cronogramas = _mapper.Map<List<Cronograma>>(lista);
            Cronogramas = _CronogramaRepository.CreateMultiple(Cronogramas);
            List<CronogramaResponse> result = _mapper.Map<List<CronogramaResponse>>(Cronogramas);
            return result;
        }

        public CronogramaResponse Update(CronogramaRequest entity)
        {
            Cronograma Cronograma = _mapper.Map<Cronograma>(entity);
            Cronograma = _CronogramaRepository.Update(Cronograma);
            CronogramaResponse result = _mapper.Map<CronogramaResponse>(Cronograma);
            return result;
        }

        public List<CronogramaResponse> UpdateMultiple(List<CronogramaRequest> lista)
        {
            List<Cronograma> Cronogramas = _mapper.Map<List<Cronograma>>(lista);
            Cronogramas = _CronogramaRepository.UpdateMultiple(Cronogramas);
            List<CronogramaResponse> result = _mapper.Map<List<CronogramaResponse>>(Cronogramas);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _CronogramaRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<CronogramaRequest> lista)
        {
            List<Cronograma> Cronogramas = _mapper.Map<List<Cronograma>>(lista);
            int cantidad = _CronogramaRepository.DeleteMultipleItems(Cronogramas);
            return cantidad;
        }

        public GenericFilterResponse<CronogramaResponse> GetByFilter(GenericFilterRequest request)
        {

            GenericFilterResponse<CronogramaResponse> result = _mapper.Map<GenericFilterResponse<CronogramaResponse>>(_CronogramaRepository.GetByFilter(request));

            return result;
        }


        #endregion END CRUD METHODS
    }
}