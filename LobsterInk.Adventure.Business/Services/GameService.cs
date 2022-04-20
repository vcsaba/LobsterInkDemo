using LobsterInk.Adventure.Data.Repositories;
using LobsterInk.Adventure.Shared.Models;

namespace LobsterInk.Adventure.Business.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;

        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<string>? AddAsync(Game game)
        {
            var newGameId = _repository.Add(game);

            return await Task.FromResult(newGameId);
        }

        public async Task<Game>? GetAsync(string sessionId)
        {
            var game = _repository.Get(sessionId);

            return await Task.FromResult(game);
        }

        public async Task<Node>? GetStepAsync(string sessionId, string answerId)
        {
            var gameStep = _repository.GetNextStep(sessionId, answerId);

            return await Task.FromResult(gameStep);
        }
    }
}
