using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Basistraining.Ib.WebApp.Startup))]
namespace Basistraining.Ib.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
