using LobsterInk.Adventure.Data.Repositories;
using AdventureModel = LobsterInk.Adventure.Shared.Models.Adventure;

namespace LobsterInk.Adventure.Business.Services
{
    public class AdventureService : IAdventureService
    {
        private readonly IAdventureRepository _adventureRepository;

        public AdventureService(IAdventureRepository adventureRepository)
        {
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
    }
}
