﻿using DomainYandexMusic.Entities;
using System.Collections.Generic;

namespace PresentationYandexMusic.Models.SingerModels
{
    public class SingerDetailViewModel
    {
        public Singer Singer { get; set; }
        public Genre SingerGenre { get; set; }
        public List<Track> LikedTracks { get; set; }
        
        public int AmountTracks { get; set; }
        public int AmountAlbums { get; set; }
    }
}