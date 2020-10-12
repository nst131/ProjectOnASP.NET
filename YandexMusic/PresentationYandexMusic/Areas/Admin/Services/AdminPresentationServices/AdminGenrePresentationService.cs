using AutoMapper;
using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel;
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

        //public void AddGenre(GenreViewModel genreModel)
        //{
        //    Genre genre = Mapper.Map<GenreViewModel, Genre>(genreModel);

        //    genreModel.GenreImage.InputStream
        //        .Read(genre.GenreImage.ImageData, 0, genreModel.GenreImage.ContentLength);

        //    genreDomainService.Entry(genre).State = EntityState.Added;
        //    genreDomainService.SaveChanges();
        //}

        public void AddGenre(GenreViewModel genreModel)
        {
            Genre genre = Mapper.Map<GenreViewModel, Genre>(genreModel);

            genre.GenreImage.ImageData = GetArray(genreModel.GenreImage);
                                                    
            genreDomainService.Entry(genre).State = EntityState.Added;
            genreDomainService.SaveChanges();
        }
    }
}