using DomainYandexMusic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfastructureYandexMusic.Configurations
{
    public class NoveltyConfiguration : EntityTypeConfiguration<Novelty>
    {
        NoveltyConfiguration()
        {
            ToTable("Novelty");

            HasKey(x => x.Id);

            HasMany(x => x.Tracks)
                .WithOptional(x => x.Novelty)
                .HasForeignKey(x => x.NoveltyId)
                .WillCascadeOnDelete(true);
        }
    }
}
