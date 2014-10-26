using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SC.Service.Presentation.Startup))]
namespace SC.Service.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
