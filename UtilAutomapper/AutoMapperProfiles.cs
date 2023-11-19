using AutoMapper;
using BDModel.DBWifihome;
using Models.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilAutomapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Ubigeo, UbigeoRequest>().ReverseMap();
            CreateMap<Ubigeo, UbigeoResponse>().ReverseMap();
            CreateMap<UbigeoRequest, UbigeoResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<UbigeoResponse>, GenericFilterResponse<Ubigeo>>().ReverseMap();

            CreateMap<Rol, RolRequest>().ReverseMap();
            CreateMap<Rol, RolResponse>().ReverseMap();
            CreateMap<RolRequest, RolResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<RolResponse>, GenericFilterResponse<Rol>>().ReverseMap();

            CreateMap<Asistencium, AsistenciaRequest>().ReverseMap();
            CreateMap<Asistencium, AsistenciaResponse>().ReverseMap();
            CreateMap<AsistenciaRequest, AsistenciaResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<AsistenciaResponse>, GenericFilterResponse<Asistencium>>().ReverseMap();

            CreateMap<Contrato, ContratoRequest>().ReverseMap();
            CreateMap<Contrato, ContratoResponse>().ReverseMap();
            CreateMap<ContratoRequest, ContratoResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<ContratoResponse>, GenericFilterResponse<Contrato>>().ReverseMap();

            CreateMap<ContratoUsuario, ContratoUsuarioRequest>().ReverseMap();
            CreateMap<ContratoUsuario, ContratoUsuarioResponse>().ReverseMap();
            CreateMap<ContratoUsuarioRequest, ContratoUsuarioResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<ContratoUsuarioResponse>, GenericFilterResponse<ContratoUsuario>>().ReverseMap();

            CreateMap<Cronograma, CronogramaRequest>().ReverseMap();
            CreateMap<Cronograma, CronogramaResponse>().ReverseMap();
            CreateMap<CronogramaRequest, CronogramaResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<CronogramaResponse>, GenericFilterResponse<Cronograma>>().ReverseMap();

            CreateMap<DetalleContrato, DetalleContratoRequest>().ReverseMap();
            CreateMap<DetalleContrato, DetalleContratoResponse>().ReverseMap();
            CreateMap<DetalleContratoRequest, DetalleContratoResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<DetalleContratoResponse>, GenericFilterResponse<DetalleContrato>>().ReverseMap();

            CreateMap<Direccion, DireccionRequest>().ReverseMap();
            CreateMap<Direccion, DireccionResponse>().ReverseMap();
            CreateMap<DireccionRequest, DireccionResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<DireccionResponse>, GenericFilterResponse<Direccion>>().ReverseMap();

            CreateMap<Persona, PersonaRequest>().ReverseMap();
            CreateMap<Persona, PersonaResponse>().ReverseMap();
            CreateMap<PersonaRequest, PersonaResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<ProductoCliente, ProductoClienteRequest>().ReverseMap();
            CreateMap<ProductoCliente, ProductoClienteResponse>().ReverseMap();
            CreateMap<ProductoClienteRequest, ProductoClienteResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<ProductoClienteResponse>, GenericFilterResponse<ProductoCliente>>().ReverseMap();

            CreateMap<ProductoServicio, ProductoServicioRequest>().ReverseMap();
            CreateMap<ProductoServicio, ProductoServicioResponse>().ReverseMap();
            CreateMap<ProductoServicioRequest, ProductoServicioResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<ProductoServicioResponse>, GenericFilterResponse<ProductoServicio>>().ReverseMap();

            CreateMap<QuejasReclamo, QuejasReclamoRequest>().ReverseMap();
            CreateMap<QuejasReclamo, QuejasReclamoResponse>().ReverseMap();
            CreateMap<QuejasReclamoRequest, QuejasReclamoResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<QuejasReclamoResponse>, GenericFilterResponse<QuejasReclamo>>().ReverseMap();

            CreateMap<TipoDocumento, TipoDocumentoRequest>().ReverseMap();
            CreateMap<TipoDocumento, TipoDocumentoResponse>().ReverseMap();
            CreateMap<TipoDocumentoRequest, TipoDocumentoResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<TipoDocumentoResponse>, GenericFilterResponse<TipoDocumento>>().ReverseMap();

            CreateMap<Usuario, UsuarioRequest>().ReverseMap();
            CreateMap<Usuario, UsuarioResponse>().ReverseMap();
            CreateMap<UsuarioRequest, UsuarioResponse>().ReverseMap();
            CreateMap<GenericFilterResponse<UsuarioResponse>, GenericFilterResponse<Usuario>>().ReverseMap();
        }
    }
}
