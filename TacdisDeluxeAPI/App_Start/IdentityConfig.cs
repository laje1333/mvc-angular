using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using TacdisDeluxeAPI.Models;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Infrastructure;
using TacdisDeluxeAPI.Providers;
using System;
using System.Web.Http;

namespace TacdisDeluxeAPI
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class IdentityConfig
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new IdentityContext());
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
                new RoleManager<AppRole>(
                    new RoleStore<AppRole>(context.Get<IdentityContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<AppUserManager, AppUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager, DefaultAuthenticationTypes.ApplicationCookie))
                }
            });

            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider("bubbel"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);  
        }



        //public IdentityConfig(IUserStore<ApplicationUser> store)
        //    : base(store)
        //{
        //}

        //public static IdentityConfig Create(IdentityFactoryOptions<IdentityConfig> options, IOwinContext context)
        //{
        //    var manager = new IdentityConfig(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
        //    // Configure validation logic for usernames
        //    manager.UserValidator = new UserValidator<ApplicationUser>(manager)
        //    {
        //        AllowOnlyAlphanumericUserNames = false,
        //        RequireUniqueEmail = true
        //    };
        //    // Configure validation logic for passwords
        //    manager.PasswordValidator = new PasswordValidator
        //    {
        //        RequiredLength = 6,
        //        RequireNonLetterOrDigit = true,
        //        RequireDigit = true,
        //        RequireLowercase = true,
        //        RequireUppercase = true,
        //    };
        //    var dataProtectionProvider = options.DataProtectionProvider;
        //    if (dataProtectionProvider != null)
        //    {
        //        manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
        //    }
        //    return manager;
        //}


    }
}
