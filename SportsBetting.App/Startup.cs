using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportsBetting.App.Startup))]
namespace SportsBetting.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
