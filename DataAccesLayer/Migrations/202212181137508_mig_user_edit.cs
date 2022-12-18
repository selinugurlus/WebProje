namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_user_edit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "user_mail", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "user_password", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "user_password", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "user_mail", c => c.String(maxLength: 50));
        }
    }
}
