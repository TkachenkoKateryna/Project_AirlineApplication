using Microsoft.Owin;
using Owin;
using AirlineApplication.Core.Models;
using AirlineApplication.Persistence;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(AirlineApplication.Startup))]
namespace AirlineApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
