using System;
using System.Configuration;
using System.Security.Principal;
using Fiddler;
using GoWHunter.Fiddler;
using GoWHunter.Fiddler.Receipe;
using GoWHunter.Fiddler.SessionDecorator;
using GoWHunter.Fiddler.SessionTamper;
using Con = System.Console;

namespace GoWHunter.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FiddlerApplication.Startup(8666, FiddlerCoreStartupFlags.Default);
            FiddlerApplication.oSAZProvider = new DNZSAZProvider();
            GoWTHRecipe recipe = new GoWTHRecipe("QqZ5d1kWkz1D", "GQWLAycpxwFo");
            recipe.Cook(50, 100,50);
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