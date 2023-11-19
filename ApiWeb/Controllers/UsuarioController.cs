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
    public class UsuarioController : ControllerBase
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IUsuarioBussnies _UsuarioBussnies;
        private readonly IMapper _mapper;
        public UsuarioController(IMapper mapper)
        {
            _mapper = mapper;
            _UsuarioBussnies = new UsuarioBussnies(mapper);
        }
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region CRUD METHODS
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA Usuario
        /// </summary>
        /// <returns>List-UsuarioResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UsuarioResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            //int a = 0, b=5, c=6;

            //sabemos que no puede haber una división entre ==> 0
            //c = b / a;


            return Ok(_UsuarioBussnies.GetAll());
        }
        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>UsuarioResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_UsuarioBussnies.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA Usuario
        /// </summary>
        /// <param name="request">UsuarioRequest</param>
        /// <returns>UsuarioResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] UsuarioRequest request)
        {
            return Ok(_UsuarioBussnies.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA Usuario EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public IActionResult GetByFilter([FromBody] GenericFilterRequest request)
        {
            GenericFilterResponse<UsuarioResponse> res = _UsuarioBussnies.GetByFilter(request);

            return Ok(res);
        }

        /// <summary>
        /// RETORNA LA TABLA Usuario EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<UsuarioRequest> request)
        {
            List<UsuarioResponse> res = _UsuarioBussnies.CreateMultiple(request);

            return Ok(res);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA Usuario
        /// </summary>
        /// <param name="request">UsuarioRequest</param>
        /// <returns>UsuarioResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] UsuarioRequest request)
        {
            return Ok(_UsuarioBussnies.Update(request));
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
            return Ok(_UsuarioBussnies.Delete(id));
        }
        #endregion CRUD METHODS
    }
}
