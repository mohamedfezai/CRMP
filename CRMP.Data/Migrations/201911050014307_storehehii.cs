namespace CRMP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storehehii : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "storeImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "storeImage");
        }
    }
}
