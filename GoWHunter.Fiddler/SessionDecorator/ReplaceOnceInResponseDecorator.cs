using System.Collections.Generic;

namespace GoWHunter.Fiddler.SessionDecorator
{
    public class ReplaceOnceInResponseDecorator : ReplaceDecoratorBase
    {
        public ReplaceOnceInResponseDecorator(Dictionary<string, string> dict) : base(dict, ReplaceAction.ReplaceOnceInResponse)
        {
        }
    }
}