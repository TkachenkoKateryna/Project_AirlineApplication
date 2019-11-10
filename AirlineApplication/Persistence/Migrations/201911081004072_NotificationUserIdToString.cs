namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotificationUserIdToString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Notifications", new[] { "User_Id" });
            DropColumn("dbo.Notifications", "UserId");
            RenameColumn(table: "dbo.Notifications", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Notifications", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Notifications", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Notifications", new[] { "UserId" });
            AlterColumn("dbo.Notifications", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Notifications", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Notifications", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notifications", "User_Id");
        }
    }
}
