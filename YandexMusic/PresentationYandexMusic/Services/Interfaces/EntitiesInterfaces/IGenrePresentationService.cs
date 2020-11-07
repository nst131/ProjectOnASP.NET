using DomainYandexMusic.Entities;
using PresentationYandexMusic.Models.GenreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IGenrePresentationService : IBasePresentationService
    {
        GenreViewModel GetGenreViewModel();
        GenreImage RedirectGenreImage(int id);
    }
}
