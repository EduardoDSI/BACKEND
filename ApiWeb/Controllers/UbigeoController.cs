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
    public class UbigeoController : ControllerBase
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IUbigeoBussnies _UbigeoBussnies;
        private readonly IMapper _mapper;
        public UbigeoController(IMapper mapper)
        {
            _mapper = mapper;
            _UbigeoBussnies = new UbigeoBussnies(mapper);
        }
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region CRUD METHODS
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA Ubigeo
        /// </summary>
        /// <returns>List-UbigeoResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UbigeoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            //int a = 0, b=5, c=6;

            //sabemos que no puede haber una división entre ==> 0
            //c = b / a;


            return Ok(_UbigeoBussnies.GetAll());
        }
        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>UbigeoResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UbigeoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_UbigeoBussnies.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA Ubigeo
        /// </summary>
        /// <param name="request">UbigeoRequest</param>
        /// <returns>UbigeoResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UbigeoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] UbigeoRequest request)
        {
            return Ok(_UbigeoBussnies.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA Ubigeo EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public IActionResult GetByFilter([FromBody] GenericFilterRequest request)
        {
            GenericFilterResponse<UbigeoResponse> res = _UbigeoBussnies.GetByFilter(request);

            return Ok(res);
        }

        /// <summary>
        /// RETORNA LA TABLA Ubigeo EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<UbigeoRequest> request)
        {
            List<UbigeoResponse> res = _UbigeoBussnies.CreateMultiple(request);

            return Ok(res);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA Ubigeo
        /// </summary>
        /// <param name="request">UbigeoRequest</param>
        /// <returns>UbigeoResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UbigeoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] UbigeoRequest request)
        {
            return Ok(_UbigeoBussnies.Update(request));
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
            return Ok(_UbigeoBussnies.Delete(id));
        }
        #endregion CRUD METHODS
    }
}
