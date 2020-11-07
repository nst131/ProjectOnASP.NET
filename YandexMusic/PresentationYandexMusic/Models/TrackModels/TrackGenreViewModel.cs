using DomainYandexMusic.Entities;
using System.Collections.Generic;

namespace PresentationYandexMusic.Models.TrackModels
{
    public class TrackGenreViewModel
    {
        public List<Track> Tracks { get; set; }
        public List<Track> LikedTrack { get; set; }
    }
}