namespace The2r.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMapUrltoActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "MapUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "MapUrl");
        }
    }
}
