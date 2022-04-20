using LobsterInk.Adventure.Shared.Models;

namespace LobsterInk.Adventure.Data.Repositories
{
    public interface IGameRepository
    {
        string? Add(Game game);

        Game? Get(string sessionId);

        Node? GetNextStep(string sessionId, string answerId);
    }
}
