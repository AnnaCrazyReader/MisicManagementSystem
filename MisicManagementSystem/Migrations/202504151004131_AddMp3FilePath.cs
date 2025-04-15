namespace MusicManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMp3FilePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "mp3_file_path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "mp3_file_path");
        }
    }
}
