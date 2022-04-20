using LobsterInk.Adventure.Api.Models;
using LobsterInk.Adventure.Business.Services;
using LobsterInk.Adventure.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LobsterInk.Adventure.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NodeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ITreeService _treeService;

        public NodeController(ITreeService treeService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<NodeController>();
            _treeService = treeService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateNodeApiModel node)
        {
            var newId = await _treeService.AddNodeAsync(node);

            return Ok(newId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Node>> Get([Required] string id)
        {
            var node = await _treeService.GetNodeAsync(id);
            if (node == null)
            {
                string errorMessage = $"Node cannot be found with ID '{id}'!";
                _logger.LogWarning(errorMessage);

                return NotFound(new { Error = errorMessage });
            }

            return Ok(node);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateNodeApiModel node)
        {
            var newNode = await _treeService.UpdateNodeAsync(node);
            if (newNode == null)
            {
                string errorMessage = $"Node cannot be found with ID '{node?.Id}'!";
                _logger.LogWarning(errorMessage);

                return NotFound(new { Error = errorMessage });
            }

            return Ok(newNode);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] string id)
        {
            await _treeService.DeleteNodeAsync(id);

            return Ok();
        }
    }
}
