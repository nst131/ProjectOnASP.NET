using System.Collections.Generic;

namespace DomainYandexMusic.Entities
{
    public class Novelty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; }

        public Novelty()
        {
            Tracks = new List<Track>();
        }
    }
}
