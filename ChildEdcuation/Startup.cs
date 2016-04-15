using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChildEdcuation.Startup))]
namespace ChildEdcuation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
