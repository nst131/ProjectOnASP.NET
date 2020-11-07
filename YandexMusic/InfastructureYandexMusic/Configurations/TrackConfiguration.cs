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

            HasMany(x => x.Playlists)
                .WithMany(x => x.Tracks)
                .Map(x => x.MapRightKey("PlaylistId"))
                .Map(x => x.MapLeftKey("TrackId"));

            HasOptional(x => x.Singer)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.SingerId)
                .WillCascadeOnDelete(true);
            Property(x => x.SingerId).IsOptional();

            HasOptional(x => x.Album)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.AlbumId)
                .WillCascadeOnDelete(true);
            Property(x => x.AlbumId).IsOptional();

            HasOptional(x => x.Genre)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.GenreId)
                .WillCascadeOnDelete(true);
            Property(x => x.GenreId).IsOptional();

            HasOptional(x => x.Novelty) 
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.NoveltyId)
                .WillCascadeOnDelete(false);
            Property(x => x.NoveltyId).IsOptional();

            HasOptional(x => x.Popular) 
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.PopularId)
                .WillCascadeOnDelete(false);
            Property(x => x.PopularId).IsOptional();

            HasOptional(x => x.TrackImage) 
                .WithRequired(x => x.Track)
                .WillCascadeOnDelete(true);

            HasOptional(x => x.TrackFile) 
                .WithRequired(x => x.Track)
                .WillCascadeOnDelete(true);
        }
    }
}
