namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUserRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2e9a7263-1d56-4c1a-97bf-841fd97ebdb8', N'user@gmail.com', 0, N'AOMzECmv0vcHGsrcY3sUSM0EANfR7oLueDuB/ytTzLXjUGtPGqq93Hw21MkPovhcQg==', N'b549bd8d-880e-47df-a53a-2204c699c4a6', NULL, 0, 0, NULL, 1, 0, N'user@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6007fa5c-4446-4346-a673-e250b9c98482', N'dispatcher@gmail.com', 0, N'ALgFLAZi8DGW/vE0eU6AUx32SSWWHYGfMAg9dpfGpMOOX5I4ezJLnzUuDoL4wltI3w==', N'5a09550e-2212-458b-84e0-d5d8d32ec92f', NULL, 0, 0, NULL, 1, 0, N'dispatcher@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bfcc14ee-9817-43a2-b8b5-76b9aa6b87a8', N'admin@gmail.com', 0, N'AI782zBiUBx4QkcWXr2wELMCVwq8KWXiCFKTVHZGhQskpzGRDDIFvJliWx1Lv6uolg==', N'416c17a4-3d87-47cd-91f7-62c2ddb4e70a', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b086336e-44bb-4f08-925f-00933d629f30', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bb34876d-d5c5-423e-913f-b01c8cfac452', N'Dispatcher')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e3e906ee-a67d-4446-ac27-ef56297b8b57', N'User')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bfcc14ee-9817-43a2-b8b5-76b9aa6b87a8', N'b086336e-44bb-4f08-925f-00933d629f30')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6007fa5c-4446-4346-a673-e250b9c98482', N'bb34876d-d5c5-423e-913f-b01c8cfac452')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2e9a7263-1d56-4c1a-97bf-841fd97ebdb8', N'e3e906ee-a67d-4446-ac27-ef56297b8b57')
");
        }
        
        public override void Down()
        {
        }
    }
}
