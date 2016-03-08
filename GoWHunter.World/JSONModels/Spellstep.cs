namespace GoWHunter.World.JSONModels
{
    public class Spellstep
    {
        public int Amount { get; set; }
        public string BoardTarget { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string GemModifier { get; set; }
        public float GemModifierMultiplier { get; set; }
        public int PercentageChance { get; set; }
        public bool Primarypower { get; set; }
        public float SpellPowerMultiplier { get; set; }
        public int StatusAmount { get; set; }
        public string StatusModifier { get; set; }
        public string Target { get; set; }
        public bool TrueDamage { get; set; }
        public string Type { get; set; }
        public bool UseCounterForAmount { get; set; }
    }
}