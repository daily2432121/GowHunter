using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoWHunter.World.Localization
{
    public class RuneItem
    {
        public string Tag { get; set; }
        public string Text { get; set; }
        public int Rarity { get; set; }
        
    }

    public class Runes
    {
        public List<RuneItem> RuneItems { get; set; }
    }
}
