using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClickMap.Startup))]
namespace ClickMap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
