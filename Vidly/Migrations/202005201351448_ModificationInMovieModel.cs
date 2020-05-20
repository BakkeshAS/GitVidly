namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificationInMovieModel : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Movies", "GenreType_Id", "dbo.GenreTypes");
            //DropIndex("dbo.Movies", new[] { "GenreType_Id" });
            //DropColumn("dbo.Movies", "GenreType_Id");

            //AddColumn("dbo.Movies", "GenreTypeId", c => c.Byte(nullable: false));
            //CreateIndex("dbo.Movies", "GenreTypeId");
            //AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes", "Id");
           
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "GenreTypeId");
        }
    }
}
