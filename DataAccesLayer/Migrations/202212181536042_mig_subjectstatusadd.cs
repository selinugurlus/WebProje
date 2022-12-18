namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_subjectstatusadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "subject_status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "subject_status");
        }
    }
}
