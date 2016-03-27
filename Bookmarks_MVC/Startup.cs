using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bookmarks_MVC.Startup))]
namespace Bookmarks_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
