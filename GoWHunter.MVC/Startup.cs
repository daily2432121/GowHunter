using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoWHunter.MVC.Startup))]
namespace GoWHunter.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
