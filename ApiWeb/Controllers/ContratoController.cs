using AutoMapper;
using Bussnies;
using IBussnies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.RequestResponseModel;
using System.Net;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContratoController : ControllerBase
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IContratoBussnies _ContratoBussnies;
        private readonly IMapper _mapper;
        public ContratoController(IMapper mapper)
        {
            _mapper = mapper;
            _ContratoBussnies = new ContratoBussnies(mapper);
        }
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region CRUD METHODS
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA Contrato
        /// </summary>
        /// <returns>List-ContratoResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ContratoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            //int a = 0, b=5, c=6;

            //sabemos que no puede haber una división entre ==> 0
            //c = b / a;


            return Ok(_ContratoBussnies.GetAll());
        }
        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>ContratoResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ContratoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_ContratoBussnies.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA Contrato
        /// </summary>
        /// <param name="request">ContratoRequest</param>
        /// <returns>ContratoResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ContratoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] ContratoRequest request)
        {
            return Ok(_ContratoBussnies.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA Contrato EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public IActionResult GetByFilter([FromBody] GenericFilterRequest request)
        {
            GenericFilterResponse<ContratoResponse> res = _ContratoBussnies.GetByFilter(request);

            return Ok(res);
        }

        /// <summary>
        /// RETORNA LA TABLA Contrato EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<ContratoRequest> request)
        {
            List<ContratoResponse> res = _ContratoBussnies.CreateMultiple(request);

            return Ok(res);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA Contrato
        /// </summary>
        /// <param name="request">ContratoRequest</param>
        /// <returns>ContratoResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ContratoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] ContratoRequest request)
        {
            return Ok(_ContratoBussnies.Update(request));
        }

        /// <summary>
        /// ELIMINA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>cantidad de registros eliminados</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(int))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]

        public IActionResult Delete(int id)
        {
            return Ok(_ContratoBussnies.Delete(id));
        }
        #endregion CRUD METHODS
    }
}
