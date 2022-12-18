namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_user_addstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "user_status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "user_status");
        }
    }
}
