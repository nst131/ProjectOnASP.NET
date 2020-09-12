using DomainYandexMusic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfastructureYandexMusic.Configurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            ToTable("Genre");

            HasKey(x => x.Id);

            HasMany(x => x.Tracks)
                .WithOptional(x => x.Genre)
                .HasForeignKey(x => x.GenreId)
                .WillCascadeOnDelete(true);
        }
    }
}
