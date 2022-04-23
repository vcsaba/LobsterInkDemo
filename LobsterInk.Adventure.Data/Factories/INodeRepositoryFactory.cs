using LobsterInk.Adventure.Data.Repositories;
using LobsterInk.Adventure.Shared.Models;

namespace LobsterInk.Adventure.Data.Factories
{
    /// <summary>
    /// Public interface for <see cref="INodeRepositoryFactory"/>.
    /// </summary>
    public interface INodeRepositoryFactory
    {
        /// <summary>
        /// Creates the appropriate node repository.
        /// </summary>
        /// <returns>Returns with the <see cref="INodeRepository"/>.</returns>
        INodeRepository<Node> CreateRepository();
    }
}
