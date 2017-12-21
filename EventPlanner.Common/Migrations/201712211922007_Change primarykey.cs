namespace EventPlanner.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changeprimarykey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DatePreferences");
            DropPrimaryKey("dbo.EventUserGroups");
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.DatePreferences", "DatePreferenceID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.EventUserGroups", "EventUserGroupID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Posts", "PostID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DatePreferences", "DatePreferenceID");
            AddPrimaryKey("dbo.EventUserGroups", "EventUserGroupID");
            AddPrimaryKey("dbo.Posts", "PostID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Posts");
            DropPrimaryKey("dbo.EventUserGroups");
            DropPrimaryKey("dbo.DatePreferences");
            AlterColumn("dbo.Posts", "PostID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EventUserGroups", "EventUserGroupID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.DatePreferences", "DatePreferenceID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Posts", "PostID");
            AddPrimaryKey("dbo.EventUserGroups", "EventUserGroupID");
            AddPrimaryKey("dbo.DatePreferences", "DatePreferenceID");
        }
    }
}
