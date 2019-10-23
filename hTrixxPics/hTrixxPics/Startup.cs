using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hTrixxPics.Startup))]
namespace hTrixxPics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
