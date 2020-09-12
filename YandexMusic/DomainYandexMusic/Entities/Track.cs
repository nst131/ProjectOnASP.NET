using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Entities
{
    public class Track
    {
        public int Id { get; set; }

        public int SingerId { get; set; }
        public ICollection<Singer> Singers { get; set; }

        public int PlaylistId { get; set; }
        public ICollection<Playlist> Playlists { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int NoveltyId { get; set; }
        public Novelty Novelty { get; set; }

        public int PopularId { get; set; }
        public Popular Popular { get; set; }

        public Track()
        {
            Singers = new List<Singer>();
            Playlists = new List<Playlist>();
        }
    }
}
