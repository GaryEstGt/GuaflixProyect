using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Guaflix.Startup))]
namespace Guaflix
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
