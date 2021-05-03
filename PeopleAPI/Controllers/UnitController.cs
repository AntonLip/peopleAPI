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
    public class UnitController : ControllerBase
    {
        private readonly IUnitServices _unitServices;
        private readonly ILogger<UnitController> _logger;
        public UnitController(IUnitServices unitServices,
                            ILogger<UnitController> logger)
        {
            _unitServices = unitServices;
            _logger = logger;
        }
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "All unit", Type = typeof(ResultDto<List<UnitDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<UnitDto>>>> GetAllUnitAsync()
        {
            return Ok(await _unitServices.GetAllAsync());
        }

        [HttpGet]
        [Route("oficers")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Oficers unit", Type = typeof(ResultDto<List<UnitDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<UnitDto>>>> GetOficerUnitAsync()
        {
            return Ok(await _unitServices.GetUnitByStatus(true));
        }
        [HttpGet]
        [Route("cadets")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Cadets unit", Type = typeof(ResultDto<List<UnitDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<UnitDto>>>> GetCadetUnitAsync()
        {
            return Ok(await _unitServices.GetUnitByStatus(false));
        }
        [HttpGet]
        [Route("{unitId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get  unit by Id", Type = typeof(ResultDto<List<UnitDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<UnitDto>>>> GetUnitByIdAsync(Guid unitId)
        {
            return Ok(await _unitServices.GetByIdAsync(unitId));
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Create unit", Type = typeof(ResultDto<List<UnitDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<UnitDto>>> CreateUnitAsync(AddUnitDto unitDto)
        {
            return Ok(await _unitServices.AddAsync(unitDto));
        }

        [HttpPut]
        [Route("{unitId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Update unit by Id", Type = typeof(ResultDto<List<UnitDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<UnitDto>>> UpdateUnitAsync([FromRoute]Guid unitId, [FromBody] UnitDto unitDto)
        {
            return Ok(await _unitServices.UpdateAsync(unitId, unitDto));
        }
        [HttpDelete]
        [Route("{unitId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "delete  unit ", Type = typeof(ResultDto<List<UnitDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<UnitDto>>>> RemoveUnitAsync(Guid unitId)
        {
            return Ok(await _unitServices.RemoveAsync(unitId));
        }
    }
}
