namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeletedToFlight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "IsDeleted");
        }
    }
}
