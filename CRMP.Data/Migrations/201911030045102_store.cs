namespace CRMP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class store : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "Heure_ouverture", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stores", "Heure_fermeture", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Stores", "storeName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Stores", "storeaddress", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Stores", "storeDesc", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "storeDesc", c => c.String());
            AlterColumn("dbo.Stores", "storeaddress", c => c.String());
            AlterColumn("dbo.Stores", "storeName", c => c.String());
            DropColumn("dbo.Stores", "Heure_fermeture");
            DropColumn("dbo.Stores", "Heure_ouverture");
        }
    }
}
