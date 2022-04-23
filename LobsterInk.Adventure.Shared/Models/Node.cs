namespace LobsterInk.Adventure.Shared.Models
{
    public class Node
    {
        public string? Id { get; set; }

        public string Message { get; set; }

        public string Details { get; set; }

        public string? ParentId { get; set; }

        public Node? Parent { get; set; }

        public List<Node>? Children { get; set; }

        public bool IsSelected { get; set; }
    }
}
