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
    public class ProductoClienteBussnies : IProductoClienteBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IProductoClienteRepository _ProductoClienteRepository;
        private readonly IMapper _mapper;
        public ProductoClienteBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _ProductoClienteRepository = new ProductoClienteRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
        public List<ProductoClienteResponse> GetAll()
        {
            List<ProductoCliente> ProductoClientes = _ProductoClienteRepository.GetAll();
            List<ProductoClienteResponse> lstResponse = _mapper.Map<List<ProductoClienteResponse>>(ProductoClientes);
            return lstResponse;
        }

        public ProductoClienteResponse GetById(int id)
        {
            ProductoCliente ProductoCliente = _ProductoClienteRepository.GetById(id);
            ProductoClienteResponse resul = _mapper.Map<ProductoClienteResponse>(ProductoCliente);
            return resul;
        }

        public ProductoClienteResponse Create(ProductoClienteRequest entity)
        {
            ProductoCliente ProductoCliente = _mapper.Map<ProductoCliente>(entity);
            ProductoCliente = _ProductoClienteRepository.Create(ProductoCliente);
            ProductoClienteResponse result = _mapper.Map<ProductoClienteResponse>(ProductoCliente);
            return result;
        }
        public List<ProductoClienteResponse> CreateMultiple(List<ProductoClienteRequest> lista)
        {
            List<ProductoCliente> ProductoClientes = _mapper.Map<List<ProductoCliente>>(lista);
            ProductoClientes = _ProductoClienteRepository.CreateMultiple(ProductoClientes);
            List<ProductoClienteResponse> result = _mapper.Map<List<ProductoClienteResponse>>(ProductoClientes);
            return result;
        }

        public ProductoClienteResponse Update(ProductoClienteRequest entity)
        {
            ProductoCliente ProductoCliente = _mapper.Map<ProductoCliente>(entity);
            ProductoCliente = _ProductoClienteRepository.Update(ProductoCliente);
            ProductoClienteResponse result = _mapper.Map<ProductoClienteResponse>(ProductoCliente);
            return result;
        }

        public List<ProductoClienteResponse> UpdateMultiple(List<ProductoClienteRequest> lista)
        {
            List<ProductoCliente> ProductoClientes = _mapper.Map<List<ProductoCliente>>(lista);
            ProductoClientes = _ProductoClienteRepository.UpdateMultiple(ProductoClientes);
            List<ProductoClienteResponse> result = _mapper.Map<List<ProductoClienteResponse>>(ProductoClientes);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _ProductoClienteRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<ProductoClienteRequest> lista)
        {
            List<ProductoCliente> ProductoClientes = _mapper.Map<List<ProductoCliente>>(lista);
            int cantidad = _ProductoClienteRepository.DeleteMultipleItems(ProductoClientes);
            return cantidad;
        }

        public GenericFilterResponse<ProductoClienteResponse> GetByFilter(GenericFilterRequest request)
        {

            GenericFilterResponse<ProductoClienteResponse> result = _mapper.Map<GenericFilterResponse<ProductoClienteResponse>>(_ProductoClienteRepository.GetByFilter(request));

            return result;
        }


        #endregion END CRUD METHODS
    }
}