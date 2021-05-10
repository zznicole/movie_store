using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(movie_store.Startup))]
namespace movie_store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
