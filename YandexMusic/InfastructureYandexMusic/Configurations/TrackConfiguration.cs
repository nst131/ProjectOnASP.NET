using DomainYandexMusic.Entities;
using System.Data.Entity.ModelConfiguration;

namespace InfastructureYandexMusic.Configurations
{
    public class TrackConfiguration : EntityTypeConfiguration<Track>
    {
        public TrackConfiguration()
        {
            ToTable("Track");

            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
            Property(x => x.TimeOfCreation)
                .IsRequired();
            Property(x => x.Liked)
                .IsRequired();

            HasMany(x => x.Playlists) // View
                .WithMany(x => x.Tracks)
                .Map(x => x.MapRightKey("PlaylistId"))
                .Map(x => x.MapLeftKey("TrackId"));

            HasOptional(x => x.Singer) // View
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.SingerId)
                .WillCascadeOnDelete(false);
            Property(x => x.SingerId).IsOptional();

            HasOptional(x => x.Album) // View
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.AlbumId)
                .WillCascadeOnDelete(false);
            Property(x => x.AlbumId).IsOptional();

            HasOptional(x => x.Genre) // View
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.GenreId)
                .WillCascadeOnDelete(false);
            Property(x => x.GenreId).IsOptional();

            HasOptional(x => x.Novelty) // Initiliazer
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.NoveltyId)
                .WillCascadeOnDelete(false);
            Property(x => x.NoveltyId).IsOptional();

            HasOptional(x => x.Popular) // Initiliazer
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.PopularId)
                .WillCascadeOnDelete(false);
            Property(x => x.PopularId).IsOptional();

            HasOptional(x => x.TrackImage) //--
                .WithRequired(x => x.Track)
                .Map(x => x.MapKey("TrackId")) //
                .WillCascadeOnDelete(false);

            HasOptional(x => x.TrackFile) //--
                .WithRequired(x => x.Track)
                .Map(x => x.MapKey("TrackId")) //
                .WillCascadeOnDelete(false);
        }
    }
}
