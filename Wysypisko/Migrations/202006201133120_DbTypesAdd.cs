namespace Wysypisko.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbTypesAdd : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into [dbo].[DocumentTypes] (DocumentTypeDescription) values ('Image')");
            Sql("Insert Into [dbo].[DocumentTypes] (DocumentTypeDescription) values ('Pdf')");
            Sql("Insert Into [dbo].[DocumentTypes] (DocumentTypeDescription) values ('Text')");
        }
        
        public override void Down()
        {
        }
    }
}
