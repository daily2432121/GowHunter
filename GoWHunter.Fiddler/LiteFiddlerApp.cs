using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Fiddler;
using static Fiddler.FiddlerApplication;

namespace GoWHunter.Fiddler
{
    public class LiteFiddlerApp
    {
        private string _cert;
        private string _key;
        private readonly int _port;
        private readonly List<ReplaceSet> _replaceSets;
        private List<TamperSender> _tamperSenders = new List<TamperSender>();

        public void AddTamperSender(TamperSender sender)
        {
            _tamperSenders.Add(sender);
        }

        public LiteFiddlerApp(ReplaceConfig config, int port)
        {
            _replaceSets = config.ReplaceSets;
            _port = port;
        }

        public bool IsStarted => IsStarted();

        public bool IsClosing => isClosing;

        public void Listen()
        {
            
            BeforeResponse += App_BeforeResponse;
            BeforeRequest += App_BeforeRequest;
            InstallCertificate();
            Prefs.SetBoolPref("fiddler.echoservice.enabled", true);
            Startup(_port, FiddlerCoreStartupFlags.Default);
        }


        private void App_BeforeRequest(Session oSession)
        {
            var body = Encoding.UTF8.GetString(oSession.requestBodyBytes);
            foreach (var set in _replaceSets)
            {
                var callFunctionUrl = set.Url;
                foreach (var item in set.ReplaceItems)
                {
                    var hackString = item.ReplaceWith;
                    var regex = item.RegEx;
                    var keyword = item.Keyword;
                    if (!oSession.uriContains(callFunctionUrl)) continue;
                    if (!body.Contains(keyword) || body.Contains(hackString))
                    {
                        return;
                    }
                    body = regex.Replace(body, hackString);
                }
            }
            oSession.utilSetRequestBody(body);
        }


        public void Stop()
        {
            BeforeResponse -= App_BeforeResponse;
            if (!IsStarted) return;
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

        public bool InstallCertificate()
        {
            if (!CertMaker.rootCertExists())
            {
                if (!CertMaker.createRootCert())
                {
                    return false;
                }
                Console.WriteLine("Certificate is created.");
            }
            var certStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
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


        private void ImportSessions(List<Session> oAllSessions)
        {
            TranscoderTuple oImporter = oTranscoders.GetImporter("SAZ");
            if (null != oImporter)
            {
                Dictionary<string, object> dictOptions = new Dictionary<string, object>();
                dictOptions.Add("Filename", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ToLoad.saz");

                Session[] oLoaded = DoImport("SAZ", false, dictOptions, null);

                if ((oLoaded != null) && (oLoaded.Length > 0))
                {
                    oAllSessions.AddRange(oLoaded);
                    Console.WriteLine("Loaded: " + oLoaded.Length + " sessions.");
                }
            }
        }
    }
}