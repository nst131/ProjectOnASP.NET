using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Entities
{
    public class Popular
    {
        public int Id { get; set; }

        public ICollection<Track> Tracks { get; set; }

        public Popular()
        {
            Tracks = new List<Track>();
        }
    }
}
