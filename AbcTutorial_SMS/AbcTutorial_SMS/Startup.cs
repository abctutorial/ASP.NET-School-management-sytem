using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AbcTutorial_SMS.Startup))]
namespace AbcTutorial_SMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
