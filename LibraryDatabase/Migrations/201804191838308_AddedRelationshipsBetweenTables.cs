namespace LibraryDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipsBetweenTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "GenreID", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "AuthorID", c => c.Int(nullable: false));
            AddColumn("dbo.CheckOutLedgers", "BookID", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "GenreID");
            CreateIndex("dbo.Books", "AuthorID");
            CreateIndex("dbo.CheckOutLedgers", "BookID");
            AddForeignKey("dbo.Books", "AuthorID", "dbo.Authors", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Books", "GenreID", "dbo.Genres", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CheckOutLedgers", "BookID", "dbo.Books", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckOutLedgers", "BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.Books", "AuthorID", "dbo.Authors");
            DropIndex("dbo.CheckOutLedgers", new[] { "BookID" });
            DropIndex("dbo.Books", new[] { "AuthorID" });
            DropIndex("dbo.Books", new[] { "GenreID" });
            DropColumn("dbo.CheckOutLedgers", "BookID");
            DropColumn("dbo.Books", "AuthorID");
            DropColumn("dbo.Books", "GenreID");
        }
    }
}
