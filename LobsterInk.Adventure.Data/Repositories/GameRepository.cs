using AutoMapper;
using LobsterInk.Adventure.Data.Database;
using LobsterInk.Adventure.Data.Entities;
using LobsterInk.Adventure.Data.Factories;
using LobsterInk.Adventure.Shared.Models;
using Microsoft.Extensions.Logging;

namespace LobsterInk.Adventure.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly INodeRepositoryFactory _repositoryFactory;
        private readonly LobsterInkContext _context;

        public GameRepository(LobsterInkContext context, INodeRepositoryFactory repositoryFactory, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GameRepository>();

            _mapper = mapper;
            _context = context;
            _repositoryFactory = repositoryFactory;
        }

        public string? Add(Game game)
        {
            if (game == null)
            {
                _logger.LogWarning($"'{nameof(GameRepository)}', Parameter '{nameof(game)}' in '{nameof(Add)}' method: wrong or empty entity!");
                return null;
            }

            var entity = _mapper.Map<GameEntity>(game);

            var newEntity = _context.Games.Add(entity);
            var startingNodeId = _context.Adventures.FirstOrDefault(y => y.Id.Equals(game.AdventureId)).StartingNodeId;
            _context.GameSteps.Add(new GameStepEntity
            {
                GameId = newEntity.Entity.Id,
                SelectedNodeId = startingNodeId
            });

            _context.SaveChanges();

            return newEntity.Entity.Id;
        }

        public Game? Get(string sessionId)
        {
            var entity = _context.Games.FirstOrDefault(y => y.SessionId.Equals(sessionId));
            if (entity == null)
            {
                _logger.LogWarning($"'{nameof(GameRepository)}', Parameter '{nameof(sessionId)}' in '{nameof(Get)}' method: entity can not be found!");
                return null;
            }

            var game = _mapper.Map<Game>(entity);
            return game;
        }

        public Node? GetNextStep(string sessionId, string answerId)
        {
            var currentGameStep = GetLatestGameStep(sessionId);
            var currentGameStepNode = GetGameStepNode(sessionId, gameStepEntity: currentGameStep);

            var selectedGameStep = _repositoryFactory.CreateRepository().Get(answerId);
            if (currentGameStepNode?.Id?.Equals(selectedGameStep?.ParentId) ?? false)
            {
                var newGameStepEntity = _context.GameSteps.Add(new GameStepEntity
                {
                    GameId = currentGameStep.GameId,
                    SelectedNodeId = answerId
                });

                _context.SaveChanges();

                return _mapper.Map<Node>(GetGameStepNode(sessionId, gameStepEntity: newGameStepEntity.Entity));
            }

            return currentGameStepNode;
        }

        private GameStepEntity? GetLatestGameStep(string sessionId)
        {
            return _context.GameSteps.OrderByDescending(y => y.SelectedTime)
                .FirstOrDefault(y => sessionId.Equals(y.Game.SessionId));
        }

        private Node? GetGameStepNode(string sessionId, GameStepEntity gameStepEntity = null)
        {
            if (gameStepEntity == null)
            {
                gameStepEntity = GetLatestGameStep(sessionId);
                if (gameStepEntity == null)
                {
                    _logger.LogWarning($"'{nameof(GameRepository)}', Parameter '{nameof(sessionId)}' in '{nameof(GetGameStepNode)}' method: entity can not be found!");
                    return null;
                }
            }

            var nodeEntity = _repositoryFactory.CreateRepository().Get(gameStepEntity.SelectedNodeId);
            if (nodeEntity == null)
            {
                _logger.LogWarning($"'{nameof(GameRepository)}', Parameter '{nameof(sessionId)}' in '{nameof(GetNextStep)}' method: node entity can not be found!");
                return null;
            }

            var node = _mapper.Map<Node>(nodeEntity);
            return node;
        }

        public IEnumerable<GameStep>? GetSteps(string gameId)
        {
            var entities = _context.GameSteps.Where(y => y.GameId.Equals(gameId));
            if (entities == null)
            {
                _logger.LogWarning($"'{nameof(GameRepository)}', Parameter '{nameof(gameId)}' in '{nameof(GetSteps)}' method: entity can not be found!");
                return null;
            }

            return entities.Select(y => _mapper.Map<GameStep>(y));
        }
    }
}
