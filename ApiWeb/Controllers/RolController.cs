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
    public class RolController : ControllerBase
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IRolBussnies _RolBussnies;
        private readonly IMapper _mapper;
        public RolController(IMapper mapper)
        {
            _mapper = mapper;
            _RolBussnies = new RolBussnies(mapper);
        }
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region CRUD METHODS
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA Rol
        /// </summary>
        /// <returns>List-RolResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<RolResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            //int a = 0, b=5, c=6;

            //sabemos que no puede haber una división entre ==> 0
            //c = b / a;


            return Ok(_RolBussnies.GetAll());
        }
        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>RolResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(RolResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_RolBussnies.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA Rol
        /// </summary>
        /// <param name="request">RolRequest</param>
        /// <returns>RolResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(RolResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] RolRequest request)
        {
            return Ok(_RolBussnies.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA Rol EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public IActionResult GetByFilter([FromBody] GenericFilterRequest request)
        {
            GenericFilterResponse<RolResponse> res = _RolBussnies.GetByFilter(request);

            return Ok(res);
        }

        /// <summary>
        /// RETORNA LA TABLA Rol EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<RolRequest> request)
        {
            List<RolResponse> res = _RolBussnies.CreateMultiple(request);

            return Ok(res);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA Rol
        /// </summary>
        /// <param name="request">RolRequest</param>
        /// <returns>RolResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(RolResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] RolRequest request)
        {
            return Ok(_RolBussnies.Update(request));
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
            return Ok(_RolBussnies.Delete(id));
        }
        #endregion CRUD METHODS
    }
}
