using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(najjar.biz.Startup))]
namespace najjar.biz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
