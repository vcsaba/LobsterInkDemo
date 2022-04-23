using AdventureModel = LobsterInk.Adventure.Shared.Models.Adventure;

namespace LobsterInk.Adventure.Business.Services
{
    public interface IAdventureService
    {
        Task<string> AddAdventureAsync(AdventureModel adventure);

        Task<AdventureModel> GetAdventureAsync(string id);

        Task<AdventureModel> GetAdventureAsync(string id, string sessionId);

        Task<IEnumerable<AdventureModel>> ListAdventuresAsync();

        Task<AdventureModel> UpdateAdventureAsync(AdventureModel adventure);

        Task DeleteAdventureAsync(string id);
    }
}
