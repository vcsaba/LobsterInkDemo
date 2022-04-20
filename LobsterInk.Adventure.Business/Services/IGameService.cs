using LobsterInk.Adventure.Shared.Models;

namespace LobsterInk.Adventure.Business.Services
{
    public interface IGameService
    {
        Task<string>? AddAsync(Game game);

        Task<Game>? GetAsync(string sessionId);

        Task<Node>? GetStepAsync(string sessionId, string answerId);
    }
}
