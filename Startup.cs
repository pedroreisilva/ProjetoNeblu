using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestaoArtigos.Startup))]
namespace GestaoArtigos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
