namespace MyWareHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product_NameMax1204 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 1024));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
        }
    }
}
