using System.Collections.Generic;

namespace DomainYandexMusic.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; }

        public GenreImage GenreImage { get; set; }

        public Genre()
        {
            Tracks = new List<Track>();
        }
    }
}
 