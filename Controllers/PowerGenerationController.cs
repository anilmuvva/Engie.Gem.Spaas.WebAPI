using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Engie.Gem.Spaas.WebAPI.DTO;
using Engie.Gem.Spaas.WebAPI.BusinessService;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Engie.Gem.Spaas.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PowerGenerationController : ControllerBase
    {

        private readonly ILogger<PowerGenerationController> _logger;
        private readonly IPowerGenerationService _powerPlantService;
        public PowerGenerationController(ILogger<PowerGenerationController> logger, IPowerGenerationService powerPlantService)
        {
            _logger = logger;
            _powerPlantService = powerPlantService;
        }


        [HttpPost]
        [Route("productionplan")]        
        public async Task<IActionResult> ProductionPlanAsync([FromBody] RequestPayload request)
        {
            var response = await _powerPlantService.GetproductionPlanAsync(request);
            return Ok(response);
       
        }
    
    }
}
