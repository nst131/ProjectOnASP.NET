using DomainYandexMusic.Entities;
using System.Data.Entity.ModelConfiguration;

namespace InfastructureYandexMusic.Configurations
{
    public class AlbumConfiguration : EntityTypeConfiguration<Album>
    {
        public AlbumConfiguration()
        {
            ToTable("Album");

            HasKey(x => x.Id);

            HasMany(x => x.Tracks)
                .WithOptional(x => x.Album)
                .HasForeignKey(x => x.AlbumId)
                .WillCascadeOnDelete(true);
        }
    }
}
