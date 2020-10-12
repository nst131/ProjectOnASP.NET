using System.Collections.Generic;

namespace DomainYandexMusic.Entities
{
    public class Singer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; } 

        public ICollection<Album> Albums { get; set; }

        public SingerImage SingerImage { get; set; }

        public Singer()
        {
            Tracks = new List<Track>();
        }
    }
}
