namespace CRMP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storeimage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reclamations",
                c => new
                    {
                        ReclamationId = c.Int(nullable: false, identity: true),
                        typeRec = c.String(),
                        descRec = c.String(),
                        responseRec = c.String(),
                        etatRec = c.String(),
                        dataRec = c.DateTime(nullable: false),
                        userId = c.Int(),
                    })
                .PrimaryKey(t => t.ReclamationId)
                .ForeignKey("dbo.Users", t => t.userId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        lastName = c.String(),
                        role = c.String(),
                        gender = c.String(),
                        birthDate = c.DateTime(nullable: false),
                        userAddress = c.String(),
                        userNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        storeImage = c.String(),
                        storeName = c.String(nullable: false, maxLength: 25),
                        storeaddress = c.String(nullable: false, maxLength: 500),
                        Heure_ouverture = c.DateTime(nullable: false),
                        Heure_fermeture = c.DateTime(nullable: false),
                        storeNum = c.String(),
                        storeDesc = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reclamations", "userId", "dbo.Users");
            DropIndex("dbo.Reclamations", new[] { "userId" });
            DropTable("dbo.Stores");
            DropTable("dbo.Users");
            DropTable("dbo.Reclamations");
        }
    }
}
