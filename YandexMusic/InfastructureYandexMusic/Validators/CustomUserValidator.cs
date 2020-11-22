using DomainYandexMusic.Entities;
using InfastructureYandexMusic.ApplicationManagers;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InfastructureYandexMusic.Validators
{
    public class CustomUserValidator : UserValidator<ApplicationUser>
    {
        public CustomUserValidator(ApplicationUserManager mgr)
            : base(mgr)
        {
            AllowOnlyAlphanumericUserNames = false;
            RequireUniqueEmail = true;
        }

        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);
            if (user.Email.ToLower().EndsWith("@spam.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Данный домен находится в спам-базе. Выберите другой почтовый сервис");
                result = new IdentityResult(errors);
            }

            Regex regex = new Regex(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$"); 
            if(!regex.IsMatch(user.Email))
            {
                var errors = result.Errors.ToList();
                errors.Add("Введите существующий email");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}
