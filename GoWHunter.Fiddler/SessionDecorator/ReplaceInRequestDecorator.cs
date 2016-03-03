using System;
using System.Collections.Generic;

namespace GoWHunter.Fiddler.SessionDecorator
{
    public class ReplaceInRequestDecorator : ReplaceDecoratorBase
    {
        public ReplaceInRequestDecorator(Dictionary<string, string> dict) : base(dict, ReplaceAction.ReplaceInRequest)
        {
        }

    }

    public class GoWTHDecorator : ReplaceTagsInRequestDecorator
    {
        public GoWTHDecorator(string userName, string password, long clientUnixTicks = 0)
        {
            if (clientUnixTicks == 0)
            {
                clientUnixTicks = GetTicks();
            }
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"UserName", userName},
                {"Password", password},
                {"ClientUnixTicks", clientUnixTicks.ToString()}
            };
            Dict = dict;
        }
        private long GetTicks()
        {
            return (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}