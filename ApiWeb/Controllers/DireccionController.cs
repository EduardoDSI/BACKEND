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
    public class DireccionController : ControllerBase
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IDireccionBussnies _DireccionBussnies;
        private readonly IMapper _mapper;
        public DireccionController(IMapper mapper)
        {
            _mapper = mapper;
            _DireccionBussnies = new DireccionBussnies(mapper);
        }
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region CRUD METHODS
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA Direccion
        /// </summary>
        /// <returns>List-DireccionResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<DireccionResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            //int a = 0, b=5, c=6;

            //sabemos que no puede haber una división entre ==> 0
            //c = b / a;


            return Ok(_DireccionBussnies.GetAll());
        }
        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>DireccionResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DireccionResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_DireccionBussnies.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA Direccion
        /// </summary>
        /// <param name="request">DireccionRequest</param>
        /// <returns>DireccionResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DireccionResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] DireccionRequest request)
        {
            return Ok(_DireccionBussnies.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA Direccion EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public IActionResult GetByFilter([FromBody] GenericFilterRequest request)
        {
            GenericFilterResponse<DireccionResponse> res = _DireccionBussnies.GetByFilter(request);

            return Ok(res);
        }

        /// <summary>
        /// RETORNA LA TABLA Direccion EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<DireccionRequest> request)
        {
            List<DireccionResponse> res = _DireccionBussnies.CreateMultiple(request);

            return Ok(res);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA Direccion
        /// </summary>
        /// <param name="request">DireccionRequest</param>
        /// <returns>DireccionResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DireccionResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] DireccionRequest request)
        {
            return Ok(_DireccionBussnies.Update(request));
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
            return Ok(_DireccionBussnies.Delete(id));
        }
        #endregion CRUD METHODS
    }
}
