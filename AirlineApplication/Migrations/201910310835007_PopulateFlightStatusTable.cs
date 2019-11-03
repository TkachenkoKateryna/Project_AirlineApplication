namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFlightStatusTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT FlightStatus ON");
            Sql("INSERT INTO FlightStatus (StatusId, Value, Description) VALUES (1, 'A','Active')");
            Sql("INSERT INTO FlightStatus (StatusId, Value, Description) VALUES (2, 'C','Canceled')");
            Sql("INSERT INTO FlightStatus (StatusId, Value, Description) VALUES (3, 'D','Diverted')");
            Sql("INSERT INTO FlightStatus (StatusId, Value, Description) VALUES (4, 'L','Landed')");
            Sql("INSERT INTO FlightStatus (StatusId, Value, Description) VALUES (5, 'R','Redirected')");
            Sql("INSERT INTO FlightStatus (StatusId, Value, Description) VALUES (6, 'S','Scheduled')");
            Sql("INSERT INTO FlightStatus (StatusId, Value, Description) VALUES (7, 'U','Unknown')");
            Sql("INSERT INTO FlightStatus (StatusId, Value, Description) VALUES (8, 'NO','Not Operational')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM FlightStatus WHERE Id In(1,2,3,4,5,6,7,8)");
            Sql("SET IDENTITY_INSERT FlightStatus OFF");
        }
    }
}
