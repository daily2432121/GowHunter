using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoWHunter.World.JSONModels;
using Newtonsoft.Json;

namespace GoWHunter.World
{
    public class WorldParser
    {
        public Rootobject Obj { get; private set; } = new Rootobject();
        public Dictionary<int, Troop> TroopsDictById { get; private set; } =  new Dictionary<int, Troop>();
        public Dictionary<string, List<Troop>> TroopsDictByRarity { get; private set; } = new Dictionary<string, List<Troop>>();
        public Dictionary<string, int> TroopsCountDictByRarity { get; private set; } = new Dictionary<string, int>();

        public WorldParser(string worldFile)
        {
            ParseFromFile(worldFile);
            Init(Obj);
        }
        public void ParseFromFile(string worldFile)
        {
            Obj = JsonConvert.DeserializeObject<Rootobject>(File.ReadAllText(worldFile));
        }

        public void Init(Rootobject obj)
        {
            TroopsDictById = obj.Troops.ToDictionary(t => t.Id);
            TroopsDictByRarity = obj.Troops.GroupBy(t=>t.TroopRarity).ToDictionary(t => t.Key, l=>l.ToList());
            TroopsCountDictByRarity = obj.Troops.GroupBy(t => t.TroopRarity).ToDictionary(t => t.Key, c => c.Count());
        }

        public int GetCountInSameRarity(string rarity, List<int> troopIds)
        {
            //return sourceList.Select(GetTune).Count(r => r.Rarity == rarity);
            return troopIds.Select(t => TroopsDictById[t]).Count(r => r.TroopRarity == rarity);
        }
    }
}
