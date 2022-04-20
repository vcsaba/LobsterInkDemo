using LobsterInk.Adventure.Data.Models;

namespace LobsterInk.Adventure.Business.Services
{
    /// <summary>
    /// Public interface for <see cref="ISessionService"/>.
    /// </summary>
    public interface ISessionService
    {
        /// <summary>
        /// Gets the storage type assiciated with the session.
        /// </summary>
        /// <returns>Returns with the storage type.</returns>
        StorageType GetStorageType();
    }
}
