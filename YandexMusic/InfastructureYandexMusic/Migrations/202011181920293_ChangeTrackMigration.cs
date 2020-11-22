namespace InfastructureYandexMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTrackMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPlaylists",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        PlaylistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.PlaylistId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Playlist", t => t.PlaylistId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PlaylistId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Track", "NumberOfLikes", c => c.Int(nullable: false));
            AddColumn("dbo.Track", "Like", c => c.Boolean());
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.Track", "Liked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Track", "Liked", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Users", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserPlaylists", "PlaylistId", "dbo.Playlist");
            DropForeignKey("dbo.UserPlaylists", "UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Id" });
            DropIndex("dbo.UserPlaylists", new[] { "PlaylistId" });
            DropIndex("dbo.UserPlaylists", new[] { "UserId" });
            DropColumn("dbo.Track", "Like");
            DropColumn("dbo.Track", "NumberOfLikes");
            DropTable("dbo.Users");
            DropTable("dbo.UserPlaylists");
        }
    }
}
