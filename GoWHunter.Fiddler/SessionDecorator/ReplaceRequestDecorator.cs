using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GoWHunter.Fiddler.SessionTamper;

namespace GoWHunter.Fiddler.SessionDecorator
{
    public class ReplaceDecoratorBase : ISessionDecorator
    {
        protected Dictionary<string, string> Dict = new Dictionary<string, string>();
        ReplaceAction _replaceAction;
        public ReplaceDecoratorBase(Dictionary<string, string> dict, ReplaceAction replaceAction)
        {
            Dict = dict;
            _replaceAction = replaceAction;
        }

        
        public ReplaceDecoratorBase(ReplaceAction replaceAction)
        {
            _replaceAction = replaceAction;
        }

        protected ReplaceDecoratorBase()
        {
            
        }

        public void UpsertReplaceEntry(string key, string value)
        {
            if (Dict.ContainsKey(key))
            {
                Dict[key] = value;
            }
            else
            {
                Dict.Add(key, value);
            }

        }

        public void Decorate(ISessionTamper temper)
        {
            var original = temper.Tamp;
            temper.Tamp = session =>
            {
                original(session);
                foreach (var p in Dict)
                {
                    var action = RepalceActionFactory.GetReplaceAction(_replaceAction);
                    action(session, p.Key, p.Value);
                }
            };
        }
    }
}
