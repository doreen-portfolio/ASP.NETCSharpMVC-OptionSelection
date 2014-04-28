using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OptionSelection.Startup))]
namespace OptionSelection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
