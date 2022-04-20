using LobsterInk.Adventure.Api.Models;
using LobsterInk.Adventure.Business.Services;
using LobsterInk.Adventure.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LobsterInk.Adventure.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IGameService _gameService;

        public GameController(IGameService gameService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GameController>();

            _gameService = gameService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Start(CreateGameApiModel game)
        {
            var newGameId = await _gameService.AddAsync(game);

            return Ok(newGameId);
        }

        [HttpGet("{sessionId}")]
        public async Task<ActionResult<Game>> Get([Required] string sessionId)
        {
            var game = await _gameService.GetAsync(sessionId);

            return Ok(game);
        }

        [HttpGet("play/{sessionId}")]
        public async Task<ActionResult<Node>> Play([Required] string sessionId)
        {
            var node = await _gameService.GetStepAsync(sessionId, answerId: null);

            return Ok(node);
        }

        [HttpGet("play/{sessionId}/{answerId}")]
        public async Task<ActionResult<Node>> Play([Required] string sessionId, string answerId)
        {
            var node = await _gameService.GetStepAsync(sessionId, answerId);

            return Ok(node);
        }
    }
}
