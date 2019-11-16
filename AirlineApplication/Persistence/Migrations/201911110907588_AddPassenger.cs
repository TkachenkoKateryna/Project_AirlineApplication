namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPassenger : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        PassengerId = c.Int(nullable: false, identity: true),
                        FlightId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PassengerId)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.FlightId)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Flights", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Flights", "ApplicationUser_Id");
            AddForeignKey("dbo.Flights", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passengers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Flights", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Passengers", "FlightId", "dbo.Flights");
            DropIndex("dbo.Passengers", new[] { "User_Id" });
            DropIndex("dbo.Passengers", new[] { "FlightId" });
            DropIndex("dbo.Flights", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Flights", "ApplicationUser_Id");
            DropTable("dbo.Passengers");
        }
    }
}
