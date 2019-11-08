namespace CRMP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetomany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        categorie = c.Int(nullable: false),
                        prodName = c.String(nullable: false, maxLength: 25),
                        prodDesc = c.String(nullable: false, maxLength: 500),
                        prodPrice = c.Double(nullable: false),
                        prodQuantity = c.Int(nullable: false),
                        prodImage = c.String(),
                        StoreId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .Index(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "StoreId", "dbo.Stores");
            DropIndex("dbo.Products", new[] { "StoreId" });
            DropTable("dbo.Products");
        }
    }
}
