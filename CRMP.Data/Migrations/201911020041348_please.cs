namespace CRMP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class please : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productsses",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        categorie = c.Int(nullable: false),
                        prodName = c.String(nullable: false, maxLength: 25),
                        prodDesc = c.String(nullable: false, maxLength: 500),
                        prodPrice = c.Double(nullable: false),
                        prodQuantity = c.Int(nullable: false),
                        prodImage = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productsses");
        }
    }
}
