using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WALimaRoomsV3._5.Startup))]
namespace WALimaRoomsV3._5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
