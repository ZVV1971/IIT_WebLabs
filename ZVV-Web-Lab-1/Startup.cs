using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZVV_Web_Lab_1.Startup))]

namespace ZVV_Web_Lab_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}