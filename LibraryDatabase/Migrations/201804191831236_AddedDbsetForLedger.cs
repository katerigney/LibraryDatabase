namespace LibraryDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDbsetForLedger : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckOutLedgers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserEmail = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CheckOutLedgers");
        }
    }
}
