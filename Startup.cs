using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(The2r.Startup))]
namespace The2r
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
