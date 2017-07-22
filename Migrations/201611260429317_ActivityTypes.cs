namespace The2r.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[ActivityTypes] ([Id],[Name]) VALUES (1,'Running')");
            Sql("INSERT INTO [dbo].[ActivityTypes] ([Id],[Name]) VALUES (2,'Hiking')");
            Sql("INSERT INTO [dbo].[ActivityTypes] ([Id],[Name]) VALUES (3,'Swimming')");
            Sql("INSERT INTO [dbo].[ActivityTypes] ([Id],[Name]) VALUES (4,'Biking')");
            Sql("INSERT INTO [dbo].[ActivityTypes] ([Id],[Name]) VALUES (5,'Skiing')");
            Sql("INSERT INTO [dbo].[ActivityTypes] ([Id],[Name]) VALUES (6,'Walking')");
            Sql("INSERT INTO [dbo].[ActivityTypes] ([Id],[Name]) VALUES (7,'Climbing')");
            Sql("INSERT INTO [dbo].[ActivityTypes] ([Id],[Name]) VALUES (8,'Workout')");
        }
        
        public override void Down()
        {
        }
    }
}
