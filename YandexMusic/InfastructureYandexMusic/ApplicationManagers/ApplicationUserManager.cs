using DomainYandexMusic.Entities;
using InfastructureYandexMusic.Context;
using InfastructureYandexMusic.Services;
using InfastructureYandexMusic.Validators;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;

namespace InfastructureYandexMusic.ApplicationManagers
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
            UserValidator = new CustomUserValidator(this);
            PasswordValidator = new CustomPasswordValidator(4);

            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            EmailService = new EmailService();
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<CoreDbContext>()));

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity")) 
                    { 
                        TokenLifespan = TimeSpan.FromMinutes(5) 
                    };
            }

            return manager;
        }
    }
}
