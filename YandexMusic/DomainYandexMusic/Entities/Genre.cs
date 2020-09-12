using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        public ICollection<Track> Tracks { get; set; }

        public Genre()
        {
            Tracks = new List<Track>();
        }
    }
}
