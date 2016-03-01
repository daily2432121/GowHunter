using System;
using System.Configuration;
using System.Security.Principal;
using Con = System.Console;

namespace GoWHunter.Console
{
    internal class Program
    {
        private static void Main(string[] args)
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