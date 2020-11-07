using AutoMapper;
using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel.Genre;
using System.Data.Entity;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices
{
    public class AdminGenrePresentationService : GetArrayImage, IAdminGenrePresentationService
    {
        private readonly IGenreDomainService genreDomainService;

        public AdminGenrePresentationService(IGenreDomainService genreDomainService)
        {
            this.genreDomainService = genreDomainService;
        }

        public void AddGenre(CreateGenreViewModel genreModel)
        {
            Genre genre = Mapper.Map<CreateGenreViewModel, Genre>(genreModel);

            genre.GenreImage.ImageData = GetArray(genreModel.GenreImage);

            genreDomainService.Entry(genre).State = EntityState.Added;
            genreDomainService.SaveChanges();
        }
    }
}