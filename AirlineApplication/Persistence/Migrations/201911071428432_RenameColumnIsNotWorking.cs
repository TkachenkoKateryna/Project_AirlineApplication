namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColumnIsNotWorking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CrewMembers", "isNotWorking", c => c.Boolean(nullable: false));
            DropColumn("dbo.CrewMembers", "isWorking");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CrewMembers", "isWorking", c => c.Boolean(nullable: false));
            DropColumn("dbo.CrewMembers", "isNotWorking");
        }
    }
}
