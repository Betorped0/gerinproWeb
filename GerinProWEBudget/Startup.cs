using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GerinProWEBudget.Startup))]
namespace GerinProWEBudget
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
