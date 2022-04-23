using LobsterInk.Adventure.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace LobsterInk.Adventure.Web.Controllers
{
    public class TreeController : Controller
    {
        private readonly ILogger<TreeController> _logger;

        public TreeController(ILogger<TreeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string adventureId, string sessionId)
        {
            var _adventureService = new AdventureService();
            var viewModel = _adventureService.GetTreeIndexViewModel(adventureId, sessionId);

            return View(viewModel);
        }
    }
}
