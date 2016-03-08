namespace GoWHunter.World.JSONModels
{
    public class Heroclass
    {
        public string Abbreviation { get; set; }
        public int[] ArmorIncrease { get; set; }
        public int[] AttackIncrease { get; set; }
        public string[] Augment { get; set; }
        public string[] AugmentName { get; set; }
        public string BonusColor { get; set; }
        public string BonusWeapon { get; set; }
        public int ClassWeaponId { get; set; }
        public string Code { get; set; }
        public int[] HealthIncrease { get; set; }
        public int KingdomId { get; set; }
        public string Name { get; set; }
        public int[] SpellIds { get; set; }
        public string[] Traits { get; set; }
    }
}