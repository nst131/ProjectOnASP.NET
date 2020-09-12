using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Entities
{
    public class Singer
    {
        public int Id { get; set; }

        public ICollection<Track> Tracks { get; set; }

        public ICollection<Album> Albums { get; set; }

        public Singer()
        {
            Tracks = new List<Track>();
        }
    }
}
