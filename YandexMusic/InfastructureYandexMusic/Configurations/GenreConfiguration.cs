using DomainYandexMusic.Entities;
using System.Data.Entity.ModelConfiguration;

namespace InfastructureYandexMusic.Configurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            ToTable("Genre");

            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsOptional()
                .HasMaxLength(50);

            HasOptional(x => x.GenreImage)
                .WithRequired(x => x.Genre)
                .WillCascadeOnDelete(true);
        }
    }
}
