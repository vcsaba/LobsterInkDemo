using LobsterInk.Adventure.Web.Models;
using Newtonsoft.Json;

namespace LobsterInk.Adventure.Web.Services
{
    public class AdventureService
    {
        private const string _apiBaseUrl = "http://localhost:5081";
        private readonly WebHelperService _webHelperService;

        public AdventureService()
        {
            _webHelperService = new WebHelperService();
        }

        public IndexViewModel GetIndexViewModel()
        {
            var adventures = _webHelperService.Get<List<Shared.Models.Adventure>>($"{_apiBaseUrl}/api/adventure");
            var viewModel = new IndexViewModel
            {
                Adventures = adventures
            };

            return viewModel;
        }

        public GameViewModel GetGameViewModel(string sessionId, string selectedNodeId, bool newGame = false, string adventureId = null)
        {
            if (newGame)
            {
                CreateGame(adventureId, sessionId);
            }

            var url = string.IsNullOrEmpty(selectedNodeId) ? $"{_apiBaseUrl}/api/game/play/{sessionId}" : $"{_apiBaseUrl}/api/game/play/{sessionId}/{selectedNodeId}";
            var node = _webHelperService.Get<Shared.Models.Node>(url);
            var gameViewModel = new GameViewModel
            {
                AdventureId = adventureId,
                Node = node
            };

            return gameViewModel;
        }

        private void CreateGame(string adventureId, string sessionId)
        {
            var requestData = new { adventureId, sessionId };

            var gameId = _webHelperService.Post($"{_apiBaseUrl}/api/game", JsonConvert.SerializeObject(requestData));
        }
    }
}
