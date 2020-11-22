using DomainYandexMusic.Entities;
using System.Data.Entity.ModelConfiguration;

namespace InfastructureYandexMusic.Configurations
{
    class UserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfiguration()
        {
            ToTable("Users");

            HasKey(c => c.Id);

            HasMany(c => c.Playlists)
                .WithMany(c => c.Users)
                .Map(c => c.
                ToTable("UserPlaylists")
                .MapLeftKey("UserId")
                .MapRightKey("PlaylistId"));
        }
    }
}
