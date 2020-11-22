using System.Collections.Generic;
using DomainYandexMusic.Entities;

namespace PresentationYandexMusic.Models.TrackModels
{
    public class TrackGenreViewModel
    {
        public List<Track> Tracks { get; set; }

        public List<Track> LikedTrack { get; set; }
    }
}