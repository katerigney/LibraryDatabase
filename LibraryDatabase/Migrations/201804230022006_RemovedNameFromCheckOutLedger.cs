namespace LibraryDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedNameFromCheckOutLedger : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CheckOutLedgers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckOutLedgers", "Name", c => c.String());
        }
    }
}
