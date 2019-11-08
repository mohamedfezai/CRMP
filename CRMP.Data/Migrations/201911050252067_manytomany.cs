namespace CRMP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreProducts",
                c => new
                    {
                        Store_StoreId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Store_StoreId, t.Product_ProductId })
                .ForeignKey("dbo.Stores", t => t.Store_StoreId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Store_StoreId)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.StoreProducts", "Store_StoreId", "dbo.Stores");
            DropIndex("dbo.StoreProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.StoreProducts", new[] { "Store_StoreId" });
            DropTable("dbo.StoreProducts");
        }
    }
}
