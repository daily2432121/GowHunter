namespace GoWHunter.World.JSONModels
{
    public class Spell
    {
        public int Cost { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int OverrideAI { get; set; }
        public string Randomize { get; set; }
        public Spellstep[] SpellSteps { get; set; }
        public string Target { get; set; }
    }
}