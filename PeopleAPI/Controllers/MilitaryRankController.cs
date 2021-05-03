using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleAPI.Filters;
using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.Interfaces.Services;
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
    public class MilitaryRankController : ControllerBase
    {
        private readonly IMilitaryRankService _militaryRankService;
        private readonly ILogger<MilitaryRankController> _logger;
        public MilitaryRankController(IMilitaryRankService militaryRankService,
            ILogger<MilitaryRankController> logger)
        {
            _militaryRankService = militaryRankService;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "All ranks", Type = typeof(ResultDto<List<MilitaryRankDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<MilitaryRankDto>>>> GetAllOficersAsync()
        {
            return Ok(await _militaryRankService.GetAllAsync());
        }


        [HttpGet]
        [Route("oficers")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "All oficers ranks", Type = typeof(ResultDto<List<MilitaryRankDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<MilitaryRankDto>>>> GetOficerRanksAsync()
        {
            return Ok(await _militaryRankService.GetByStatusAsync(true));
        }

        [HttpGet]
        [Route("cadets")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "All oficers ranks", Type = typeof(ResultDto<List<MilitaryRankDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<MilitaryRankDto>>>> GetCadetRanksAsync()
        {
            return Ok(await _militaryRankService.GetByStatusAsync(false));
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Create  ranks", Type = typeof(ResultDto<List<MilitaryRankDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<MilitaryRankDto>>>> CreateAsync([FromBody] AddMilitaryRankDto addMilitaryRankDto)
        {
            return Ok(await _militaryRankService.AddAsync(addMilitaryRankDto));
        }
        [HttpDelete]
        [Route("{militaryRankId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Delete  ranks", Type = typeof(ResultDto<List<MilitaryRankDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<MilitaryRankDto>>>> DeleteAsync([FromRoute] Guid militaryRankId)
        {
            return Ok(await _militaryRankService.RemoveAsync(militaryRankId));
        }
    }
}
