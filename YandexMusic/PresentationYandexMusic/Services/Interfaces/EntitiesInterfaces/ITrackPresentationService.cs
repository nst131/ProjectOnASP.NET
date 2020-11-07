using DomainYandexMusic.Entities;
using PresentationYandexMusic.Models.TrackModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface ITrackPresentationService : IBasePresentationService
    {
        TrackGenreViewModel GetTrackGenreViewModel(int id);
        TrackImage RedirecttrackImage(int id);
    }
}
