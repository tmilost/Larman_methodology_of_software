using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoPlac0.Startup))]
namespace AutoPlac0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
