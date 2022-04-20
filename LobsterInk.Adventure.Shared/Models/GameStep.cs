namespace LobsterInk.Adventure.Shared.Models
{
    public class GameStep
    {
        public string Id { get; set; }

        public DateTime? SelectedTime { get; set; }

        public string GameId { get; set; }

        public Game? Game { get; set; }

        public string SelectedNodeId { get; set; }

        public object? SelectedNode { get; set; }
    }
}
