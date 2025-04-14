namespace MisicManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        artist_id = c.Int(nullable: false, identity: true),
                        artist_name = c.String(),
                        country_origin = c.String(),
                        birth_year = c.Int(nullable: false),
                        musical_genre = c.String(),
                        profile_photo = c.String(),
                    })
                .PrimaryKey(t => t.artist_id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        song_id = c.Int(nullable: false, identity: true),
                        track_name = c.String(),
                        release_year = c.Int(nullable: false),
                        duration = c.Time(nullable: false, precision: 7),
                        play_count = c.Int(nullable: false),
                        album_title = c.String(),
                        artist_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.song_id)
                .ForeignKey("dbo.Artists", t => t.artist_id, cascadeDelete: true)
                .Index(t => t.artist_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "artist_id", "dbo.Artists");
            DropIndex("dbo.Songs", new[] { "artist_id" });
            DropTable("dbo.Songs");
            DropTable("dbo.Artists");
        }
    }
}
