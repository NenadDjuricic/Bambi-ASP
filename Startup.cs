using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestDataBase.Startup))]
namespace TestDataBase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
