namespace The2r.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Latitude", c => c.Decimal(precision: 18, scale: 5));
            AddColumn("dbo.AspNetUsers", "Longitude", c => c.Decimal(precision: 18, scale: 5));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Longitude");
            DropColumn("dbo.AspNetUsers", "Latitude");
            DropColumn("dbo.AspNetUsers", "City");
        }
    }
}
