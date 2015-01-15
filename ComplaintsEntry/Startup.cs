using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComplaintsEntry.Startup))]
namespace ComplaintsEntry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
