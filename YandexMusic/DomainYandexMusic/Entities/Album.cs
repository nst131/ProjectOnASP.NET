using System.Collections.Generic;

namespace DomainYandexMusic.Entities
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; } 

        public int SingerId { get; set; }
        public Singer Singer { get; set; } 
        public AlbumImage AlbumImage { get; set; } 

        public Album()
        {
            Tracks = new List<Track>();
        }
    }
}
