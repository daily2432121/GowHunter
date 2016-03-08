namespace GoWHunter.World.JSONModels
{
    public class Kingdom
    {
        public int BannerArmorBonus { get; set; }
        public int BannerAttackBonus { get; set; }
        public string BannerDescription { get; set; }
        public string BannerFileBase { get; set; }
        public int BannerHealthBonus { get; set; }
        public string BannerManaDescription { get; set; }
        public string BannerName { get; set; }
        public int BannerSpellPowerBonus { get; set; }
        public Battle[] Battles { get; set; }
        public string ByLine { get; set; }
        public string Description { get; set; }
        public string FileBase { get; set; }
        public int GoldIncome { get; set; }
        public int GoldMax { get; set; }
        public int Id { get; set; }
        public int LevelRequired { get; set; }
        public int[] Links { get; set; }
        public int LootTableId { get; set; }
        public Manacolors ManaColors { get; set; }
        public string Name { get; set; }
        public int NumLinks { get; set; }
        public string PassiveDescription { get; set; }
        public int PassiveManaBonusPercentage { get; set; }
        public string ReferenceName { get; set; }
        public int[] TroopIds { get; set; }
        public bool Tutorial { get; set; }
        public bool Used { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
    }
}