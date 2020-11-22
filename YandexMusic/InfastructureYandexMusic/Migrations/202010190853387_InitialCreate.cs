namespace InfastructureYandexMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        SingerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Singer", t => t.SingerId)
                .Index(t => t.SingerId);
            
            CreateTable(
                "dbo.AlbumImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Album", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Singer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SingerImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Singer", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Track",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TimeOfCreation = c.DateTime(nullable: false),
                        Liked = c.Int(nullable: false),
                        SingerId = c.Int(),
                        AlbumId = c.Int(),
                        GenreId = c.Int(),
                        NoveltyId = c.Int(),
                        PopularId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Album", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Novelties", t => t.NoveltyId)
                .ForeignKey("dbo.Populars", t => t.PopularId)
                .ForeignKey("dbo.Singer", t => t.SingerId, cascadeDelete: true)
                .Index(t => t.SingerId)
                .Index(t => t.AlbumId)
                .Index(t => t.GenreId)
                .Index(t => t.NoveltyId)
                .Index(t => t.PopularId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenreImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genre", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Novelties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlaylistImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Playlist", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Populars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrackFiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FileLocation = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Track", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.TrackImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Track", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.TrackPlaylists",
                c => new
                    {
                        TrackId = c.Int(nullable: false),
                        Playlist_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrackId, t.Playlist_Id })
                .ForeignKey("dbo.Track", t => t.TrackId, cascadeDelete: true)
                .ForeignKey("dbo.Playlist", t => t.Playlist_Id, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.Playlist_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Album", "SingerId", "dbo.Singer");
            DropForeignKey("dbo.TrackImages", "Id", "dbo.Track");
            DropForeignKey("dbo.TrackFiles", "Id", "dbo.Track");
            DropForeignKey("dbo.Track", "SingerId", "dbo.Singer");
            DropForeignKey("dbo.Track", "PopularId", "dbo.Populars");
            DropForeignKey("dbo.TrackPlaylists", "Playlist_Id", "dbo.Playlist");
            DropForeignKey("dbo.TrackPlaylists", "TrackId", "dbo.Track");
            DropForeignKey("dbo.PlaylistImages", "Id", "dbo.Playlist");
            DropForeignKey("dbo.Track", "NoveltyId", "dbo.Novelties");
            DropForeignKey("dbo.Track", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.GenreImages", "Id", "dbo.Genre");
            DropForeignKey("dbo.Track", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.SingerImages", "Id", "dbo.Singer");
            DropForeignKey("dbo.AlbumImages", "Id", "dbo.Album");
            DropIndex("dbo.TrackPlaylists", new[] { "Playlist_Id" });
            DropIndex("dbo.TrackPlaylists", new[] { "TrackId" });
            DropIndex("dbo.TrackImages", new[] { "Id" });
            DropIndex("dbo.TrackFiles", new[] { "Id" });
            DropIndex("dbo.PlaylistImages", new[] { "Id" });
            DropIndex("dbo.GenreImages", new[] { "Id" });
            DropIndex("dbo.Track", new[] { "PopularId" });
            DropIndex("dbo.Track", new[] { "NoveltyId" });
            DropIndex("dbo.Track", new[] { "GenreId" });
            DropIndex("dbo.Track", new[] { "AlbumId" });
            DropIndex("dbo.Track", new[] { "SingerId" });
            DropIndex("dbo.SingerImages", new[] { "Id" });
            DropIndex("dbo.AlbumImages", new[] { "Id" });
            DropIndex("dbo.Album", new[] { "SingerId" });
            DropTable("dbo.TrackPlaylists");
            DropTable("dbo.TrackImages");
            DropTable("dbo.TrackFiles");
            DropTable("dbo.Populars");
            DropTable("dbo.PlaylistImages");
            DropTable("dbo.Playlist");
            DropTable("dbo.Novelties");
            DropTable("dbo.GenreImages");
            DropTable("dbo.Genre");
            DropTable("dbo.Track");
            DropTable("dbo.SingerImages");
            DropTable("dbo.Singer");
            DropTable("dbo.AlbumImages");
            DropTable("dbo.Album");
        }
    }
}
