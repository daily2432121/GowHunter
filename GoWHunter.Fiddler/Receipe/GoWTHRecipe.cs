using System;
using GoWHunter.Fiddler.SessionDecorator;

namespace GoWHunter.Fiddler.Receipe
{
    public class GoWTHRecipe : Recipe
    {
        private string _userName;
        private string _password;

        public override string Name
        {
            get
            {
                return "Treasure Hunt";
            }

            
        }

        public GoWTHRecipe(string userName, string password, int runes)
        {
            //AddStep(() =>
            //{
            //    SessionTamper.SessionTamper tamper = new SessionTamper.SessionTamper(new GoWTHDecorator(userName, password));
            //    TamperSender sender = new TamperSender(tamper);
            //    sender.ReadTampAndSend("buy_glory.saz");
            //});

            //AddStep(() =>
            //{
            //    SessionTamper.SessionTamper tamper = new SessionTamper.SessionTamper(new GoWTHDecorator(userName, password));
            //    TamperSender sender = new TamperSender(tamper);
            //    sender.ReadTampAndSend("start_loot.saz");
            //});

            AddStep(() =>
            {
                SessionTamper.SessionTamper tamper = new SessionTamper.SessionTamper(new GoWTHDecorator(userName, password, runes));
                TamperSender sender = new TamperSender(tamper);
                sender.ReadTampAndSend("submit_loot.saz");
            });
        }

        
    }

    public class PvPRecipe : Recipe
    {
        public PvPRecipe(string userName, string password, string opponentName)
        {
            AddStep(() =>
            {
                SessionTamper.SessionTamper tamper = new SessionTamper.SessionTamper(new PvPDecorator(userName, password, opponentName));
                TamperSender sender = new TamperSender(tamper);
                sender.ReadTampAndSend("pvp.saz");
            });
        }

        public override string Name
        {
            get
            {
                return "PVP";
            }
        }
    }
}