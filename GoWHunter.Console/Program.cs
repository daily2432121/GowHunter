using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using Fiddler;
using GoWHunter.Fiddler;
using GoWHunter.Fiddler.Receipe;
using GoWHunter.Fiddler.SessionDecorator;
using GoWHunter.Fiddler.SessionTamper;
using GoWHunter.World;
using GoWHunter.World.Localization;
using RestSharp;
using Con = System.Console;

namespace GoWHunter.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TestRecipe();

            //var body = GetLoginBody("QqZ5d1kWkz1D", "GQWLAycpxwFo");

        }

        private static void TestRecipe()
        {
            FiddlerApplication.Startup(8666, FiddlerCoreStartupFlags.Default);
            FiddlerApplication.oSAZProvider = new DNZSAZProvider();
            //GoWTHRecipe recipe = new GoWTHRecipe("QqZ5d1kWkz1D", "GQWLAycpxwFo");
            GoWTHRecipe recipe = new GoWTHRecipe("AnzPk4MLuY29", "KDkuCjLMVLXC");
            //GoWTHRecipe recipe = new GoWTHRecipe("9jPPy3DWqZgt", "19yf5dsJ2FQS");
            recipe.Cook(50, 20, 50);
            FiddlerApplication.Shutdown();
        }
        private static void TestListen()
        {
            if (!IsUserAdministrator())
            {
                Con.WriteLine("Please start as Admin");
                Con.ReadKey();
                return;
            }

            var app = new LiteFiddlerApp(ReplaceConfig.GenerateFromJson("HackList.json"),
                int.Parse(ConfigurationManager.AppSettings["FiddlerPort"]));
            app.Listen();
            Con.ReadKey();
            app.Stop();
        }

        private static void TestCalculate()
        {
            WorldParser world = new WorldParser(@"Jsons\World.json");
            LoginResultParser loginResult = new LoginResultParser(@"Jsons\LoginResult.json",false);
            LocalizationParser dict = new LocalizationParser(@"Jsons\Runes.json");
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
                e.Name = name;
                e.Type = type;
                e.Expectation = value.ExpectationInAll;
                e.Chance = value.ChanceInAll;
                e.Stars = value.Stars;
                output.Add(e);
            }
            var arr = output.Select(e => $"{e.ChestNumber},{e.Name},{e.Type},{e.Chance},{e.Expectation},{e.Stars}").ToArray();
            var text = string.Join(Environment.NewLine, arr);
            text = "ChestNumber,Name,Type,Chance,Expectation,Stars" + Environment.NewLine + text;
            File.WriteAllText(@"c:\temp\output.csv", text);
        }
        private static long GetTicks()
        {
            return (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }


        static string GetLoginBody(string userName, string pwd)
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

        public static bool IsUserAdministrator()
        {
            //bool value to hold our return value
            bool isAdmin;
            WindowsIdentity user = null;
            try
            {
                //get the currently logged in user
                user = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
            {
                isAdmin = false;
            }
            finally
            {
                user?.Dispose();
            }
            return isAdmin;
        }
    }
}