namespace The2r.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivitySubscriptionAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivitySubscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        ActivityTypeId = c.Byte(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityTypes", t => t.ActivityTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.ActivityTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivitySubscriptions", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ActivitySubscriptions", "ActivityTypeId", "dbo.ActivityTypes");
            DropIndex("dbo.ActivitySubscriptions", new[] { "ActivityTypeId" });
            DropIndex("dbo.ActivitySubscriptions", new[] { "ApplicationUserId" });
            DropTable("dbo.ActivitySubscriptions");
        }
    }
}
