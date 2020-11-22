using System.Collections.Generic;

namespace DomainYandexMusic.Entities
{
    public class Playlist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }

        public PlaylistImage PlaylistImage { get; set; }

        public Playlist()
        {
            Tracks = new List<Track>();
        }
    }
}
