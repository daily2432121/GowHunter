using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWHunter.World.JSONModels
{
    public class LoginResult
    {
        public List<PChest> pChests { get; set; }
    }

    public class PChest
    {
        public int Cost { get; set; }
        public List<Reward> Rewards { get; set; }
        public string Type { get; set; }
        public int? EndTime { get; set; }
        public int? StartTime { get; set; }
    }

    public class Reward
    {
        public double Chance { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public string Type { get; set; }
        public List<int> Included { get; set; }
        public List<double> RarityChance { get; set; }
    }

    
}
