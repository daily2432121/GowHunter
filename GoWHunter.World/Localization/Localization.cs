using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoWHunter.World.Localization
{
    public class LocalizationParser
    {
        public Runes Runes { get; set; }
        public Dictionary<string, RuneItem> RuneDict { get; private set; }
        public Dictionary<int, int> RarityCountDict { get; set; }

        public LocalizationParser(string fileName)
        {
            LoadFromFile(fileName);
        }

        public void LoadFromFile(string fileName)
        {

            var result = JsonConvert.DeserializeObject<Localization>(File.ReadAllText(fileName));
            var runes = result.Runes;
            RuneDict = runes.RuneItems.ToDictionary(r => r.Tag);
            RarityCountDict = runes.RuneItems.GroupBy(r => r.Rarity).ToDictionary(r => r.Key, l => l.Count());

        }

        public int GetRuneCountInSameRarity(int rarity, List<int> sourceList)
        {
            return sourceList.Select(GetTune).Count(r => r.Rarity == rarity);
            
        }

        public RuneItem GetTune(int id)
        {
            var key = string.Format("[RUNE{0:00}_NAME]", id);
            return RuneDict[key];
        }

    }
    public class Localization
    {
        public Runes Runes { get; set; }

    }
}