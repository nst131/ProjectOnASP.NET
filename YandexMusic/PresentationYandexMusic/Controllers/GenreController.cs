﻿using System.Web.Mvc;
using DomainYandexMusic.Entities;
using Microsoft.AspNet.Identity;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Controllers
{
    public partial class GenreController : Controller
    {
        private readonly IGenrePresentationService genrePresentation;

        public GenreController(IGenrePresentationService genrePresentation)
        {
            this.genrePresentation = genrePresentation;
        }

        public virtual FileResult GetGenreImage(int id)
        {
            GenreImage image = genrePresentation.RedirectGenreImage(id);

            if (image != null)
            {
                return File(image.ImageData, image.ImageMimeType);
            }

            return null;
        }

        public virtual ViewResult GetAllGenres()
        {
            return View(genrePresentation.GetGenreViewModel(User.Identity.GetUserId()));
        }
    }
}