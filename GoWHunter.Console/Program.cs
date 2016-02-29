using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Con = System.Console;
namespace GoWHunter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!IsUserAdministrator())
            {
                Con.WriteLine("Please start as Admin");
                Con.ReadKey();
                return;
            }

            LiteFiddlerApp app = new LiteFiddlerApp();
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
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            finally
            {
                if (user != null)
                    user.Dispose();
            }
            return isAdmin;
        }
    }

}
