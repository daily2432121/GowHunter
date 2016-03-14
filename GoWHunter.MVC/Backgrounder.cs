using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using GoWHunter.World;
using GoWHunter.World.Localization;
using RestSharp;

namespace GoWHunter.MVC
{

    public class Backgrounder
    {
        private static Backgrounder _instance;
        private static string _worldFilePath;
        private static string _runeFilePath;

        public static Backgrounder Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Backgrounder();
                    _instance.Load();
                    ThreadPool.QueueUserWorkItem(AutoRefresh);
                }
                return _instance;
            }
            
            
        }

        private static object _lock = new object();
        public static DateTime LastUpdated { get; private set; } 
        public List<dynamic> CalculationResult { get; private set; }

        private Backgrounder()
        {
        }
        
        private static void AutoRefresh(object stateInfo)
        {
            while (true)
            {
                lock (_lock)
                {
                    if (DateTime.Now - LastUpdated >= TimeSpan.FromSeconds(300))
                    {
                        Backgrounder newData = new Backgrounder();
                        newData.Load();

                        lock (_lock)
                        {
                            if (newData.CalculationResult != null)
                            {
                                _instance = newData;
                            }
                        }
                    }
                }
                Thread.Sleep(TimeSpan.FromSeconds(300));
            }
        }

        private void Load()
        {
            try
            {
                var body = GetLoginBody("QqZ5d1kWkz1D", "GQWLAycpxwFo");
                if (_worldFilePath == null)
                {
                    _worldFilePath = HttpContext.Current.Server.MapPath(@"~\Jsons\World.json");
                }
                if (_runeFilePath == null)
                {
                    _runeFilePath = HttpContext.Current.Server.MapPath(@"~\Jsons\Runes.json");
                }
                WorldParser world = new WorldParser(_worldFilePath);

                LoginResultParser loginResult = new LoginResultParser(body, true);
                LocalizationParser dict = new LocalizationParser(_runeFilePath);
                DropRateCalculator calc = new DropRateCalculator();
                var result = calc.Calculate(loginResult.pChests, world, dict);
                List<dynamic> output = new List<dynamic>();
                foreach (var r in result)
                {
                    var key = r.Key.Split('|');
                    int chestNumber = int.Parse(key[0]);
                    string type = key[1];
                    string name = key[2];
                    var value = r.Value;
                    dynamic e = new ExpandoObject();
                    e.ChestNumber = chestNumber;
                    e.Chest = Enum.GetName(typeof(ChestType), chestNumber);
                    e.Name = name;
                    e.Type = type;
                    e.Expectation = value.ExpectationInAll;
                    e.Chance = value.ChanceInAll;
                    e.Stars = value.Stars;
                    output.Add(e);
                }
                CalculationResult =  output;
                LastUpdated = DateTime.Now;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                CalculationResult = null;
            }
            
        }

        private static long GetTicks()
        {
            return (long)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        private string GetLoginBody(string userName, string pwd)
        {
            long ticks = GetTicks();
            var client = new RestClient("http://gemsofwar.parseapp.com");
            var request = new RestRequest("call_function", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                clientTime = ticks,
                detailedInfoMode = 1,
                facebook = 0,
                fullScreen = 1,
                functionName = "login_user",
                googleplay = 1,
                googleplus = 0,
                hint = 2,
                music = 1,
                password = pwd,
                username = userName,
                savetime = ticks - 10,
                slowMode = 0,
                sound = 1
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return content;
        }
    }
}