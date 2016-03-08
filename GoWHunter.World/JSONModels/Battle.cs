namespace GoWHunter.World.JSONModels
{
    public class Battle
    {
        public int ChallengeId { get; set; }
        public int Difficulty { get; set; }
        public int LootTableId { get; set; }
        public Manacolors1 ManaColors { get; set; }
        public string Name { get; set; }
        public int[] TroopIds { get; set; }
        public string Type { get; set; }
        public bool Used { get; set; }
    }
}