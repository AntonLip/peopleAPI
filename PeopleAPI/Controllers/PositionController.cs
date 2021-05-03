using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleAPI.Filters;
using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.Interfaces;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PeopleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [ExceptionFilter]
    [HttpModelResultFilter]
    public class PositionController : ControllerBase
    {
        private readonly IPositionServices _positionServices;
        private readonly ILogger<PositionController> _logger;
        public PositionController(IPositionServices positionServices,
                                    ILogger<PositionController> logger)
        {
            _positionServices = positionServices;
            _logger = logger;

        }
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "All position", Type = typeof(ResultDto<List<PositionDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<PositionDto>>>> GetAllPositionAsync()
        {
            return Ok(await _positionServices.GetAllAsync());
        }

        [HttpGet]
        [Route("{positionId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get  position by Id", Type = typeof(ResultDto<List<PositionDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<PositionDto>>>> GetPositionByIdAsync(Guid positionId)
        {
            return Ok(await _positionServices.GetByIdAsync(positionId));
        }
        [HttpGet]
        [Route("oficers")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Oficers unit", Type = typeof(ResultDto<List<PositionDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<PositionDto>>>> GetOficerUnitAsync()
        {
            return Ok(await _positionServices.GetPositionByStatus(true));
        }
        [HttpGet]
        [Route("cadets")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Cadets unit", Type = typeof(ResultDto<List<PositionDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<PositionDto>>>> GetCadetUnitAsync()
        {
            return Ok(await _positionServices.GetPositionByStatus(false));
        }
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Create postition", Type = typeof(ResultDto<List<PositionDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<PositionDto>>> CreatePositionAsync(AddPositionDto positionDto)
        {
            return Ok(await _positionServices.AddAsync(positionDto));
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Update position by Id", Type = typeof(ResultDto<List<PositionDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<PositionDto>>> UpdatePositionAsync(Guid positionId, PositionDto positionDto)
        {
            return Ok(await _positionServices.UpdateAsync(positionId, positionDto));
        }
        [HttpDelete]
        [Route("{positionId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get  position by Id", Type = typeof(ResultDto<List<PositionDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<PositionDto>>>> RemovePositionAsync(Guid positionId)
        {
            return Ok(await _positionServices.RemoveAsync(positionId));
        }
    }
}
