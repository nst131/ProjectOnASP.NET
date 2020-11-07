using DomainYandexMusic.Entities;
using System.Collections.Generic;

namespace PresentationYandexMusic.Models.GenreModels
{
    public class GenreViewModel
    {
        public List<Genre> Genres { get; set; }
        public List<Track> LikedTracks { get; set; }
    }
}