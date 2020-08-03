namespace Wysypisko.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelRequeirements : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "DocumentName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "DocumentName", c => c.String(maxLength: 100));
        }
    }
}
