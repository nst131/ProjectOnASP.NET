using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace InfastructureYandexMusic.Validators
{
    class CustomPasswordValidator : IIdentityValidator<string>
    {
        public int RequiredLength { get; set; } 
        public CustomPasswordValidator(int length)
        {
            RequiredLength = length;
        }

        public Task<IdentityResult> ValidateAsync(string item)
        {
            if (String.IsNullOrEmpty(item) || item.Length < RequiredLength)
            {
                return Task.FromResult(IdentityResult.Failed(
                                String.Format("Минимальная длина пароля равна {0}", RequiredLength)));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
