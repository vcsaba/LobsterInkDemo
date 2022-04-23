using LobsterInk.Adventure.Api.Models;
using LobsterInk.Adventure.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using AdventureModel = LobsterInk.Adventure.Shared.Models.Adventure;

namespace LobsterInk.Adventure.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdventureController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAdventureService _adventureService;

        public AdventureController(IAdventureService adventureService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AdventureController>();
            _adventureService = adventureService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateAdventureApiModel adventure)
        {
            var newId = await _adventureService.AddAdventureAsync(adventure);

            return Ok(newId);
        }

        [HttpGet]
        public async Task<ActionResult<List<AdventureModel>>> List()
        {
            var adventureList = await _adventureService.ListAdventuresAsync();

            return Ok(adventureList ?? new List<AdventureModel>());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdventureModel>> Get([Required] string id)
        {
            var adventure = await _adventureService.GetAdventureAsync(id);
            if (adventure == null)
            {
                string errorMessage = $"Adventure cannot be found with ID '{id}'!";
                _logger.LogWarning(errorMessage);

                return NotFound(new { Error = errorMessage });
            }

            return Ok(adventure);
        }

        [HttpGet("{id}/{sessionId}")]
        public async Task<ActionResult<AdventureModel>> Get([Required] string id, string sessionId)
        {
            var adventure = await _adventureService.GetAdventureAsync(id, sessionId);
            if (adventure == null)
            {
                string errorMessage = $"Adventure cannot be found with ID '{id}'!";
                _logger.LogWarning(errorMessage);

                return NotFound(new { Error = errorMessage });
            }

            return Ok(adventure);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AdventureModel adventure)
        {
            var newAdventure = await _adventureService.UpdateAdventureAsync(adventure);
            if (newAdventure == null)
            {
                string errorMessage = $"Adventure cannot be found with ID '{adventure?.Id}'!";
                _logger.LogWarning(errorMessage);

                return NotFound(new { Error = errorMessage });
            }

            return Ok(newAdventure);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] string id)
        {
            await _adventureService.DeleteAdventureAsync(id);

            return Ok();
        }
    }
}
