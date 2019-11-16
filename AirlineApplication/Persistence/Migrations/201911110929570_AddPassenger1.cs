namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPassenger1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Passengers", new[] { "User_Id" });
            DropColumn("dbo.Passengers", "UserId");
            RenameColumn(table: "dbo.Passengers", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Passengers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Passengers", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Passengers", new[] { "UserId" });
            AlterColumn("dbo.Passengers", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Passengers", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Passengers", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Passengers", "User_Id");
        }
    }
}
