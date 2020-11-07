using System;
using System.Collections.Generic;

namespace DomainYandexMusic.Entities
{
    public class Track
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime TimeOfCreation { get; set; } 
        public int Liked { get; set; } 

        public int SingerId { get; set; }
        public Singer Singer { get; set; }

        public ICollection<Playlist> Playlists { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; } 

        public int GenreId { get; set; }
        public Genre Genre { get; set; } 

        public int NoveltyId { get; set; }
        public Novelty Novelty { get; set; } 

        public int PopularId { get; set; }
        public Popular Popular { get; set; } 

        public TrackImage TrackImage { get; set; }
        public TrackFile TrackFile { get; set; }

        public Track()
        {
            Playlists = new List<Playlist>();
        }
    }
}
