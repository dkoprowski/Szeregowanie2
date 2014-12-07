namespace SzeregowanieProjekt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class what : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Task", "label", c => c.String());
            AddColumn("dbo.Task", "release", c => c.Int(nullable: false));
            AddColumn("dbo.Task", "deadline", c => c.Int(nullable: false));
            AddColumn("dbo.Task", "processingTime", c => c.Int(nullable: false));
            AddColumn("dbo.Task", "color_red", c => c.Int(nullable: false));
            AddColumn("dbo.Task", "color_green", c => c.Int(nullable: false));
            AddColumn("dbo.Task", "color_blue", c => c.Int(nullable: false));
            DropColumn("dbo.Task", "name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Task", "name", c => c.String());
            DropColumn("dbo.Task", "color_blue");
            DropColumn("dbo.Task", "color_green");
            DropColumn("dbo.Task", "color_red");
            DropColumn("dbo.Task", "processingTime");
            DropColumn("dbo.Task", "deadline");
            DropColumn("dbo.Task", "release");
            DropColumn("dbo.Task", "label");
        }
    }
}
