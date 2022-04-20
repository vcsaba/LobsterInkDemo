namespace LobsterInk.Adventure.Data.Entities.NestedSet
{
    public class NestedSetNodeEntity
    {
        public string Id { get; set; }

        public string Message { get; set; }

        public string Details { get; set; }

        public string? ParentId { get; set; }

        public int? Left { get; set; }

        public int? Right { get; set; }
    }
}
