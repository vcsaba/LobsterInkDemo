namespace LobsterInk.Adventure.Shared.Models
{
    public class Game
    {
        public string Id { get; set; }

        public string AdventureId { get; set; }

        public Adventure? Adventure { get; set; }

        public string SessionId { get; set; }

        public IEnumerable<GameStep>? Steps { get; set; }
    }
}
