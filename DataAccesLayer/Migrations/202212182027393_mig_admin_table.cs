namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        admin_id = c.Int(nullable: false, identity: true),
                        admin_username = c.String(maxLength: 50),
                        admin_password = c.String(maxLength: 50),
                        admin_role = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.admin_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
