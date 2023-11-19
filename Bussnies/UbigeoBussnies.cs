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
    public class UbigeoBussnies : IUbigeoBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IUbigeoRepository _UbigeoRepository;
        private readonly IMapper _mapper;
        public UbigeoBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _UbigeoRepository = new UbigeoRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
        public List<UbigeoResponse> GetAll()
        {
            List<Ubigeo> Ubigeos = _UbigeoRepository.GetAll();
            List<UbigeoResponse> lstResponse = _mapper.Map<List<UbigeoResponse>>(Ubigeos);
            return lstResponse;
        }

        public UbigeoResponse GetById(int id)
        {
            Ubigeo Ubigeo = _UbigeoRepository.GetById(id);
            UbigeoResponse resul = _mapper.Map<UbigeoResponse>(Ubigeo);
            return resul;
        }

        public UbigeoResponse Create(UbigeoRequest entity)
        {
            Ubigeo Ubigeo = _mapper.Map<Ubigeo>(entity);
            Ubigeo = _UbigeoRepository.Create(Ubigeo);
            UbigeoResponse result = _mapper.Map<UbigeoResponse>(Ubigeo);
            return result;
        }
        public List<UbigeoResponse> CreateMultiple(List<UbigeoRequest> lista)
        {
            List<Ubigeo> Ubigeos = _mapper.Map<List<Ubigeo>>(lista);
            Ubigeos = _UbigeoRepository.CreateMultiple(Ubigeos);
            List<UbigeoResponse> result = _mapper.Map<List<UbigeoResponse>>(Ubigeos);
            return result;
        }

        public UbigeoResponse Update(UbigeoRequest entity)
        {
            Ubigeo Ubigeo = _mapper.Map<Ubigeo>(entity);
            Ubigeo = _UbigeoRepository.Update(Ubigeo);
            UbigeoResponse result = _mapper.Map<UbigeoResponse>(Ubigeo);
            return result;
        }

        public List<UbigeoResponse> UpdateMultiple(List<UbigeoRequest> lista)
        {
            List<Ubigeo> Ubigeos = _mapper.Map<List<Ubigeo>>(lista);
            Ubigeos = _UbigeoRepository.UpdateMultiple(Ubigeos);
            List<UbigeoResponse> result = _mapper.Map<List<UbigeoResponse>>(Ubigeos);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _UbigeoRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<UbigeoRequest> lista)
        {
            List<Ubigeo> Ubigeos = _mapper.Map<List<Ubigeo>>(lista);
            int cantidad = _UbigeoRepository.DeleteMultipleItems(Ubigeos);
            return cantidad;
        }

        public GenericFilterResponse<UbigeoResponse> GetByFilter(GenericFilterRequest request)
        {

            GenericFilterResponse<UbigeoResponse> result = _mapper.Map<GenericFilterResponse<UbigeoResponse>>(_UbigeoRepository.GetByFilter(request));

            return result;
        }


        #endregion END CRUD METHODS
    }
}