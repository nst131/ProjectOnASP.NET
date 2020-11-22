using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace DomainYandexMusic.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<Playlist> Playlists { get; set; }
    }
}
