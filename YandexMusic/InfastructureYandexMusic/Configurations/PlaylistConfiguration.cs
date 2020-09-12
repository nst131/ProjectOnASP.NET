using DomainYandexMusic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfastructureYandexMusic.Configurations
{
    public class PlaylistConfiguration : EntityTypeConfiguration<Playlist>
    {
        public PlaylistConfiguration()
        {
            ToTable("Playlist");

            HasKey(x => x.Id);

            HasMany(x => x.Tracks)
                .WithMany(x => x.Playlists)
                .Map(x => x.MapRightKey("TrackId")
                .MapLeftKey("PlaykistId"));
        }
    }
}
