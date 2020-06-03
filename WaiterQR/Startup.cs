using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WaiterQR.Startup))]
namespace WaiterQR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
