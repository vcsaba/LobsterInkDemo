using LobsterInk.Adventure.Business.Services;
using LobsterInk.Adventure.Data.Factories;
using LobsterInk.Adventure.Data.Repositories;

namespace LobsterInk.Adventure.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddServices();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IParentAssociationNodeRepository, ParentAssociationNodeRepository>();
            services.AddScoped<IMaterializedPathRepository, MaterializedPathRepository>();
            services.AddScoped<INestedSetRepository, NestedSetRepository>();

            services.AddScoped<INodeRepositoryFactory, NodeRepositoryFactory>();

            services.AddScoped<IAdventureRepository, AdventureRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ITreeService, TreeService>();
            services.AddScoped<IAdventureService, AdventureService>();
            services.AddScoped<IGameService, GameService>();
        }
    }
}
