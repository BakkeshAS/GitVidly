namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ignore : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Customers", "DOB", c => c.DateTime());
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Customers", "DOB", c => c.DateTime(nullable: false));
        }
    }
}
