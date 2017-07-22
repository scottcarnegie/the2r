namespace The2r.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateActivity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", "ActivityTypeId", "dbo.ActivityTypes");
            DropIndex("dbo.Activities", new[] { "ActivityTypeId" });
            AlterColumn("dbo.Activities", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Activities", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Activities", "MinimumAttendees", c => c.Byte());
            AlterColumn("dbo.Activities", "MaximumAttendees", c => c.Int());
            AlterColumn("dbo.Activities", "EventStart", c => c.DateTime());
            AlterColumn("dbo.Activities", "Latitude", c => c.Decimal(precision: 18, scale: 5));
            AlterColumn("dbo.Activities", "Longitude", c => c.Decimal(precision: 18, scale: 5));
            AlterColumn("dbo.Activities", "ActivityTypeId", c => c.Byte());
            CreateIndex("dbo.Activities", "ActivityTypeId");
            AddForeignKey("dbo.Activities", "ActivityTypeId", "dbo.ActivityTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "ActivityTypeId", "dbo.ActivityTypes");
            DropIndex("dbo.Activities", new[] { "ActivityTypeId" });
            AlterColumn("dbo.Activities", "ActivityTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Activities", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 5));
            AlterColumn("dbo.Activities", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 5));
            AlterColumn("dbo.Activities", "EventStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Activities", "MaximumAttendees", c => c.Int(nullable: false));
            AlterColumn("dbo.Activities", "MinimumAttendees", c => c.Byte(nullable: false));
            AlterColumn("dbo.Activities", "Description", c => c.String());
            AlterColumn("dbo.Activities", "Name", c => c.String());
            CreateIndex("dbo.Activities", "ActivityTypeId");
            AddForeignKey("dbo.Activities", "ActivityTypeId", "dbo.ActivityTypes", "Id", cascadeDelete: true);
        }
    }
}
