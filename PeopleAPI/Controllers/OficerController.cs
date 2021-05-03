using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleAPI.Filters;
using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.DTOModels.Oficer;
using PeopleAPI.Models.Interfaces;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PeopleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [ExceptionFilter]
    [HttpModelResultFilter]
    public class OficerController : ControllerBase
    {
        private readonly IOficerService _oficerService;
        private readonly ILogger<OficerController> _logger;
        public OficerController(IOficerService oficerService,
            ILogger<OficerController> logger)
        {
            _oficerService = oficerService;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "All oficers", Type = typeof(ResultDto<List<PersonInfoDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<PersonInfoDto>>>> GetAllOficersAsync()
        {
            return Ok(await _oficerService.GetAllAsync());
        }

        [HttpGet]
        [Route("lecturals")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "All oficers", Type = typeof(ResultDto<List<PersonInfoDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<PersonInfoDto>>>> GetAllLecturalNameAsync()
        {
            return Ok(await _oficerService.GetLecturalNames());
        }

        [HttpPost]
        [Route("filtered")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get filtered oficer", Type = typeof(ResultDto<PersonInfoDto>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<PersonInfoDto>>> GetFilteredOficersAsync([FromBody] PersonFilter filter)
        {
            return Ok(await _oficerService.GetFilteredOficers(filter));
        }

        [HttpGet]
        [Route("{oficerId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "oficer by id", Type = typeof(ResultDto<PersonInfoDto>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<PersonInfoDto>>> GetOficersByIdAsync([FromRoute] Guid oficerId)
        {
            return Ok(await _oficerService.GetFullInfoByIdAsync(oficerId));
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Create oficer", Type = typeof(ResultDto<PersonInfoDto>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<PersonInfoDto>>> CreateOficer(AddOficerDto model)
        {
            return Ok(await _oficerService.AddAsync(model));
        }

        [HttpDelete]
        [Route("{oficerId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Remove oficer", Type = typeof(ResultDto<PersonInfoDto>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<PersonInfoDto>>> RemoveOficer([FromRoute]Guid oficerId)
        {
            return Ok(await _oficerService.RemoveAsync(oficerId));
        }
        [HttpPut]
        [Route("{oficerId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Update oficer", Type = typeof(ResultDto<PersonInfoDto>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<PersonInfoDto>>> UpdateOficer([FromRoute] Guid oficerId, [FromBody] UpdateOficerDto model)
        {
            return Ok(await _oficerService.UpdateAsync(oficerId, model));
        }
    }
}
