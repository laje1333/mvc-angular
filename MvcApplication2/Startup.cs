using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcApplication2.Startup))]
namespace MvcApplication2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
