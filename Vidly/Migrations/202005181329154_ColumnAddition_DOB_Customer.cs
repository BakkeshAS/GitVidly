namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnAddition_DOB_Customer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DOB", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DOB");
        }
    }
}
