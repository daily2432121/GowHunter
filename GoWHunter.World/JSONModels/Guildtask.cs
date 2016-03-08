namespace GoWHunter.World.JSONModels
{
    public class Guildtask
    {
        public int GoldRequired { get; set; }
        public int GuildLevel { get; set; }
        public int Id { get; set; }
        public int MaxGuildLevel { get; set; }
        public string Name { get; set; }
        public Rewards Rewards { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
    }
}