namespace Vic.SportsStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            Sql("UPDATE [dbo].[Products] SET [Name] = 'noname' WHERE Name is NULL");

            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            Sql("UPDATE [dbo].[Products] SET [Description] = 'no' WHERE Description is NULL");

            AlterColumn("dbo.Products", "Category", c => c.String(nullable: false));
            Sql("UPDATE [dbo].[Products] SET [Category] = 'no' WHERE Category is NULL");
        }

        public override void Down()
        {
            AlterColumn("dbo.Products", "Category", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
