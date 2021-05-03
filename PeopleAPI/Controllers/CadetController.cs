using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.DTOModels.Cadet;
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
    public class CadetController : ControllerBase
    {
        private readonly ICadetService _cadetService;
        private readonly ILogger<CadetController> _logger;
        public CadetController(ICadetService cadetService,
            ILogger<CadetController> logger)
        {
            _cadetService = cadetService;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "All cadet", Type = typeof(ResultDto<List<PersonInfoDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<PersonInfoDto>>>> GetAllCadetssAsync()
        {
            return Ok(await _cadetService.GetAllAsync());
        }



        [HttpPost]
        [Route("filtered")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get filtered cadet", Type = typeof(ResultDto<PersonInfoDto>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<PersonInfoDto>>> GetFilteredCadetsAsync([FromBody] PersonFilter filter)
        {
            return Ok(await _cadetService.GetFilteredOficers(filter));
        }

        [HttpGet]
        [Route("{cadetId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "cadet by id", Type = typeof(ResultDto<PersonInfoDto>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<PersonInfoDto>>> GetCadetByIdAsync([FromRoute] Guid cadetId)
        {
            return Ok(await _cadetService.GetFullInfoByIdAsync(cadetId));
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Create cadet", Type = typeof(ResultDto<PersonInfoDto>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<PersonInfoDto>>> CreateCadet([FromBody] AddCadetDto model)
        {
            return Ok(await _cadetService.AddAsync(model));
        }

        [HttpDelete]
        [Route("{cadetId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Remove cadet", Type = typeof(ResultDto<PersonInfoDto>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<PersonInfoDto>>> RemoveCadet([FromRoute] Guid cadetId)
        {
            return Ok(await _cadetService.RemoveAsync(cadetId));
        }

        [HttpPut]
        [Route("{cadetId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Update cadet", Type = typeof(ResultDto<PersonInfoDto>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<PersonInfoDto>>> UpdateCadet([FromRoute] Guid cadetId, [FromBody] UpdateCadetDto model)
        {
            return Ok(await _cadetService.UpdateAsync(cadetId, model));
        }
    }
}
