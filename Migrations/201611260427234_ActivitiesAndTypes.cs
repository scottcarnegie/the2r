namespace The2r.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivitiesAndTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Difficulty = c.Byte(nullable: false),
                        MinimumAttendees = c.Byte(nullable: false),
                        MaximumAttendees = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        EventStart = c.DateTime(nullable: false),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 5),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 5),
                        ActivityTypeId = c.Byte(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityTypes", t => t.ActivityTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.ActivityTypeId);
            
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Activities", "ActivityTypeId", "dbo.ActivityTypes");
            DropIndex("dbo.Activities", new[] { "ActivityTypeId" });
            DropIndex("dbo.Activities", new[] { "ApplicationUserId" });
            DropTable("dbo.ActivityTypes");
            DropTable("dbo.Activities");
        }
    }
}
