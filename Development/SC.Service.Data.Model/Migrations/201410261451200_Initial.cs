namespace SC.Service.Data.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Summary = c.String(nullable: false, maxLength: 200),
                        Details = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Details = c.String(nullable: false),
                        Location = c.String(nullable: false, maxLength: 100),
                        FacebookEventId = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
            DropTable("dbo.Announcements");
        }
    }
}
