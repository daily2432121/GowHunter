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

    public class PvPDecorator : ReplaceTagsInRequestDecorator
    {

        public PvPDecorator(string userName, string password,  string opponentName, long clientUnixTicks = 0)
        {
            if (clientUnixTicks == 0)
            {
                clientUnixTicks = GetTicks();
            }
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"UserName", userName},
                {"Password", password},
                {"ClientUnixTicks", clientUnixTicks.ToString()},
                {"OpponentName", opponentName}
            };
            Dict = dict;
        }
        private long GetTicks()
        {
            return (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }


    public class GoWTHDecorator : ReplaceTagsInRequestDecorator
    {
        public GoWTHDecorator(string userName, string password, int runes, long clientUnixTicks = 0)
        {
            if (clientUnixTicks == 0)
            {
                clientUnixTicks = GetTicks();
            }
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"UserName", userName},
                {"Password", password},
                {"ClientUnixTicks", clientUnixTicks.ToString()},
                {"RunesGained", runes.ToString()}
            };
            Dict = dict;
        }
        private long GetTicks()
        {
            return (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}