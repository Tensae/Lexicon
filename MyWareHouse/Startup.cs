using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWareHouse.Startup))]
namespace MyWareHouse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
