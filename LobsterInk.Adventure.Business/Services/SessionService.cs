using LobsterInk.Adventure.Data.Models;
using Microsoft.Extensions.Configuration;

namespace LobsterInk.Adventure.Business.Services
{
    public class SessionService : ISessionService
    {
        private readonly IConfiguration _configuration;

        public SessionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public StorageType GetStorageType()
        {
            Enum.TryParse(_configuration[Shared.Constants.Configurations.StorageTypeKey], out StorageType storageType);

            return storageType;
        }
    }
}
