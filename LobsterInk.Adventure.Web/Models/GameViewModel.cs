using LobsterInk.Adventure.Shared.Models;

namespace LobsterInk.Adventure.Web.Models
{
    public class GameViewModel
    {
        public string AdventureId { get; set; }

        public string SessionId { get; set; }

        public Node Node { get; set; }
    }
}
