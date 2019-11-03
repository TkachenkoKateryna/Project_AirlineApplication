namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DELETEFROMFlights : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Flights");
        }
        
        public override void Down()
        {
        }
    }
}
