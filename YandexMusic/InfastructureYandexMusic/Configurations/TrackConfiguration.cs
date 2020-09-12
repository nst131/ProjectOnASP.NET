using DomainYandexMusic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfastructureYandexMusic.Configurations
{
    public class TrackConfiguration : EntityTypeConfiguration<Track>
    {
        public TrackConfiguration()
        {
            ToTable("Track");

            HasKey(x => x.Id);

            HasMany(x => x.Singers)
                .WithMany(x => x.Tracks)
                .Map(x => x.MapRightKey("SingerId")
                .MapLeftKey("TrackId"));
        }
    }
}
