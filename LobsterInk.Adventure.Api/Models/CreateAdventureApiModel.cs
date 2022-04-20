using LobsterInk.Adventure.Shared.Models;
using System.Text.Json.Serialization;

namespace LobsterInk.Adventure.Api.Models
{
    public class CreateAdventureApiModel : Shared.Models.Adventure
    {
        [JsonIgnore]
        public new string? Id { get; set; }

        [JsonIgnore]
        public new Node? StartingNode { get; set; }
    }
}
