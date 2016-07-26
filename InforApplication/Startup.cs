using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InforApplication.Startup))]
namespace InforApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
