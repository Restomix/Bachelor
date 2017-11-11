using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bacheler_work.Startup))]
namespace Bacheler_work
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
