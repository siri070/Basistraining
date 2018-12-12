using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Basistraining.Ib.Web.Startup))]
namespace Basistraining.Ib.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
