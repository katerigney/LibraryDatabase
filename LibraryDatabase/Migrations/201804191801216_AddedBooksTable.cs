namespace LibraryDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBooksTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        YearPublished = c.String(),
                        Condition = c.String(),
                        IsCheckedOut = c.Boolean(nullable: false),
                        DueByDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
