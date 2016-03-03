using Fiddler;
using GoWHunter.Fiddler.SessionTamper;

namespace GoWHunter.Fiddler
{
    public class TamperSender
    {
        private ISessionTamper _tamper;
        public void SendRequest(Session session)
        {
            FiddlerApplication.oProxy.SendRequest(session.oRequest.headers, session.requestBodyBytes, null);
        }

        private Session[] GetSessionsFromSaz(string fileName)
        {
            
            var exePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(exePath)+ @"\Sazs\"+fileName;
            return Utilities.ReadSessionArchive(path, true);
            
        }

        public void ReadTampAndSend(string filePath)
        {
            Session session = GetSessionsFromSaz(filePath)[0];
            TampAndSend(session);
        }

        public void TampAndSend(Session session)
        {
            _tamper.Tamp(session);
            SendRequest(session);
        }
        public TamperSender(ISessionTamper tamper)
        {
            _tamper = tamper;
        }

    }
}