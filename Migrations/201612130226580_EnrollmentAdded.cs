namespace The2r.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnrollmentAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        ActivityId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.ActivityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Enrollments", "ActivityId", "dbo.Activities");
            DropIndex("dbo.Enrollments", new[] { "ActivityId" });
            DropIndex("dbo.Enrollments", new[] { "ApplicationUserId" });
            DropTable("dbo.Enrollments");
        }
    }
}
