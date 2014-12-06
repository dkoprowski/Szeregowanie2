using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SzeregowanieProjekt2.Startup))]
namespace SzeregowanieProjekt2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
