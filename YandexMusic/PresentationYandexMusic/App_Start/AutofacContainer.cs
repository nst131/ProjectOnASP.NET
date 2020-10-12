using Autofac;
using Autofac.Integration.Mvc;
using DomainYandexMusic.Repositories;
using DomainYandexMusic.Services.Interfaces;
using DomainYandexMusic.UnitOfWork;
using FluentValidation;
using FluentValidation.Mvc;
using InfastructureYandexMusic.Context;
using InfastructureYandexMusic.Repositories;
using InfastructureYandexMusic.UnitOfWork;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.Validation;
using PresentationYandexMusic.Services.Interfaces;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace PresentationYandexMusic.App_Start
{
    public static class AutofacContainer
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<CoreDbContext>().As<ICoreDbContext>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(IBasePresentationService).Assembly)
                .Where(t => typeof(IBasePresentationService).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(IAdminBasePresentationService).Assembly)
                .Where(t => typeof(IAdminBasePresentationService).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(IBaseDomainService).Assembly)
               .Where(t => typeof(IBaseDomainService).IsAssignableFrom(t))
               .AsImplementedInterfaces()
               .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
                .AsClosedTypesOf(typeof(IBaseRepository<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            AssemblyScanner.FindValidatorsInAssemblyContaining<AdminValidationOfGenreCreate>()
                    .ForEach(result =>
                    {
                        builder.RegisterType(result.ValidatorType)
                        .Keyed<IValidator>(result.InterfaceType)
                        .As<IValidator>();
                    }); // Validation Genre

            AssemblyScanner.FindValidatorsInAssemblyContaining<AdminValidationOfSingerCreate>()
                    .ForEach(result =>
                    {
                        builder.RegisterType(result.ValidatorType)
                        .Keyed<IValidator>(result.InterfaceType)
                        .As<IValidator>();
                    }); // Validation Singer


            AssemblyScanner.FindValidatorsInAssemblyContaining<AdminValidationOfAlbumCreate>()
                    .ForEach(result =>
                    {
                        builder.RegisterType(result.ValidatorType)
                        .Keyed<IValidator>(result.InterfaceType)
                        .As<IValidator>();
                    }); // Validation Album


            AssemblyScanner.FindValidatorsInAssemblyContaining<AdminValidationOfPlaylistCreate>()
                    .ForEach(result =>
                    {
                        builder.RegisterType(result.ValidatorType)
                        .Keyed<IValidator>(result.InterfaceType)
                        .As<IValidator>();
                    }); // Validation Playlist

            builder.RegisterFilterProvider();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            FluentValidationModelValidatorProvider.Configure(config =>
            {
                config.ValidatorFactory = new AutofacValidatorFactory(container);
            }); // Validation use ValidatorFactory
        }
    }
}