using System.Collections.Generic;
using DomainYandexMusic.Entities;

namespace PresentationYandexMusic.Models.GenreModels
{
    public class GenreViewModel
    {
        public List<Genre> Genres { get; set; }

        public List<Track> LikedTracks { get; set; }
    }
}