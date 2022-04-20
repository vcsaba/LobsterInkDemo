namespace LobsterInk.Adventure.Shared.Models
{
    public class Adventure
    {
        public string? Id { get; set; }

        public string Name { get; set; }

        public string? StartingNodeId { get; set; }

        public Node? StartingNode { get; set; }
    }
}
