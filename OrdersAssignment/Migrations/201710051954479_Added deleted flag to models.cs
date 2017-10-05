namespace OrdersAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeddeletedflagtomodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsDeleted");
            DropColumn("dbo.Customers", "IsDeleted");
        }
    }
}
