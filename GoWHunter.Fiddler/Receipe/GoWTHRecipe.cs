using GoWHunter.Fiddler.SessionDecorator;

namespace GoWHunter.Fiddler.Receipe
{
    public class GoWTHRecipe : Recipe
    {
        private string _userName;
        private string _password;
        public GoWTHRecipe(string userName, string password)
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
                SessionTamper.SessionTamper tamper = new SessionTamper.SessionTamper(new GoWTHDecorator(userName, password));
                TamperSender sender = new TamperSender(tamper);
                sender.ReadTampAndSend("submit_loot.saz");
            });
        }

        
    }
}