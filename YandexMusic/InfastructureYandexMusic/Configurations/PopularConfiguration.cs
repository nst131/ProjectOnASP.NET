using DomainYandexMusic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfastructureYandexMusic.Configurations
{
    public class PopularConfiguration : EntityTypeConfiguration<Popular>
    {
        public PopularConfiguration()
        {
            ToTable("Popular");

            HasKey(x => x.Id);

            HasMany(x => x.Tracks)
                .WithOptional(x => x.Popular)
                .HasForeignKey(x => x.PopularId)
                .WillCascadeOnDelete(true);
        }
    }
}
