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
    public class QuejasReclamoBussnies : IQuejasReclamoBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IQuejasReclamoRepository _QuejasReclamoRepository;
        private readonly IMapper _mapper;
        public QuejasReclamoBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _QuejasReclamoRepository = new QuejasReclamoRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
        public List<QuejasReclamoResponse> GetAll()
        {
            List<QuejasReclamo> QuejasReclamos = _QuejasReclamoRepository.GetAll();
            List<QuejasReclamoResponse> lstResponse = _mapper.Map<List<QuejasReclamoResponse>>(QuejasReclamos);
            return lstResponse;
        }

        public QuejasReclamoResponse GetById(int id)
        {
            QuejasReclamo QuejasReclamo = _QuejasReclamoRepository.GetById(id);
            QuejasReclamoResponse resul = _mapper.Map<QuejasReclamoResponse>(QuejasReclamo);
            return resul;
        }

        public QuejasReclamoResponse Create(QuejasReclamoRequest entity)
        {
            QuejasReclamo QuejasReclamo = _mapper.Map<QuejasReclamo>(entity);
            QuejasReclamo = _QuejasReclamoRepository.Create(QuejasReclamo);
            QuejasReclamoResponse result = _mapper.Map<QuejasReclamoResponse>(QuejasReclamo);
            return result;
        }
        public List<QuejasReclamoResponse> CreateMultiple(List<QuejasReclamoRequest> lista)
        {
            List<QuejasReclamo> QuejasReclamos = _mapper.Map<List<QuejasReclamo>>(lista);
            QuejasReclamos = _QuejasReclamoRepository.CreateMultiple(QuejasReclamos);
            List<QuejasReclamoResponse> result = _mapper.Map<List<QuejasReclamoResponse>>(QuejasReclamos);
            return result;
        }

        public QuejasReclamoResponse Update(QuejasReclamoRequest entity)
        {
            QuejasReclamo QuejasReclamo = _mapper.Map<QuejasReclamo>(entity);
            QuejasReclamo = _QuejasReclamoRepository.Update(QuejasReclamo);
            QuejasReclamoResponse result = _mapper.Map<QuejasReclamoResponse>(QuejasReclamo);
            return result;
        }

        public List<QuejasReclamoResponse> UpdateMultiple(List<QuejasReclamoRequest> lista)
        {
            List<QuejasReclamo> QuejasReclamos = _mapper.Map<List<QuejasReclamo>>(lista);
            QuejasReclamos = _QuejasReclamoRepository.UpdateMultiple(QuejasReclamos);
            List<QuejasReclamoResponse> result = _mapper.Map<List<QuejasReclamoResponse>>(QuejasReclamos);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _QuejasReclamoRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<QuejasReclamoRequest> lista)
        {
            List<QuejasReclamo> QuejasReclamos = _mapper.Map<List<QuejasReclamo>>(lista);
            int cantidad = _QuejasReclamoRepository.DeleteMultipleItems(QuejasReclamos);
            return cantidad;
        }

        public GenericFilterResponse<QuejasReclamoResponse> GetByFilter(GenericFilterRequest request)
        {

            GenericFilterResponse<QuejasReclamoResponse> result = _mapper.Map<GenericFilterResponse<QuejasReclamoResponse>>(_QuejasReclamoRepository.GetByFilter(request));

            return result;
        }


        #endregion END CRUD METHODS
    }
}