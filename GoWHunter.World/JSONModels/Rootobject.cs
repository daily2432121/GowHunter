namespace GoWHunter.World.JSONModels
{
    public class Rootobject
    {
        public Avatarskin[] AvatarSkins { get; set; }
        public Cloud[] Clouds { get; set; }
        public Conversationcharacter[] ConversationCharacters { get; set; }
        public Guildtask[] GuildTasks { get; set; }
        public Heroclass[] HeroClasses { get; set; }
        public Kingdom[] Kingdoms { get; set; }
        public Loottable[] LootTables { get; set; }
        public Material[] Materials { get; set; }
        public Quest[] Quests { get; set; }
        public Spell[] Spells { get; set; }
        public Trait[] Traits { get; set; }
        public Troop[] Troops { get; set; }
        public Weapon[] Weapons { get; set; }
    }
}