namespace Wysypisko.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigraion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentName = c.String(maxLength: 100),
                        DateSaved = c.DateTime(nullable: false),
                        DocumentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeId, cascadeDelete: true)
                .Index(t => t.DocumentTypeId);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentTypeDescription = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "DocumentTypeId", "dbo.DocumentTypes");
            DropIndex("dbo.Documents", new[] { "DocumentTypeId" });
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Documents");
        }
    }
}
