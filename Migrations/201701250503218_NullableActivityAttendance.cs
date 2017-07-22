namespace The2r.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableActivityAttendance : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activities", "CurrentEnrollment", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activities", "CurrentEnrollment", c => c.Int(nullable: false));
        }
    }
}
