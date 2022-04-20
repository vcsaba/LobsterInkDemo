namespace LobsterInk.Adventure.Data.Entities.MaterializedPath
{
    public class MaterializedPathNodeEntity
    {
        public string Id { get; set; }

        public string Message { get; set; }

        public string Details { get; set; }

        public string? ParentId { get; set; }

        public string? ParentPath { get; set; }
    }
}
