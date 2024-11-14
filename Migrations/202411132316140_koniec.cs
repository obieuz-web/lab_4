namespace lab_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class koniec : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "Name");
        }
    }
}
