using System.Collections.Generic;

namespace DomainYandexMusic.Entities
{
    public class Popular
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; }

        public Popular()
        {
            Tracks = new List<Track>();
        }
    }
}
