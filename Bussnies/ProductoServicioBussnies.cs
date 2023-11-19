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
    public class ProductoServicioBussnies : IProductoServicioBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IProductoServicioRepository _ProductoServicioRepository;
        private readonly IMapper _mapper;
        public ProductoServicioBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _ProductoServicioRepository = new ProductoServicioRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
        public List<ProductoServicioResponse> GetAll()
        {
            List<ProductoServicio> ProductoServicios = _ProductoServicioRepository.GetAll();
            List<ProductoServicioResponse> lstResponse = _mapper.Map<List<ProductoServicioResponse>>(ProductoServicios);
            return lstResponse;
        }

        public ProductoServicioResponse GetById(int id)
        {
            ProductoServicio ProductoServicio = _ProductoServicioRepository.GetById(id);
            ProductoServicioResponse resul = _mapper.Map<ProductoServicioResponse>(ProductoServicio);
            return resul;
        }

        public ProductoServicioResponse Create(ProductoServicioRequest entity)
        {
            ProductoServicio ProductoServicio = _mapper.Map<ProductoServicio>(entity);
            ProductoServicio = _ProductoServicioRepository.Create(ProductoServicio);
            ProductoServicioResponse result = _mapper.Map<ProductoServicioResponse>(ProductoServicio);
            return result;
        }
        public List<ProductoServicioResponse> CreateMultiple(List<ProductoServicioRequest> lista)
        {
            List<ProductoServicio> ProductoServicios = _mapper.Map<List<ProductoServicio>>(lista);
            ProductoServicios = _ProductoServicioRepository.CreateMultiple(ProductoServicios);
            List<ProductoServicioResponse> result = _mapper.Map<List<ProductoServicioResponse>>(ProductoServicios);
            return result;
        }

        public ProductoServicioResponse Update(ProductoServicioRequest entity)
        {
            ProductoServicio ProductoServicio = _mapper.Map<ProductoServicio>(entity);
            ProductoServicio = _ProductoServicioRepository.Update(ProductoServicio);
            ProductoServicioResponse result = _mapper.Map<ProductoServicioResponse>(ProductoServicio);
            return result;
        }

        public List<ProductoServicioResponse> UpdateMultiple(List<ProductoServicioRequest> lista)
        {
            List<ProductoServicio> ProductoServicios = _mapper.Map<List<ProductoServicio>>(lista);
            ProductoServicios = _ProductoServicioRepository.UpdateMultiple(ProductoServicios);
            List<ProductoServicioResponse> result = _mapper.Map<List<ProductoServicioResponse>>(ProductoServicios);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _ProductoServicioRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<ProductoServicioRequest> lista)
        {
            List<ProductoServicio> ProductoServicios = _mapper.Map<List<ProductoServicio>>(lista);
            int cantidad = _ProductoServicioRepository.DeleteMultipleItems(ProductoServicios);
            return cantidad;
        }

        public GenericFilterResponse<ProductoServicioResponse> GetByFilter(GenericFilterRequest request)
        {

            GenericFilterResponse<ProductoServicioResponse> result = _mapper.Map<GenericFilterResponse<ProductoServicioResponse>>(_ProductoServicioRepository.GetByFilter(request));

            return result;
        }


        #endregion END CRUD METHODS
    }
}