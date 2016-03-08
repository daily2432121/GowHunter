namespace GoWHunter.World.JSONModels
{
    public class Weapon
    {
        public string FileBase { get; set; }
        public int Id { get; set; }
        public Manacolors4 ManaColors { get; set; }
        public int MasteryRequirement { get; set; }
        public string Name { get; set; }
        public string ReferenceName { get; set; }
        public int SpellId { get; set; }
        public string WeaponRarity { get; set; }
    }
}