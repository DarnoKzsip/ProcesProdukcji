namespace ProcesProdukcji.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TransportCost = c.Double(nullable: false),
                        CostOfWorkingHour = c.Double(nullable: false),
                        SearchHistory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SearchHistories", t => t.SearchHistory_ID)
                .Index(t => t.SearchHistory_ID);
            
            CreateTable(
                "dbo.SearchHistories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        ModuleName1 = c.String(),
                        ModuleName2 = c.String(),
                        ModuleName3 = c.String(),
                        ModuleName4 = c.String(),
                        ProductionCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        AssemblyTime = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Description = c.String(),
                        SearchHistory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SearchHistories", t => t.SearchHistory_ID)
                .Index(t => t.SearchHistory_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modules", "SearchHistory_ID", "dbo.SearchHistories");
            DropForeignKey("dbo.Cities", "SearchHistory_ID", "dbo.SearchHistories");
            DropIndex("dbo.Modules", new[] { "SearchHistory_ID" });
            DropIndex("dbo.Cities", new[] { "SearchHistory_ID" });
            DropTable("dbo.Modules");
            DropTable("dbo.SearchHistories");
            DropTable("dbo.Cities");
        }
    }
}
