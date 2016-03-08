namespace GoWHunter.World.JSONModels
{
    public class Troop
    {
        public int[] ArmorIncrease { get; set; }
        public int Armor_Base { get; set; }
        public int Armor_PerLevel { get; set; }
        public int[] Ascension_Armor { get; set; }
        public int[] Ascension_Attack { get; set; }
        public int[] Ascension_Health { get; set; }
        public int[] AttackIncrease { get; set; }
        public int Attack_Base { get; set; }
        public int Attack_PerLevel { get; set; }
        public string Description { get; set; }
        public int DropChance { get; set; }
        public string FileBase { get; set; }
        public int GoldToRecruit { get; set; }
        public int[] HealthIncrease { get; set; }
        public int Health_Base { get; set; }
        public int Health_PerLevel { get; set; }
        public int Id { get; set; }
        public Manacolors3 ManaColors { get; set; }
        public int MaterialIdToRecruit { get; set; }
        public int MaterialsToRecruit { get; set; }
        public string Name { get; set; }
        public int PortraitOffsetX { get; set; }
        public int PortraitOffsetY { get; set; }
        public string PrimaryColor { get; set; }
        public string ReferenceName { get; set; }
        public string SoundCastSpell { get; set; }
        public string SoundDeath { get; set; }
        public string SoundSelection { get; set; }
        public int SpellId { get; set; }
        public int[] SpellPowerIncrease { get; set; }
        public int SpellPower_Base { get; set; }
        public int SpellPower_PerLevel { get; set; }
        public int TimeToRecruit { get; set; }
        public string[] Traits { get; set; }
        public string TroopRarity { get; set; }
        public string TroopType { get; set; }
    }
}