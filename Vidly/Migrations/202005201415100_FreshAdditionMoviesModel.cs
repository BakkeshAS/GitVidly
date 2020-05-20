namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FreshAdditionMoviesModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Stock = c.Int(nullable: false),
                        GenreTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GenreTypes", t => t.GenreTypeId, cascadeDelete: true)
                .Index(t => t.GenreTypeId);

            // read the last comments
            //I added the lines below to override the E.F.s scaffolding the foreign key for GenreTypeId
            // When E.F. Try doing this?
            // when we add a GenreType's property in Movie Class 
            //so Itried adding below code
            //CreateIndex("dbo.Movies", "GenreTypeId");
            //AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes", "Id", cascadeDelete: true);

            //the data types of the Id in the GenreTypes and the foreign Key I tried using were mismatching 
            //so E.F. took charge of creating a foreign key. Once I took care of the data types, E.F. created 
            //the above code, taking GenreTypeId as the foreign key in Movies tbl
            // E.F. auto-detects the "Id" postfix to any property of a Model to consider it as a foreign key.
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypeId" });
            DropTable("dbo.Movies");
        }
    }
}
