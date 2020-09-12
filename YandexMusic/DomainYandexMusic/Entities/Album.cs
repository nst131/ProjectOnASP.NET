using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Entities
{
    public class Album
    {
        public int Id { get; set; }

        public ICollection<Track> Tracks { get; set; }

        public int SingerId { get; set; }
        public Singer Singer { get; set; }

        public Album()
        {
            Tracks = new List<Track>();
        }
    }
}
