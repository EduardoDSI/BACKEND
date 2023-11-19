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
    public class ContratoBussnies : IContratoBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IContratoRepository _ContratoRepository;
        private readonly IMapper _mapper;
        public ContratoBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _ContratoRepository = new ContratoRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
        public List<ContratoResponse> GetAll()
        {
            List<Contrato> Contratos = _ContratoRepository.GetAll();
            List<ContratoResponse> lstResponse = _mapper.Map<List<ContratoResponse>>(Contratos);
            return lstResponse;
        }

        public ContratoResponse GetById(int id)
        {
            Contrato Contrato = _ContratoRepository.GetById(id);
            ContratoResponse resul = _mapper.Map<ContratoResponse>(Contrato);
            return resul;
        }

        public ContratoResponse Create(ContratoRequest entity)
        {
            Contrato Contrato = _mapper.Map<Contrato>(entity);
            Contrato = _ContratoRepository.Create(Contrato);
            ContratoResponse result = _mapper.Map<ContratoResponse>(Contrato);
            return result;
        }
        public List<ContratoResponse> CreateMultiple(List<ContratoRequest> lista)
        {
            List<Contrato> Contratos = _mapper.Map<List<Contrato>>(lista);
            Contratos = _ContratoRepository.CreateMultiple(Contratos);
            List<ContratoResponse> result = _mapper.Map<List<ContratoResponse>>(Contratos);
            return result;
        }

        public ContratoResponse Update(ContratoRequest entity)
        {
            Contrato Contrato = _mapper.Map<Contrato>(entity);
            Contrato = _ContratoRepository.Update(Contrato);
            ContratoResponse result = _mapper.Map<ContratoResponse>(Contrato);
            return result;
        }

        public List<ContratoResponse> UpdateMultiple(List<ContratoRequest> lista)
        {
            List<Contrato> Contratos = _mapper.Map<List<Contrato>>(lista);
            Contratos = _ContratoRepository.UpdateMultiple(Contratos);
            List<ContratoResponse> result = _mapper.Map<List<ContratoResponse>>(Contratos);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _ContratoRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<ContratoRequest> lista)
        {
            List<Contrato> Contratos = _mapper.Map<List<Contrato>>(lista);
            int cantidad = _ContratoRepository.DeleteMultipleItems(Contratos);
            return cantidad;
        }

        public GenericFilterResponse<ContratoResponse> GetByFilter(GenericFilterRequest request)
        {

            GenericFilterResponse<ContratoResponse> result = _mapper.Map<GenericFilterResponse<ContratoResponse>>(_ContratoRepository.GetByFilter(request));

            return result;
        }


        #endregion END CRUD METHODS
    }
}