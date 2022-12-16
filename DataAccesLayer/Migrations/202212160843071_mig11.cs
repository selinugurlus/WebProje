namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "user_id", "dbo.Users");
            DropForeignKey("dbo.Contents", "Subject_subject_id", "dbo.Subjects");
            DropIndex("dbo.Contents", new[] { "user_id" });
            DropIndex("dbo.Contents", new[] { "Subject_subject_id" });
            RenameColumn(table: "dbo.Contents", name: "Subject_subject_id", newName: "subject_id");
            AlterColumn("dbo.Contents", "user_id", c => c.Int());
            AlterColumn("dbo.Contents", "subject_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Contents", "subject_id");
            CreateIndex("dbo.Contents", "user_id");
            AddForeignKey("dbo.Contents", "user_id", "dbo.Users", "user_id");
            AddForeignKey("dbo.Contents", "subject_id", "dbo.Subjects", "subject_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.Contents", "user_id", "dbo.Users");
            DropIndex("dbo.Contents", new[] { "user_id" });
            DropIndex("dbo.Contents", new[] { "subject_id" });
            AlterColumn("dbo.Contents", "subject_id", c => c.Int());
            AlterColumn("dbo.Contents", "user_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Contents", name: "subject_id", newName: "Subject_subject_id");
            CreateIndex("dbo.Contents", "Subject_subject_id");
            CreateIndex("dbo.Contents", "user_id");
            AddForeignKey("dbo.Contents", "Subject_subject_id", "dbo.Subjects", "subject_id");
            AddForeignKey("dbo.Contents", "user_id", "dbo.Users", "user_id", cascadeDelete: true);
        }
    }
}
