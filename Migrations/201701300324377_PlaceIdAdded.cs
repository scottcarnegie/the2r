namespace The2r.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlaceIdAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "PlaceId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "PlaceId");
        }
    }
}
