using AutoMapper;
using LobsterInk.Adventure.Data.Database;
using LobsterInk.Adventure.Data.Entities;
using LobsterInk.Adventure.Data.Factories;
using LobsterInk.Adventure.Shared.Models;
using Microsoft.Extensions.Logging;
using AdventureModel = LobsterInk.Adventure.Shared.Models.Adventure;

namespace LobsterInk.Adventure.Data.Repositories
{
    public class AdventureRepository : IAdventureRepository
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly INodeRepositoryFactory _repositoryFactory;
        private readonly LobsterInkContext _context;

        public AdventureRepository(LobsterInkContext context, INodeRepositoryFactory repositoryFactory, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AdventureRepository>();

            _mapper = mapper;
            _context = context;
            _repositoryFactory = repositoryFactory;
        }

        public string? Add(AdventureModel adventure)
        {
            if (adventure == null)
            {
                _logger.LogWarning($"'{nameof(AdventureRepository)}', Parameter '{nameof(adventure)}' in '{nameof(Add)}' method: wrong or empty entity!");
                return null;
            }

            var entity = _mapper.Map<AdventureEntity>(adventure);
            var newEntity = _context.Adventures.Add(entity);

            _context.SaveChanges();

            return newEntity.Entity.Id;
        }

        public AdventureModel? Get(string id)
        {
            var entity = _context.Adventures.FirstOrDefault(y => y.Id == id);
            if (entity == null)
            {
                _logger.LogWarning($"'{nameof(AdventureRepository)}', Parameter '{nameof(id)}' in '{nameof(Get)}' method: entity can not be found!");
                return null;
            }

            var adventure = _mapper.Map<AdventureModel>(entity);
            GetAllNode(adventure);

            return adventure;
        }

        public IEnumerable<AdventureModel> List()
        {
            var adventures = _context.Adventures.OrderBy(y => y.Name).Select(y => _mapper.Map<AdventureModel>(y)).ToList();
            foreach (var adventure in adventures)
            {
                GetStartingNode(adventure);
            }

            return adventures;
        }

        public AdventureModel? Update(AdventureModel adventure)
        {
            if (adventure == null)
            {
                _logger.LogWarning($"'{nameof(AdventureRepository)}', Parameter '{nameof(adventure)}' in '{nameof(Update)}' method: wrong or empty entity!");
                return null;
            }

            var entity = _mapper.Map<AdventureEntity>(adventure);
            var updatedEntity = _context.Adventures.Update(entity);

            _context.SaveChanges();

            var updatedAdventure = _mapper.Map<AdventureModel>(updatedEntity.Entity);

            return updatedAdventure;
        }

        public void Delete(string id)
        {
            var entityToRemove = _context.Adventures.FirstOrDefault(y => y.Id.Equals(id));
            if (entityToRemove == null)
            {
                _logger.LogWarning($"'{nameof(AdventureRepository)}', Parameter '{nameof(id)}' in '{nameof(Delete)}' method: entity can not be found!");
                return;
            }

            _context.Adventures.Remove(entityToRemove);
            _context.SaveChanges();
        }

        private void GetStartingNode(AdventureModel adventure)
        {
            if (string.IsNullOrEmpty(adventure?.StartingNodeId))
            {
                return;
            }

            var startingNode = _repositoryFactory.CreateRepository().Get(adventure.StartingNodeId);
            adventure.StartingNode = startingNode;
        }

        private void GetAllNode(AdventureModel adventure)
        {
            if (string.IsNullOrEmpty(adventure?.StartingNodeId))
            {
                return;
            }

            adventure.StartingNode = GetNode(adventure.StartingNodeId);
        }

        private Node GetNode(string nodeId)
        {
            var node = _repositoryFactory.CreateRepository().Get(nodeId);
            if (node.Children != null)
            {
                for (int i = 0; i < node.Children.Count; i++)
                {
                    node.Children[i] = GetNode(node.Children[i].Id);
                }
            }

            return node;
        }
    }
}
