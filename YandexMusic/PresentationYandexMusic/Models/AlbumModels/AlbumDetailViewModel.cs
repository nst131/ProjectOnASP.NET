using DomainYandexMusic.Entities;
using System.Collections.Generic;

namespace PresentationYandexMusic.Models.AlbumModels
{
    public class AlbumDetailViewModel
    {
        public string SingerName { get; set; }

        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public List<Track> Tracks { get; set; }

        public List<Track> LikedTrack { get; set; }

        public int AmountTracks { get; set; }
    }
}