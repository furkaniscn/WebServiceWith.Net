namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kantar",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UretimYeri = c.String(maxLength: 50),
                        KantarNo = c.String(maxLength: 50),
                        Plaka = c.String(maxLength: 50),
                        Base64 = c.String(),
                        confidences = c.String(maxLength: 50),
                        displayNames = c.String(maxLength: 50),
                        ids = c.String(maxLength: 50),
                        deployedModelId = c.String(maxLength: 50),
                        model = c.String(),
                        modelDisplayName = c.String(maxLength: 50),
                        modelVersionId = c.String(maxLength: 50),
                        AddTimeStamp = c.DateTime(),
                        APITimeStamp = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Plaka",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Plaka = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Plaka");
            DropTable("dbo.Kantar");
        }
    }
}
