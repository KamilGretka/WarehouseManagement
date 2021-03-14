namespace WarehouseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_migration_05 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentHeaders",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ClientNumber = c.Int(nullable: false),
                        ClientName = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        GrossPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Message = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Amount = c.Int(nullable: false),
                        DocumentId = c.Guid(nullable: false),
                        GrossPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DocumentHeaders", t => t.DocumentId, cascadeDelete: true)
                .Index(t => t.DocumentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "DocumentId", "dbo.DocumentHeaders");
            DropIndex("dbo.Products", new[] { "DocumentId" });
            DropTable("dbo.Products");
            DropTable("dbo.Logs");
            DropTable("dbo.DocumentHeaders");
        }
    }
}
