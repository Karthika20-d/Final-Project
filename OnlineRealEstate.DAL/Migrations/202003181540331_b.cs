namespace OnlineRealEstate.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyFeatures", "PropertyFeatureName", c => c.String(nullable: false));
            DropColumn("dbo.PropertyFeatures", "PropertyFeature");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PropertyFeatures", "PropertyFeature", c => c.String(nullable: false));
            DropColumn("dbo.PropertyFeatures", "PropertyFeatureName");
        }
    }
}
