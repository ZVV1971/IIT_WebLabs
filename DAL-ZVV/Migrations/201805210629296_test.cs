namespace DAL_ZVV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LabGlasswares", "GW_Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LabGlasswares", "GW_Type", c => c.String());
        }
    }
}
