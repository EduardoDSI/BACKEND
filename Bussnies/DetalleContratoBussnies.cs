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
    public class DetalleContratoBussnies : IDetalleContratoBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IDetalleContratoRepository _DetalleContratoRepository;
        private readonly IMapper _mapper;
        public DetalleContratoBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _DetalleContratoRepository = new DetalleContratoRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
        public List<DetalleContratoResponse> GetAll()
        {
            List<DetalleContrato> DetalleContratos = _DetalleContratoRepository.GetAll();
            List<DetalleContratoResponse> lstResponse = _mapper.Map<List<DetalleContratoResponse>>(DetalleContratos);
            return lstResponse;
        }

        public DetalleContratoResponse GetById(int id)
        {
            DetalleContrato DetalleContrato = _DetalleContratoRepository.GetById(id);
            DetalleContratoResponse resul = _mapper.Map<DetalleContratoResponse>(DetalleContrato);
            return resul;
        }

        public DetalleContratoResponse Create(DetalleContratoRequest entity)
        {
            DetalleContrato DetalleContrato = _mapper.Map<DetalleContrato>(entity);
            DetalleContrato = _DetalleContratoRepository.Create(DetalleContrato);
            DetalleContratoResponse result = _mapper.Map<DetalleContratoResponse>(DetalleContrato);
            return result;
        }
        public List<DetalleContratoResponse> CreateMultiple(List<DetalleContratoRequest> lista)
        {
            List<DetalleContrato> DetalleContratos = _mapper.Map<List<DetalleContrato>>(lista);
            DetalleContratos = _DetalleContratoRepository.CreateMultiple(DetalleContratos);
            List<DetalleContratoResponse> result = _mapper.Map<List<DetalleContratoResponse>>(DetalleContratos);
            return result;
        }

        public DetalleContratoResponse Update(DetalleContratoRequest entity)
        {
            DetalleContrato DetalleContrato = _mapper.Map<DetalleContrato>(entity);
            DetalleContrato = _DetalleContratoRepository.Update(DetalleContrato);
            DetalleContratoResponse result = _mapper.Map<DetalleContratoResponse>(DetalleContrato);
            return result;
        }

        public List<DetalleContratoResponse> UpdateMultiple(List<DetalleContratoRequest> lista)
        {
            List<DetalleContrato> DetalleContratos = _mapper.Map<List<DetalleContrato>>(lista);
            DetalleContratos = _DetalleContratoRepository.UpdateMultiple(DetalleContratos);
            List<DetalleContratoResponse> result = _mapper.Map<List<DetalleContratoResponse>>(DetalleContratos);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _DetalleContratoRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<DetalleContratoRequest> lista)
        {
            List<DetalleContrato> DetalleContratos = _mapper.Map<List<DetalleContrato>>(lista);
            int cantidad = _DetalleContratoRepository.DeleteMultipleItems(DetalleContratos);
            return cantidad;
        }

        public GenericFilterResponse<DetalleContratoResponse> GetByFilter(GenericFilterRequest request)
        {

            GenericFilterResponse<DetalleContratoResponse> result = _mapper.Map<GenericFilterResponse<DetalleContratoResponse>>(_DetalleContratoRepository.GetByFilter(request));

            return result;
        }


        #endregion END CRUD METHODS
    }
}