using System.Collections.Generic;

namespace DomainYandexMusic.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LasttName { get; set; }

        public UserImage UserImage { get; set; }
        public ICollection<Playlist> Playlists { get; set; }

        public User()
        {
            Playlists = new List<Playlist>();
        }
    }
}
