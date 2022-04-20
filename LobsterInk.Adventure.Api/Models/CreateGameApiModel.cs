using LobsterInk.Adventure.Shared.Models;
using System.Text.Json.Serialization;

namespace LobsterInk.Adventure.Api.Models
{
    public class CreateGameApiModel : Game
    {
        [JsonIgnore]
        public new string? Id { get; set; }

        [JsonIgnore]
        public new Shared.Models.Adventure? Adventure { get; set; }

        [JsonIgnore]
        public new IEnumerable<GameStep>? Steps { get; set; }
    }
}
