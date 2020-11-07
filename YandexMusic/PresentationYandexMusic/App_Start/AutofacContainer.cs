using Autofac;
using Autofac.Integration.Mvc;
using DomainYandexMusic.Repositories;
using DomainYandexMusic.Services;
using DomainYandexMusic.Services.Interfaces;
using DomainYandexMusic.UnitOfWork;
using FluentValidation;
using FluentValidation.Mvc;
using InfastructureYandexMusic.Context;
using InfastructureYandexMusic.Repositories;
using InfastructureYandexMusic.UnitOfWork;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.Validation.Album;
using PresentationYandexMusic.Areas.Admin.Validation.Genre;
using PresentationYandexMusic.Areas.Admin.Validation.Playlist;
using PresentationYandexMusic.Areas.Admin.Validation.Singer;
using PresentationYandexMusic.Areas.Admin.Validation.Track;
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
            builder.RegisterType<CheckFile>().As<ICheckFile>().InstancePerLifetimeScope();

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

            AssemblyScanner.FindValidatorsInAssemblyContaining<AdminValidationOfAlbumCreate>()
                    .ForEach(result =>
                    {
                        builder.RegisterType(result.ValidatorType)
                        .Keyed<IValidator>(result.InterfaceType)
                        .As<IValidator>();
                    }); // Validation CreateAlbum

            AssemblyScanner.FindValidatorsInAssemblyContaining<AdminValidationOfGenreCreate>()
                    .ForEach(result =>
                    {
                        builder.RegisterType(result.ValidatorType)
                        .Keyed<IValidator>(result.InterfaceType)
                        .As<IValidator>();
                    }); // Validation CreateGenre

            AssemblyScanner.FindValidatorsInAssemblyContaining<AdminValidationOfSingerCreate>()
                    .ForEach(result =>
                    {
                        builder.RegisterType(result.ValidatorType)
                        .Keyed<IValidator>(result.InterfaceType)
                        .As<IValidator>();
                    }); // Validation CreateSinger

            AssemblyScanner.FindValidatorsInAssemblyContaining<AdminValidationOfPlaylistCreate>()
                    .ForEach(result =>
                    {
                        builder.RegisterType(result.ValidatorType)
                        .Keyed<IValidator>(result.InterfaceType)
                        .As<IValidator>();
                    }); // Validation CreatePlaylist


            AssemblyScanner.FindValidatorsInAssemblyContaining<AdminValidationOfTrackCreate>()
                    .ForEach(result =>
                    {
                        builder.RegisterType(result.ValidatorType)
                        .Keyed<IValidator>(result.InterfaceType)
                        .As<IValidator>();
                    }); // Validation CreateTrack

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