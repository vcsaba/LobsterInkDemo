namespace LobsterInk.Adventure.Data.Entities
{
    public class AdventureEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string? StartingNodeId { get; set; }

        public virtual IEnumerable<GameEntity>? Games { get; set; }
    }
}
