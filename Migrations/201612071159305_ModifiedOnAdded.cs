namespace The2r.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedOnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "ModifiedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "ModifiedOn");
        }
    }
}
