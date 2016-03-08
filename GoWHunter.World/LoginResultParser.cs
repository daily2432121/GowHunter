using System.Collections.Generic;
using System.IO;
using GoWHunter.World.JSONModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoWHunter.World
{
    public class LoginResultParser
    {
        public LoginResult Obj { get; private set; } = new LoginResult();
        public List<PChest> pChests { get; private set; }
        public LoginResultParser(string str, bool isRawJson)
        {
            string text;
            if (isRawJson)
            {
                text = str;
            }
            else
            {
                text = File.ReadAllText(str);
            }
            dynamic json = JValue.Parse(text);
            var pChests = json.result.pChests;
            ParseFromFile(pChests.ToString());
        }

        private LoginResultParser(string rawJson)
        {
            dynamic json = JValue.Parse(rawJson);
            var pChests = json.result.pChests;
            ParseFromFile(pChests.ToString());
        }
        public void ParseFromFile(string rawJson)
        {
            pChests= JsonConvert.DeserializeObject<List<PChest>>(rawJson);
        }
    }
}