namespace CRMP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pls1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StoreProducts", "Store_StoreId", "dbo.Stores");
            DropForeignKey("dbo.StoreProducts", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.StoreProducts", new[] { "Store_StoreId" });
            DropIndex("dbo.StoreProducts", new[] { "Product_ProductId" });
            AddColumn("dbo.Products", "StoreId", c => c.Int());
            CreateIndex("dbo.Products", "StoreId");
            AddForeignKey("dbo.Products", "StoreId", "dbo.Stores", "StoreId");
            DropTable("dbo.StoreProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StoreProducts",
                c => new
                    {
                        Store_StoreId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Store_StoreId, t.Product_ProductId });
            
            DropForeignKey("dbo.Products", "StoreId", "dbo.Stores");
            DropIndex("dbo.Products", new[] { "StoreId" });
            DropColumn("dbo.Products", "StoreId");
            CreateIndex("dbo.StoreProducts", "Product_ProductId");
            CreateIndex("dbo.StoreProducts", "Store_StoreId");
            AddForeignKey("dbo.StoreProducts", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.StoreProducts", "Store_StoreId", "dbo.Stores", "StoreId", cascadeDelete: true);
        }
    }
}
