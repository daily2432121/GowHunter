using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Fiddler;
using static Fiddler.FiddlerApplication;

namespace GoWHunter
{
    public class LiteFiddlerApp
    {
        private string _cert;
        private string _key;

        public void Listen()
        {
            //App.OnNotification += AppOnOnNotification;
            BeforeResponse += App_BeforeResponse;
            BeforeRequest += App_BeforeRequest;
            InstallCertificate();
            Prefs.SetBoolPref("fiddler.echoservice.enabled", true);
            Startup(8887, FiddlerCoreStartupFlags.Default);
            

        }

        public bool IsStarted => IsStarted();

        public bool IsClosing => isClosing;


        void App_BeforeRequest(Session oSession)
        {
            //oSession.bBufferResponse = true;
            Monitor.Enter(oSession);
            var regex = new Regex(@"""FinalGems"":\[\[.*\]\],");
            var callFunctionUrl = "gemsofwar.parseapp.com/call_function";
            var keyword = "submit_loot";
            string hackString =
                @"""FinalGems"":[[7,7,7,7,7,7,7,7],[7,7,7,7,7,7,7,7],[7,7,7,7,7,7,7,7],[7,7,7,7,7,7,7,7],[7,7,7,7,7,7,7,7],[7,7,7,7,7,7,7,7],[7,7,7,7,7,7,7,7],[7,7,7,7,7,7,7,7]],";
            if (oSession.uriContains(callFunctionUrl))
            {
                string body = Encoding.UTF8.GetString(oSession.requestBodyBytes);
                if (!body.Contains(keyword) || body.Contains(hackString)) { return; }
                string newBody = regex.Replace(body, hackString);
                oSession.utilSetRequestBody(newBody);
            }
            Monitor.Exit(oSession);
        }


        public void Stop()
        {
            BeforeResponse -= App_BeforeResponse;
            if (IsStarted)
                try
                {
                    Shutdown();
                    Thread.Sleep(500);
                }
                catch
                {
                    oProxy.Detach();
                }
        }

        private void App_BeforeResponse(Session oSession)
        {

        }

        private void AppOnOnNotification(object sender, NotificationEventArgs notificationEventArgs)
        {
            throw new NotImplementedException();
        }


        public bool InstallCertificate()
        {
            if (!CertMaker.rootCertExists())
            {
                if (!CertMaker.createRootCert())
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Certificate is created.");
                }
            }
            X509Store certStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.ReadWrite);
            try
            {
                certStore.Add(CertMaker.GetRootCertificate());
            }
            finally
            {
                certStore.Close();
            }
            return true;
        }

        public bool UninstallCertificate()
        {
            if (CertMaker.rootCertExists())
            {
                if (!CertMaker.removeFiddlerGeneratedCerts(true))
                    return false;
            }

            _cert = null;
            _key = null;
            return true;
        }
    }
}
