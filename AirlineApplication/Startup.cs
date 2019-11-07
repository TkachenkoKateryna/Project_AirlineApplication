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
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {

               var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Kate Tkachenko";
                user.Email = "katetkacenko@gmail.com";

                string userPWD = "Jjobva2407";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Dispatcher";
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
        }
    }
}
