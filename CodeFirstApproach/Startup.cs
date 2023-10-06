using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using CodeFirstApproach.Identity;
using System.Runtime.Remoting.Contexts;

[assembly: OwinStartup(typeof(CodeFirstApproach.Startup))]

namespace CodeFirstApproach
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/account/login")
            });
            this.CreateRoleAndUsers();
        }

        public void CreateRoleAndUsers()
        {
            var appDbContext = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(appDbContext));
            var appUserStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(appUserStore);

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                if (userManager.FindByName("admin") == null)
                {
                    var user = new ApplicationUser();
                    user.UserName = "admin";
                    user.Email = "admin@email.com";
                    string userPassword = "admin123";
                    var checkUser = userManager.Create(user, userPassword);
                    if (checkUser.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "Admin");
                    }
                }
            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

                if (userManager.FindByName("manager") == null)
                {
                    var user = new ApplicationUser();
                    user.UserName = "manager";
                    user.Email = "manager@email.com";
                    string userPassword = "manager123";
                    var checkUser = userManager.Create(user, userPassword);
                    if (checkUser.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "Manager");
                    }
                }
            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
        }
    }
}
