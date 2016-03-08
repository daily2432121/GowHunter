using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GoWHunter.Fiddler
{
    public class ReplaceConfig
    {
        public string ConfigName { get; set; }
        public List<ReplaceSet> ReplaceSets { get; set; }

        public static ReplaceConfig GenerateFromJson(string fileName)
        {
            return JsonConvert.DeserializeObject<ReplaceConfig>(File.ReadAllText(fileName));
        }
    }
}