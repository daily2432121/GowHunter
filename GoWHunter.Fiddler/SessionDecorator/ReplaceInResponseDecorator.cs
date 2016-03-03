using System.Collections.Generic;

namespace GoWHunter.Fiddler.SessionDecorator
{
    public class ReplaceInResponseDecorator : ReplaceDecoratorBase
    {
        public ReplaceInResponseDecorator(Dictionary<string, string> dict) : base(dict, ReplaceAction.ReplaceInResponse)
        {
        }
    }
}