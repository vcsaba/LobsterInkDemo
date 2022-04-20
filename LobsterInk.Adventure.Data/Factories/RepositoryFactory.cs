using LobsterInk.Adventure.Data.Models;
using LobsterInk.Adventure.Data.Repositories;
using LobsterInk.Adventure.Shared.Models;
using Microsoft.Extensions.Configuration;

namespace LobsterInk.Adventure.Data.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IParentAssociationNodeRepository _parentAssociationNodeRepository;
        private readonly IMaterializedPathRepository _materializedPathRepository;
        private readonly INestedSetRepository _nestedSetRepository;

        public RepositoryFactory(IConfiguration configuration, IParentAssociationNodeRepository parentAssociationNodeRepository, IMaterializedPathRepository materializedPathRepository, INestedSetRepository nestedSetRepository)
        {
            _configuration = configuration;
            _nestedSetRepository = nestedSetRepository;
            _parentAssociationNodeRepository = parentAssociationNodeRepository;
            _materializedPathRepository = materializedPathRepository;
        }

        public INodeRepository<Node> CreateRepository()
        {
            Enum.TryParse(_configuration[Shared.Constants.Configurations.StorageTypeKey], out StorageType storageType);

            switch (storageType)
            {
                case StorageType.MaterializedPath:
                    {
                        return _materializedPathRepository;
                    }

                case StorageType.NestedSet:
                    {
                        return _nestedSetRepository;
                    }

                case StorageType.ParentAssociation:
                default:
                    {
                        return _parentAssociationNodeRepository;
                    }
            }
        }
    }
}
