using DomainYandexMusic.Entities;
using PresentationYandexMusic.Models.AlbumModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IAlbumPresentationService : IBasePresentationService
    {
        AlbumDetailViewModel GetAlbumDetailViewModel(int id);
        AlbumImage RedirectAlbumImage(int id);
    }
}
