using AutoMapper;
using LobsterInk.Adventure.Data.Database;
using LobsterInk.Adventure.Data.Entities.ParentAssociation;
using LobsterInk.Adventure.Shared.Models;
using Microsoft.Extensions.Logging;

namespace LobsterInk.Adventure.Data.Repositories
{
    public class ParentAssociationNodeRepository : IParentAssociationNodeRepository
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly LobsterInkContext _context;

        public ParentAssociationNodeRepository(LobsterInkContext context, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ParentAssociationNodeRepository>();

            _mapper = mapper;
            _context = context;
        }

        public string? Add(Node node)
        {
            if (node == null)
            {
                _logger.LogWarning($"'{nameof(ParentAssociationNodeRepository)}', Parameter '{nameof(node)}' in '{nameof(Add)}' method: wrong or empty entity!");
                return null;
            }

            var entity = _mapper.Map<ParentAssociationNodeEntity>(node);
            var newEntity = _context.ParentAssociationNodeEntities.Add(entity);

            _context.SaveChanges();

            return newEntity.Entity.Id;
        }

        public Node? Get(string id)
        {
            var entity = _context.ParentAssociationNodeEntities.FirstOrDefault(y => y.Id == id);
            if (entity == null)
            {
                _logger.LogWarning($"'{nameof(ParentAssociationNodeRepository)}', Parameter '{nameof(id)}' in '{nameof(Get)}' method: entity can not be found!");
                return null;
            }

            var node = _mapper.Map<Node>(entity);
            GetNodeChildren(node);

            return node;
        }

        public Node? Update(Node node)
        {
            if (node == null)
            {
                _logger.LogWarning($"'{nameof(ParentAssociationNodeRepository)}', Parameter '{nameof(node)}' in '{nameof(Update)}' method: wrong or empty entity!");
                return null;
            }

            var entity = _mapper.Map<ParentAssociationNodeEntity>(node);
            var updatedEntity = _context.ParentAssociationNodeEntities.Update(entity);

            // TODO: UPDATE THE SUB-TREE...

            _context.SaveChanges();

            var updatedNode = _mapper.Map<Node>(updatedEntity.Entity);

            return updatedNode;
        }

        public void Delete(string id)
        {
            var entityToRemove = _context.ParentAssociationNodeEntities.FirstOrDefault(y => y.Id.Equals(id));
            if (entityToRemove == null)
            {
                _logger.LogWarning($"'{nameof(ParentAssociationNodeRepository)}', Parameter '{nameof(id)}' in '{nameof(Delete)}' method: entity can not be found!");
                return;
            }

            _context.ParentAssociationNodeEntities.Remove(entityToRemove);
            _context.SaveChanges();
        }

        private void GetNodeChildren(Node node)
        {
            var children = _context.ParentAssociationNodeEntities.Where(y => y.ParentId == node.Id).ToList();
            if (children.Any())
            {
                node.Children = children.Select(y => _mapper.Map<Node>(y)).ToList();
            }
        }
    }
}
