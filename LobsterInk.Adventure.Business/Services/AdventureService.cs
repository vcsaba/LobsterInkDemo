using LobsterInk.Adventure.Data.Repositories;
using LobsterInk.Adventure.Shared.Models;
using AdventureModel = LobsterInk.Adventure.Shared.Models.Adventure;

namespace LobsterInk.Adventure.Business.Services
{
    public class AdventureService : IAdventureService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IAdventureRepository _adventureRepository;

        public AdventureService(IGameRepository gameRepository, IAdventureRepository adventureRepository)
        {
            _gameRepository = gameRepository;
            _adventureRepository = adventureRepository;
        }

        public async Task<string> AddAdventureAsync(AdventureModel adventure)
        {
            var newId = _adventureRepository.Add(adventure);

            return await Task.FromResult(newId);
        }

        public async Task<AdventureModel> GetAdventureAsync(string id)
        {
            var adventure = _adventureRepository.Get(id);

            return await Task.FromResult(adventure);
        }

        public async Task<AdventureModel> GetAdventureAsync(string id, string sessionId)
        {
            var adventure = _adventureRepository.Get(id);
            var game = _gameRepository.Get(sessionId);
            var gameSteps = _gameRepository.GetSteps(game.Id);

            SetSelectedField(adventure.StartingNode, gameSteps);

            return await Task.FromResult(adventure);
        }

        public async Task<IEnumerable<AdventureModel>> ListAdventuresAsync()
        {
            var list = _adventureRepository.List();

            return await Task.FromResult(list);
        }

        public async Task<AdventureModel> UpdateAdventureAsync(AdventureModel adventure)
        {
            var updatedNode = _adventureRepository.Update(adventure);

            return await Task.FromResult(updatedNode);
        }

        public async Task DeleteAdventureAsync(string id)
        {
            _adventureRepository.Delete(id);

            await Task.FromResult(0);
        }

        private void SetSelectedField(Node node, IEnumerable<GameStep> gameSteps)
        {
            node.IsSelected = gameSteps.Any(y => y.SelectedNodeId.Equals(node.Id, StringComparison.InvariantCultureIgnoreCase));

            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    SetSelectedField(child, gameSteps);
                }
            }
        }
    }
}
