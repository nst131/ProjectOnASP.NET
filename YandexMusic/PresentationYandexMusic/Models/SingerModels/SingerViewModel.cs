using DomainYandexMusic.Entities;
using System.Collections.Generic;

namespace PresentationYandexMusic.Models.SingerModels
{
    public class SingerViewModel
    {
        public List<Singer> Singers { get; set; }
        public List<Track> LikedTracks { get; set; }
    }
}