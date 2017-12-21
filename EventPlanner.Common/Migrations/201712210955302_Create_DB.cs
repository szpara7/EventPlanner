namespace EventPlanner.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatePreferences",
                c => new
                    {
                        DatePreferenceID = c.String(nullable: false, maxLength: 128),
                        MinDate = c.DateTime(nullable: false),
                        MaxDate = c.DateTime(nullable: false),
                        EventID = c.Guid(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DatePreferenceID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.EventID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Guid(nullable: false),
                        EventName = c.String(nullable: false),
                        Description = c.String(),
                        MinDate = c.DateTime(nullable: false),
                        MaxDate = c.DateTime(nullable: false),
                        IsEnded = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.EventUserGroups",
                c => new
                    {
                        EventUserGroupID = c.String(nullable: false, maxLength: 128),
                        UserID = c.String(maxLength: 128),
                        EventID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EventUserGroupID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.String(nullable: false, maxLength: 128),
                        Content = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        EventID = c.Guid(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.EventID)
                .Index(t => t.UserID);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "FirstNameASD");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FirstNameASD", c => c.String(nullable: false));
            DropForeignKey("dbo.DatePreferences", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.DatePreferences", "EventID", "dbo.Events");
            DropForeignKey("dbo.Posts", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "EventID", "dbo.Events");
            DropForeignKey("dbo.EventUserGroups", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventUserGroups", "EventID", "dbo.Events");
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropIndex("dbo.Posts", new[] { "EventID" });
            DropIndex("dbo.EventUserGroups", new[] { "EventID" });
            DropIndex("dbo.EventUserGroups", new[] { "UserID" });
            DropIndex("dbo.DatePreferences", new[] { "UserID" });
            DropIndex("dbo.DatePreferences", new[] { "EventID" });
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Posts");
            DropTable("dbo.EventUserGroups");
            DropTable("dbo.Events");
            DropTable("dbo.DatePreferences");
        }
    }
}
