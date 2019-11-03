namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAirportsTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Airports ON");
            Sql("INSERT INTO Airports (AirportId,IATA,Name,City) VALUES (1, 'KBP','Boryspil International Airport', 'Kiev')");
            Sql("INSERT INTO Airports (AirportId,IATA,Name,City) VALUES (2,'IEV','Kiev (Zhuliany) International Airport', 'Kiev')");
            Sql("INSERT INTO Airports (AirportId,IATA,Name,City) VALUES (3,'DNK', 'Dnipropetrovsk International Airport', 'Dnipro')");
            Sql("INSERT INTO Airports (AirportId,IATA,Name,City) VALUES (4,'HRK', 'Kharkiv International Airport', 'Khariv')");
            Sql("INSERT INTO Airports (AirportId,IATA,Name,City) VALUES (5,'LWO', 'Lviv Danylo Halytskyi International Airport', 'Lviv')");
            Sql("INSERT INTO Airports (AirportId,IATA,Name,City) VALUES (6, 'ODS', 'Odessa International Airport', 'Odessa')");
            Sql("INSERT INTO Airports (AirportId,IATA,Name,City) VALUES (7,'IFO', 'Ivano-Frankivsk International Airport', 'Ivano-frankivsk')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Airports WHERE AirportId In(1,2,3,4,5,6,7)");
            Sql("SET IDENTITY_INSERT Airports OFF");
        }
    }
}
