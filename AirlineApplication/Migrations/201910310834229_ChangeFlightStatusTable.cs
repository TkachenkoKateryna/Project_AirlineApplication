namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFlightStatusTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlightStatus", "Value", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.FlightStatus", "Description", c => c.String());
            DropColumn("dbo.FlightStatus", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FlightStatus", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.FlightStatus", "Description");
            DropColumn("dbo.FlightStatus", "Value");
        }
    }
}
