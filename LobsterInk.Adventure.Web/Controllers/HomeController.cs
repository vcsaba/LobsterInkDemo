using LobsterInk.Adventure.Web.Models;
using LobsterInk.Adventure.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LobsterInk.Adventure.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var _adventureService = new AdventureService();
            var viewModel = _adventureService.GetIndexViewModel();

            return View(viewModel);
        }

        public IActionResult Game(string adventureId, string nextNodeId)
        {
            var _adventureService = new AdventureService();
            var sessionId = GetSessionId(out var newSessionIdCreated);

            var viewModel = _adventureService.GetGameViewModel(sessionId, selectedNodeId: nextNodeId, newGame: newSessionIdCreated, adventureId: adventureId);

            return View(viewModel);
        }

        public IActionResult ResetSession(string adventureId)
        {
            ResetSessionId();

            return RedirectToActionPermanent(nameof(Game), new { adventureId });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetSessionId(out bool newSessionId)
        {
            var sessionIdKey = "gameSessionId";
            var sessionId = HttpContext.Session.GetString(sessionIdKey);

            newSessionId = string.IsNullOrEmpty(sessionId);
            if (newSessionId)
            {
                sessionId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString(sessionIdKey, sessionId);
                Task.Run(async () => await HttpContext.Session.CommitAsync()).Wait();
            }

            return sessionId;
        }

        private void ResetSessionId()
        {
            HttpContext.Session.Clear();
        }
    }
}
