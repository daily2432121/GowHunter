using System.Collections.Generic;

namespace GoWHunter.Fiddler.SessionDecorator
{
    public class ReplaceTagsInRequestDecorator : ReplaceDecoratorBase
    {
        public ReplaceTagsInRequestDecorator(Dictionary<string, string> dict) : base(dict, ReplaceAction.ReplaceTagsInRequest)
        {
        }
        public ReplaceTagsInRequestDecorator() : base(ReplaceAction.ReplaceTagsInRequest)
        {
        }
    }
}