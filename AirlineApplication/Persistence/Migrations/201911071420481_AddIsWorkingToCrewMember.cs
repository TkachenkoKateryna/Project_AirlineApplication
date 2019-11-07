namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsWorkingToCrewMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CrewMembers", "isWorking", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CrewMembers", "isWorking");
        }
    }
}
