namespace LobsterInk.Adventure.Data.Entities
{
    public class GameEntity
    {
        public string Id { get; set; }

        public string AdventureId { get; set; }

        public virtual AdventureEntity Adventure { get; set; }

        public string SessionId { get; set; }

        public virtual IEnumerable<GameStepEntity>? Steps { get; set; }
    }
}
