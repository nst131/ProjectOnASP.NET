using DomainYandexMusic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfastructureYandexMusic.Configurations
{
    public class SingerConfiguration : EntityTypeConfiguration<Singer>
    {
        public SingerConfiguration()
        {
            ToTable("Singer");

            HasKey(x => x.Id);

            HasMany(x => x.Albums)
                .WithOptional(x => x.Singer)
                .HasForeignKey(x => x.SingerId)
                .WillCascadeOnDelete(true);
        }
    }
}
