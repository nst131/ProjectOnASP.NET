using System;
using Autofac;
using FluentValidation;

namespace PresentationYandexMusic.App_Start
{
    internal class AutofacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IContainer container;

        public AutofacValidatorFactory(IContainer container)
        {
            this.container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator = container.ResolveOptionalKeyed<IValidator>(validatorType);
            return validator;
        }
    }
}