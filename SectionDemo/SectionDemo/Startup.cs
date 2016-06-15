using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SectionDemo.Startup))]
namespace SectionDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
