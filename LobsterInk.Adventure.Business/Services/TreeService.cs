using LobsterInk.Adventure.Shared.Models;
using LobsterInk.Adventure.Data.Factories;

namespace LobsterInk.Adventure.Business.Services
{
    public class TreeService : ITreeService
    {
        private readonly INodeRepositoryFactory _repositoryFactory;

        public TreeService(INodeRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<string> AddNodeAsync(Node node)
        {
            var newId = _repositoryFactory.CreateRepository().Add(node);

            return await Task.FromResult(newId);
        }

        public async Task<Node> GetNodeAsync(string id)
        {
            var node = _repositoryFactory.CreateRepository().Get(id);

            return await Task.FromResult(node);
        }

        public async Task<Node> UpdateNodeAsync(Node node)
        {
            var updatedNode = _repositoryFactory.CreateRepository().Update(node);

            return await Task.FromResult(updatedNode);
        }

        public async Task DeleteNodeAsync(string id)
        {
            _repositoryFactory.CreateRepository().Delete(id);

            await Task.FromResult(0);
        }
    }
}
