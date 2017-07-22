namespace The2r.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateActivityLocationDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "LocationName", c => c.String());
            AddColumn("dbo.Activities", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "Address");
            DropColumn("dbo.Activities", "LocationName");
        }
    }
}
