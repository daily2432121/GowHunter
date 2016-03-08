namespace GoWHunter.World.JSONModels
{
    public class Quest
    {
        public Condition[] Conditions { get; set; }
        public string Description { get; set; }
        public Endconversation EndConversation { get; set; }
        public int Id { get; set; }
        public int KingdomId { get; set; }
        public int LootTableId { get; set; }
        public string Name { get; set; }
        public Objective[] Objectives { get; set; }
        public int Priority { get; set; }
        public string RewardDescription { get; set; }
        public Startconversation StartConversation { get; set; }
    }
}