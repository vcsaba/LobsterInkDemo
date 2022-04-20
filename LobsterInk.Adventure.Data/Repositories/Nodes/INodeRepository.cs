using LobsterInk.Adventure.Shared.Models;

namespace LobsterInk.Adventure.Data.Repositories
{
    /// <summary>
    /// Public interface for <see cref="INodeRepository"/>.
    /// </summary>
    public interface INodeRepository<T> where T : Node
    {
        /// <summary>
        /// Adds a new node. Does re-index processes if need to.
        /// </summary>
        /// <param name="node">The node to add.</param>
        /// <typeparam name="T">The type of the node.</typeparam>
        /// <returns>Returns with the new identifier associated with the new entity.</returns>
        string? Add(T node);

        /// <summary>
        /// Gets the node by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <typeparam name="T">The type of the node.</typeparam>
        /// <returns>Returns with the node.</returns>
        T? Get(string Id);

        /// <summary>
        /// Updates the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>Returns with the update node.</returns>
        T? Update(T node);

        /// <summary>
        /// Deletes the node.
        /// </summary>
        /// <param name="id">The id of the node to delete.</param>
        void Delete(string id);
    }
}
