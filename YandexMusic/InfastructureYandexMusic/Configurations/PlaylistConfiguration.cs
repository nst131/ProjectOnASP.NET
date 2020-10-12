using DomainYandexMusic.Entities;
using System.Data.Entity.ModelConfiguration;

namespace InfastructureYandexMusic.Configurations
{
    public class PlaylistConfiguration : EntityTypeConfiguration<Playlist>
    {
        public PlaylistConfiguration()
        {
            ToTable("Playlist");

            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsOptional()
                .HasMaxLength(50);

            HasOptional(x => x.PlaylistImage)
                .WithRequired(x => x.Playlist)
                .Map(x => x.MapKey("PlayImageId"))
                .WillCascadeOnDelete(false);
        }
    }
}
