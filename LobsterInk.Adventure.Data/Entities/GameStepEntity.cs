namespace LobsterInk.Adventure.Data.Entities
{
    public class GameStepEntity
    {
        public string Id { get; set; }

        public DateTime? SelectedTime { get; set; }

        public string GameId { get; set; }

        public virtual GameEntity? Game { get; set; }

        public string SelectedNodeId { get; set; }
    }
}
