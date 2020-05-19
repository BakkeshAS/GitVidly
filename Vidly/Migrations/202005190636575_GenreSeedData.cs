namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreSeedData : DbMigration
    {
        public override void Up()
        {
            // seed data for Genre
            Sql("INSERT INTO dbo.GenreTypes ( Name) VALUES ('Horror') ");
            Sql("INSERT INTO dbo.GenreTypes ( Name) VALUES ('Action') ");
            Sql("INSERT INTO dbo.GenreTypes ( Name) VALUES ( 'SiFi') ");
            Sql("INSERT INTO dbo.GenreTypes ( Name) VALUES ('Romantic') ");
            Sql("INSERT INTO dbo.GenreTypes ( Name) VALUES ('Drama') ");
            Sql("INSERT INTO dbo.GenreTypes ( Name) VALUES ('Animation') ");
            Sql("INSERT INTO dbo.GenreTypes ( Name) VALUES ('Adventure') ");
        }
        
        public override void Down()
        {
        }
    }
}
