namespace LibraryDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAuthorDiedDateToBeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Died", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "Died", c => c.DateTime(nullable: false));
        }
    }
}
