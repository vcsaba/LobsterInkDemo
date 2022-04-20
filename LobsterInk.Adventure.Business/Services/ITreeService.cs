using LobsterInk.Adventure.Shared.Models;

namespace LobsterInk.Adventure.Business.Services
{
    /// <summary>
    /// Public interface for <see cref="ITreeService"/>.
    /// </summary>
    public interface ITreeService
    {
        /// <summary>
        /// Adds a new node to the tree.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>Returns with the identifier of the new node.</returns>
        Task<string> AddNodeAsync(Node node);

        /// <summary>
        /// Gets the node by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns with the node if found. Otherwise returns with <see cref="null"/>.</returns>
        Task<Node> GetNodeAsync(string id);

        /// <summary>
        /// Updates the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>Returns with the update node.</returns>
        Task<Node> UpdateNodeAsync(Node node);

        /// <summary>
        /// Deletes the node.
        /// </summary>
        /// <param name="id">The id of the node to delete.</param>
        /// <returns>Returns with the task.</returns>
        Task DeleteNodeAsync(string id);
    }
}
