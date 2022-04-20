using LobsterInk.Adventure.Shared.Models;
using System.Text.Json.Serialization;

namespace LobsterInk.Adventure.Api.Models
{
    public class UpdateNodeApiModel : Node
    {
        [JsonIgnore]
        public new Node? Parent { get; set; }

        [JsonIgnore]
        public new List<Node>? Children { get; set; }
    }
}
