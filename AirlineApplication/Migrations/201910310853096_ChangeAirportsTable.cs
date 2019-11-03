namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAirportsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Airports", "IATA", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Airports", "IATA");
        }
    }
}
