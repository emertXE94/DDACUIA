using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DDACUIA.Startup))]
namespace DDACUIA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
