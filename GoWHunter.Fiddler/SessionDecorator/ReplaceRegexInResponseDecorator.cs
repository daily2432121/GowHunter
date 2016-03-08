using System.Collections.Generic;

namespace GoWHunter.Fiddler.SessionDecorator
{
    public class ReplaceRegexInResponseDecorator : ReplaceDecoratorBase
    {
        public ReplaceRegexInResponseDecorator(Dictionary<string, string> dict) : base(dict, ReplaceAction.ReplaceRegexInResponse)
        {
        }
    }
}