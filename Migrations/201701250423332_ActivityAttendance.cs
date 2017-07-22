namespace The2r.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityAttendance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "CurrentEnrollment", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "CurrentEnrollment");
        }
    }
}
