using AdventureModel = LobsterInk.Adventure.Shared.Models.Adventure;

namespace LobsterInk.Adventure.Data.Repositories
{
    public interface IAdventureRepository
    {
        string? Add(AdventureModel adventure);

        AdventureModel? Get(string Id);

        IEnumerable<AdventureModel> List();

        AdventureModel? Update(AdventureModel adventure);

        void Delete(string id);
    }
}
