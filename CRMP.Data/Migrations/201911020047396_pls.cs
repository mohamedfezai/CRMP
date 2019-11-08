namespace CRMP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pls : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Productsses", newName: "Products");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Products", newName: "Productsses");
        }
    }
}
