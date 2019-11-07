namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProfessionsTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Professions ON");
            Sql("INSERT INTO Professions (ProfessionId,Name) VALUES (1, 'Captain')");
            Sql("INSERT INTO Professions (ProfessionId,Name) VALUES (2, 'First Pilot')");
            Sql("INSERT INTO Professions (ProfessionId,Name) VALUES (3, 'Navigator')");
            Sql("INSERT INTO Professions (ProfessionId,Name) VALUES (4, 'Radio Operator')");
            Sql("INSERT INTO Professions (ProfessionId,Name) VALUES (5, 'Main Flight Attendant')");
            Sql("INSERT INTO Professions (ProfessionId,Name) VALUES (6, 'Flight Attendant')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Professions WHERE Id In(1,2,3,4,5,6)");
            Sql("SET IDENTITY_INSERT Professions OFF");
        }
    }
}
