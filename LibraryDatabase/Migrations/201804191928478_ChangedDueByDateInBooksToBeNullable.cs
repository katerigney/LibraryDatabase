namespace LibraryDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDueByDateInBooksToBeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "DueByDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "DueByDate", c => c.DateTime(nullable: false));
        }
    }
}
