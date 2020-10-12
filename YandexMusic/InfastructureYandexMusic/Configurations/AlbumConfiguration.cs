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

            Property(x => x.Name)
                .IsOptional()
                .HasMaxLength(50);

            HasRequired(x => x.Singer) //
                .WithMany(x => x.Albums)
                .HasForeignKey(x => x.SingerId)
                .WillCascadeOnDelete(false);

            HasOptional(x => x.AlbumImage) //--
                .WithRequired(x => x.Album)
                .Map(x => x.MapKey("AlbumImageId"))
                .WillCascadeOnDelete(false);
        }
    }
}
