namespace The2r.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [SubscribeToEmail], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [MemberSince]) VALUES (N'87e0d727-5437-4a58-b46d-bd7b623cdb6b', 0, N'scott.carnegie@tidbytes.ca', 0, N'AAfNfX4km9mFLu0x4YTNvUhV1+oqM9+GEJnSrVjKszqlBw2Po0gchbFUG58y+dJa5g==', N'30bd0f13-4651-4c41-97d6-5cb806302047', NULL, 0, 0, NULL, 1, 0, N'scott.carnegie@tidbytes.ca', N'System', N'Admin', N'2017-01-28 22:01:28')");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4d7ab44d-9f63-4f33-b1ef-7b57c0e0f920', N'IsAdministrator')");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'87e0d727-5437-4a58-b46d-bd7b623cdb6b', N'4d7ab44d-9f63-4f33-b1ef-7b57c0e0f920')");
        }
        
        public override void Down()
        {
        }
    }
}
