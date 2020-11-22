using System.Collections.Generic;
using DomainYandexMusic.Entities;

namespace PresentationYandexMusic.Models.AlbumModels
{
    public class AlbumDetailViewModel
    {
        public int SingerId { get; set; }

        public string SingerName { get; set; }

        public int AlbumId { get; set; }

        public string AlbumName { get; set; }

        public List<Track> Tracks { get; set; }

        public List<Track> LikedTrack { get; set; }

        public int AmountTracks { get; set; }
    }
}