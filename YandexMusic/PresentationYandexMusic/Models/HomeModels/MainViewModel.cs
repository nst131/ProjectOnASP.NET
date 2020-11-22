using System.Collections.Generic;
using DomainYandexMusic.Entities;

namespace PresentationYandexMusic.Models.HomeModels
{
    public class MainViewModel
    {
        public List<Track> PopularTracks { get; set; }

        public List<Track> NoveltyTracks { get; set; }

        public List<Album> Albums { get; set; }
    }
}