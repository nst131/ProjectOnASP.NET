using DomainYandexMusic.Entities;
using System.Data.Entity.ModelConfiguration;

namespace InfastructureYandexMusic.Configurations
{
    public class SingerConfiguration : EntityTypeConfiguration<Singer>
    {
        public SingerConfiguration()
        {
            ToTable("Singer");

            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsOptional()
                .HasMaxLength(50);

            HasOptional(x => x.SingerImage)
                .WithRequired(x => x.Singer)
                .Map(x => x.MapKey("SingerId"))
                .WillCascadeOnDelete(false);
        }
    }
}
